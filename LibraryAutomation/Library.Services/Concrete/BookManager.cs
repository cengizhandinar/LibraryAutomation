using System;
using System.Collections.Generic;
using System.Linq;
using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Core.Result.Concrete;
using Library.Data.Abstract;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.BookDto;
using Library.Services.Abstract;
using Library.Services.Utilities;

namespace Library.Services.Concrete
{
    /// <summary>
    /// Kitap tablosu işlemleri için kullanılacak sınıf.
    /// </summary>
    public class BookManager : ManagerBase, IBookService
    {
        public BookManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IAppResult HardDelete(int id)
        {
            var entity = UnitOfWork.GetRepository<Book>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var bookName = entity.Name;
            UnitOfWork.GetRepository<Book>().Delete(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Book.HardDelete(bookName));
        }
        public IAppResult<BookGetDto> Get(int id)
        {
            var entity = UnitOfWork.GetRepository<Book>().Get(
                u => u.Id == id && u.GeneralStatus == GeneralStatus.Active,
                u => u.Publisher, u => u.Writer);
            return entity != null
                ? new AppResult<BookGetDto>().Success(new BookGetDto { Book = entity })
                : new AppResult<BookGetDto>().Warning(Messages.Book.NotFound());
        }
        public IAppResult<BookListDto> GetAllInStock()
        {
            var entities = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.Stock != 0 && u.GeneralStatus == GeneralStatus.Active,
                u => u.Publisher, u => u.Writer);
            if (entities.Count <= -1)
            {
                return new AppResult<BookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<BookListDto>().Warning(Messages.Book.NotFoundInStock())
                : new AppResult<BookListDto>().Success(new BookListDto { Books = entities });
        }
        public IAppResult<BookListDto> GetAllDeleted()
        {
            var entities = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.GeneralStatus != GeneralStatus.Active,
                u => u.Publisher, u => u.Writer);
            if (entities.Count <= -1)
            {
                return new AppResult<BookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<BookListDto>().Warning(Messages.Book.NotFoundDeleted())
                : new AppResult<BookListDto>().Success(new BookListDto { Books = entities });
        }
        public IAppResult<BookListDto> GetAllNonStock()
        {
            var entities = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.Stock == 0 && u.GeneralStatus == GeneralStatus.Active,
                u => u.Publisher, u => u.Writer);
            if (entities.Count <= -1)
            {
                return new AppResult<BookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<BookListDto>().Warning(Messages.Book.NotFoundNonStock())
                : new AppResult<BookListDto>().Success(new BookListDto { Books = entities });
        }
        public IAppResult<BookGetDto> GetDeleted(int id)
        {
            var entity = UnitOfWork.GetRepository<Book>().Get(
                u => u.Id == id && u.GeneralStatus != GeneralStatus.Active,
                u => u.Publisher, u => u.Writer);
            return entity != null
                ? new AppResult<BookGetDto>().Success(new BookGetDto { Book = entity })
                : new AppResult<BookGetDto>().Warning(Messages.Book.NotFound());
        }
        public IAppResult<BookListDto> GetAllNonDeleted()
        {
            var entities = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.GeneralStatus == GeneralStatus.Active,
                u => u.Publisher, u => u.Writer);
            if (entities.Count <= -1)
            {
                return new AppResult<BookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<BookListDto>().Warning(Messages.Book.NotFoundActive())
                : new AppResult<BookListDto>().Success(new BookListDto { Books = entities });
        }
        public IAppResult Delete(int id, string updatedByName)
        {
            var entity = UnitOfWork.GetRepository<Book>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var bookControl = UnitOfWork.GetRepository<UserBook>()
                .Any(ub => ub.BookId == id && ub.BookStatus == BookStatus.Reading);
            if (bookControl) return new AppResult().Fail(Messages.Book.NotDelivered(entity.Name));
            entity.Stock -= 1;
            entity.Writer.NumberOfBooks -= 1;
            entity.UpdatedByName = updatedByName;
            entity.GeneralStatus = GeneralStatus.Deleted;
            UnitOfWork.GetRepository<Book>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Book.Delete(entity.Name));
        }
        public IAppResult UndoDelete(int id, string updatedByName)
        {
            var entity = UnitOfWork.GetRepository<Book>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.Stock += 1;
            entity.Writer.NumberOfBooks += 1;
            entity.UpdatedByName = updatedByName;
            entity.UpdatedDate = DateTime.Now;
            entity.GeneralStatus = GeneralStatus.Active;
            UnitOfWork.GetRepository<Book>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Book.UndoDelete(entity.Name));
        }
        public IAppResult Add(BookAddDto entity, string createdByName)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var writer = UnitOfWork.GetRepository<Writer>().Find(entity.WriterId);
            if (writer == null) return new AppResult().Fail(new ArgumentNullException().Message);
            if (UnitOfWork.GetRepository<Book>().Any(u => u.Name == entity.Name && u.WriterId == entity.WriterId))
                return new AppResult().Warning(Messages.Book.IsThere(entity.Name));
            var newEntity = Mapper.Map<Book>(entity);
            writer.NumberOfBooks += 1;
            newEntity.CreatedByName = createdByName;
            newEntity.UpdatedByName = createdByName;
            UnitOfWork.GetRepository<Book>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Book.Add(newEntity.Name));
        }
        public IAppResult<BookListDto> SearchByName(string bookName)
        {
            var result = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.GeneralStatus == GeneralStatus.Active && u.Name.Contains(bookName),
                u => u.Publisher, u => u.Writer);
            return result.Count <= -1
                ? new AppResult<BookListDto>().Fail(new ArgumentOutOfRangeException().Message)
                : new AppResult<BookListDto>().Success(new BookListDto { Books = result });
        }
        public IAppResult<BookListDto> FindDeletedBooksByText(string text)
        {
            var entities = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.Name.Contains(text) && u.GeneralStatus != GeneralStatus.Active);
            return entities.Count > -1 
                ? new AppResult<BookListDto>().Success(new BookListDto { Books = entities }) 
                : new AppResult<BookListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
        public IAppResult Update(BookUpdateDto entity, string updatedByName)
        {
            var oldEntity = UnitOfWork.GetRepository<Book>().Find(entity.Id);
            if (oldEntity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var newEntity = Mapper.Map(entity, oldEntity);
            newEntity.UpdatedByName = updatedByName;
            UnitOfWork.GetRepository<Book>().Update(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Book.Update(newEntity.Name));
        }
        public IAppResult<BookListDto> SearchByWriterName(string writerName)
        {
            var result = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.GeneralStatus == GeneralStatus.Active && u.Writer.Name == writerName,
                u => u.Publisher, u => u.Writer);
            return result.Count <= -1
                ? new AppResult<BookListDto>().Fail(new ArgumentOutOfRangeException().Message)
                : new AppResult<BookListDto>().Success(new BookListDto { Books = result });
        }
        public IAppResult<BookListDto> SearchByCategoryName(string categoryName)
        {
            var entities = UnitOfWork.GetRepository<BookCategory>().GetAll(bc =>
                    bc.Category.Name == categoryName,
                bc => bc.Category, bc => bc.Book);
            var books = UnitOfWork.GetRepository<Book>().GetAll(
                b => b.GeneralStatus == GeneralStatus.Active,
                b => b.Publisher, b => b.Writer);
            if (entities.Count <= -1 || books.Count <= -1)
                return new AppResult<BookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            IList<Book> list = books.Where(book => entities.Any(bc => bc.BookId == book.Id)).ToList();
            return new AppResult<BookListDto>().Success(new BookListDto { Books = list });
        }
    }
}