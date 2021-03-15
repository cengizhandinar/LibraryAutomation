using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Library.App.Popup;
using Library.Core.Enum;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Library.Services.Abstract;
using System.Collections.Generic;
using Library.Entities.Entities.Concrete;
using Library.App.Utilities.ImageControls;
using Library.Entities.Entities.Dtos.UserBookDto;
using Library.Entities.Entities.Dtos.FavoriteBookDto;

namespace Library.App.UserPanel
{
    public partial class Archive : Form
    {
        #region Field

        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IWriterService _writerService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IUserBookService _userBookService;
        private readonly IFavoriteBookService _favoriteBookService;

        private int _bookId = -1;
        private readonly int _userId;

        #endregion Field

        #region Constructor

        public Archive(IBookService bookService, IWriterService writerService, IFavoriteBookService favoriteBookService, ICategoryService categoryService, IUserBookService userBookService, IUserService userService, ICommentService commentService, int userId)
        {
            _userId = userId;
            _userBookService = userBookService;
            _userService = userService;
            _commentService = commentService;
            _bookService = bookService;
            _writerService = writerService;
            _categoryService = categoryService;
            _favoriteBookService = favoriteBookService;

            InitializeComponent();
        }

        #endregion Constructor

        #region FormLoad

        private void Archive_Load(object sender, EventArgs e)
        {
            FillGrid();
            FillComboBox();
        }

        #endregion FormLoad

        #region Methods

        private void FillGrid(IList<Book> list = null)
        {
            if (list == null) list = GetAllNonDeleted();

            gcArchive.DataSource = list.OrderBy(b => b.ReleaseDate);

            void BookColumnVisible()
            {
                gvArchive.Columns[1].Visible = false;
                gvArchive.Columns[2].Visible = false;
                gvArchive.Columns[5].Visible = false;
                gvArchive.Columns[7].Visible = false;
                gvArchive.Columns[8].Visible = false;
                gvArchive.Columns[9].Visible = false;
                gvArchive.Columns[10].Visible = false;
                gvArchive.Columns[11].Visible = false;
                gvArchive.Columns[12].Visible = false;
                gvArchive.Columns[13].Visible = false;
                gvArchive.Columns[14].Visible = false;
                gvArchive.Columns[15].Visible = false;
                gvArchive.Columns[16].Visible = false;
                gvArchive.Columns[17].Visible = false;
                gvArchive.Columns[18].Visible = false;
                gvArchive.Columns[19].Visible = false;
                gvArchive.Columns[20].Visible = false;
                gvArchive.Columns[22].Visible = false;
                gvArchive.Columns[24].Visible = false;
            }
            BookColumnVisible();

            lblMessage.Text = $@"{list.Count} adet kitap listeleniyor.      ";
        }

