using Library.Core.Result.Abstract;
using Library.Entities.Entities.Dtos.ContactDto;

namespace Library.Services.Abstract
{
    public interface IContactService
    {
        IAppResult HardDelete(int id);
        IAppResult<ContactGetDto> Get(int id);
        IAppResult<ContactListDto> GetAllDeleted();
        IAppResult<ContactGetDto> GetDeleted(int id);
        IAppResult<ContactListDto> GetAllNonDeleted();
        IAppResult Delete(int id, string updatedByName);
        IAppResult UndoDelete(int id, string updatedByName);
        IAppResult Add(ContactAddDto entity, string createdByName);
        IAppResult<ContactListDto> FindContactsByUserName(string text);
        IAppResult<ContactListDto> FindDeletedContactsByUserName(string text);
    }
}
