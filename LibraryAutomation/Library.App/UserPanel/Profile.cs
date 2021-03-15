using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Library.App.Popup;
using Library.App.Utilities.FormControls;
using Library.App.Utilities.ImageControls;
using Library.Core.Enum;
using Library.Data.ImageHelper;
using Library.Data.Utilities;
using Library.Entities.Entities.Dtos.UserDto;
using Library.Services.Abstract;

namespace Library.App.UserPanel
{
    public partial class Profile : Form
    {
        #region Field

        private bool _isReset;
        private readonly int _userId;
        private string _fileName = string.Empty;
        private readonly IUserService _userService;
        private readonly IImageHelper _imageHelper;
        private readonly IUserBookService _userBookService;
        private readonly IFavoriteBookService _favoriteBookService;

        #endregion Field

        #region Constructor

        public Profile(IUserService userService, IImageHelper imageHelper, IUserBookService userBookService, IFavoriteBookService favoriteBookService, int userId)
        {
            _userId = userId;
            InitializeComponent();
            _userService = userService;
            _imageHelper = imageHelper;
            _userBookService = userBookService;
            _favoriteBookService = favoriteBookService;
        }

        #endregion Constructor

        #region FormLoad

        private void Profile_Load(object sender, EventArgs e)
        {
            FillObject();
        }

        #endregion

        #region Methods

        private void FillObject()
        {
            var user = _userService.Get(_userId);
            var countFavorite = _favoriteBookService.GetAll(_userId);
            var countRead = _userBookService.GetAllReadByUser(_userId);
            var countLend = _userBookService.GetAllReadingByUser(_userId);
            if (countFavorite.ResultStatus == ResultStatus.Success)
                lblFavoriteCount.Text = Convert.ToString(countFavorite.Data.FavoriteBooks.Count);
            if (countRead.ResultStatus == ResultStatus.Success)
                lblReadedCount.Text = Convert.ToString(countRead.Data.UserBooks.Count);
            if (countLend.ResultStatus == ResultStatus.Success)
                lblLendedCount.Text = Convert.ToString(countLend.Data.UserBooks.Count);

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
                var stream = new FileStream($"{Directory.GetCurrentDirectory()}\\img\\{user.Data.User.Picture}", FileMode.OpenOrCreate);
                pictureBox1.Image = Helpers.ImageResize(Image.FromStream(stream), new Size(175, 200));
                stream.Flush(); stream.Close();
            }
            else
                Alert.Show(user.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// Sistemdeki kullanıcıyı günceller.
        /// </summary>
        private new void Update()
        {
            if (XtraMessageBox.Show("Bilgileriniz güncellenecektir. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
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
            };
            var isNewPicture = false;
            var oldUser = _userService.Get(_userId);
            string oldUserPicture;
            if (oldUser.ResultStatus == ResultStatus.Success)
            {
                oldUserPicture = oldUser.Data.User.Picture;
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

                if (_isReset) newUser.Picture = "userImages/defaultUser.png";
            }
            else
            {
                Alert.Show(oldUser.Message, ResultStatus.Warning);
                return;
            }

            var updatedUser = _userService.Update(newUser, txtUsername.Text, true);
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
                        FillObject();
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
        private void Freeze()
        {
            if (XtraMessageBox.Show("Hesabınız dondurulacaktır. Tekrar aktif etmek için yetkili ile görüşmelisiniz. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            var result = _userService.Delete(_userId, "Admin", true);
            switch (result.ResultStatus)
            {
                case ResultStatus.Success:
                    Alert.Show(result.Message, ResultStatus.Success);
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

        private void Delete()
        {
            if (XtraMessageBox.Show(
                $"Profiliniz tamamen silinecektir. Emin misiniz?",
                "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            var result = _userService.HardDelete(_userId, true);
            if (result.ResultStatus != ResultStatus.Success)
            {
                Alert.Show(result.Message, ResultStatus.Error);
                return;
            }
            Alert.Show(result.Message, ResultStatus.Success);
        }

        private void ClearItems()
        {
            FormControls.ClearFormControls(this);
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
            Update();
        }

        private void btnFreezeAccount_Click(object sender, EventArgs e)
        {
            Freeze();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
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

        private void btnImgReset_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.defaultUser;
            _isReset = true;
        }

        #endregion
    }
}