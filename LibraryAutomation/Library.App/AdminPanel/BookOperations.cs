using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Library.App.Popup;
using Library.Core.Enum;
using DevExpress.XtraEditors;
using Library.Services.Abstract;
using Library.Data.ImageHelper;
using Library.Entities.Entities.Concrete;
using Library.App.Utilities.FormControls;
using Library.App.Utilities.ImageControls;
using Library.Entities.Entities.Dtos.BookDto;
using static System.String;

namespace Library.App.AdminPanel
{
    public partial class BookOperations : Form
    {
        #region Field

        private readonly IBookService _bookService;
        private readonly IImageHelper _imageHelper;
        private readonly IWriterService _writerService;
        private readonly IPublisherService _publisherService;
        private readonly ICategoryService _categoryService;

        // Gridde seçilen kitabın Id bilgisi
        private int _bookId = -1;
        private string _fileName = Empty;

        #endregion Field

        #region Constructor

        public BookOperations(IBookService bookService, IImageHelper imageHelper, IWriterService writerService, IPublisherService publisherService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _imageHelper = imageHelper;
            _writerService = writerService;
            _publisherService = publisherService;
            _categoryService = categoryService;
            InitializeComponent();
            FillComboBox();
            FillGrid();
        }

        #endregion Constructor

        #region Methods

        private void FillGrid(IList<Book> list = null)
        {
            if (list == null) list = GetAllNonDeleted();
            var newList = from item in list
                          select new
                          {
                              item.Id,
                              item.GeneralStatus,
                              Kitap_Adı = item.Name,
                              Yazar = item.Writer.Name,
                              Yayın_Tarihi = item.ReleaseDate,
                              Sayfa = item.NumberOfPages,
                              Stok= item.Stock,
                              Raf_No = item.Place,
                              Oluşturulma = item.CreatedDate,
                              Güncellenme = item.UpdatedDate
                          };

            gcBook.DataSource = newList.OrderBy(b => b.Oluşturulma);

            void BookColumnVisible()
            {
                gvBook.Columns[0].Visible = false;
                gvBook.Columns[1].Visible = false;
            }
            BookColumnVisible();

            lblMessage.Text = $"{list.Count} adet kitap listeleniyor.      ";
        }

