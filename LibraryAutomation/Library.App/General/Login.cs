using System;
using System.Windows.Forms;
using Library.App.Popup;
using Library.Core.Enum;
using Library.Data.Utilities;
using Library.Services.Abstract;

namespace Library.App.General
{
    public partial class Login : Form
    {
        #region Fields

        public string UserName { get; set; }
        public bool IsConnected { get; set; }
        private readonly IUserService _userService;

        #endregion Fields

        #region Constructor

        public Login(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        #endregion Constructor

        #region Buttons

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = txtUsername.Text;
            var password = txtPassword.Text;
            var encryptPassword = !string.IsNullOrEmpty(password)
                ? PasswordHelper.Encrypt(password) 
                : null;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                Alert.Show("Kullanıcı adı ya da şifre boş bırakılamaz.", ResultStatus.Warning);
                return;
            }
            var user = _userService.GetByName(userName);
            if (user.ResultStatus == ResultStatus.Success)
            {
                if (user.Data.User.Password != encryptPassword)
                {
                    Alert.Show("Kullanıcı adı ya da şifre hatalı.", ResultStatus.Error);
                    return;
                }
                if (user.Data.User.GeneralStatus != GeneralStatus.Active)
                {
                    Alert.Show("Sisteme giriş yapmanız yasaklanmıştır.", ResultStatus.Error);
                    return;
                }
                DialogResult = DialogResult.OK;
                IsConnected = true;
                UserName = userName;
            }
            else
                Alert.Show(user.Message, ResultStatus.Warning);
        }

        #endregion Buttons

        #region Events

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }

        #endregion Events
    }
}