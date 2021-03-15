using System;
using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Core.Result.Concrete;
using Library.Data.Abstract;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.WriterDto;
using Library.Services.Abstract;
using Library.Services.Utilities;

namespace Library.Services.Concrete
{
    /// <summary>
    /// Yazar tablosu işlemleri için kullanılacak sınıf.
    /// </summary>
    public class WriterManager : ManagerBase, IWriterService
    {
        public WriterManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IAppResult Delete(int id)
        {
            var entity = UnitOfWork.GetRepository<Writer>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.GeneralStatus = GeneralStatus.Deleted;
            UnitOfWork.GetRepository<Writer>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Writer.Delete(entity.Name));
        }
        public IAppResult HardDelete(int id)
        {
            var entity = UnitOfWork.GetRepository<Writer>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var writerName = entity.Name;
            UnitOfWork.GetRepository<Writer>().Delete(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Writer.HardDelete(writerName));
        }
        public IAppResult UndoDelete(int id)
        {
            var entity = UnitOfWork.GetRepository<Writer>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.GeneralStatus = GeneralStatus.Active;
            UnitOfWork.GetRepository<Writer>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Writer.UndoDelete(entity.Name));
        }
        public IAppResult Add(WriterAddDto entity)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            if (UnitOfWork.GetRepository<Writer>().Any(w => w != null && w.Name == entity.Name))
                return new AppResult().Warning(Messages.Writer.IsThere(entity.Name));
            var newEntity = Mapper.Map<Writer>(entity);
            UnitOfWork.GetRepository<Writer>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Writer.Add(newEntity.Name));
        }
        public IAppResult<WriterGetDto> Get(int id)
        {
            var entity = UnitOfWork.GetRepository<Writer>()
                .Get(w => w != null && w.Id == id && w.GeneralStatus == GeneralStatus.Active);
            return entity != null
                ? new AppResult<WriterGetDto>().Success(new WriterGetDto { Writer = entity })
                : new AppResult<WriterGetDto>().Warning(Messages.Writer.NotFound());
        }
        public IAppResult<WriterListDto> GetAllDeleted()
        {
            var entities = UnitOfWork.GetRepository<Writer>().GetAll(w => w.GeneralStatus != GeneralStatus.Active);
            if (entities.Count <= -1)
            {
                return new AppResult<WriterListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<WriterListDto>().Warning(Messages.Writer.NotFoundDeleted())
                : new AppResult<WriterListDto>().Success(new WriterListDto { Writers = entities });
        }
        public IAppResult Update(WriterUpdateDto entity)
        {
            var oldEntity = UnitOfWork.GetRepository<Writer>().Find(entity.Id);
            if (oldEntity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var newEntity = Mapper.Map(entity, oldEntity);
            UnitOfWork.GetRepository<Writer>().Update(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Writer.Update(newEntity.Name));
        }
        public IAppResult<WriterGetDto> GetDeleted(int id)
        {
            var entity = UnitOfWork.GetRepository<Writer>()
                .Get(w => w != null && w.Id == id && w.GeneralStatus != GeneralStatus.Active);
            return entity != null
                ? new AppResult<WriterGetDto>().Success(new WriterGetDto { Writer = entity })
                : new AppResult<WriterGetDto>().Warning(Messages.Writer.NotFound());
        }
        public IAppResult<WriterListDto> GetAllNonDeleted()
        {
            var entities = UnitOfWork.GetRepository<Writer>().GetAll(w => w.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1)
            {
                return new AppResult<WriterListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<WriterListDto>().Warning(Messages.Writer.NotFoundActive())
                : new AppResult<WriterListDto>().Success(new WriterListDto { Writers = entities });
        }
        public IAppResult<WriterListDto> FindWritersByText(string text)
        {
            var entities = UnitOfWork.GetRepository<Writer>().GetAll(
                w => w.Name.Contains(text) && w.GeneralStatus == GeneralStatus.Active);
            return entities.Count > -1
                ? new AppResult<WriterListDto>().Success(new WriterListDto { Writers = entities })
                : new AppResult<WriterListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
        public IAppResult<WriterListDto> FindDeletedWritersByText(string text)
        {
            var entities = UnitOfWork.GetRepository<Writer>().GetAll(
                w => w.Name.Contains(text) && w.GeneralStatus != GeneralStatus.Active);
            return entities.Count > -1
                ? new AppResult<WriterListDto>().Success(new WriterListDto { Writers = entities })
                : new AppResult<WriterListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
    }
}