using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Library.App.Popup;
using Library.Core.Enum;
using Library.Entities.Entities.Dtos.ContactDto;
using Library.Services.Abstract;

namespace Library.App.UserPanel
{
    public partial class Contact : Form
    {
        #region Field

        public string Message;
        private readonly int _userId;
        private readonly IUserService _userService;
        private readonly IContactService _contactService;

        #endregion Field

        #region Constructor

        public Contact(IContactService contactService, IUserService userService, int userId)
        {
            _userId = userId;
            _userService = userService;
            _contactService = contactService;
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        private void Add()
        {
            var user = _userService.Get(_userId);
            if (user.ResultStatus == ResultStatus.Success)
            {
                if (XtraMessageBox.Show("Mesajınız yetkili kişiye gönderilecektir. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
                var comment = new ContactAddDto
                {
                    UserId = _userId,
                    Content = txtMessage.Text,
                    GeneralStatus = GeneralStatus.Active
                };
                var result = _contactService.Add(comment, user.Data.User.UserName);
                Alert.Show(result.Message,
                    result.ResultStatus == ResultStatus.Success 
                        ? ResultStatus.Success 
                        : ResultStatus.Error);
                txtMessage.Text = null;
            }
            else
                Alert.Show(user.Message, ResultStatus.Error);
        }

        #endregion Methods

        #region Buttons

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                Alert.Show("Yorum alanı boş bırakılamaz.", ResultStatus.Error);
                return;
            }
            Add();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion Buttons
    }
}