        /// <summary>
        /// Tüm comboboxları doldur.
        /// </summary>
        private void FillComboBox()
        {
            cbSearchWriter.Properties.Items.Clear();
            cbSearchCategory.Properties.Items.Clear();
            var writers = _writerService.GetAllNonDeleted();
            var categories = _categoryService.GetAllNonDeleted();

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
            switch (categories.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        foreach (var category in categories.Data.Categories)
                        {
                            cbSearchCategory.Properties.Items.Add(category.Name);
                        }
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(categories.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(categories.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Tüm aktif kitapların listesini getir.
        /// </summary>
        private IList<Book> GetAllNonDeleted()
        {
            var books = _bookService.GetAllNonDeleted();
            switch (books.ResultStatus)
            {
                case ResultStatus.Success:
                    return books.Data.Books;
                case ResultStatus.Warning:
                    Alert.Show(books.Message, ResultStatus.Warning);
                    return null;
                default:
                    Alert.Show(books.Message, ResultStatus.Error);
                    return null;
            }
        }

        /// <summary>
        /// Gridde seçilen kitapların bilgilerini getir.
        /// </summary>
        private void GetObject(int bookId = -1)
        {
            if (gvArchive.SelectedRowsCount <= 0) return;
            if (bookId == -1) int.TryParse(gvArchive.GetRowCellValue(gvArchive.FocusedRowHandle, "Id").ToString(), out _bookId);
            else _bookId = bookId;
            var book = _bookService.Get(_bookId);

            if (book.ResultStatus == ResultStatus.Success)
            {
                lblNumberOfReads.Visible = true;
                lblNumberOfFavorite.Visible = true;
                lblNumberOfComment.Visible = true;
                txtName.Text = book.Data.Book.Name;
                txtAbout.Text = book.Data.Book.Description;
                txtWriter.Text = book.Data.Book.Writer.Name;
                txtPublisher.Text = book.Data.Book.Publisher.Name;
                txtShelfNumber.Text = Convert.ToString(book.Data.Book.Place);
                txtPageNumber.Text = Convert.ToString(book.Data.Book.NumberOfPages);
                lblNumberOfReads.Text = Convert.ToString(book.Data.Book.NumberOfReads);
                txtReleaseDate.DateTime = Convert.ToDateTime(book.Data.Book.ReleaseDate);
                lblNumberOfFavorite.Text = Convert.ToString(book.Data.Book.NumberOfFavorites);
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
        /// Seçilen kitabı favorilere ekler
        /// </summary>
        private void AddFavorite()
        {
            var favoriteBook = new FavoriteBookAddDto
            {
                BookId = _bookId,
                UserId = _userId,
            };
            if (XtraMessageBox.Show($"Favorilerinize eklenecektir. Onaylıyor musunuz?", "Soru", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            var added = _favoriteBookService.Add(favoriteBook);
            switch (added.ResultStatus)
            {
                case ResultStatus.Success:
                    Alert.Show(added.Message, ResultStatus.Success);
                    GetObject(_bookId);
                    break;
                case ResultStatus.Warning:
                    Alert.Show(added.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(added.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Seçilen kitabı okunanlar arasına ekler
        /// </summary>
        private void AddReaded()
        {
            var userBook = new UserBookAddDto()
            {
                BookId = _bookId,
                UserId = _userId
            };
            if (XtraMessageBox.Show($"Okuduklarınız arasına eklenecektir. Onaylıyor musunuz?", "Soru", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            var added = _userBookService.AddReaded(userBook);
            switch (added.ResultStatus)
            {
                case ResultStatus.Success:
                    Alert.Show(added.Message, ResultStatus.Success);
                    GetObject(_bookId);
                    break;
                case ResultStatus.Warning:
                    Alert.Show(added.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(added.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Seçilen kitabı okuyacaklarım arasına ekler
        /// </summary>
        private void AddWillRead()
        {
            var userBook = new UserBookAddDto()
            {
                BookId = _bookId,
                UserId = _userId
            };
            if (XtraMessageBox.Show($"Okuyacaklarınız arasına eklenecektir. Onaylıyor musunuz?", "Soru", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            var added = _userBookService.AddWillRead(userBook);
            switch (added.ResultStatus)
            {
                case ResultStatus.Success:
                    Alert.Show(added.Message, ResultStatus.Success);
                    GetObject(_bookId);
                    break;
                case ResultStatus.Warning:
                    Alert.Show(added.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(added.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Kitap adına göre ara.
        /// </summary>
        private void SearchByName()
        {
            var searchText = txtSearchByName.Text;
            if (string.IsNullOrEmpty(searchText)) { FillGrid(); return; }

            var books = _bookService.SearchByName(searchText);
            if (books.ResultStatus == ResultStatus.Success) FillGrid(books.Data.Books);
            else FillGrid();
        }

        /// <summary>
        /// Kategoriye göre ara.
        /// </summary>
        private void SearchByCategory()
        {
            var books = _bookService.SearchByCategoryName(cbSearchCategory.SelectedItem.ToString());
            if (books.ResultStatus == ResultStatus.Success) FillGrid(books.Data.Books);
            else FillGrid();
        }

        /// <summary>
        /// Yazar adına göre ara.
        /// </summary>
        private void SearchByWriter()
        {
            var books = _bookService.SearchByWriterName(cbSearchWriter.SelectedItem.ToString());
            if (books.ResultStatus == ResultStatus.Success) FillGrid(books.Data.Books);
            else FillGrid();
        }

        /// <summary>
        /// Stokta olmayan kitapları getir.
        /// </summary>
        private void GetAllNonStock()
        {
            var books = _bookService.GetAllNonStock();
            switch (books.ResultStatus)
            {
                case ResultStatus.Success:
                    FillGrid(books.Data.Books);
                    break;
                case ResultStatus.Warning:
                    Alert.Show(books.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(books.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Stokta olan kitapları getir.
        /// </summary>
        private void GetAllInStock()
        {
            var books = _bookService.GetAllInStock();
            switch (books.ResultStatus)
            {
                case ResultStatus.Success:
                    FillGrid(books.Data.Books);
                    break;
                case ResultStatus.Warning:
                    Alert.Show(books.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(books.Message, ResultStatus.Error);
                    break;
            }
        }

        #endregion Methods

        #region Buttons

        private void btnAddFavorite_Click(object sender, EventArgs e)
        {
            if (_bookId > -1 && _userId > -1)
                AddFavorite();
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
        private void btnAddReaded_Click(object sender, EventArgs e)
        {
            if (_bookId > -1 && _userId > -1)
                AddReaded();
            else
                Alert.Show("Lütfen bir kitap seçiniz", ResultStatus.Info);
        }
        private void btnAddWllRead_Click(object sender, EventArgs e)
        {
            if (_bookId > -1 && _userId > -1)
                AddWillRead();
            else
                Alert.Show("Lütfen bir kitap seçiniz", ResultStatus.Info);
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

        #region Events

        private void cbSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchCategory.SelectedIndex != -1)
                SearchByCategory();
            else FillGrid();
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            SearchByName();
        }

        private void cbSearchWriter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchWriter.SelectedIndex != -1)
                SearchByWriter();
            else FillGrid();
        }

        private void ceAllInStock_CheckedChanged(object sender, EventArgs e)
        {
            if (ceAllInStock.Checked) GetAllInStock();
            else FillGrid();
        }

        private void ceAllNonStock_CheckedChanged(object sender, EventArgs e)
        {
            if (ceAllNonStock.Checked) GetAllNonStock();
            else FillGrid();
        }

        #endregion

        #region LinkLabel

        private void lnkExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = @"Excel Documents (*.xls)|*.xls", FileName = "archive.xls" };
            if (sfd.ShowDialog() == DialogResult.OK) gcArchive.ExportToXls(sfd.FileName);
        }

        #endregion LinkLabel

        #region GridControl

        private void gvArchive_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GetObject();
        }

        #endregion

        #region Timer

        private void timer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd.MMMM.yyyy HH:mm:ss");
        }

        #endregion Timer
    }
}