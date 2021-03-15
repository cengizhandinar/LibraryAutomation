using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Library.App.Popup;
using Library.Core.Enum;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.BookCategoryDto;
using Library.Services.Abstract;
using static System.String;

namespace Library.App.AdminPanel
{
    public partial class BookCategoryOperations : Form
    {
        #region Field

        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;
        private readonly IBookCategoryService _bookCategoryService;
        private int _bookId = -1;
        private int _categoryId = -1;

        #endregion Field

        #region Constructor

        public BookCategoryOperations(ICategoryService categoryService, IBookService bookService, IBookCategoryService bookCategoryService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
            _bookCategoryService = bookCategoryService;
            InitializeComponent();
        }

        #endregion Constructor

        #region Form Load

        private void BookCategoryOperations_Load(object sender, EventArgs e)
        {
            FillGridBook();
            FillComboBox();
        }

        #endregion Form Load

        #region Methods

        private void FillGridBook(IList<Book> list = null)
        {
            if (list == null) list = GetAllNonDeleted();

            var newList = from item in list
                          select new
                          {
                              item.Id,
                              Kitap_Adı = item.Name,
                              Yazar_Adı = item.Writer.Name
                          };

            gcBook.DataSource = newList.OrderBy(b => b.Kitap_Adı);

            gvBook.Columns[0].Visible = false;

            lblBookMessage.Text = $"{list.Count} adet kitap listeleniyor.      ";
        }

