using Library.Core.Result.Abstract;
using Library.Entities.Entities.Dtos.PublisherDto;

namespace Library.Services.Abstract
{
    public interface IPublisherService
    {
        IAppResult Delete(int id);
        IAppResult HardDelete(int id);
        IAppResult UndoDelete(int id);
        IAppResult Add(PublisherAddDto entity);
        IAppResult<PublisherGetDto> Get(int id);
        IAppResult<PublisherListDto> GetAllDeleted();
        IAppResult Update(PublisherUpdateDto entity);
        IAppResult<PublisherGetDto> GetDeleted(int id);
        IAppResult<PublisherListDto> GetAllNonDeleted();
        IAppResult<PublisherListDto> FindPublishersByText(string text);
        IAppResult<PublisherListDto> FindDeletedPublishersByText(string text);
    }
}
