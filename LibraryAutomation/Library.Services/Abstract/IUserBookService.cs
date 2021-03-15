using Library.Core.Result.Abstract;
using Library.Entities.Entities.Dtos.UserBookDto;

namespace Library.Services.Abstract
{
    public interface IUserBookService
    {
        IAppResult HardDelete(int id);
        IAppResult ReceiveBook(int userBookId);
        int DefinedNumberOfBooksForUser(int userId);
        IAppResult LendBook(UserBookAddDto entity);
        IAppResult AddReaded(UserBookAddDto entity);
        IAppResult AddWillRead(UserBookAddDto entity);
        IAppResult<UserBookGetDto> Get(int userBookId);
        IAppResult<UserBookListDto> GetAllReadByUser(int userId);
        IAppResult<UserBookListDto> GetAllReadingByUser(int userId);
        IAppResult<UserBookListDto> GetAllWillReadByUser(int userId);
        IAppResult<UserBookListDto> GetAllReadAndReadingByUser(int userId);
        IAppResult<UserBookListDto> GetAllReadAndReadingByBook(int bookId);
        IAppResult<UserBookListDto> SearchReadByText(string text, int userId);
        IAppResult<UserBookListDto> SearchWillReadByText(string text, int userId);
        IAppResult<UserBookListDto> SearchReadByWriterName(string text, int userId);
        IAppResult<UserBookListDto> SearchWillReadByWriterName(string text, int userId);
    }
}
