using System;
using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Core.Result.Concrete;
using Library.Data.Abstract;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.UserDto;
using Library.Services.Abstract;
using Library.Services.Utilities;

namespace Library.Services.Concrete
{
    /// <summary>
    /// Kullanıcı tablosu işlemleri için kullanılacak sınıf.
    /// </summary>
    public class UserManager : ManagerBase, IUserService
    {
        public UserManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IAppResult HardDelete(int id, bool isUser)
        {
            var entity = UnitOfWork.GetRepository<User>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            UnitOfWork.GetRepository<User>().Delete(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.User.HardDelete(entity.UserName, isUser));
        }
        public IAppResult<UserGetDto> Get(int id)
        {
            var entity = UnitOfWork.GetRepository<User>().Get(u => u.Id == id && u.GeneralStatus==GeneralStatus.Active);
            return entity != null
                ? new AppResult<UserGetDto>().Success(new UserGetDto { User = entity })
                : new AppResult<UserGetDto>().Warning(Messages.User.NotFound());
        }
        public IAppResult<UserListDto> GetAllDeleted()
        {
            var entities = UnitOfWork.GetRepository<User>().GetAll(u => u != null && u.GeneralStatus != GeneralStatus.Active);
            if (entities.Count <= -1)
            {
                return new AppResult<UserListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<UserListDto>().Warning(Messages.User.NotFoundDeleted())
                : new AppResult<UserListDto>().Success(new UserListDto { Users = entities });
        }
        public IAppResult<UserGetDto> GetDeleted(int id)
        {
            var entity = UnitOfWork.GetRepository<User>().Get(u => u.Id == id && u.GeneralStatus != GeneralStatus.Active);
            return entity != null
                ? new AppResult<UserGetDto>().Success(new UserGetDto { User = entity })
                : new AppResult<UserGetDto>().Warning(Messages.User.NotFound());
        }
        public IAppResult<UserListDto> GetAllNonDeleted()
        {
            var entities = UnitOfWork.GetRepository<User>().GetAll(u => u != null && u.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1)
            {
                return new AppResult<UserListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<UserListDto>().Warning(Messages.User.NotFoundActive())
                : new AppResult<UserListDto>().Success(new UserListDto { Users = entities });
        }
        public IAppResult<UserGetDto> GetByName(string name)
        {
            var entity = UnitOfWork.GetRepository<User>().Get(u => u != null && u.UserName == name);
            return entity != null
                ? new AppResult<UserGetDto>().Success(new UserGetDto { User = entity })
                : new AppResult<UserGetDto>().Warning(Messages.User.NotFound());
        }
        public IAppResult UndoDelete(int id, string updatedByName)
        {
            var entity = UnitOfWork.GetRepository<User>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedByName = updatedByName;
            entity.GeneralStatus = GeneralStatus.Active;
            UnitOfWork.GetRepository<User>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.User.UndoDelete(entity.UserName));
        }
        public IAppResult<UserListDto> FindUsersByText(string text)
        {
            var entities = UnitOfWork.GetRepository<User>().GetAll(
                u => (u.FirstName.Contains(text) || u.LastName.Contains(text) || u.UserName.Contains(text)) 
                     && u.GeneralStatus == GeneralStatus.Active);
            return entities.Count > -1
                ? new AppResult<UserListDto>().Success(new UserListDto { Users = entities })
                : new AppResult<UserListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
        public IAppResult Add(UserAddDto entity, string createdByName)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            if (UnitOfWork.GetRepository<User>().Any(u => u.UserName == entity.UserName))
                return new AppResult().Warning(Messages.User.IsThereUserName());
            if (UnitOfWork.GetRepository<User>().Any(u => u.Email == entity.Email))
                return new AppResult().Warning(Messages.User.IsThereEmail());
            var newEntity = Mapper.Map<User>(entity);
            newEntity.CreatedByName = createdByName;
            newEntity.UpdatedByName = createdByName;
            UnitOfWork.GetRepository<User>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.User.Add(newEntity.UserName));
        }
        public IAppResult Delete(int id, string updatedByName, bool isUser)
        {
            var entity = UnitOfWork.GetRepository<User>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedByName = updatedByName;
            entity.GeneralStatus = GeneralStatus.Deleted;
            UnitOfWork.GetRepository<User>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.User.Delete(entity.UserName, isUser));
        }
        public IAppResult<UserListDto> FindDeletedUsersByText(string text)
        {
            var entities = UnitOfWork.GetRepository<User>().GetAll(
                u => (u.FirstName.Contains(text) || u.LastName.Contains(text) || u.UserName.Contains(text)) 
                     && u.GeneralStatus != GeneralStatus.Active);
            return entities.Count > -1
                ? new AppResult<UserListDto>().Success(new UserListDto { Users = entities })
                : new AppResult<UserListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
        public IAppResult UpdateRole(UserGetDto entity, string updatedByName)
        {
            var oldEntity = UnitOfWork.GetRepository<User>().Find(entity.User.Id);
            if (oldEntity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var newEntity = Mapper.Map(entity, oldEntity);
            newEntity.UpdatedByName = updatedByName;
            UnitOfWork.GetRepository<User>().Update(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.User.RoleUpdate(newEntity.UserName));
        }
        public IAppResult<UserListDto> FindUsersByRole(AccessStatus accessStatus)
        {
            var entities = UnitOfWork.GetRepository<User>().GetAll(
                u => u.AccessStatus == accessStatus && u.GeneralStatus == GeneralStatus.Active);
            return entities.Count > -1
                ? new AppResult<UserListDto>().Success(new UserListDto { Users = entities })
                : new AppResult<UserListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
        public IAppResult Update(UserUpdateDto entity, string updatedByName, bool isUser)
        {
            var oldEntity = UnitOfWork.GetRepository<User>().Find(entity.Id);
            var isNewUsername = false;
            var isNewEmail = false;
            if (oldEntity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            if (oldEntity.UserName != entity.UserName) isNewUsername = true;
            if (oldEntity.Email != entity.Email) isNewEmail = true;
            if (isNewUsername && UnitOfWork.GetRepository<User>().Any(u => u.UserName == entity.UserName))
                return new AppResult().Warning(Messages.User.IsThereUserName());
            if (isNewEmail && UnitOfWork.GetRepository<User>().Any(u => u.Email == entity.Email))
                return new AppResult().Warning(Messages.User.IsThereEmail());
            var newEntity = Mapper.Map(entity, oldEntity);
            if (isUser)
            {
                newEntity.GeneralStatus = GeneralStatus.Active;
                newEntity.AccessStatus = AccessStatus.Member;
            }
            newEntity.UpdatedByName = updatedByName;
            UnitOfWork.GetRepository<User>().Update(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.User.Update(newEntity.UserName,isUser));
        }
    }
}