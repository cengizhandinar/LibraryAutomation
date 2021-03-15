using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Library.App.Popup;
using Library.Core.Enum;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.UserBookDto;
using Library.Services.Abstract;
using Library.Services.Utilities;
using static System.String;

namespace Library.App.AdminPanel
{
    public partial class UserBookOperations : Form
    {
        #region Field

        private readonly IUserBookService _userBookService;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        private int _userId = -1;
        private int _bookId = -1;
        private int _userBookId = -1;

        #endregion Field

        #region Constructor

        public UserBookOperations(IUserBookService userBookService, IUserService userService, IBookService bookService)
        {
            _userBookService = userBookService;
            _userService = userService;
            _bookService = bookService;
            InitializeComponent();
        }

        #endregion Constructor

        #region FormLoad

        private void UserBookOperations_Load(object sender, EventArgs e)
        {
            FillGridBook();
            FillGridUser();
        }

        #endregion FormLoad

        #region Methods

        private void FillGridBook(IList<Book> list = null)
        {
            if (list == null) list = GetAllBookInStock();
            var newList = from item in list
                          select new
                          {
                              item.Id,
                              item.Stock,
                              Kitap_Ad = item.Name,
                              Yazar = item.Writer.Name,
                              Yayınevi = item.Publisher.Name,
                              Sayfa = item.NumberOfPages
                          };
            gcBook.DataSource = newList.OrderBy(u => u.Kitap_Ad);

            void BookColumnVisible()
            {
                gvBook.Columns[0].Visible = false;
                gvBook.Columns[1].Visible = false;
            }
            BookColumnVisible();

            lblBookMessage.Text = $"{list.Count} adet kitap listeleniyor.      ";
        }
        private void FillGridUser(IList<User> list = null)
        {
            if (list == null) list = GetAllUserNonDeleted();
            var newList = from item in list
                          select new
                          {
                              item.Id,
                              item.AccessStatus,
                              Ad_Soyad = item.FirstName + " " + item.LastName,
                              Telefon = item.PhoneNumber,
                              EMail = item.Email,
                              DefinedNumberOfBooks = _userBookService.DefinedNumberOfBooksForUser(item.Id)
                          };
            gcUser.DataSource = newList.OrderBy(u => u.Ad_Soyad);

            void UserColumnVisible()
            {
                gvUser.Columns[0].Visible = false;
                gvUser.Columns[1].Visible = false;
                gvUser.Columns[5].Visible = false;
            }
            UserColumnVisible();

            lblUserMessage.Text = $"{list.Count} adet kullanıcı listeleniyor.      ";
        }

