using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Library.App.Popup;
using Library.Core.Enum;
using Library.Entities.Entities.Concrete;
using Library.Services.Abstract;
using static System.String;

namespace Library.App.AdminPanel
{
    public partial class ControlCenter : Form
    {
        #region Fields

        private int _generalId = -1;
        private bool _isUser;
        private bool _isBook;
        private bool _isWriter;
        private bool _isContact;
        private bool _isCategory;
        private bool _isPublisher;
        private bool _isComment;
        private string _userName;
        private string _bookName;
        private string _writerName;
        private string _contactName;
        private string _categoryName;
        private string _commentName;
        private string _publisherName;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IWriterService _writerService;
        private readonly IContactService _contactService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IPublisherService _publisherService;

        #endregion Fields

        #region Constructor

        public ControlCenter(IUserService userService, IBookService bookService, ICategoryService categoryService, IContactService contactService, ICommentService commentService, IWriterService writerService, IPublisherService publisherService)
        {
            _userService = userService;
            _bookService = bookService;
            _categoryService = categoryService;
            _contactService = contactService;
            _commentService = commentService;
            _writerService = writerService;
            _publisherService = publisherService;
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Tüm silinen kitapların listesini getir.
        /// </summary>
        private void GetAllDeletedBooks(IList<Book> listDeleted = null)
        {
            var books = _bookService.GetAllDeleted();
            switch (books.ResultStatus)
            {
                case ResultStatus.Success:
                    panel5.Visible = true;
                    gcDeleted.DataSource = null;
                    gvDeleted.Columns.Clear();
                    gcDeleted.DataSource = listDeleted == null
                        ? books.Data.Books.OrderBy(c => c.UpdatedDate)
                        : listDeleted.OrderBy(c => c.UpdatedDate);

                    void BookColumnVisible()
                    {
                        gvDeleted.Columns[1].Visible = false;
                        gvDeleted.Columns[2].Visible = false;
                        gvDeleted.Columns[5].Visible = false;
                        gvDeleted.Columns[7].Visible = false;
                        gvDeleted.Columns[8].Visible = false;
                        gvDeleted.Columns[9].Visible = false;
                        gvDeleted.Columns[10].Visible = false;
                        gvDeleted.Columns[11].Visible = false;
                        gvDeleted.Columns[12].Visible = false;
                        gvDeleted.Columns[13].Visible = false;
                        gvDeleted.Columns[14].Visible = false;
                        gvDeleted.Columns[15].Visible = false;
                        gvDeleted.Columns[16].Visible = false;
                        gvDeleted.Columns[17].Visible = false;
                        gvDeleted.Columns[18].Visible = false;
                        gvDeleted.Columns[19].Visible = false;
                        gvDeleted.Columns[20].Visible = false;
                        gvDeleted.Columns[22].Visible = false;
                        gvDeleted.Columns[24].Visible = false;
                    }
                    BookColumnVisible();

                    lblMessage.Text = $@"{books.Data.Books.Count} adet arşivlenen kitap listeleniyor.    ";
                    break;
                case ResultStatus.Warning:
                    Alert.Show(books.Message, ResultStatus.Warning);
                    panel5.Visible = false;
                    return;
                default:
                    Alert.Show(books.Message, ResultStatus.Error);
                    panel5.Visible = false;
                    return;
            }
        }
        /// <summary>
        /// Tüm silinen kullanıcıların listesini getir.
        /// </summary>
        private void GetAllDeletedUsers(IList<User> listDeleted = null)
        {
            var users = _userService.GetAllDeleted();
            switch (users.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        panel5.Visible = true;
                        gcDeleted.DataSource = null;
                        gvDeleted.Columns.Clear();
                        gcDeleted.DataSource = listDeleted == null
                            ? users.Data.Users.OrderBy(c => c.UpdatedDate)
                            : listDeleted.OrderBy(c => c.UpdatedDate);

                        void UserColumnVisible()
                        {
                            gvDeleted.Columns[2].Visible = false;
                            gvDeleted.Columns[3].Visible = false;
                            gvDeleted.Columns[4].Visible = false;
                            gvDeleted.Columns[7].Visible = false;
                            gvDeleted.Columns[8].Visible = false;
                            gvDeleted.Columns[10].Visible = false;
                            gvDeleted.Columns[11].Visible = false;
                            gvDeleted.Columns[12].Visible = false;
                            gvDeleted.Columns[13].Visible = false;
                            gvDeleted.Columns[14].Visible = false;
                            gvDeleted.Columns[15].Visible = false;
                            gvDeleted.Columns[16].Visible = false;
                            gvDeleted.Columns[18].Visible = false;
                            gvDeleted.Columns[20].Visible = false;
                        }
                        UserColumnVisible();

                        lblMessage.Text = $@"{users.Data.Users.Count} adet arşivlenen kullanıcı listeleniyor.    ";
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(users.Message, ResultStatus.Warning);
                    panel5.Visible = false;
                    return;
                default:
                    Alert.Show(users.Message, ResultStatus.Error);
                    panel5.Visible = false;
                    return;
            }
        }
        /// <summary>
        /// Tüm silinen kategorilerin listesini getir.
        /// </summary>
        private void GetAllDeletedCategories(IList<Category> listDeleted = null)
        {
            var categories = _categoryService.GetAllDeleted();
            switch (categories.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        var result = listDeleted ?? categories.Data.Categories;
                        panel5.Visible = true;
                        gcDeleted.DataSource = null;
                        gvDeleted.Columns.Clear();
                        var newList = from item in result
                                      select new
                                      {
                                          item.Id,
                                          item.ParentId,
                                          Kategori_Adı = item.Name,
                                          Alt_Kategori_Adı = item.ParentId != 0 ? _categoryService.GetByParent(item.ParentId).Data.Category.Name : Empty
                                      };
                        gcDeleted.DataSource = newList.OrderBy(c => c.Alt_Kategori_Adı);

                        void CategoryColumnVisible()
                        {
                            gvDeleted.Columns["Id"].Visible = false;
                            gvDeleted.Columns["ParentId"].Visible = false;
                        }
                        CategoryColumnVisible();

                        lblMessage.Text = $@"{categories.Data.Categories.Count} adet arşivlenen kategori listeleniyor.    ";
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(categories.Message, ResultStatus.Warning);
                    panel5.Visible = false;
                    return;
                default:
                    Alert.Show(categories.Message, ResultStatus.Error);
                    panel5.Visible = false;
                    return;
            }
        }
        /// <summary>
        /// Tüm silinen yazarların listesini getir.
        /// </summary>
        private void GetAllDeletedWriters(IList<Writer> listDeleted = null)
        {
            var writers = _writerService.GetAllDeleted();
            switch (writers.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        panel5.Visible = true;
                        gcDeleted.DataSource = null;
                        gvDeleted.Columns.Clear();
                        gcDeleted.DataSource = listDeleted == null
                            ? writers.Data.Writers.OrderBy(c => c.Name)
                            : listDeleted.OrderBy(c => c.Name);

                        void WriterColumnVisible()
                        {
                            gvDeleted.Columns[0].Visible = false;
                            gvDeleted.Columns[2].Visible = false;
                            gvDeleted.Columns[3].Visible = false;
                            gvDeleted.Columns[5].Visible = false;
                            gvDeleted.Columns[6].Visible = false;
                            gvDeleted.Columns[7].Visible = false;
                        }
                        WriterColumnVisible();

                        lblMessage.Text = $@"{writers.Data.Writers.Count} adet arşivlenen yazar listeleniyor.    ";
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(writers.Message, ResultStatus.Warning);
                    panel5.Visible = false;
                    return;
                default:
                    Alert.Show(writers.Message, ResultStatus.Error);
                    panel5.Visible = false;
                    return;
            }
        }
        /// <summary>
        /// Tüm silinen yayınevlerinin listesini getir.
        /// </summary>
        private void GetAllDeletedPublishers(IList<Publisher> listDeleted = null)
        {
            var publishers = _publisherService.GetAllDeleted();
            switch (publishers.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        panel5.Visible = true;
                        gcDeleted.DataSource = null;
                        gvDeleted.Columns.Clear();
                        gcDeleted.DataSource = listDeleted == null
                            ? publishers.Data.Publishers.OrderBy(c => c.Name)
                            : listDeleted.OrderBy(c => c.Name);

                        void PublisherColumnVisible()
                        {
                            gvDeleted.Columns[0].Visible = false;
                            gvDeleted.Columns[3].Visible = false;
                            gvDeleted.Columns[4].Visible = false;
                        }
                        PublisherColumnVisible();

                        lblMessage.Text = $@"{publishers.Data.Publishers.Count} adet arşivlenen yayınevi listeleniyor.    ";
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(publishers.Message, ResultStatus.Warning);
                    panel5.Visible = false;
                    return;
                default:
                    Alert.Show(publishers.Message, ResultStatus.Error);
                    panel5.Visible = false;
                    return;
            }
        }
        /// <summary>
        /// Tüm silinen yorumların listesini getir.
        /// </summary>
        private void GetAllDeletedComments(IList<Comment> listDeleted = null)
        {
            var comments = _commentService.GetAllDeleted();
            switch (comments.ResultStatus)
            {
                case ResultStatus.Success:
                {
                    var result = listDeleted ?? comments.Data.Comments;
                        panel5.Visible = true;
                        gcDeleted.DataSource = null;
                        gvDeleted.Columns.Clear();
                        var newList = from item in result
                                      select new
                                      {
                                          item.Id,
                                          item.GeneralStatus,
                                          Yorum_Sahibi = item.User.FirstName + " " + item.User.LastName,
                                          Yorum_Yapılan_Kitap = item.Book.Name,
                                          Yorum_Tarihi = item.CreatedDate,
                                      };
                        gcDeleted.DataSource = newList.OrderBy(c => c.Yorum_Tarihi);

                        gvDeleted.Columns[0].Visible = false;

                        lblMessage.Text = $@"{comments.Data.Comments.Count} adet arşivlenen yorum listeleniyor.    ";
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(comments.Message, ResultStatus.Warning);
                    panel5.Visible = false;
                    return;
                default:
                    Alert.Show(comments.Message, ResultStatus.Error);
                    panel5.Visible = false;
                    return;
            }
        }
        /// <summary>
        /// Tüm silinen mesajların listesini getir.
        /// </summary>
        private void GetAllDeletedContacts(IList<Contact> listDeleted = null)
        {
            var contacts = _contactService.GetAllDeleted();
            switch (contacts.ResultStatus)
            {
                case ResultStatus.Success:
                    {
                        var result = listDeleted ?? contacts.Data.Contacts;
                        panel5.Visible = true;
                        gcDeleted.DataSource = null;
                        gvDeleted.Columns.Clear();
                        var newList = from item in result
                                      select new
                                      {
                                          item.Id,
                                          item.GeneralStatus,
                                          Mesaj_Sahibi = item.User.FirstName + " " + item.User.LastName,
                                          Mesaj_Tarihi = item.CreatedDate
                                      };
                        gcDeleted.DataSource = newList.OrderBy(c => c.Mesaj_Tarihi);

                        void ContactColumnVisible()
                        {
                            gvDeleted.Columns[0].Visible = false;
                            gvDeleted.Columns[1].Visible = false;
                        }
                        ContactColumnVisible();

                        lblMessage.Text = $@"{contacts.Data.Contacts.Count} adet arşivlenen mesaj listeleniyor.    ";
                        break;
                    }
                case ResultStatus.Warning:
                    Alert.Show(contacts.Message, ResultStatus.Warning);
                    panel5.Visible = false;
                    return;
                default:
                    Alert.Show(contacts.Message, ResultStatus.Error);
                    panel5.Visible = false;
                    return;
            }
        }

        private void GetObjectName()
        {
            if (gvDeleted.SelectedRowsCount <= 0) return;
            int.TryParse(gvDeleted.GetRowCellValue(gvDeleted.FocusedRowHandle, "Id").ToString(), out _generalId);
            if (_isUser) _userName = _userService.GetDeleted(_generalId).Data.User.UserName;
            if (_isBook) _bookName = _bookService.GetDeleted(_generalId).Data.Book.Name;
            if (_isCategory) _categoryName = _categoryService.GetDeleted(_generalId).Data.Category.Name;
            if (_isWriter) _writerName = _writerService.GetDeleted(_generalId).Data.Writer.Name;
            if (_isPublisher) _publisherName = _publisherService.GetDeleted(_generalId).Data.Publisher.Name;
            if (_isComment) _commentName = _commentService.Get(_generalId).Data.Comment.User.UserName;
            if (_isContact) _contactName = _contactService.GetDeleted(_generalId).Data.Contact.User.UserName;
        }

        private void Search()
        {
            var searchText = txtSearch.Text;
            if (_isUser)
            {
                if (IsNullOrEmpty(searchText)) GetAllDeletedUsers();
                var users = _userService.FindDeletedUsersByText(searchText);
                if (users.ResultStatus == ResultStatus.Success && users.Data.Users.Count>0) GetAllDeletedUsers(users.Data.Users);
                else GetAllDeletedUsers();
            }
            else if (_isBook)
            {
                if (IsNullOrEmpty(searchText)) GetAllDeletedBooks();
                var books = _bookService.FindDeletedBooksByText(searchText);
                if (books.ResultStatus == ResultStatus.Success && books.Data.Books.Count > 0) GetAllDeletedBooks(books.Data.Books);
                else GetAllDeletedBooks();
            }
            else if (_isCategory)
            {
                if (IsNullOrEmpty(searchText)) GetAllDeletedCategories();
                var categories = _categoryService.FindDeletedCategoriesByText(searchText);
                if (categories.ResultStatus == ResultStatus.Success && categories.Data.Categories.Count > 0) GetAllDeletedCategories(categories.Data.Categories);
                else GetAllDeletedCategories();
            }
            else if (_isContact)
            {
                if (IsNullOrEmpty(searchText)) GetAllDeletedContacts();
                var contacts = _contactService.FindDeletedContactsByUserName(searchText);
                if (contacts.ResultStatus == ResultStatus.Success && contacts.Data.Contacts.Count > 0) GetAllDeletedContacts(contacts.Data.Contacts);
                else GetAllDeletedContacts();
            }
            else if (_isComment)
            {
                if (IsNullOrEmpty(searchText)) GetAllDeletedComments();
                var comments = _commentService.FindDeletedCommentsByText(searchText);
                if (comments.ResultStatus == ResultStatus.Success && comments.Data.Comments.Count > 0) GetAllDeletedComments(comments.Data.Comments);
                else GetAllDeletedComments();
            }
            else if (_isWriter)
            {
                if (IsNullOrEmpty(searchText)) GetAllDeletedWriters();
                var writers = _writerService.FindDeletedWritersByText(searchText);
                if (writers.ResultStatus == ResultStatus.Success && writers.Data.Writers.Count > 0) GetAllDeletedWriters(writers.Data.Writers);
                else GetAllDeletedWriters();
            }
            else if (_isPublisher)
            {
                if (IsNullOrEmpty(searchText)) GetAllDeletedPublishers();
                var publishers = _publisherService.FindDeletedPublishersByText(searchText);
                if (publishers.ResultStatus == ResultStatus.Success && publishers.Data.Publishers.Count > 0) GetAllDeletedPublishers(publishers.Data.Publishers);
                else GetAllDeletedPublishers();
            }
        }

        private void ClearItems()
        {
            _generalId = -1;
            _isBook = false;
            _isUser = false;
            _isCategory = false;
            _isComment = false;
            _isContact = false;
            _isPublisher = false;
            _isWriter = false;
            lblMessage.Text = Empty;
            btnComment.PaintStyle = PaintStyles.Light;
            btnPublishers.PaintStyle = PaintStyles.Light;
            btnWriters.PaintStyle = PaintStyles.Light;
            btnCategories.PaintStyle = PaintStyles.Light;
            btnBooks.PaintStyle = PaintStyles.Light;
            btnUsers.PaintStyle = PaintStyles.Light;
            btnContact.PaintStyle = PaintStyles.Light;
        }

        #endregion Methods

        #region Buttons

        private void btnComment_Click(object sender, EventArgs e)
        {
            ClearItems();
            btnComment.PaintStyle = PaintStyles.Default;
            _isComment = true;
            GetAllDeletedComments();
        }
        private void btnPublishers_Click(object sender, EventArgs e)
        {
            ClearItems();
            btnPublishers.PaintStyle = PaintStyles.Default;
            _isPublisher = true;
            GetAllDeletedPublishers();
        }
        private void btnWriters_Click(object sender, EventArgs e)
        {
            ClearItems();
            btnWriters.PaintStyle = PaintStyles.Default;
            _isWriter = true;
            GetAllDeletedWriters();
        }
        private void btnCategories_Click(object sender, EventArgs e)
        {
            ClearItems();
            btnCategories.PaintStyle = PaintStyles.Default;
            _isCategory = true;
            GetAllDeletedCategories();
        }
        private void btnBooks_Click(object sender, EventArgs e)
        {
            ClearItems();
            btnBooks.PaintStyle = PaintStyles.Default;
            _isBook = true;
            GetAllDeletedBooks();
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            ClearItems();
            btnUsers.PaintStyle = PaintStyles.Default;
            _isUser = true;
            GetAllDeletedUsers();
        }
        private void btnContact_Click(object sender, EventArgs e)
        {
            ClearItems();
            btnContact.PaintStyle = PaintStyles.Default;
            _isContact = true;
            GetAllDeletedContacts();
        }

        private void btnHardDelete_Click(object sender, EventArgs e)
        {
            if (_generalId > 0)
            {
                if (_isUser)
                {
                    if (XtraMessageBox.Show(
                        $"{_userName} adlı kullanıcı arşivden silinecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _userService.HardDelete(_generalId, false);
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isUser = true;
                    GetAllDeletedUsers();
                }
                else if (_isBook)
                {
                    if (XtraMessageBox.Show(
                        $"{_bookName} adlı kitap arşivden silinecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _bookService.HardDelete(_generalId);
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isBook = true;
                    GetAllDeletedBooks();
                }
                else if (_isCategory)
                {
                    if (XtraMessageBox.Show(
                        $"{_categoryName} adlı kategori arşivden silinecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _categoryService.HardDelete(_generalId);
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isCategory = true;
                    GetAllDeletedCategories();
                }
                else if (_isContact)
                {
                    if (XtraMessageBox.Show(
                        $"{_contactName} adlı kullanıcının mesajı arşivden silinecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _contactService.HardDelete(_generalId);
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isContact = true;
                    GetAllDeletedContacts();
                }
                else if (_isComment)
                {
                    if (XtraMessageBox.Show(
                        $"{_commentName} adlı kullanıcının yorumu arşivden silinecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _commentService.HardDelete(_generalId, false);
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isComment = true;
                    GetAllDeletedComments();
                }
                else if (_isWriter)
                {
                    if (XtraMessageBox.Show(
                        $"{_writerName} adlı yazar arşivden silinecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _writerService.HardDelete(_generalId);
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isWriter = true;
                    GetAllDeletedWriters();
                }
                else if (_isPublisher)
                {
                    if (XtraMessageBox.Show(
                        $"{_publisherName} adlı yayınevi arşivden silinecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _publisherService.HardDelete(_generalId);
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isPublisher = true;
                    GetAllDeletedPublishers();
                }
                else
                    Alert.Show("İşlem gerçekleşirken bir hata oluştu", ResultStatus.Warning);
            }
            else
                Alert.Show("Lütfen arşivden kaldırılacak öğeyi seçiniz.", ResultStatus.Info);
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (_generalId > 0)
            {
                if (_isUser)
                {
                    if (XtraMessageBox.Show(
                        $"{_userName} adlı kullanıcı arşivden geri getirilecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _userService.UndoDelete(_generalId, "Admin");
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isUser = true;
                    GetAllDeletedUsers();
                }
                else if (_isBook)
                {
                    if (XtraMessageBox.Show(
                        $"{_bookName} adlı kitap arşivden geri getirilecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _bookService.UndoDelete(_generalId, "Admin");
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isBook = true;
                    GetAllDeletedBooks();
                }
                else if (_isCategory)
                {
                    if (XtraMessageBox.Show(
                        $"{_categoryName} adlı kategori arşivden geri getirilecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _categoryService.UndoDelete(_generalId);
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isCategory = true;
                    GetAllDeletedCategories();
                }
                else if (_isContact)
                {
                    if (XtraMessageBox.Show(
                        $"{_contactName} adlı kullanıcının mesajı arşivden geri getirilecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _contactService.UndoDelete(_generalId, "Admin");
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isContact = true;
                    GetAllDeletedContacts();
                }
                else if (_isComment)
                {
                    if (XtraMessageBox.Show(
                        $"{_commentName} adlı kullanıcının yorumu arşivden geri getirilecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _commentService.UndoDelete(_generalId, "Admin");
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isComment = true;
                    GetAllDeletedComments();
                }
                else if (_isWriter)
                {
                    if (XtraMessageBox.Show(
                        $"{_writerName} adlı yazar arşivden geri getirilecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _writerService.UndoDelete(_generalId);
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isWriter = true;
                    GetAllDeletedWriters();
                }
                else if (_isPublisher)
                {
                    if (XtraMessageBox.Show(
                        $"{_publisherName} adlı yayınevi arşivden geri getirilecektir. Emin misiniz?",
                        "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var result = _publisherService.UndoDelete(_generalId);
                    if (result.ResultStatus != ResultStatus.Success)
                    {
                        Alert.Show(result.Message, ResultStatus.Error);
                        return;
                    }
                    Alert.Show(result.Message, ResultStatus.Success);
                    ClearItems();
                    _isPublisher = true;
                    GetAllDeletedPublishers();
                }
                else
                    Alert.Show("İşlem gerçekleşirken bir hata oluştu", ResultStatus.Warning);
            }
            else
                Alert.Show("Lütfen arşivden geri getireceğiniz öğeyi seçiniz.", ResultStatus.Info);
        }

        #endregion Buttons

        #region Events

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        #endregion Events

        #region GridControl

        private void gvDeleted_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GetObjectName();
        }

        #endregion GridControl

        #region Timer

        private void timer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd.MMMM.yyyy HH:mm:ss");
        }

        #endregion Timer

        #region LinkLabel

        private void lnkExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = @"Excel Documents (*.xls)|*.xls", FileName = "deleted.xls" };
            if (sfd.ShowDialog() == DialogResult.OK) gcDeleted.ExportToXls(sfd.FileName);
        }

        #endregion LinkLabel
    }
}