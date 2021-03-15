using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Entities.Entities.Dtos.UserDto;

namespace Library.Services.Abstract
{
    public interface IUserService
    {
        IAppResult<UserGetDto> Get(int id);
        IAppResult<UserListDto> GetAllDeleted();
        IAppResult HardDelete(int id, bool isUser);
        IAppResult<UserGetDto> GetDeleted(int id);
        IAppResult<UserListDto> GetAllNonDeleted();
        IAppResult<UserGetDto> GetByName(string name);
        IAppResult UndoDelete(int id, string updatedByName);
        IAppResult<UserListDto> FindUsersByText(string text);
        IAppResult Add(UserAddDto entity, string createdByName);
        IAppResult Delete(int id, string updatedByName, bool isUser);
        IAppResult<UserListDto> FindDeletedUsersByText(string text);
        IAppResult UpdateRole(UserGetDto entity, string updatedByName);
        IAppResult<UserListDto> FindUsersByRole(AccessStatus accessStatus);
        IAppResult Update(UserUpdateDto entity, string updatedByName, bool isUser);
    }
}