        /// <summary>
        /// Tüm comboboxları doldur.
        /// </summary>
        private void FillComboBox()
        {
            cbAllCategory.Properties.Items.Clear();
            cbSearchBookByCategory.Properties.Items.Clear();
            var categories = _categoryService.GetAllNonDeleted();

            switch (categories.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        foreach (var category in categories.Data.Categories)
                        {
                            cbAllCategory.Properties.Items.Add(category.Name);
                            cbSearchBookByCategory.Properties.Items.Add(category.Name);
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
        /// Kategorisi olmayan kitapların listesini getir.
        /// </summary>
        private void GetAllBookByNonCategory()
        {
            var booksNonCategory = _bookCategoryService.GetAllBookByNonCategory();
            switch (booksNonCategory.ResultStatus)
            {
                case ResultStatus.Success:
                    FillGridBook(booksNonCategory.Data.Books);
                    break;
                case ResultStatus.Warning:
                    Alert.Show(booksNonCategory.Message, ResultStatus.Warning);
                    break;
                default:
                    Alert.Show(booksNonCategory.Message, ResultStatus.Error);
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
        /// Silinecek kategorinin bilgisini alır ve comboboxa doldurur.
        /// </summary>
        private void GetDeleting()
        {
            if (gvCategory.SelectedRowsCount <= 0) return;
            int.TryParse(gvCategory.GetRowCellValue(gvCategory.FocusedRowHandle, "Id").ToString(), out _categoryId);
            var category = _categoryService.Get(_categoryId);

            if (category.ResultStatus == ResultStatus.Success)
            {
                lblDeleted.Text = "Silinecek Kategori";
                lblDeleted.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                lblDeleted.ForeColor = Color.DarkRed;
                cbAllCategory.Enabled = false;
                cbAllCategory.SelectedItem = category.Data.Category.Name;
            }
            else
                Alert.Show(category.Message, ResultStatus.Warning);
        }

        /// <summary>
        /// Kitaba ait kategorileri gride doldurur.
        /// </summary>
        private void FillGridCategory()
        {
            if (gvBook.SelectedRowsCount <= 0) return;
            int.TryParse(gvBook.GetRowCellValue(gvBook.FocusedRowHandle, "Id").ToString(), out _bookId);
            var categories = _categoryService.GetAllByBookId(_bookId);

            switch (categories.ResultStatus)
            {
                case ResultStatus.Success:
                {
                    lblDeleted.Text = "Eklenecek Kategori:";
                    lblDeleted.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    lblDeleted.ForeColor = Color.Black;
                    cbAllCategory.SelectedIndex = -1;
                        var newList = from item in categories.Data.Categories
                                      select new
                                      {
                                          item.Id,
                                          item.ParentId,
                                          Kategori_Adı = item.Name,
                                          Üst_Kategori_Adı = item.ParentId != 0 ? _categoryService.GetByParent(item.ParentId).Data.Category.Name : Empty
                                      };
                        gcCategory.DataSource = newList.OrderBy(c => c.Üst_Kategori_Adı);

                        void CategoryColumnVisible()
                        {
                            gvCategory.Columns["Id"].Visible = false;
                            gvCategory.Columns["ParentId"].Visible = false;
                        }
                        CategoryColumnVisible();

                        lblCategoryMessage.Text = $"{categories.Data.Categories.Count} adet kategori listeleniyor.";
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(categories.Message, ResultStatus.Warning);
                    gcCategory.DataSource = null;
                    break;
                default:
                    Alert.Show(categories.Message, ResultStatus.Error);
                    break;
            }
        }

        /// <summary>
        /// Sisteme yeni kitap kategorisi ekler.
        /// </summary>
        private void Add()
        {
            if (cbAllCategory.SelectedIndex != -1 && _bookId > -1)
            {
                var category = _categoryService.GetByName(cbAllCategory.SelectedItem.ToString());
                if (category.ResultStatus == ResultStatus.Success)
                {
                    var bookCategory = new BookCategoryAddDto
                    {
                        BookId = _bookId,
                        CategoryId = category.Data.Category.Id
                    };
                    var added = _bookCategoryService.Add(bookCategory);
                    if (added.ResultStatus == ResultStatus.Success)
                    {
                        Alert.Show(added.Message, ResultStatus.Success);
                        FillGridBook();
                        ClearItems();
                    }
                    else if (added.ResultStatus == ResultStatus.Warning)
                        Alert.Show(added.Message, ResultStatus.Warning);
                    else
                        Alert.Show(added.Message, ResultStatus.Error);
                }
                else Alert.Show(category.Message, ResultStatus.Warning);
            }
            else
                Alert.Show("Herhangi bir kitap veya kategori seçilmedi.", ResultStatus.Info);
        }

        /// <summary>
        /// Seçilen kitabın kategorisini veritabanından kaldırır.
        /// </summary>
        private void HardDelete()
        {
            if (_categoryId > -1 && _bookId > -1)
            {
                var category = _categoryService.Get(_categoryId);
                var book = _bookService.Get(_bookId);
                if (category.ResultStatus == ResultStatus.Success)
                {
                    if (book.ResultStatus == ResultStatus.Success)
                    {
                        if (XtraMessageBox.Show(
                            $"{book.Data.Book.Name} adlı kitaba ait {category.Data.Category.Name} kategorisi veritabanından kaldırılacaktır. Emin misiniz?",
                            "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                        if (XtraMessageBox.Show(
                            "Bağlı olduğu alt kategoriler ve ilgili kitapların kategori bilgisi varsa onlar da kaldırılacaktır. Devam etmek istiyor musunuz?",
                            "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                        var result = _bookCategoryService.HardDelete(_categoryId,_bookId);
                        var parents = _categoryService.GetParents(_categoryId);
                        if (result.ResultStatus == ResultStatus.Success)
                        {
                            switch (parents.ResultStatus)
                            {
                                case ResultStatus.Success:
                                    {
                                        var count = parents.Data.Categories.Count;
                                        for (var i = 0; i < count; i++)
                                        {
                                            _bookCategoryService.HardDelete(parents.Data.Categories[i].Id,_bookId);
                                        }
                                        Alert.Show(result.Message, ResultStatus.Success);
                                        FillGridBook();
                                        ClearItems();
                                        break;
                                    }
                                case ResultStatus.Warning:
                                    Alert.Show(result.Message, ResultStatus.Success);
                                    FillGridBook();
                                    ClearItems();
                                    break;
                                default:
                                    Alert.Show(parents.Message, ResultStatus.Error);
                                    break;
                            }
                        }
                        else
                            Alert.Show(result.Message, ResultStatus.Error);
                    }
                    else
                        Alert.Show(book.Message, ResultStatus.Warning);
                }
                else
                    Alert.Show(category.Message, ResultStatus.Warning);
            }
            else
                Alert.Show("Herhangi bir kitap veya kategori seçilmedi.", ResultStatus.Info);
        }

        /// <summary>
        /// Form içindeki kontrolleri temizler.
        /// </summary>
        private void ClearItems()
        {
            _categoryId = -1;
            _bookId = -1;
            lblDeleted.Text = "Eklenecek Kategori:";
            lblDeleted.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            lblDeleted.ForeColor = Color.Black;
            cbAllCategory.SelectedIndex = -1;
            cbSearchBookByCategory.SelectedIndex = -1;
            ceAllBook.Checked = false;
            gcCategory.DataSource = null;
            cbAllCategory.Enabled = true;
            txtBookName.Text = null;
        }

        /// <summary>
        /// Kategori' ye göre ara.
        /// </summary>
        private void SearchBooksByCategoryName()
        {
            var books = _bookService.SearchByCategoryName(cbSearchBookByCategory.SelectedItem.ToString());
            if (books.ResultStatus == ResultStatus.Success) FillGridBook(books.Data.Books);
            else FillGridBook();
        }

        /// <summary>
        /// İsme göre ara.
        /// </summary>
        private void SearchBooksByBookName()
        {
            var searchText = txtBookName.Text;
            if (IsNullOrEmpty(searchText)) { FillGridBook(); return; }

            var books = _bookService.SearchByName(searchText);
            if (books.ResultStatus == ResultStatus.Success) FillGridBook(books.Data.Books);
            else FillGridBook();
        }

        #endregion Methods

        #region Buttons

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HardDelete();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearItems();
        }

        #endregion Buttons

        #region LinkLabel

        private void lnkExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog {Filter = @"Excel Documents (*.xls)|*.xls", FileName = "BooksNonCategory.xls"};
            if (sfd.ShowDialog() == DialogResult.OK) gcBook.ExportToXls(sfd.FileName);
        }

        #endregion LinkLabel

        #region Events

        private void cbSearchBookByCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchBookByCategory.SelectedIndex != -1)
                SearchBooksByCategoryName();
            else FillGridBook();
        }
        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            SearchBooksByBookName();
        }
        private void ceAllBook_CheckedChanged(object sender, EventArgs e)
        {
            if (ceAllBook.Checked) GetAllBookByNonCategory();
            else FillGridBook();
        }

        #endregion Events

        #region GridControl

        private void gvBook_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            FillGridCategory();
        }
        private void gvCategory_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GetDeleting();
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