        private IList<User> GetAllUserNonDeleted()
        {
            var users = _userService.GetAllNonDeleted();
            switch (users.ResultStatus)
            {
                case ResultStatus.Success:
                    return users.Data.Users;
                case ResultStatus.Warning:
                    Alert.Show(users.Message, ResultStatus.Warning);
                    return null;
                default:
                    Alert.Show(users.Message, ResultStatus.Error);
                    return null;
            }
        }
        private IList<Book> GetAllBookInStock()
        {
            var books = _bookService.GetAllInStock();
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

        private void FillGridProcessForUser(int userId = -1)
        {
            if (gvUser.SelectedRowsCount <= 0) return;
            if (userId == -1) int.TryParse(gvUser.GetRowCellValue(gvUser.FocusedRowHandle, "Id").ToString(), out _userId);
            else _userId = userId;

            var resultUser = _userBookService.GetAllReadAndReadingByUser(_userId);

            switch (resultUser.ResultStatus)
            {
                case ResultStatus.Success:
                    var newList = from item in resultUser.Data.UserBooks
                                  select new
                                  {
                                      item.Id,
                                      Okuduğu_Kitap = item.Book.Name,
                                      Alış_Tarihi = item.LendDate,
                                      Teslim_Tarihi = item.ReceiveDate,
                                  };
                    gvUserBook.Columns.Clear();
                    gcUserBook.DataSource = newList.OrderBy(c => c.Teslim_Tarihi);

                    void CategoryColumnVisible()
                    {
                        gvUserBook.Columns[0].Visible = false;
                    }
                    CategoryColumnVisible();

                    break;
                case ResultStatus.Warning:
                    Alert.Show(resultUser.Message, ResultStatus.Warning);
                    gcUserBook.DataSource = null;
                    break;
                default:
                    Alert.Show(resultUser.Message, ResultStatus.Error);
                    break;
            }
        }
        private void FillGridProcessForBook()
        {
            if (gvBook.SelectedRowsCount <= 0) return;
            int.TryParse(gvBook.GetRowCellValue(gvBook.FocusedRowHandle, "Id").ToString(), out _bookId);
            var resultBook = _userBookService.GetAllReadAndReadingByBook(_bookId);

            switch (resultBook.ResultStatus)
            {
                case ResultStatus.Success:
                    var newList = from item in resultBook.Data.UserBooks
                                  select new
                                  {
                                      item.Id,
                                      Okuyan_Kullanıcı = item.User.FirstName + " " + item.User.LastName,
                                      Alış_Tarihi = item.LendDate,
                                      Teslim_Tarihi = item.ReceiveDate,
                                  };
                    gvUserBook.Columns.Clear();
                    gcUserBook.DataSource = newList.OrderBy(c => c.Teslim_Tarihi);

                    void CategoryColumnVisible()
                    {
                        gvUserBook.Columns[0].Visible = false;
                    }
                    CategoryColumnVisible();

                    break;
                case ResultStatus.Warning:
                    Alert.Show(resultBook.Message, ResultStatus.Warning);
                    gcUserBook.DataSource = null;
                    break;
                default:
                    Alert.Show(resultBook.Message, ResultStatus.Error);
                    break;
            }
        }

        private void LendBook()
        {
            var getUser = _userService.Get(_userId);
            var getBook = _bookService.Get(_bookId);
            var numberOfBooks = _userBookService.DefinedNumberOfBooksForUser(_userId);
            if (numberOfBooks == 3)
            {
                Alert.Show(Messages.UserBook.LimitOfUser(getUser.Data.User.UserName), ResultStatus.Warning);
                return;
            }
            if (getUser.ResultStatus == ResultStatus.Success)
            {
                if (getBook.ResultStatus == ResultStatus.Success)
                {
                    var userBook = new UserBookAddDto
                    {
                        UserId = _userId,
                        BookId = _bookId,
                    };
                    if (XtraMessageBox.Show(
                        $"{getBook.Data.Book.Name} kitabı {getUser.Data.User.UserName} kullanıcısına ödünç verilecektir. Devam etmek istiyor musunuz?",
                        "Soru", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes) return;
                    var added = _userBookService.LendBook(userBook);
                    switch (added.ResultStatus)
                    {
                        case ResultStatus.Success:
                            Alert.Show(added.Message, ResultStatus.Success);
                            FillGridUser();
                            FillGridBook();
                            FillGridProcessForUser(_userId);
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
                else
                    Alert.Show(getBook.Message, ResultStatus.Warning);
            }
            else
                Alert.Show(getUser.Message, ResultStatus.Warning);
        }
        private void ReceiveBook()
        {
            var result = _userBookService.Get(_userBookId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                if (XtraMessageBox.Show(
                    $"{result.Data.UserBook.Book.Name} kitabı {result.Data.UserBook.User.UserName} kullanıcısından teslim alınacaktır. Devam etmek istiyor musunuz?",
                    "Soru", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
                var updated = _userBookService.ReceiveBook(_userBookId);
                switch (updated.ResultStatus)
                {
                    case ResultStatus.Success:
                        Alert.Show(updated.Message, ResultStatus.Success);
                        FillGridUser();
                        FillGridBook();
                        FillGridProcessForUser(result.Data.UserBook.UserId);
                        ClearItems();
                        break;
                    case ResultStatus.Warning:
                        Alert.Show(updated.Message, ResultStatus.Warning);
                        break;
                    default:
                        Alert.Show(updated.Message, ResultStatus.Error);
                        break;
                }
            }
            else
                Alert.Show(result.Message, ResultStatus.Warning);
        }
        private void HardDelete()
        {
            var userBook = _userBookService.HardDelete(_userBookId);
            if (userBook.ResultStatus == ResultStatus.Success)
            {
                Alert.Show(userBook.Message, ResultStatus.Success);
                FillGridUser();
                FillGridBook();
                FillGridProcessForUser();
                ClearItems();
            }
            else
                Alert.Show(userBook.Message, ResultStatus.Error);
        }
        private void ClearItems()
        {
            _userId = -1;
            _bookId = -1;
            _userBookId = -1;
        }

        private void SearchUser()
        {
            var searchText = txtSearchByUser.Text;
            if (IsNullOrEmpty(searchText)) { FillGridUser(); return; }

            var users = _userService.FindUsersByText(searchText);
            if (users.ResultStatus == ResultStatus.Success) FillGridUser(users.Data.Users);
            else FillGridUser();
        }
        private void SearchBook()
        {
            var searchText = txtSearchByBook.Text;
            if (IsNullOrEmpty(searchText)) { FillGridBook(); return; }

            var books = _bookService.SearchByName(searchText);
            if (books.ResultStatus == ResultStatus.Success) FillGridBook(books.Data.Books);
            else FillGridBook();
        }

        #endregion Methods

        #region Buttons

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (_userBookId == -1)
            {
                Alert.Show("Lütfen sağdaki listeden teslim işlemi için bir tanımlama seçiniz.", ResultStatus.Info);
                return;
            }
            ReceiveBook();
        }
        private void btnLend_Click(object sender, EventArgs e)
        {
            if (_bookId == -1 || _userId == -1)
            {
                Alert.Show("Lütfen kitabı ve tanımlanacak kullanıcıyı seçiniz.", ResultStatus.Info);
                return;
            }
            LendBook();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bookId == -1 || _userId == -1)
            {
                Alert.Show("Lütfen sağdaki listeden iptal işlemi için bir tanımlama seçiniz.", ResultStatus.Info);
                return;
            }
            HardDelete();
        }

        #endregion Buttons

        #region Events

        private void txtSearchByBook_TextChanged(object sender, EventArgs e)
        {
            SearchBook();
        }
        private void txtSearchByUser_TextChanged(object sender, EventArgs e)
        {
            SearchUser();
        }

        #endregion Events

        #region GridControl

        private void gvUser_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            FillGridProcessForUser();
        }
        private void gvBook_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            FillGridProcessForBook();
        }
        private void gvUserBook_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int.TryParse(gvUserBook.GetRowCellValue(gvUserBook.FocusedRowHandle, "Id").ToString(), out _userBookId);
        }

        #endregion GridControl
    }
}