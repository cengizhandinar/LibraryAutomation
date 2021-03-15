using System;
using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Core.Result.Concrete;
using Library.Data.Abstract;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.ContactDto;
using Library.Services.Abstract;
using Library.Services.Utilities;

namespace Library.Services.Concrete
{
    /// <summary>
    /// İletişim tablosu işlemleri için kullanılacak sınıf.
    /// </summary>
    public class ContactManager : ManagerBase, IContactService
    {
        public ContactManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IAppResult HardDelete(int id)
        {
            var entity = UnitOfWork.GetRepository<Contact>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var userName = entity.User.UserName;
            UnitOfWork.GetRepository<Contact>().Delete(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Contact.HardDelete(userName));
        }
        public IAppResult<ContactGetDto> Get(int id)
        {
            var entity = UnitOfWork.GetRepository<Contact>().Get(
                c => c != null && c.Id == id && c.GeneralStatus==GeneralStatus.Active, 
                c => c.User);
            return entity != null
                ? new AppResult<ContactGetDto>().Success(new ContactGetDto { Contact = entity })
                : new AppResult<ContactGetDto>().Warning(Messages.Contact.NotFound());
        }
        public IAppResult<ContactListDto> GetAllDeleted()
        {
            var entities = UnitOfWork.GetRepository<Contact>().GetAll(
                c => c != null && c.GeneralStatus == GeneralStatus.Deleted,
                c => c.User);
            if (entities.Count <= -1)
            {
                return new AppResult<ContactListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<ContactListDto>().Warning(Messages.Contact.NotFoundDeleted())
                : new AppResult<ContactListDto>().Success(new ContactListDto { Contacts = entities });
        }
        public IAppResult<ContactGetDto> GetDeleted(int id)
        {
            var entity = UnitOfWork.GetRepository<Contact>().Get(
                c => c != null && c.Id == id && c.GeneralStatus != GeneralStatus.Active,
                c => c.User);
            return entity != null
                ? new AppResult<ContactGetDto>().Success(new ContactGetDto { Contact = entity })
                : new AppResult<ContactGetDto>().Warning(Messages.Contact.NotFound());
        }
        public IAppResult<ContactListDto> GetAllNonDeleted()
        {
            var entities = UnitOfWork.GetRepository<Contact>().GetAll(
                c => c.GeneralStatus == GeneralStatus.Active,
                c => c.User);
            if (entities.Count <= -1)
            {
                return new AppResult<ContactListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<ContactListDto>().Warning(Messages.Contact.NotFoundActive())
                : new AppResult<ContactListDto>().Success(new ContactListDto { Contacts = entities });
        }
        public IAppResult Delete(int id, string updatedByName)
        {
            var entity = UnitOfWork.GetRepository<Contact>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedByName = updatedByName;
            entity.GeneralStatus = GeneralStatus.Deleted;
            UnitOfWork.GetRepository<Contact>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Contact.Delete(entity.User.UserName));
        }
        public IAppResult UndoDelete(int id, string updatedByName)
        {
            var entity = UnitOfWork.GetRepository<Contact>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedByName = updatedByName;
            entity.GeneralStatus = GeneralStatus.Active;
            UnitOfWork.GetRepository<Contact>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Contact.UndoDelete(entity.User.UserName));
        }
        public IAppResult Add(ContactAddDto entity, string createdByName)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var newEntity = Mapper.Map<Contact>(entity);
            newEntity.CreatedByName = createdByName;
            newEntity.UpdatedByName = createdByName;
            UnitOfWork.GetRepository<Contact>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Contact.Add(newEntity.User.UserName));
        }
        public IAppResult<ContactListDto> FindContactsByUserName(string text)
        {
            var entities = UnitOfWork.GetRepository<Contact>().GetAll(
                c => (c.User.FirstName.Contains(text) || c.User.LastName.Contains(text) || c.User.UserName.Contains(text)) &&
                     c.GeneralStatus == GeneralStatus.Active, 
                c => c.User);
            return entities.Count > -1
                ? new AppResult<ContactListDto>().Success(new ContactListDto { Contacts = entities })
                : new AppResult<ContactListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
        public IAppResult<ContactListDto> FindDeletedContactsByUserName(string text)
        {
            var entities = UnitOfWork.GetRepository<Contact>().GetAll(
                c => (c.User.FirstName.Contains(text) || c.User.LastName.Contains(text) || c.User.UserName.Contains(text)) &&
                     c.GeneralStatus != GeneralStatus.Active, 
                c => c.User);
            return entities.Count > -1
                ? new AppResult<ContactListDto>().Success(new ContactListDto { Contacts = entities })
                : new AppResult<ContactListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
    }
}