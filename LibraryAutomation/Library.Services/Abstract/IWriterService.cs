using Library.Core.Result.Abstract;
using Library.Entities.Entities.Dtos.WriterDto;

namespace Library.Services.Abstract
{
    public interface IWriterService
    {
        IAppResult Delete(int id);
        IAppResult HardDelete(int id);
        IAppResult UndoDelete(int id);
        IAppResult Add(WriterAddDto entity);
        IAppResult<WriterGetDto> Get(int id);
        IAppResult<WriterListDto> GetAllDeleted();
        IAppResult Update(WriterUpdateDto entity);
        IAppResult<WriterGetDto> GetDeleted(int id);
        IAppResult<WriterListDto> GetAllNonDeleted();
        IAppResult<WriterListDto> FindWritersByText(string text);
        IAppResult<WriterListDto> FindDeletedWritersByText(string text);
    }
}