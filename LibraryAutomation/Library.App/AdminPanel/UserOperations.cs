using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Library.App.Popup;
using Library.Core.Enum;
using Library.Data.Utilities;
using DevExpress.XtraEditors;
using Library.Data.ImageHelper;
using Library.Services.Abstract;
using Library.Entities.Entities.Concrete;
using Library.App.Utilities.FormControls;
using Library.App.Utilities.ImageControls;
using Library.Entities.Entities.Dtos.UserDto;

namespace Library.App.AdminPanel
{
    public partial class UserOperations : Form
    {
        #region Field

        private readonly IUserService _userService;
        private readonly IImageHelper _imageHelper;

        private int _userId = -1;
        private string _fileName = string.Empty;

        #endregion Field

        #region Constructor

        public UserOperations(IUserService userService, IImageHelper imageHelper)
        {
            _userService = userService;
            _imageHelper = imageHelper;
            InitializeComponent();
            FillComboBox();
            FillGrid();
        }

        #endregion Constructor

        #region Methods

        private void FillGrid(IList<User> list = null)
        {
            if (list == null) list = GetAllNonDeleted();

            gcUser.DataSource = list.OrderBy(u => u.UpdatedDate);

            void UserColumnVisible()
            {
                gvUser.Columns[2].Visible = false;
                gvUser.Columns[3].Visible = false;
                gvUser.Columns[4].Visible = false;
                gvUser.Columns[7].Visible = false;
                gvUser.Columns[8].Visible = false;
                gvUser.Columns[10].Visible = false;
                gvUser.Columns[11].Visible = false;
                gvUser.Columns[12].Visible = false;
                gvUser.Columns[13].Visible = false;
                gvUser.Columns[14].Visible = false;
                gvUser.Columns[15].Visible = false;
                gvUser.Columns[16].Visible = false;
                gvUser.Columns[18].Visible = false;
                gvUser.Columns[20].Visible = false;
            }
            UserColumnVisible();

            lblMessage.Text = $"{list.Count} adet kullanıcı listeleniyor.      ";
        }

        /// <summary>
        /// Tüm comboboxları doldur.
        /// </summary>
        private void FillComboBox()
        {
            cbAccess.Properties.Items.Clear();
            cbStatus.Properties.Items.Clear();
            cbSearchAccess.Properties.Items.Clear();
            cbAccess.Properties.Items.AddRange(Enum.GetValues(typeof(AccessStatus)));
            cbSearchAccess.Properties.Items.AddRange(Enum.GetValues(typeof(AccessStatus)));
            cbStatus.Properties.Items.AddRange(Enum.GetValues(typeof(GeneralStatus)));
        }

        /// <summary>
        /// Tüm aktif kullanıcıların listesini getir.
        /// </summary>
        private IList<User> GetAllNonDeleted()
        {
            var users = _userService.GetAllNonDeleted();
            switch (users.ResultStatus)
            {
                case ResultStatus.Success:
                    return users.Data.Users;
                case ResultStatus.Warning:
                    Alert.Show(users.Message, ResultStatus.Warning);
                    return null;
                default:
                    Alert.Show(users.Message, ResultStatus.Error);
                    return null;
            }
        }

