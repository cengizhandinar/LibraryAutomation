using Library.Core.Result.Abstract;
using Library.Entities.Entities.Dtos.FavoriteBookDto;

namespace Library.Services.Abstract
{
    public interface IFavoriteBookService
    {
        IAppResult Add(FavoriteBookAddDto entity);
        IAppResult HardDelete(FavoriteBookGetDto entity);
        IAppResult<FavoriteBookListDto> GetAll(int userId);
        IAppResult<FavoriteBookGetDto> Get(int bookId, int userId);
        IAppResult<FavoriteBookListDto> SearchByFavoriteByText(string text, int userId);
        IAppResult<FavoriteBookListDto> SearchByFavoriteByWriterName(string text, int userId);
    }
}
