using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using Library.App.Popup;
using Library.Core.Enum;
using Library.Services.Abstract;

namespace Library.App.UserPanel
{
    public partial class SeeComment : Form
    {
        #region Field

        private readonly int _bookId;
        private readonly ICommentService _commentService;

        #endregion Field

        #region Constructor

        public SeeComment(ICommentService commentService, int bookId)
        {
            _bookId = bookId;
            _commentService = commentService;
            InitializeComponent();
        }

        #endregion Constructor

        #region FormLoad

        private void SeeComment_Load(object sender, EventArgs e)
        {
            GetObject();
        }

        #endregion FormLoad

        #region Methods

        private void GetObject()
        {
            var book = _commentService.GetAllNonDeletedByBookId(_bookId);
            switch (book.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        var count = 1;
                        var list = from item in book.Data.Comments
                                   select new
                                   {
                                       Numara = count++,
                                       Yorum = item.CommentText,
                                       Yorum_Sahibi = item.User.UserName,
                                       Puanı = item.Rating,
                                       Yorum_Tarihi = item.CreatedDate
                                   };
                        gcComments.DataSource = list.OrderBy(c => c.Yorum_Tarihi);
                        gvComments.Columns[0].Width = 75;
                        gvComments.Columns[0].OptionsColumn.FixedWidth = true;
                        gvComments.Columns[1].ColumnEdit = new RepositoryItemMemoEdit();
                        gvComments.Columns[1].AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
                        gvComments.Columns[1].AppearanceCell.TextOptions.VAlignment = VertAlignment.Top;
                        gvComments.Columns[1].AppearanceCell.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        gvComments.Columns[2].Width = 300;
                        gvComments.Columns[2].OptionsColumn.FixedWidth = true;
                        gvComments.Columns[3].Width = 50;
                        gvComments.Columns[3].OptionsColumn.FixedWidth = true;
                        gvComments.Columns[4].Width = 175;
                        gvComments.Columns[4].OptionsColumn.FixedWidth = true;
                        gvComments.Columns[4].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(book.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(book.Message, ResultStatus.Error);
                    break;
            }
        }

        #endregion Methods

        #region Buttons

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion Buttons
    }
}