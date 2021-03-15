using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using Library.App.Popup;
using Library.App.Utilities.FormControls;
using Library.Core.Enum;
using Library.Services.Abstract;

namespace Library.App.UserPanel
{
    public partial class SeeCommentPersonal : Form
    {
        #region Field

        private int _commentId;
        private readonly int _userId;
        private readonly ICommentService _commentService;

        #endregion Field

        #region Constructor

        public SeeCommentPersonal(ICommentService commentService, int userId)
        {
            _userId = userId;
            _commentService = commentService;
            InitializeComponent();
        }

        #endregion Constructor

        #region FormLoad

        private void SeeCommentPersonal_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        #endregion FormLoadSeeComment

        #region Methods

        private void FillGrid()
        {
            var comments = _commentService.GetAllByUserId(_userId);
            if (comments.Data==null)
            {
                Close();
                return;
            }
            switch (comments.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        var count = 1;
                        var list = from item in comments.Data.Comments
                                   select new
                                   {
                                       item.Id,
                                       BookId=item.Book.Id,
                                       item.GeneralStatus,
                                       Numara = count++,
                                       Yorumunuz = item.CommentText,
                                       Kitap_Adı = item.Book.Name,
                                       Puanı = item.Rating,
                                       Yorum_Tarihi = item.CreatedDate
                                   };
                        gcCommentsPersonal.DataSource = list.OrderBy(c => c.Yorum_Tarihi);
                        gvCommentsPersonal.Columns[3].Width = 75;
                        gvCommentsPersonal.Columns[3].OptionsColumn.FixedWidth = true;
                        gvCommentsPersonal.Columns[4].ColumnEdit = new RepositoryItemMemoEdit();
                        gvCommentsPersonal.Columns[4].AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
                        gvCommentsPersonal.Columns[4].AppearanceCell.TextOptions.VAlignment = VertAlignment.Top;
                        gvCommentsPersonal.Columns[4].AppearanceCell.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        gvCommentsPersonal.Columns[6].ColumnEdit = new RepositoryItemRatingControl();
                        gvCommentsPersonal.Columns[6].Width = 150;
                        gvCommentsPersonal.Columns[6].OptionsColumn.FixedWidth = true;
                        gvCommentsPersonal.Columns[7].Width = 175;
                        gvCommentsPersonal.Columns[7].OptionsColumn.FixedWidth = true;
                        gvCommentsPersonal.Columns[7].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

                        void CommentsVisible()
                        {
                            gvCommentsPersonal.Columns[0].Visible = false;
                            gvCommentsPersonal.Columns[1].Visible = false;
                            gvCommentsPersonal.Columns[2].Visible = false;
                        }
                        CommentsVisible();

                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(comments.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(comments.Message, ResultStatus.Error);
                    break;
            }
        }
        private void DeleteComment()
        {
            var comment = _commentService.Get(_commentId);
            if (comment.ResultStatus == ResultStatus.Success)
            {
                if (XtraMessageBox.Show($"Yorumunuz kaldırılacaktır. Onaylıyor musunuz?", "Soru", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
                var deleted = _commentService.HardDelete(_commentId,true);
                switch (deleted.ResultStatus)
                {
                    case ResultStatus.Success:
                        Alert.Show(deleted.Message, ResultStatus.Success);
                        ClearItems();
                        FillGrid();
                        break;
                    case ResultStatus.Warning:
                        Alert.Show(deleted.Message, ResultStatus.Warning);
                        break;
                    default:
                        Alert.Show(deleted.Message, ResultStatus.Error);
                        break;
                }
            }
            else
                Alert.Show(comment.Message, ResultStatus.Warning);
        }
        private void UpdateComment()
        {
            if (_userId > -1 && _commentId > -1)
            {
                var form = new UpdateComment(_commentService,_commentId);
                Hide();
                var result = form.ShowDialog();
                switch (result)
                {
                    case DialogResult.Ignore:
                        form.Close();
                        Show();
                        break;
                    case DialogResult.OK:
                        form.Close();
                        Show();
                        FillGrid();
                        Alert.Show(form.Message, ResultStatus.Success);
                        break;
                }
            }
            else
                Alert.Show("Lütfen güncellemek istediğiniz yorumu seçiniz.", ResultStatus.Info);
        }

        /// <summary>
        /// Form içindeki kontrolleri temizler.
        /// </summary>
        private void ClearItems()
        {
            _commentId = -1;
            FormControls.ClearFormControls(this);
        }

        #endregion Methods

        #region Buttons

        private void btnDeleteComment_Click(object sender, EventArgs e)
        {
            if (_commentId > -1) DeleteComment();
            else Alert.Show("Lütfen bir yorum seçiniz.",ResultStatus.Info);
        }

        private void btnUpdateComment_Click(object sender, EventArgs e)
        {
            UpdateComment();
        }

        #endregion Buttons

        #region Timer

        private void timer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd.MMMM.yyyy HH:mm:ss");
        }

        #endregion

        #region LinkLabel

        private void lnkExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = @"Excel Documents (*.xls)|*.xls", FileName = "comments.xls" };
            if (sfd.ShowDialog() == DialogResult.OK) gcCommentsPersonal.ExportToXls(sfd.FileName);
        }

        #endregion LinkLabel

        #region GridControl

        private void gvCommentsPersonal_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gvCommentsPersonal.SelectedRowsCount <= 0) return;
            int.TryParse(gvCommentsPersonal.GetRowCellValue(gvCommentsPersonal.FocusedRowHandle, "Id").ToString(), out _commentId);
        }

        #endregion
    }
}