        /// <summary>
        /// Tüm comboboxları doldur.
        /// </summary>
        private void FillComboBox()
        {
            cbStatus.Properties.Items.Clear();
            cbWriters.Properties.Items.Clear();
            cbPublisher.Properties.Items.Clear();
            cbSearchWriter.Properties.Items.Clear();
            cbSearchCategory.Properties.Items.Clear();
            var writers = _writerService.GetAllNonDeleted();
            var categories = _categoryService.GetAllNonDeleted();
            var publishers = _publisherService.GetAllNonDeleted();
            cbStatus.Properties.Items.AddRange(Enum.GetValues(typeof(GeneralStatus)));

            switch (writers.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        foreach (var writer in writers.Data.Writers)
                        {
                            cbWriters.Properties.Items.Add(writer.Name);
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
            switch (publishers.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        foreach (var publisher in publishers.Data.Publishers)
                        {
                            cbPublisher.Properties.Items.Add(publisher.Name);
                        }
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(publishers.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(publishers.Message, ResultStatus.Error);
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
        private void GetObject()
        {
            if (gvBook.SelectedRowsCount <= 0) return;
            int.TryParse(gvBook.GetRowCellValue(gvBook.FocusedRowHandle, "Id").ToString(), out _bookId);
            var book = _bookService.Get(_bookId);

            if (book.ResultStatus == ResultStatus.Success)
            {
                lblComment.Visible = true;
                lblFavorite.Visible = true;
                lblReaded.Visible = true;
                labelComment.Visible = true;
                labelFavorite.Visible = true;
                labelReaded.Visible = true;
                txtName.Text = book.Data.Book.Name;
                txtAbout.Text = book.Data.Book.Description;
                cbWriters.SelectedItem = book.Data.Book.Writer.Name;
                ratingControl1.Rating = book.Data.Book.RatingAverage;
                txtStock.Text = Convert.ToString(book.Data.Book.Stock);
                cbPublisher.SelectedItem = book.Data.Book.Publisher.Name;
                txtShelfNum.Text = Convert.ToString(book.Data.Book.Place);
                lblReaded.Text = Convert.ToString(book.Data.Book.NumberOfReads);
                txtPageNum.Text = Convert.ToString(book.Data.Book.NumberOfPages);
                lblFavorite.Text = Convert.ToString(book.Data.Book.NumberOfFavorites);
                lblComment.Text = Convert.ToString(book.Data.Book.NumberOfComments);
                txtReleaseDate.DateTime = Convert.ToDateTime(book.Data.Book.ReleaseDate);
                cbStatus.SelectedItem = Enum.Parse(typeof(GeneralStatus), book.Data.Book.GeneralStatus.ToString());
                var stream = new FileStream($"{Directory.GetCurrentDirectory()}\\img\\{book.Data.Book.Thumbnail}", FileMode.OpenOrCreate);
                pictureBox1.Image = Helpers.ImageResize(Image.FromStream(stream), new Size(175, 200));
                stream.Flush(); stream.Close();
            }
            else
                Alert.Show(book.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// Sisteme yeni kitap ekler.
        /// </summary>
        private void Add()
        {
            var book = new BookAddDto
            {
                Name = txtName.Text,
                NumberOfPages = Convert.ToInt32(txtPageNum.Text),
                WriterId = cbWriters.SelectedIndex + 1,
                PublisherId = cbPublisher.SelectedIndex + 1,
                Stock = Convert.ToInt32(txtStock.Text),
                ReleaseDate = txtReleaseDate.DateTime,
                Description = txtAbout.Text,
                Place = txtShelfNum.Text,
                GeneralStatus = (GeneralStatus)cbStatus.SelectedItem,
                Thumbnail = !IsNullOrEmpty(_fileName)
                    ? _imageHelper.Upload(txtName.Text, _fileName, PictureType.Book).Data.FullName
                    : "bookImages/defaultBook.png"
            };
            var added = _bookService.Add(book, "Admin");
            switch (added.ResultStatus)
            {
                case ResultStatus.Success:
                    Alert.Show(added.Message, ResultStatus.Success);
                    FillGrid();
                    ClearItems();
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
        /// Sistemdeki bir kitabı günceller.
        /// </summary>
        private new void Update()
        {
            var newBook = new BookUpdateDto
            {
                Id = _bookId,
                Name = txtName.Text,
                WriterId = cbWriters.SelectedIndex + 1,
                PublisherId = cbPublisher.SelectedIndex + 1,
                NumberOfPages = Convert.ToInt32(txtPageNum.Text),
                Stock = Convert.ToInt32(txtStock.Text),
                ReleaseDate = txtReleaseDate.DateTime,
                Description = txtAbout.Text,
                Place = txtShelfNum.Text,
                GeneralStatus = (GeneralStatus)cbStatus.SelectedItem
            };
            var isNewPicture = false;
            var oldBook = _bookService.Get(_bookId);
            string oldBookPicture;
            if (oldBook.ResultStatus == ResultStatus.Success)
            {
                oldBookPicture = _bookService.Get(_bookId).Data.Book.Thumbnail;
                if (_fileName != Empty)
                {
                    var uploadedImageDtoResult = _imageHelper.Upload(txtName.Text, _fileName, PictureType.Book);
                    if (uploadedImageDtoResult.ResultStatus == ResultStatus.Success)
                    {
                        newBook.Thumbnail = uploadedImageDtoResult.Data.FullName;
                        if (oldBookPicture != "bookImages/defaultBook.png")
                            isNewPicture = true;
                    }
                    else
                    {
                        Alert.Show(uploadedImageDtoResult.Message, ResultStatus.Error);
                        return;
                    }
                }
                else
                    newBook.Thumbnail = oldBookPicture;
            }
            else
            {
                Alert.Show(oldBook.Message, ResultStatus.Warning);
                return;
            }
            var updatedBook = _bookService.Update(newBook, "Admin");
            if (updatedBook.ResultStatus == ResultStatus.Success)
            {
                if (isNewPicture)
                {
                    var deleteResult = _imageHelper.Delete(oldBookPicture);
                    if (deleteResult.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(deleteResult.Message, ResultStatus.Error);
                        return;
                    }
                }
                Alert.Show(updatedBook.Message, ResultStatus.Success);
                FillGrid();
                ClearItems();
            }
            else Alert.Show(updatedBook.Message, ResultStatus.Error);
        }

        /// <summary>
        /// Seçilen kitabı arşivle.
        /// </summary>
        private void Delete(object sender, EventArgs e)
        {
            if (_bookId > -1)
            {
                if (XtraMessageBox.Show("Kitap arşivlenecektir. Emin misiniz?", "Soru", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes) return;
                var result = _bookService.Delete(_bookId, "Admin");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    FillGrid();
                }
                else
                    Alert.Show(result.Message, ResultStatus.Error);
            }
            else
                Alert.Show("Lütfen arşivlenecek kitabı seçiniz.", ResultStatus.Info);
        }

        /// <summary>
        /// Form içindeki kontrolleri temizler.
        /// </summary>
        private void ClearItems()
        {
            _bookId = -1;
            pictureBox1.Image = null;
            _fileName = Empty;
            lblComment.Visible = false;
            lblFavorite.Visible = false;
            lblReaded.Visible = false;
            labelComment.Visible = false;
            labelFavorite.Visible = false;
            labelReaded.Visible = false;
            ratingControl1.Rating = 0;
            txtSearchByName.Text = null;

            FormControls.ClearFormControls(this);
        }

        /// <summary>
        /// Kitap adı veya yazarına göre kitap ara.
        /// </summary>
        private void SearchByBookName()
        {
            var searchText = txtSearchByName.Text;
            if (IsNullOrEmpty(searchText)) { FillGrid(); return; }

            var books = _bookService.SearchByName(searchText);
            if (books.ResultStatus == ResultStatus.Success) FillGrid(books.Data.Books);
            else FillGrid();
        }

        /// <summary>
        /// Kategori adına göre kitap ara.
        /// </summary>
        private void SearchByCategory()
        {
            var books = _bookService.SearchByCategoryName(cbSearchCategory.SelectedItem.ToString());
            if (books.ResultStatus == ResultStatus.Success) FillGrid(books.Data.Books);
            else FillGrid();
        }

        /// <summary>
        /// Yazar adına göre kitap ara.
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormControls.CheckFormControls(gbBook))
            {
                Alert.Show("Lütfen tüm alanları doldurunuz.", ResultStatus.Warning);
                return;
            }
            if (_bookId > -1) Update();
            else Add();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearItems();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete(sender, e);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog() { Filter = @"Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;
                _fileName = ofd.FileName;
                var stream = new FileStream(_fileName, FileMode.OpenOrCreate);
                pictureBox1.Image = Helpers.ImageResize(Image.FromStream(stream), new Size(175, 200));
                stream.Flush(); stream.Close();
            }
        }

        #endregion Buttons

        #region LinkLabel

        private void lnkExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = @"Excel Documents (*.xls)|*.xls", FileName = "books.xls" };
            if (sfd.ShowDialog() == DialogResult.OK) gcBook.ExportToXls(sfd.FileName);
        }

        #endregion LinkLabel

        #region GridControl

        /// <summary>
        /// Grid üzerindeki kitaplara mouse butonu ile işlem uygular.
        /// </summary>
        private void gcBook_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Kitabı Arşivle", Delete));

            var rowIndex = gvBook.CalcHitInfo(e.X, e.Y).RowHandle;
            if (rowIndex <= -1) return;
            gvBook.ClearSelection();
            gvBook.SelectRow(rowIndex);
            _bookId = Convert.ToInt32(gvBook.GetRowCellValue(rowIndex, "Id"));
            contextMenu.Show(gcBook, new Point(e.X, e.Y));
        }
        private void gvBook_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
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
            SearchByBookName();
        }
        private void ceAllNonStock_CheckedChanged(object sender, EventArgs e)
        {
            if (ceAllNonStock.Checked) GetAllNonStock();
            else FillGrid();
        }
        private void ceAllInStock_CheckedChanged(object sender, EventArgs e)
        {
            if (ceAllInStock.Checked) GetAllInStock();
            else FillGrid();
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchCategory.SelectedIndex != -1)
                SearchByCategory();
            else FillGrid();
        }
        private void cbSearchWriter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchWriter.SelectedIndex != -1)
                SearchByWriter();
            else FillGrid();
        }

        #endregion
    }
}