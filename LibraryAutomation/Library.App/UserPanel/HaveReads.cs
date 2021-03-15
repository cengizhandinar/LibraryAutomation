using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Library.App.Popup;
using Library.App.Utilities.FormControls;
using Library.App.Utilities.ImageControls;
using Library.Core.Enum;
using Library.Entities.Entities.Concrete;
using Library.Services.Abstract;

namespace Library.App.UserPanel
{
    public partial class HaveReads : Form
    {
        #region Field

        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IWriterService _writerService;
        private readonly ICommentService _commentService;
        private readonly IUserBookService _userBookService;

        private int _bookId = -1;
        private readonly int _userId;
        private int _userBookId = -1;

        #endregion Field

        #region Constructor

        public HaveReads(IBookService bookService, IWriterService writerService, IUserBookService userBookService, ICommentService commentService, IUserService userService, int userId)
        {
            _userId = userId;
            _commentService = commentService;
            _userService = userService;
            _bookService = bookService;
            _writerService = writerService;
            _userBookService = userBookService;

            InitializeComponent();
        }

        #endregion Constructor

        #region FormLoad

        private void Favorites_Load(object sender, EventArgs e)
        {
            FillComboBox();
            FillGrid();
        }

        #endregion FormLoad

        #region Methods

        private void FillGrid(IList<UserBook> list = null)
        {
            if (list == null) list = GetAllReadByUser();
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
                              Emanet = item.LendDate,
                              Teslim = item.ReceiveDate,
                              Eklenme = (item.LendDate == item.ReceiveDate) ? "Kullanıcı" : "Kütüphane"
                          };
            gcHaveRead.DataSource = newList.OrderBy(b => b.Numara);
            gvHaveRead.Columns[3].Width = 60;
            gvHaveRead.Columns[3].OptionsColumn.FixedWidth = true;
            gvHaveRead.Columns[6].Width = 130;
            gvHaveRead.Columns[6].OptionsColumn.FixedWidth = true;
            gvHaveRead.Columns[6].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gvHaveRead.Columns[7].Width = 130;
            gvHaveRead.Columns[7].OptionsColumn.FixedWidth = true;
            gvHaveRead.Columns[7].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gvHaveRead.Columns[8].Width = 120;
            gvHaveRead.Columns[8].OptionsColumn.FixedWidth = true;
            gvHaveRead.Columns[8].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            void BookColumnVisible()
            {
                gvHaveRead.Columns[0].Visible = false;
                gvHaveRead.Columns[1].Visible = false;
                gvHaveRead.Columns[2].Visible = false;
            }
            BookColumnVisible();

            lblMessage.Text = $@"{list.Count} adet okunan kitap listeleniyor.      ";
        }

        /// <summary>
        /// Tüm comboboxları doldur.
        /// </summary>
        private void FillComboBox()
        {
            cbSearchWriter.Properties.Items.Clear();
            var writers = _writerService.GetAllNonDeleted();

            switch (writers.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        foreach (var writer in writers.Data.Writers)
                        {
                            cbSearchWriter.Properties.Items.Add(writer.Name);
                        }
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(writers.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(writers.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Tüm okunmuş kitapların listesini getir.
        /// </summary>
        private IList<UserBook> GetAllReadByUser()
        {
            var readBooks = _userBookService.GetAllReadByUser(_userId);
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
            if (gvHaveRead.SelectedRowsCount <= 0) return;
            int.TryParse(gvHaveRead.GetRowCellValue(gvHaveRead.FocusedRowHandle, "Id").ToString(), out _userBookId);
            int.TryParse(gvHaveRead.GetRowCellValue(gvHaveRead.FocusedRowHandle, "BookId").ToString(), out _bookId);
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
        /// Seçilen kitabı okunmuşlar arasından kaldırır.
        /// </summary>
        private void DeleteReads()
        {
            var readBook = _userBookService.Get(_userBookId);
            if (readBook.ResultStatus==ResultStatus.Success)
            {
                if (XtraMessageBox.Show($"Okuduklarınız arasından kaldırılacaktır. Onaylıyor musunuz?", "Soru", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
                var deleted = _userBookService.HardDelete(_userBookId);
                if (deleted.ResultStatus==ResultStatus.Success)
                {
                    Alert.Show(deleted.Message, ResultStatus.Success);
                    ClearItems();
                    FillGrid();
                }
                else
                    Alert.Show(deleted.Message, ResultStatus.Error);
            }
            else
                Alert.Show(readBook.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// Form içindeki kontrolleri temizler.
        /// </summary>
        private void ClearItems()
        {
            _bookId = -1;
            _userBookId = -1;
            lblNumberOfComment.Visible = false;
            lblNumberOfFavorites.Visible = false;
            lblNumberOfReads.Visible = false;
            txtSearchByName.Text = null;
            FormControls.ClearFormControls(this);
        }

        /// <summary>
        /// Kitap adına göre ara.
        /// </summary>
        private void SearchByName()
        {
            var searchText = txtSearchByName.Text;
            if (string.IsNullOrEmpty(searchText)) { FillGrid(); return; }

            var books = _userBookService.SearchReadByText(searchText, _userId);
            if (books.ResultStatus == ResultStatus.Success) FillGrid(books.Data.UserBooks);
            else FillGrid();
        }

        /// <summary>
        /// Yazar adına göre ara.
        /// </summary>
        private void SearchByWriter()
        {
            var books = _userBookService.SearchReadByWriterName(cbSearchWriter.SelectedItem.ToString(),
                _userId);
            if (books.ResultStatus == ResultStatus.Success) FillGrid(books.Data.UserBooks);
            else FillGrid();
        }

        #endregion Methods

        #region Buttons

        private void btnDeleteReads_Click(object sender, EventArgs e)
        {
            if (_bookId > -1 && _userId > -1)
                DeleteReads();
            else
                Alert.Show("Lütfen bir kitap seçiniz", ResultStatus.Info);
        }
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

        #region LinkLabel

        private void lnkExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog {Filter = @"Excel Documents (*.xls)|*.xls", FileName = "member.xls"};
            if (sfd.ShowDialog() == DialogResult.OK) gcHaveRead.ExportToXls(sfd.FileName);
        }

        #endregion LinkLabel

        #region GridControl

        private void gvHaveRead_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
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
            SearchByName();
        }

        private void cbSearchWriter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchWriter.SelectedIndex > -1)
                SearchByWriter();
            else
                FillGrid();
        }

        #endregion Events
    }
}