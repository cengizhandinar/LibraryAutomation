using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Library.App.Popup;
using Library.App.Utilities.FormControls;
using Library.Core.Enum;
using Library.Entities.Entities.Concrete;
using Library.Services.Abstract;
using static System.String;

namespace Library.App.AdminPanel
{
    public partial class CommentOperations : Form
    {
        #region Fields

        private readonly ICommentService _commentService;
        private int _commentId;

        #endregion Fields

        #region FormLoad

        private void CommentOperations_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        #endregion FormLoad

        #region Constructor

        public CommentOperations(ICommentService commentService)
        {
            _commentService = commentService;
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        private void FillGrid(IList<Comment> list = null)
        {
            if (list == null) list = GetAllNonDeleted();

            var newList = from item in list
                          select new
                          {
                              item.Id,
                              item.GeneralStatus,
                              Yorum_Sahibi = item.User.FirstName + " " + item.User.LastName,
                              Yorum_Yapılan_Kitap = item.Book.Name,
                              Yorum_Tarihi = item.CreatedDate,
                          };
            gcComment.DataSource = newList.OrderBy(c => c.Yorum_Tarihi);

            gvComment.Columns[0].Visible = false;

            lblMessage.Text = $"{list.Count} adet yorum listeleniyor.      ";
        }

        /// <summary>
        /// Tüm onay bekleyen yorumların listesini getir.
        /// </summary>
        private void GetAllNonApproved()
        {
            var comments = _commentService.GetAllNonApproved();
            switch (comments.ResultStatus)
            {
                case ResultStatus.Success:
                    FillGrid(comments.Data.Comments);
                    break;
                case ResultStatus.Warning:
                    Alert.Show(comments.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(comments.Message, ResultStatus.Warning);
                    break;
            }
        }

        /// <summary>
        /// Tüm aktif yorumların listesini getir.
        /// </summary>
        private IList<Comment> GetAllNonDeleted()
        {
            var comments = _commentService.GetAllNonDeleted();
            switch (comments.ResultStatus)
            {
                case ResultStatus.Success:
                    return comments.Data.Comments;
                case ResultStatus.Warning:
                    Alert.Show(comments.Message, ResultStatus.Warning);
                    return null;
                default:
                    Alert.Show(comments.Message, ResultStatus.Error);
                    return null;
            }
        }

        /// <summary>
        /// Gridde seçilen yorum bilgilerini getir.
        /// </summary>
        private void GetObject()
        {
            if (gvComment.SelectedRowsCount <= 0) return;
            int.TryParse(gvComment.GetRowCellValue(gvComment.FocusedRowHandle, "Id").ToString(), out _commentId);
            var comment = _commentService.Get(_commentId);

            if (comment.ResultStatus == ResultStatus.Success)
            {
                txtFirstName.Text = comment.Data.Comment.User.FirstName;
                txtLastName.Text = comment.Data.Comment.User.LastName;
                txtBookName.Text = comment.Data.Comment.Book.Name;
                txtContent.Text = comment.Data.Comment.CommentText;
                dateCommentDate.DateTime = comment.Data.Comment.CreatedDate;
            }
            else
                Alert.Show(comment.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// Seçilen yorumu onaylar.
        /// </summary>
        private void Approve()
        {
            if (_commentId>-1)
            {
                var approvedComment = _commentService.Approve(_commentId, "Admin");
                switch (approvedComment.ResultStatus)
                {
                    case ResultStatus.Success:
                        Alert.Show(approvedComment.Message, ResultStatus.Success);
                        FillGrid();
                        ClearItems();
                        break;
                    case ResultStatus.Info:
                        Alert.Show(approvedComment.Message, ResultStatus.Info);
                        break;
                    default:
                        Alert.Show(approvedComment.Message, ResultStatus.Error);
                        break;
                }
            }
            else
                Alert.Show("Lütfen onaylanacak yorumu seçiniz.", ResultStatus.Info);
        }

        /// <summary>
        /// Seçilen yorumu arşivler.
        /// </summary>
        private void Delete(object sender, EventArgs e)
        {
            if (_commentId > -1)
            {
                if (XtraMessageBox.Show("Yorum arşivlenecektir. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes) return;
                var result = _commentService.Delete(_commentId, "Admin");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    Alert.Show(result.Message, ResultStatus.Success);
                    FillGrid();
                    ClearItems();
                }
                else
                    Alert.Show(result.Message, ResultStatus.Error);
            }
            else
                Alert.Show("Lütfen arşivlenecek yorumu seçiniz.", ResultStatus.Info);
        }

        /// <summary>
        /// Form içindeki kontrolleri temizler.
        /// </summary>
        private void ClearItems()
        {
            _commentId = -1;
            txtSearchByBook.Text = null;
            txtSearchByUser.Text = null;
            FormControls.ClearFormControls(this);
        }

        /// <summary>
        /// Kullanıcı'ya göre yorum ara.
        /// </summary>
        private void SearchCommentByUser()
        {
            var searchText = txtSearchByUser.Text;
            if (IsNullOrEmpty(searchText)) FillGrid();

            var comments = _commentService.FindCommentsByUserName(searchText);
            if (comments.ResultStatus == ResultStatus.Success) FillGrid(comments.Data.Comments);
            else FillGrid();
        }

        /// <summary>
        /// Kitap adına göre yorum ara.
        /// </summary>
        private void SearchCommentByBook()
        {
            var searchText = txtSearchByBook.Text;
            if (IsNullOrEmpty(searchText)) FillGrid();

            var comments = _commentService.FindCommentsByBookName(searchText);
            if (comments.ResultStatus == ResultStatus.Success) FillGrid(comments.Data.Comments);
            else FillGrid();
        }

        #endregion Methods

        #region Buttons

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearItems();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtContent.Text == null)
            {
                Alert.Show("İçerik boş olamaz.", ResultStatus.Info);
                return;
            }
            Approve();
        }

        #endregion Buttons

        #region Events

        private void txtSearchByUser_TextChanged(object sender, EventArgs e)
        {
            SearchCommentByUser();
        }

        private void txtSearchByBook_TextChanged(object sender, EventArgs e)
        {
            SearchCommentByBook();
        }

        private void ceAllComment_CheckedChanged(object sender, EventArgs e)
        {
            if (ceAllComment.Checked) GetAllNonApproved();
            else FillGrid();
        }

        #endregion Events

        #region LinkLabel

        private void lnkExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = @"Excel Documents (*.xls)|*.xls", FileName = "comments.xls" };
            if (sfd.ShowDialog() == DialogResult.OK) gcComment.ExportToXls(sfd.FileName);
        }

        #endregion

        #region GridControl

        /// <summary>
        /// Grid üzerindeki yorumlara mouse butonu ile işlem uygular.
        /// </summary>
        private void gcComment_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Yorumu Arşivle", Delete));

            var rowIndex = gvComment.CalcHitInfo(e.X, e.Y).RowHandle;
            if (rowIndex <= -1) return;
            gvComment.ClearSelection();
            gvComment.SelectRow(rowIndex);
            _commentId = Convert.ToInt32(gvComment.GetRowCellValue(rowIndex, "Id"));
            contextMenu.Show(gcComment, new Point(e.X, e.Y));
        }

        private void gvComment_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
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
    }
}