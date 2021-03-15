using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using Library.App.Popup;
using Library.App.Utilities.FormControls;
using Library.App.Utilities.ImageControls;
using Library.Core.Enum;
using Library.Entities.Entities.Concrete;
using Library.Services.Abstract;

namespace Library.App.UserPanel
{
    public partial class BorrowedList : Form
    {
        #region Field

        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly ICommentService _commentService;
        private readonly IUserBookService _userBookService;

        private int _bookId = -1;
        private readonly int _userId;

        #endregion Field

        #region Constructor

        public BorrowedList(IBookService bookService, IUserBookService userBookService, ICommentService commentService, IUserService userService, int userId)
        {
            _userId = userId;
            _commentService = commentService;
            _userService = userService;
            _bookService = bookService;
            _userBookService = userBookService;

            InitializeComponent();
        }

        #endregion Constructor

        #region FormLoad

        private void Favorites_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        #endregion FormLoad

        #region Methods

        private void FillGrid(IList<UserBook> list = null)
        {
            if (list == null) list = GetAllReadingByUser();
            if (list == null)
            {
                Close();
                return;
            }
            var count = 1;
            var newList = from item in list
                          select new
                          {
                              item.Id,
                              item.BookId,
                              item.UserId,
                              Numara = count++,
                              Kitap_Adı = item.Book.Name,
                              Yazar = item.Book.Writer.Name,
                              Alış_Tarihi = item.LendDate,
                              Son_Teslim_Tarihi = item.LendDate.AddMonths(1),
                          };
            gcBorrowedList.DataSource = newList.OrderBy(b => b.Alış_Tarihi);
            gvBorrowedList.Columns[3].Width = 60;
            gvBorrowedList.Columns[3].OptionsColumn.FixedWidth = true;
            gvBorrowedList.Columns[6].Width = 130;
            gvBorrowedList.Columns[6].OptionsColumn.FixedWidth = true;
            gvBorrowedList.Columns[6].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gvBorrowedList.Columns[7].Width = 130;
            gvBorrowedList.Columns[7].OptionsColumn.FixedWidth = true;
            gvBorrowedList.Columns[7].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            void BookColumnVisible()
            {
                gvBorrowedList.Columns[0].Visible = false;
                gvBorrowedList.Columns[1].Visible = false;
                gvBorrowedList.Columns[2].Visible = false;
            }
            BookColumnVisible();

            lblMessage.Text = $@"{list.Count} adet ödünç alınan kitap listeleniyor.      ";
        }

        /// <summary>
        /// Tüm ödünç alınmış kitapların listesini getir.
        /// </summary>
        private IList<UserBook> GetAllReadingByUser()
        {
            var readBooks = _userBookService.GetAllReadingByUser(_userId);
            switch (readBooks.ResultStatus)
            {
                case ResultStatus.Success:
                    return readBooks.Data.UserBooks;
                case ResultStatus.Warning:
                    Alert.Show(readBooks.Message, ResultStatus.Warning);
                    return null;
                default:
                    Alert.Show(readBooks.Message, ResultStatus.Error);
                    return null;
            }
        }

        /// <summary>
        /// Gridde seçilen kitapların bilgilerini getir.
        /// </summary>
        private void GetObject()
        {
            if (gvBorrowedList.SelectedRowsCount <= 0) return;
            int.TryParse(gvBorrowedList.GetRowCellValue(gvBorrowedList.FocusedRowHandle, "BookId").ToString(), out _bookId);
            var book = _bookService.Get(_bookId);

            if (book.ResultStatus == ResultStatus.Success)
            {
                lblNumberOfReads.Visible = true;
                lblNumberOfFavorites.Visible = true;
                lblNumberOfComment.Visible = true;
                txtName.Text = book.Data.Book.Name;
                txtAbout.Text = book.Data.Book.Description;
                txtWriter.Text = book.Data.Book.Writer.Name;
                txtPublisher.Text = book.Data.Book.Publisher.Name;
                txtShelfNumber.Text = Convert.ToString(book.Data.Book.Place);
                txtPageNumber.Text = Convert.ToString(book.Data.Book.NumberOfPages);
                lblNumberOfReads.Text = Convert.ToString(book.Data.Book.NumberOfReads);
                txtReleaseDate.DateTime = Convert.ToDateTime(book.Data.Book.ReleaseDate);
                lblNumberOfFavorites.Text = Convert.ToString(book.Data.Book.NumberOfFavorites);
                lblNumberOfComment.Text = Convert.ToString(book.Data.Book.NumberOfComments);
                ratingControl.Rating = book.Data.Book.RatingAverage;
                var stream = new FileStream($"{Directory.GetCurrentDirectory()}\\img\\{book.Data.Book.Thumbnail}", FileMode.OpenOrCreate);
                pictureBox1.Image = Helpers.ImageResize(Image.FromStream(stream), new Size(175, 200));
                stream.Flush(); stream.Close();
            }
            else
                Alert.Show(book.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// Form içindeki kontrolleri temizler.
        /// </summary>
        private void ClearItems()
        {
            _bookId = -1;
            lblNumberOfComment.Visible = false;
            lblNumberOfFavorites.Visible = false;
            lblNumberOfReads.Visible = false;
            FormControls.ClearFormControls(this);
        }

        /// <summary>
        /// Kitap adına göre ara.
        /// </summary>
        private void SearchByName()
        {
        }

        /// <summary>
        /// Yazar adına göre ara.
        /// </summary>
        private void SearchByWriter()
        {
        }

        #endregion Methods

        #region Buttons

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            if (_bookId > -1 && _userId > -1)
            {
                var form = new AddComment(_commentService, _bookService, _userService, _bookId, _userId);
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
                        Alert.Show(form.Message, ResultStatus.Success);
                        break;
                }
            }
            else
                Alert.Show("Lütfen yorum eklemek istediğiniz kitabı seçiniz.", ResultStatus.Info);
        }
        private void btnSeeComment_Click(object sender, EventArgs e)
        {
            if (_bookId > -1)
            {
                var book = _bookService.Get(_bookId);
                if (book.ResultStatus == ResultStatus.Success)
                {
                    if (book.Data.Book.NumberOfComments == 0)
                    {
                        Alert.Show("Kitaba ait herhangi bir yorum bulunamamıştır.", ResultStatus.Info);
                        return;
                    }
                    var form = new SeeComment(_commentService, _bookId);
                    Hide();
                    var result = form.ShowDialog();
                    switch (result)
                    {
                        case DialogResult.OK:
                            form.Close();
                            Show();
                            break;
                    }
                }
                else
                    Alert.Show(book.Message, ResultStatus.Warning);
            }
            else
                Alert.Show("Lütfen yorumlarını görmek istediğiniz kitabı seçiniz.", ResultStatus.Info);
        }

        #endregion Buttons

        #region GridControl

        private void gvBorrowedList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
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

        #region Events

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbSearchWriter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion Events
    }
}