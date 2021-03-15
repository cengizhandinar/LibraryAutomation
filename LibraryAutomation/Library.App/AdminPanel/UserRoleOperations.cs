using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Library.App.Popup;
using Library.App.Utilities.FormControls;
using Library.App.Utilities.ImageControls;
using Library.Core.Enum;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.UserDto;
using Library.Services.Abstract;

namespace Library.App.AdminPanel
{
    public partial class UserRoleOperations : Form
    {
        #region Fields

        private readonly IUserService _userService;
        private int _userId = -1;

        #endregion Fields

        #region Constructor

        public UserRoleOperations(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        #endregion Constructor

        #region Form Load

        private void UserRoleOperations_Load(object sender, EventArgs e)
        {
            FillGrid();
            FillComboBox();
        }

        #endregion Form Load

        #region Methods

        private void FillGrid(IList<User> list = null)
        {
            if (list == null) list = GetAllNonDeleted();
            var newList = from item in list
                          select new
                          {
                              item.Id,
                              item.AccessStatus,
                              Adı_Soyadı = item.FirstName + " " + item.LastName,
                              Kullanıcı_Adı = item.UserName,
                              Cinsiyet = item.Gender,
                              Telefon = item.PhoneNumber,
                              Dogum_Tarihi = item.DateBirth
                          };
            gcUser.DataSource = newList.OrderBy(u => u.AccessStatus);

            void RoleColumnVisible()
            {
                gvUser.Columns[0].Visible = false;
                gvUser.Columns[1].Visible = false;
            }
            RoleColumnVisible();

            lblMessage.Text = $"{list.Count} adet kullanıcı listeleniyor.";
        }

        /// <summary>
        /// Tüm comboboxları doldur.
        /// </summary>
        private void FillComboBox()
        {
            cbRole.Properties.Items.Clear(); 
            cbSearchRole.Properties.Items.Clear();
            cbRole.Properties.Items.AddRange(Enum.GetValues(typeof(AccessStatus)));
            cbSearchRole.Properties.Items.AddRange(Enum.GetValues(typeof(AccessStatus)));
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
                cbRole.SelectedItem = Enum.Parse(typeof(AccessStatus), user.Data.User.AccessStatus.ToString());
                var stream = new FileStream($"{Directory.GetCurrentDirectory()}\\img\\{user.Data.User.Picture}", FileMode.OpenOrCreate);
                pictureBox1.Image = Helpers.ImageResize(Image.FromStream(stream), new Size(175, 200));
                stream.Flush(); stream.Close();
            }
            else
                Alert.Show(user.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// Sistemdeki kullanıcı rolünü günceller.
        /// </summary>
        private new void Update()
        {
            var user =  _userService.Get(_userId);
            if (user.ResultStatus == ResultStatus.Success)
                user.Data.User.AccessStatus = (AccessStatus)cbRole.SelectedItem;
            else
            {
                Alert.Show(user.Message, ResultStatus.Warning);
                return;
            }
            var updatedUserRole = _userService.UpdateRole(new UserGetDto { User = user.Data.User }, "Admin");
            if (updatedUserRole.ResultStatus == ResultStatus.Success)
            {
                Alert.Show(updatedUserRole.Message, ResultStatus.Success);
                FillGrid();
                ClearItems();
            }
            else Alert.Show(updatedUserRole.Message, ResultStatus.Error);
        }

        /// <summary>
        /// Form içindeki kontrolleri temizler.
        /// </summary>
        private void ClearItems()
        {
            _userId = -1;
            cbSearchRole.SelectedIndex = -1;
            pictureBox1.Image = null;
            txtSearchByName.Text = null;
            FormControls.ClearFormControls(this);
        }

        /// <summary>
        /// Role göre ara.
        /// </summary>
        private void SearchUserByRole()
        {
            var users = _userService.FindUsersByRole((AccessStatus)cbSearchRole.SelectedItem);
            if (users.ResultStatus == ResultStatus.Success) FillGrid(users.Data.Users);
            else FillGrid();
        }

        /// <summary>
        /// İsme göre ara.
        /// </summary>
        private void SearchUserByName()
        {
            var searchText = txtSearchByName.Text;
            if (string.IsNullOrEmpty(searchText)) FillGrid();

            var users = _userService.FindUsersByText(searchText);
            if (users.ResultStatus == ResultStatus.Success) FillGrid(users.Data.Users);
            else FillGrid();
        }

        #endregion Methods

        #region Buttons

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearItems();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbRole.SelectedIndex == -1)
            {
                Alert.Show("Lütfen rol seçimi yapınız..", ResultStatus.Info);
                return;
            }
            Update();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion Buttons

        #region GridControl

        private void gvUser_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GetObject();
        }

        #endregion GridControl

        #region Events

        private void cbSearchRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchRole.SelectedIndex>-1) SearchUserByRole();
            else FillGrid();
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            SearchUserByName();
        }

        #endregion Events
    }
}