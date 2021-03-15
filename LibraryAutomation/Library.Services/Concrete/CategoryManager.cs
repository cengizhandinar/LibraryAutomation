using System;
using System.Collections.Generic;
using System.Linq;
using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Core.Result.Concrete;
using Library.Data.Abstract;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.CategoryDto;
using Library.Services.Abstract;
using Library.Services.Utilities;

namespace Library.Services.Concrete
{
    /// <summary>
    /// Kategori tablosu işlemleri için kullanılacak sınıf.
    /// </summary>
    public class CategoryManager : ManagerBase, ICategoryService
    {
        public CategoryManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IAppResult Delete(int id)
        {
            var entity = UnitOfWork.GetRepository<Category>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.GeneralStatus = GeneralStatus.Deleted;
            UnitOfWork.GetRepository<Category>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Category.Delete(entity.Name));
        }
        public IAppResult HardDelete(int id)
        {
            var entity = UnitOfWork.GetRepository<Category>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var categoryName = entity.Name;
            UnitOfWork.GetRepository<Category>().Delete(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Category.HardDelete(categoryName));
        }
        public IAppResult UndoDelete(int id)
        {
            var entity = UnitOfWork.GetRepository<Category>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.GeneralStatus = GeneralStatus.Active;
            UnitOfWork.GetRepository<Category>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Category.UndoDelete(entity.Name));
        }
        public IAppResult Add(CategoryAddDto entity)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            if (UnitOfWork.GetRepository<Category>().Any(c => c.Name == entity.Name))
                return new AppResult().Warning(Messages.Category.IsThere(entity.Name));
            var newEntity = Mapper.Map<Category>(entity);
            UnitOfWork.GetRepository<Category>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Category.Add(newEntity.Name));
        }
        public IAppResult<CategoryGetDto> Get(int id)
        {
            var entity = UnitOfWork.GetRepository<Category>().Get(
                c => c != null && c.Id == id && c.GeneralStatus==GeneralStatus.Active);
            return entity != null
                ? new AppResult<CategoryGetDto>().Success(new CategoryGetDto { Category = entity })
                : new AppResult<CategoryGetDto>().Warning(Messages.Category.NotFound());
        }
        public IAppResult<CategoryListDto> GetAllDeleted()
        {
            var entities = UnitOfWork.GetRepository<Category>().GetAll(
                c => c != null && c.GeneralStatus == GeneralStatus.Deleted);
            if (entities.Count <= -1)
            {
                return new AppResult<CategoryListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<CategoryListDto>().Warning(Messages.Category.NotFoundDeleted())
                : new AppResult<CategoryListDto>().Success(new CategoryListDto { Categories = entities });
        }
        public IAppResult Update(CategoryUpdateDto entity)
        {
            var oldEntity = UnitOfWork.GetRepository<Category>().Find(entity.Id);
            if (oldEntity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var newEntity = Mapper.Map(entity, oldEntity);
            UnitOfWork.GetRepository<Category>().Update(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Category.Update(newEntity.Name));
        }
        public IAppResult<CategoryGetDto> GetDeleted(int id)
        {
            var entity = UnitOfWork.GetRepository<Category>().Get(
                c => c != null && c.Id == id && c.GeneralStatus != GeneralStatus.Active);
            return entity != null
                ? new AppResult<CategoryGetDto>().Success(new CategoryGetDto { Category = entity })
                : new AppResult<CategoryGetDto>().Warning(Messages.Category.NotFound());
        }
        public IAppResult<CategoryListDto> GetParents(int id)
        {
            var entities = UnitOfWork.GetRepository<Category>().GetAll(c => c.ParentId == id && c.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1)
                return new AppResult<CategoryListDto>().Fail(new ArgumentOutOfRangeException().Message);
            
            return entities.Count == 0
                ? new AppResult<CategoryListDto>().Warning(Messages.Category.NotFoundParents())
                : new AppResult<CategoryListDto>().Success(new CategoryListDto { Categories = entities });
        }
        public IAppResult<CategoryListDto> GetAllNonDeleted()
        {
            var entities = UnitOfWork.GetRepository<Category>().GetAll(c => c != null && c.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1)
            {
                return new AppResult<CategoryListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<CategoryListDto>().Warning(Messages.Category.NotFoundActive())
                : new AppResult<CategoryListDto>().Success(new CategoryListDto { Categories = entities });
        }
        public IAppResult<CategoryGetDto> GetByName(string name)
        {
            var entity = UnitOfWork.GetRepository<Category>().Get(c => c.Name == name && c.GeneralStatus == GeneralStatus.Active);
            return entity != null
                ? new AppResult<CategoryGetDto>().Success(new CategoryGetDto { Category = entity })
                : new AppResult<CategoryGetDto>().Warning(Messages.Category.NotFound());
        }
        public IAppResult<CategoryGetDto> GetByParent(int parentId)
        {
            var entity = UnitOfWork.GetRepository<Category>().Get(c => c != null && c.Id == parentId);
            return entity != null
                ? new AppResult<CategoryGetDto>().Success(new CategoryGetDto { Category = entity })
                : new AppResult<CategoryGetDto>().Warning(Messages.Category.NotFound());
        }
        public IAppResult<CategoryListDto> GetAllByBookId(int bookId)
        {
            var entities = UnitOfWork.GetRepository<BookCategory>().GetAll(
                bc => bc.BookId == bookId,
                bc => bc.Book, bc => bc.Category);
            var categories = UnitOfWork.GetRepository<Category>().GetAll(
                c => c.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1 || categories.Count <= -1)
            {
                return new AppResult<CategoryListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            IList<Category> list = categories.Where(category => entities.Any(bc => bc.CategoryId == category.Id)).ToList();
            return list.Count == 0
                ? new AppResult<CategoryListDto>().Warning(Messages.Category.NotFound())
                : new AppResult<CategoryListDto>().Success(new CategoryListDto { Categories = list });
        }
        public IAppResult<CategoryListDto> FindCategoriesByText(string text)
        {
            var entities = UnitOfWork.GetRepository<Category>().GetAll(
                c => c.Name.Contains(text) && c.GeneralStatus == GeneralStatus.Active);
            return entities.Count > -1
                ? new AppResult<CategoryListDto>().Success(new CategoryListDto { Categories = entities })
                : new AppResult<CategoryListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
        public IAppResult<CategoryListDto> FindDeletedCategoriesByText(string text)
        {
            var entities = UnitOfWork.GetRepository<Category>().GetAll(
                c => c.Name.Contains(text) && c.GeneralStatus != GeneralStatus.Active);
            return entities.Count > -1
                ? new AppResult<CategoryListDto>().Success(new CategoryListDto { Categories = entities })
                : new AppResult<CategoryListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
    }
}