using Library.Core.Result.Abstract;
using Library.Entities.Entities.Dtos.BookDto;

namespace Library.Services.Abstract
{
    public interface IBookService
    {
        IAppResult HardDelete(int id);
        IAppResult<BookGetDto> Get(int id);
        IAppResult<BookListDto> GetAllInStock();
        IAppResult<BookListDto> GetAllDeleted();
        IAppResult<BookListDto> GetAllNonStock();
        IAppResult<BookGetDto> GetDeleted(int id);
        IAppResult<BookListDto> GetAllNonDeleted();
        IAppResult Delete(int id, string updatedByName);
        IAppResult UndoDelete(int id, string updatedByName);
        IAppResult Add(BookAddDto entity, string createdByName);
        IAppResult<BookListDto> SearchByName(string bookName);
        IAppResult<BookListDto> FindDeletedBooksByText(string text);
        IAppResult Update(BookUpdateDto entity, string updatedByName);
        IAppResult<BookListDto> SearchByWriterName(string writerName);
        IAppResult<BookListDto> SearchByCategoryName(string categoryName);
    }
}