        /// <summary>
        /// Gridde seçilen kullanıcı bilgilerini getir.
        /// </summary>
        private void GetObject()
        {
            if (gvUser.SelectedRowsCount <= 0) return;
            int.TryParse(gvUser.GetRowCellValue(gvUser.FocusedRowHandle, "Id").ToString(), out _userId);
            var user = _userService.Get(_userId);
            if (user.ResultStatus == ResultStatus.Success)
            {
                txtName.Text = user.Data.User.FirstName;
                txtSurname.Text = user.Data.User.LastName;
                txtUsername.Text = user.Data.User.UserName;
                txtPassword.Text = PasswordHelper.Decrypt(user.Data.User.Password);
                txtMail.Text = user.Data.User.Email;
                cbGender.SelectedItem = user.Data.User.Gender;
                txtTelephone.Text = user.Data.User.PhoneNumber;
                dateBirth.DateTime = user.Data.User.DateBirth;
                txtAbout.Text = user.Data.User.About;
                cbAccess.SelectedItem = Enum.Parse(typeof(AccessStatus), user.Data.User.AccessStatus.ToString());
                cbStatus.SelectedItem = Enum.Parse(typeof(GeneralStatus), user.Data.User.GeneralStatus.ToString());
                var stream = new FileStream($"{Directory.GetCurrentDirectory()}\\img\\{user.Data.User.Picture}", FileMode.OpenOrCreate);
                pictureBox1.Image = Helpers.ImageResize(Image.FromStream(stream), new Size(175, 200));
                stream.Flush(); stream.Close();
            }
            else
                Alert.Show(user.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// Sisteme yeni kullanıcı ekler.
        /// </summary>
        private void Add()
        {
            var user = new UserAddDto
            {
                FirstName = txtName.Text,
                LastName = txtSurname.Text,
                UserName = txtUsername.Text,
                Email = txtMail.Text,
                Password = PasswordHelper.Encrypt(txtPassword.Text),
                Gender = cbGender.Text,
                PhoneNumber = txtTelephone.Text,
                DateBirth = dateBirth.DateTime,
                About = txtAbout.Text,
                AccessStatus = (AccessStatus)cbAccess.SelectedItem,
                GeneralStatus = (GeneralStatus)cbStatus.SelectedItem,
                Picture = !string.IsNullOrEmpty(_fileName)
                    ? _imageHelper.Upload(txtUsername.Text, _fileName, PictureType.User).Data.FullName
                    : "userImages/defaultUser.png"
            };
            var added = _userService.Add(user, "Admin");
            switch (added.ResultStatus)
            {
                case ResultStatus.Success:
                    Alert.Show(added.Message, ResultStatus.Success);
                    FillGrid();
                    ClearItems();
                    break;
                case ResultStatus.Warning:
                    Alert.Show(added.Message, ResultStatus.Warning);
                    break;
                case ResultStatus.Info:
                    Alert.Show(added.Message, ResultStatus.Info);
                    break;
                case ResultStatus.Error:
                    Alert.Show(added.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Sistemdeki kullanıcıyı günceller.
        /// </summary>
        private new void Update()
        {
            var newUser = new UserUpdateDto
            {
                Id = _userId,
                FirstName = txtName.Text,
                LastName = txtSurname.Text,
                UserName = txtUsername.Text,
                Password = PasswordHelper.Encrypt(txtPassword.Text),
                Email = txtMail.Text,
                Gender = cbGender.Text,
                PhoneNumber = txtTelephone.Text,
                DateBirth = dateBirth.DateTime,
                About = txtAbout.Text,
                AccessStatus = (AccessStatus)cbAccess.SelectedItem,
                GeneralStatus = (GeneralStatus)cbStatus.SelectedItem
            };
            var isNewPicture = false;
            var oldUser = _userService.Get(_userId);
            string oldUserPicture;
            if (oldUser.ResultStatus == ResultStatus.Success)
            {
                oldUserPicture = _userService.Get(_userId).Data.User.Picture;
                if (_fileName != string.Empty)
                {
                    var uploadedImageDtoResult = _imageHelper.Upload(txtUsername.Text, _fileName, PictureType.User);
                    if (uploadedImageDtoResult.ResultStatus == ResultStatus.Success)
                    {
                        newUser.Picture = uploadedImageDtoResult.Data.FullName;
                        if (oldUserPicture != "userImages/defaultUser.png" && oldUserPicture != "userImages/defaultRoot.png")
                            isNewPicture = true;
                    }
                    else
                    {
                        Alert.Show(uploadedImageDtoResult.Message, ResultStatus.Error);
                        return;
                    }
                }
                else
                    newUser.Picture = oldUserPicture;
            }
            else
            {
                Alert.Show(oldUser.Message, ResultStatus.Warning);
                return;
            }

            var updatedUser = _userService.Update(newUser, "Admin",false);
            switch (updatedUser.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        if (isNewPicture)
                        {
                            var deleteResult = _imageHelper.Delete(oldUserPicture);
                            if (deleteResult.ResultStatus != ResultStatus.Success)
                            {
                                Alert.Show(deleteResult.Message, ResultStatus.Error);
                                return;
                            }
                        }
                        Alert.Show(updatedUser.Message, ResultStatus.Success);
                        FillGrid();
                        ClearItems();
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(updatedUser.Message, ResultStatus.Warning);
                    break;
                case ResultStatus.Info:
                    Alert.Show(updatedUser.Message, ResultStatus.Info);
                    break;
                case ResultStatus.Error:
                    Alert.Show(updatedUser.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Seçilen kullanıcıyı arşivle.
        /// </summary>
        private void Delete(object sender, EventArgs e)
        {
            if (_userId > -1)
            {
                if (XtraMessageBox.Show("Kullanıcı arşivlenecektir. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
                var result = _userService.Delete(_userId, "Admin",false);
                switch (result.ResultStatus)
                {
                    case ResultStatus.Success:
                        Alert.Show(result.Message, ResultStatus.Success);
                        ClearItems();
                        FillGrid();
                        break;
                    case ResultStatus.Warning:
                        Alert.Show(result.Message, ResultStatus.Warning);
                        break;
                    case ResultStatus.Info:
                        Alert.Show(result.Message, ResultStatus.Info);
                        break;
                    case ResultStatus.Error:
                        Alert.Show(result.Message, ResultStatus.Error);
                        break;
                }
            }
            else
                Alert.Show("Lütfen arşivlenecek kullanıcıyı seçiniz.", ResultStatus.Info);
        }

        /// <summary>
        /// Form içindeki kontrolleri temizler.
        /// </summary>
        private void ClearItems()
        {
            _userId = -1;
            pictureBox1.Image = null;
            _fileName = string.Empty;
            txtSearch.Text = null;
            FormControls.ClearFormControls(this);
        }

        /// <summary>
        /// Ad, Soyad veya kullanıcı adına göre kullanıcı ara.
        /// </summary>
        private void SearchByText()
        {
            var searchText = txtSearch.Text;
            if (string.IsNullOrEmpty(searchText)) FillGrid();

            var users = _userService.FindUsersByText(searchText);
            if (users.ResultStatus == ResultStatus.Success) FillGrid(users.Data.Users);
            else FillGrid();
        }

        /// <summary>
        /// Yetkiye göre kullanıcı ara.
        /// </summary>
        private void SearchByComboBox()
        {
            var users = _userService.FindUsersByRole((AccessStatus)cbSearchAccess.SelectedItem);
            if (users.ResultStatus == ResultStatus.Success) FillGrid(users.Data.Users);
            else FillGrid();
        }

        #endregion Methods

        #region Buttons

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormControls.CheckFormControls(gbUser))
            {
                Alert.Show("Lütfen tüm alanları doldurunuz.", ResultStatus.Warning);
                return;
            }
            if (txtPassword.Text.Length != 8)
            {
                Alert.Show("Şifre 8 karakterden oluşmalıdır.", ResultStatus.Warning);
                return;
            }
            if (_userId > -1) Update();
            else Add();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearItems();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog() { Filter = @"Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;
                _fileName = ofd.FileName;
                var stream = new FileStream(_fileName, FileMode.OpenOrCreate);
                pictureBox1.Image = Helpers.ImageResize(Image.FromStream(stream), new Size(175, 200));
                stream.Flush(); stream.Close();
            }
        }

        #endregion

        #region LinkLabel

        private void lnkExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = @"Excel Documents (*.xls)|*.xls", FileName = "users.xls" };
            if (sfd.ShowDialog() == DialogResult.OK) gcUser.ExportToXls(sfd.FileName);
        }

        #endregion

        #region GridControl

        /// <summary>
        /// Grid üzerindeki kullanıcılara mouse butonu ile işlem uygular.
        /// </summary>
        private void gcUser_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Kullanıcıyı Arşivle", Delete));

            var rowIndex = gvUser.CalcHitInfo(e.X, e.Y).RowHandle;
            if (rowIndex <= -1) return;
            gvUser.ClearSelection();
            gvUser.SelectRow(rowIndex);
            _userId = Convert.ToInt32(gvUser.GetRowCellValue(rowIndex, "Id"));
            contextMenu.Show(gcUser, new Point(e.X, e.Y));
        }
        private void gvUser_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GetObject();
        }

        #endregion GridControl

        #region Timer

        private void timer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd.MMMM.yyyy HH:mm:ss");
        }

        #endregion Timer

        #region Events

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchByText();
        }

        private void cbSearchAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchAccess.SelectedIndex>-1) SearchByComboBox();
            else FillGrid();
        }

        #endregion
    }
}