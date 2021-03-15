using Library.Core.Result.Abstract;
using Library.Entities.Entities.Dtos.BookCategoryDto;
using Library.Entities.Entities.Dtos.BookDto;

namespace Library.Services.Abstract
{
    public interface IBookCategoryService
    {
        IAppResult Add(BookCategoryAddDto entity);
        IAppResult HardDelete(int categoryId, int bookId);
        IAppResult HardDeleteByCategoryId(int categoryId);
        IAppResult<BookListDto> GetAllBookByNonCategory();
    }
}
