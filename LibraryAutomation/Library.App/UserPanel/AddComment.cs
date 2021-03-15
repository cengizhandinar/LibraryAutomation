using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Library.App.Popup;
using Library.Core.Enum;
using Library.Entities.Entities.Dtos.CommentDto;
using Library.Services.Abstract;

namespace Library.App.UserPanel
{
    public partial class AddComment : Form
    {
        #region Field

        private readonly int _userId;
        private readonly int _bookId;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly ICommentService _commentService;
        public string Message;

        #endregion Field

        #region Constructor

        public AddComment(ICommentService commentService, IBookService bookService, IUserService userService, int bookId, int userId)
        {
            _userId = userId;
            _bookId = bookId;
            _userService = userService;
            _bookService = bookService;
            _commentService = commentService;
            InitializeComponent();
        }

        #endregion Constructor

        #region FormLoad

        private void AddComment_Load(object sender, EventArgs e)
        {
            GetObject();
        }

        #endregion FormLoad

        #region Methods

        private void GetObject()
        {
            var book = _bookService.Get(_bookId);
            if (book.ResultStatus == ResultStatus.Success)
                txtBookName.Text = book.Data.Book.Name;
            else
                Alert.Show(book.Message, ResultStatus.Warning);
        }
        private void Add()
        {
            var user = _userService.Get(_userId);
            if (user.ResultStatus == ResultStatus.Success)
            {
                if (XtraMessageBox.Show("Yorumunuz eklenecektir. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
                var comment = new CommentAddDto
                {
                    CommentText = txtComment.Text,
                    UserId = _userId,
                    BookId = _bookId,
                    Rating = ratingControl1.Rating
                };
                var result = _commentService.Add(comment, user.Data.User.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    Message = result.Message;
                    DialogResult = DialogResult.OK;
                }
                else
                    Alert.Show(result.Message, ResultStatus.Error);
            }
            else
                Alert.Show(user.Message, ResultStatus.Error);
        }

        #endregion Methods

        #region Buttons

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComment.Text))
            {
                Alert.Show("Yorum alanı boş bırakılamaz.", ResultStatus.Error);
                return;
            }
            if (ratingControl1.Rating == 0)
            {
                Alert.Show("Lütfen kitaba bir puan veriniz.", ResultStatus.Error);
                return;
            }
            Add();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
        }

        #endregion Buttons
    }
}