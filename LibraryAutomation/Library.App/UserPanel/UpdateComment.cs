using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Library.App.Popup;
using Library.Core.Enum;
using Library.Entities.Entities.Dtos.CommentDto;
using Library.Services.Abstract;

namespace Library.App.UserPanel
{
    public partial class UpdateComment : Form
    {
        #region Field

        private readonly int _commentId;
        private readonly ICommentService _commentService;
        public string Message;

        #endregion Field

        #region Constructor

        public UpdateComment(ICommentService commentService, int commentId)
        {
            _commentId = commentId;
            _commentService = commentService;
            InitializeComponent();
        }

        #endregion Constructor

        #region FormLoad

        private void UpdateComment_Load(object sender, EventArgs e)
        {
            GetObject();
        }

        #endregion FormLoad

        #region Methods

        private void GetObject()
        {
            var oldComment = _commentService.Get(_commentId);
            if (oldComment.ResultStatus == ResultStatus.Success)
            {
                txtBookName.Text = oldComment.Data.Comment.Book.Name;
                txtComment.Text = oldComment.Data.Comment.CommentText;
                ratingControl1.Rating = oldComment.Data.Comment.Rating;
            }
            else
                Alert.Show(oldComment.Message, ResultStatus.Warning);
        }
        private new void Update()
        {
            var oldComment = _commentService.Get(_commentId);
            if (oldComment.Data.Comment.CommentText == txtComment.Text && oldComment.Data.Comment.Rating == ratingControl1.Rating)
            {
                Alert.Show("Güncellenecek bir değişiklik bulunamadı.", ResultStatus.Info);
                return;
            }
            if (XtraMessageBox.Show("Yorumunuz güncellenecektir. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            var newComment = new CommentUpdateDto
            {
                Id = _commentId,
                CommentText = txtComment.Text,
                Rating = ratingControl1.Rating
            };
            var result = _commentService.Update(newComment);
            if (result.ResultStatus == ResultStatus.Success)
            {
                Message = result.Message;
                DialogResult = DialogResult.OK;
            }
            else
                Alert.Show(result.Message, ResultStatus.Error);
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
            Update();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
        }

        #endregion Buttons
    }
}