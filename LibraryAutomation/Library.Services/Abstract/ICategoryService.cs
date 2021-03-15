using Library.Core.Result.Abstract;
using Library.Entities.Entities.Dtos.CategoryDto;

namespace Library.Services.Abstract
{
    public interface ICategoryService
    {
        IAppResult Delete(int id);
        IAppResult HardDelete(int id);
        IAppResult UndoDelete(int id);
        IAppResult Add(CategoryAddDto entity);
        IAppResult<CategoryGetDto> Get(int id);
        IAppResult<CategoryListDto> GetAllDeleted();
        IAppResult Update(CategoryUpdateDto entity);
        IAppResult<CategoryGetDto> GetDeleted(int id);
        IAppResult<CategoryListDto> GetParents(int id);
        IAppResult<CategoryListDto> GetAllNonDeleted();
        IAppResult<CategoryGetDto> GetByName(string name);
        IAppResult<CategoryGetDto> GetByParent(int parentId);
        IAppResult<CategoryListDto> GetAllByBookId(int bookId);
        IAppResult<CategoryListDto> FindCategoriesByText(string text);
        IAppResult<CategoryListDto> FindDeletedCategoriesByText(string text);
    }
}
