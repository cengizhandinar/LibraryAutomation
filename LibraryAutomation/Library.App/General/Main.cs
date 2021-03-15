using System;
using System.Windows.Forms;
using Library.App.Popup;
using Library.Core.Enum;
using DevExpress.XtraEditors;
using Library.App.AdminPanel;
using Library.App.UserPanel;
using Library.Data.ImageHelper;
using Library.Services.Abstract;

namespace Library.App.General
{
    public partial class Main : Form
    {
        #region Fields

        private int _userId;
        private string _userName;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IImageHelper _imageHelper;
        private readonly IWriterService _writerService;
        private readonly IContactService _contactService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly ICommentService _commentService;
        private readonly IUserBookService _userBookService;
        private readonly IFavoriteBookService _favoriteBookService;
        private readonly IBookCategoryService _bookCategoryService;

        #endregion Fields

        #region Constructor

        public Main
        (
            IUserService userService,
            IBookService bookService,
            IImageHelper imageHelper,
            IWriterService writerService,
            IContactService contactService,
            ICategoryService categoryService,
            IPublisherService publisherService,
            ICommentService commentService,
            IUserBookService userBookService,
            IFavoriteBookService favoriteBookService,
            IBookCategoryService bookCategoryService
        )
        {
            _userService = userService;
            _bookService = bookService;
            _imageHelper = imageHelper;
            _writerService = writerService;
            _contactService = contactService;
            _categoryService = categoryService;
            _commentService = commentService;
            _publisherService = publisherService;
            _userBookService = userBookService;
            _favoriteBookService = favoriteBookService;
            _bookCategoryService = bookCategoryService;
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Parametre olarak bir form nesnesi alır ve bu formu PageMain üzerindeki MdiContainer üzerinde gösterir.
        /// </summary>
        private void GetForm(Form form)
        {
            centerPanel.Controls.Clear();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            centerPanel.Controls.Add(form);
            form.Show();
        }

        #endregion Methods

        #region Buttons

        #region MainButtons

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var login = new Login(_userService);
            var result = login.ShowDialog();
            if (result != DialogResult.OK) return;
            topPanel.Visible = false;
            var user = _userService.GetByName(login.UserName);
            if (user.ResultStatus != ResultStatus.Success) return;
            _userId = user.Data.User.Id;
            _userName = user.Data.User.FirstName + " " + user.Data.User.LastName;
            switch (user.Data.User.AccessStatus)
            {
                case AccessStatus.Manager:
                    adminPanel.Visible = true;
                    break;
                case AccessStatus.Member:
                    userPanel.Visible = true;
                    break;
                case AccessStatus.Visitor:
                    break;
                case AccessStatus.Personnel:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(
                $"Uygulamadan çıkış yapılacaktır. Onaylıyor musunuz?",
                "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();
        }

        #endregion MainButtons

        #region AdminButtons

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            var form = new UserOperations(_userService, _imageHelper);
            GetForm(form);
        }
        private void btnBookInfo_Click(object sender, EventArgs e)
        {
            var form = new BookOperations(_bookService, _imageHelper, _writerService, _publisherService, _categoryService);
            GetForm(form);
        }
        private void btnCategoryInfo_Click(object sender, EventArgs e)
        {
            var form = new CategoryOperations(_categoryService, _bookCategoryService);
            centerPanel.Visible = false;
            var result = form.ShowDialog();
            if (result != DialogResult.OK) return;
            form.Close();
            centerPanel.Visible = true;
        }
        private void btnWriterInfo_Click(object sender, EventArgs e)
        {
            var form = new WriterOperations(_writerService, _imageHelper);
            GetForm(form);
        }
        private void btnPublisherInfo_Click(object sender, EventArgs e)
        {
            var form = new PublisherOperations(_publisherService);
            centerPanel.Visible = false;
            var result = form.ShowDialog();
            if (result != DialogResult.OK) return;
            form.Close();
            centerPanel.Visible = true;
        }
        private void btnCommentInfo_Click(object sender, EventArgs e)
        {
            var form = new CommentOperations(_commentService);
            GetForm(form);
        }
        private void btnContactInfo_Click(object sender, EventArgs e)
        {
            var form = new ContactOperations(_contactService);
            GetForm(form);
        }
        private void btnUserBookInfo_Click(object sender, EventArgs e)
        {
            var form = new UserBookOperations(_userBookService, _userService, _bookService);
            GetForm(form);
        }
        private void btnUserRoleInfo_Click(object sender, EventArgs e)
        {
            var form = new UserRoleOperations(_userService);
            centerPanel.Visible = false;
            var result = form.ShowDialog();
            if (result != DialogResult.OK) return;
            form.Close();
            centerPanel.Visible = true;
        }
        private void btnBookCategoryInfo_Click(object sender, EventArgs e)
        {
            var form = new BookCategoryOperations(_categoryService, _bookService, _bookCategoryService);
            GetForm(form);
        }
        private void btnControlCenter_Click(object sender, EventArgs e)
        {
            var form = new ControlCenter(_userService, _bookService, _categoryService, _contactService, _commentService,
                _writerService, _publisherService);
            GetForm(form);
        }
        private void btnAdminClose_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(
                $"{_userName} çıkışınız yapılacaktır. Onaylıyor musunuz?",
                "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            centerPanel.Controls.Clear();
            topPanel.Visible = true;
            adminPanel.Visible = false;
            Alert.Show(_userName + " çıkışınız başarıyla gerçekleşmiştir.", ResultStatus.Success);
        }

        #endregion AdminButtons

        #region UserButtons

        private void btnArchive_Click(object sender, EventArgs e)
        {
            var form = new Archive(_bookService, _writerService, _favoriteBookService, _categoryService, _userBookService, _userService, _commentService, _userId);
            GetForm(form);
        }
        private void btnMyFavorites_Click(object sender, EventArgs e)
        {
            var result = _favoriteBookService.GetAll(_userId);
            switch (result.ResultStatus)
            {
                case ResultStatus.Success:
                {
                    var form = new Favorites(_bookService, _writerService, _favoriteBookService, _commentService, _userService, _userId);
                    GetForm(form);
                    break;
                }
                case ResultStatus.Warning:
                    Alert.Show(result.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(result.Message, ResultStatus.Error);
                    break;
            }
        }
        private void btnHaveRead_Click(object sender, EventArgs e)
        {
            var result = _userBookService.GetAllReadByUser(_userId);
            switch (result.ResultStatus)
            {
                case ResultStatus.Success:
                {
                    var form = new HaveReads(_bookService, _writerService, _userBookService, _commentService, _userService, _userId);
                    GetForm(form);
                    break;
                }
                case ResultStatus.Warning:
                    Alert.Show(result.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(result.Message, ResultStatus.Error);
                    break;
            }
        }
        private void btnWillRead_Click(object sender, EventArgs e)
        {
            var result = _userBookService.GetAllWillReadByUser(_userId);
            switch (result.ResultStatus)
            {
                case ResultStatus.Success:
                {
                    var form = new WillReads(_bookService, _writerService, _userBookService, _commentService, _userService, _userId);
                    GetForm(form);
                    break;
                }
                case ResultStatus.Warning:
                    Alert.Show(result.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(result.Message, ResultStatus.Error);
                    break;
            }
        }
        private void btnMyEscrowList_Click(object sender, EventArgs e)
        {
            var result = _userBookService.GetAllReadingByUser(_userId);
            switch (result.ResultStatus)
            {
                case ResultStatus.Success:
                {
                    var form = new BorrowedList(_bookService, _userBookService, _commentService, _userService, _userId);
                    GetForm(form);
                    break;
                }
                case ResultStatus.Warning:
                    Alert.Show(result.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(result.Message, ResultStatus.Error);
                    break;
            }
        }
        private void btnMyComments_Click(object sender, EventArgs e)
        {
            var result = _commentService.GetAllByUserId(_userId);
            switch (result.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        var form = new SeeCommentPersonal(_commentService, _userId);
                        GetForm(form);
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(result.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(result.Message, ResultStatus.Error);
                    break;
            }
        }
        private void btnWriters_Click(object sender, EventArgs e)
        {
            var form = new Writers(_writerService);
            GetForm(form);
        }
        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            var form = new Profile(_userService,_imageHelper,_userBookService,_favoriteBookService,_userId);
            GetForm(form);
        }
        private void btnMyContacts_Click(object sender, EventArgs e)
        {
            var form = new Contact(_contactService, _userService,_userId);
            centerPanel.Visible = false;
            var result = form.ShowDialog();
            if (result != DialogResult.OK) return;
            form.Close();
            centerPanel.Visible = true;
        }
        private void btnUserClose_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(
                $"{_userName} çıkışınız yapılacaktır. Onaylıyor musunuz?",
                "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            centerPanel.Controls.Clear();
            topPanel.Visible = true;
            userPanel.Visible = false;
            Alert.Show(_userName + " çıkışınız başarıyla gerçekleşmiştir.", ResultStatus.Success);
        }

        #endregion UserButtons

        #endregion Buttons
    }
}