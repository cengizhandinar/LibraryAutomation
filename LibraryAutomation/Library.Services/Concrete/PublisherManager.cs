using System;
using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Core.Result.Concrete;
using Library.Data.Abstract;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.PublisherDto;
using Library.Services.Abstract;
using Library.Services.Utilities;

namespace Library.Services.Concrete
{
    /// <summary>
    /// Yayınevi tablosu işlemleri için kullanılacak sınıf.
    /// </summary>
    public class PublisherManager : ManagerBase, IPublisherService
    {
        public PublisherManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IAppResult Delete(int id)
        {
            var entity = UnitOfWork.GetRepository<Publisher>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.GeneralStatus = GeneralStatus.Deleted;
            UnitOfWork.GetRepository<Publisher>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Publisher.Delete(entity.Name));
        }
        public IAppResult HardDelete(int id)
        {
            var entity = UnitOfWork.GetRepository<Publisher>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var publisherName = entity.Name;
            UnitOfWork.GetRepository<Publisher>().Delete(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Publisher.HardDelete(publisherName));
        }
        public IAppResult UndoDelete(int id)
        {
            var entity = UnitOfWork.GetRepository<Publisher>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.GeneralStatus = GeneralStatus.Active;
            UnitOfWork.GetRepository<Publisher>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Publisher.UndoDelete(entity.Name));
        }
        public IAppResult Add(PublisherAddDto entity)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            if (UnitOfWork.GetRepository<Publisher>().Any(u => u.Name == entity.Name))
                return new AppResult().Warning(Messages.Publisher.IsThere(entity.Name));
            var newEntity = Mapper.Map<Publisher>(entity);
            UnitOfWork.GetRepository<Publisher>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Publisher.Add(newEntity.Name));
        }
        public IAppResult<PublisherGetDto> Get(int id)
        {
            var entity = UnitOfWork.GetRepository<Publisher>()
                .Get(u => u.Id == id && u.GeneralStatus == GeneralStatus.Active);
            return entity != null
                ? new AppResult<PublisherGetDto>().Success(new PublisherGetDto { Publisher = entity })
                : new AppResult<PublisherGetDto>().Warning(Messages.Publisher.NotFound());
        }
        public IAppResult<PublisherListDto> GetAllDeleted()
        {
            var entities = UnitOfWork.GetRepository<Publisher>().GetAll(u => u.GeneralStatus != GeneralStatus.Active);
            if (entities.Count <= -1)
            {
                return new AppResult<PublisherListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<PublisherListDto>().Warning(Messages.Publisher.NotFoundDeleted())
                : new AppResult<PublisherListDto>().Success(new PublisherListDto { Publishers = entities });
        }
        public IAppResult Update(PublisherUpdateDto entity)
        {
            var oldEntity = UnitOfWork.GetRepository<Publisher>().Find(entity.Id);
            if (oldEntity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var newEntity = Mapper.Map(entity, oldEntity);
            UnitOfWork.GetRepository<Publisher>().Update(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Publisher.Update(newEntity.Name));
        }
        public IAppResult<PublisherGetDto> GetDeleted(int id)
        {
            var entity = UnitOfWork.GetRepository<Publisher>()
                .Get(u => u.Id == id && u.GeneralStatus != GeneralStatus.Active);
            return entity != null
                ? new AppResult<PublisherGetDto>().Success(new PublisherGetDto { Publisher = entity })
                : new AppResult<PublisherGetDto>().Warning(Messages.Publisher.NotFound());
        }
        public IAppResult<PublisherListDto> GetAllNonDeleted()
        {
            var entities = UnitOfWork.GetRepository<Publisher>().GetAll(u => u.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1)
            {
                return new AppResult<PublisherListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<PublisherListDto>().Warning(Messages.Publisher.NotFoundActive())
                : new AppResult<PublisherListDto>().Success(new PublisherListDto { Publishers = entities });
        }
        public IAppResult<PublisherListDto> FindPublishersByText(string text)
        {
            var entities = UnitOfWork.GetRepository<Publisher>().GetAll(
                u => u.Name.Contains(text) && u.GeneralStatus==GeneralStatus.Active);
            return entities.Count > -1 
                ? new AppResult<PublisherListDto>().Success(new PublisherListDto { Publishers = entities })
                : new AppResult<PublisherListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
        public IAppResult<PublisherListDto> FindDeletedPublishersByText(string text)
        {
            var entities = UnitOfWork.GetRepository<Publisher>().GetAll(
                u => u.Name.Contains(text) && u.GeneralStatus != GeneralStatus.Active);
            return entities.Count > -1
                ? new AppResult<PublisherListDto>().Success(new PublisherListDto { Publishers = entities })
                : new AppResult<PublisherListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
    }
}