using System;
using System.Collections.Generic;
using System.Linq;
using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Core.Result.Concrete;
using Library.Data.Abstract;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.UserBookDto;
using Library.Services.Abstract;
using Library.Services.Utilities;

namespace Library.Services.Concrete
{
    /// <summary>
    /// Kullanıcı-Kitap tablosu işlemleri için kullanılacak sınıf.
    /// </summary>
    public class UserBookManager : ManagerBase, IUserBookService
    {
        public UserBookManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IAppResult HardDelete(int id)
        {
            var entity = UnitOfWork.GetRepository<UserBook>().Get(
                ub => ub.Id==id,
                ub => ub.Book, ub => ub.User);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var userName = entity.User.UserName;
            var bookName = entity.Book.Name;
            switch (entity.BookStatus)
            {
                case BookStatus.Read:
                    entity.Book.NumberOfReads -= 1;
                    break;
                case BookStatus.Reading:
                    entity.Book.Stock += 1;
                    break;
                case BookStatus.WillRead:
                    entity.Book.Stock += 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            UnitOfWork.GetRepository<UserBook>().Delete(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.UserBook.HardDelete(userName, bookName));
        }
        public IAppResult ReceiveBook(int userBookId)
        {
            var userBook = UnitOfWork.GetRepository<UserBook>().Find(userBookId);
            if (userBook == null) return new AppResult().Fail(new ArgumentNullException().Message);
            userBook.Book.Stock += 1;
            userBook.Book.NumberOfReads += 1;
            userBook.ReceiveDate=DateTime.Now;
            userBook.BookStatus = BookStatus.Read;
            UnitOfWork.GetRepository<UserBook>().Update(userBook);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.UserBook.Receive(userBook.User.UserName, userBook.Book.Name));
        }
        public int DefinedNumberOfBooksForUser(int userId)
        {
            var result = UnitOfWork.GetRepository<UserBook>()
                .Count(ub => ub.UserId == userId && ub.BookStatus == BookStatus.Reading);
            return result;
        }
        public IAppResult LendBook(UserBookAddDto entity)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var book = UnitOfWork.GetRepository<Book>().Find(entity.BookId);
            var user = UnitOfWork.GetRepository<User>().Find(entity.UserId);
            var newEntity = Mapper.Map<UserBook>(entity);
            if (UnitOfWork.GetRepository<UserBook>()
                .Any(u => u.BookId == entity.BookId && u.UserId == entity.UserId && u.BookStatus == BookStatus.Reading))
                return new AppResult().Warning(Messages.UserBook.IsThereReading(user.UserName, book.Name));
            book.Stock -= 1;
            UnitOfWork.GetRepository<UserBook>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.UserBook.Lend(newEntity.User.UserName, newEntity.Book.Name));
        }
        public IAppResult AddReaded(UserBookAddDto entity)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var book = UnitOfWork.GetRepository<Book>().Find(entity.BookId);
            var user = UnitOfWork.GetRepository<User>().Find(entity.UserId);
            var newEntity = Mapper.Map<UserBook>(entity);
            if (UnitOfWork.GetRepository<UserBook>()
                .Any(u => u.BookId == entity.BookId && u.UserId == entity.UserId && u.BookStatus == BookStatus.Read))
                return new AppResult().Warning(Messages.UserBook.IsThereRead(user.UserName, book.Name));
            book.NumberOfReads += 1;
            newEntity.LendDate = DateTime.Now;
            newEntity.ReceiveDate = DateTime.Now;
            newEntity.BookStatus = BookStatus.Read;
            UnitOfWork.GetRepository<UserBook>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.UserBook.Added(user.UserName, book.Name));
        }
        public IAppResult AddWillRead(UserBookAddDto entity)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var book = UnitOfWork.GetRepository<Book>().Find(entity.BookId);
            var user = UnitOfWork.GetRepository<User>().Find(entity.UserId);
            var newEntity = Mapper.Map<UserBook>(entity);
            if (UnitOfWork.GetRepository<UserBook>()
                .Any(u => u.BookId == entity.BookId && u.UserId == entity.UserId && u.BookStatus == BookStatus.WillRead))
                return new AppResult().Warning(Messages.UserBook.IsThereReading(user.UserName, book.Name));
            newEntity.LendDate = DateTime.Now;
            newEntity.ReceiveDate = DateTime.Now;
            newEntity.BookStatus = BookStatus.WillRead;
            UnitOfWork.GetRepository<UserBook>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.UserBook.Added(user.UserName, book.Name));
        }
        public IAppResult<UserBookGetDto> Get(int userBookId)
        {
            var entity = UnitOfWork.GetRepository<UserBook>().Get(
                u => u.Id == userBookId,
                u => u.User, u => u.Book);
            return entity != null
                ? new AppResult<UserBookGetDto>().Success(new UserBookGetDto { UserBook = entity })
                : new AppResult<UserBookGetDto>().Warning(Messages.Book.NotFound());
        }
        public IAppResult<UserBookListDto> GetAllReadByUser(int userId)
        {
            var entities = UnitOfWork.GetRepository<UserBook>().GetAll(
                bc => bc.UserId == userId && bc.BookStatus == BookStatus.Read,
                bc => bc.Book, bc => bc.User,bc=>bc.Book.Publisher);
            if (entities.Count <= -1) return new AppResult<UserBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            return entities.Count == 0
                ? new AppResult<UserBookListDto>().Warning(Messages.UserBook.NotFoundRead())
                : new AppResult<UserBookListDto>().Success(new UserBookListDto { UserBooks = entities });
        }
        public IAppResult<UserBookListDto> GetAllReadingByUser(int userId)
        {
            var entities = UnitOfWork.GetRepository<UserBook>().GetAll(
                bc => bc.UserId == userId && bc.BookStatus == BookStatus.Reading,
                bc => bc.Book, bc => bc.User,bc=>bc.Book.Writer);
            if (entities.Count <= -1) return new AppResult<UserBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            return entities.Count == 0
                ? new AppResult<UserBookListDto>().Warning(Messages.UserBook.NotFoundReading())
                : new AppResult<UserBookListDto>().Success(new UserBookListDto { UserBooks = entities });
        }
        public IAppResult<UserBookListDto> GetAllWillReadByUser(int userId)
        {
            var entities = UnitOfWork.GetRepository<UserBook>().GetAll(
                bc => bc.UserId == userId && bc.BookStatus == BookStatus.WillRead,
                bc => bc.Book, bc => bc.User, bc => bc.Book.Publisher);
            if (entities.Count <= -1) return new AppResult<UserBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            return entities.Count == 0
                ? new AppResult<UserBookListDto>().Warning(Messages.UserBook.NotFoundWillRead())
                : new AppResult<UserBookListDto>().Success(new UserBookListDto { UserBooks = entities });
        }
        public IAppResult<UserBookListDto> GetAllReadAndReadingByUser(int userId)
        {
            var entities = UnitOfWork.GetRepository<UserBook>().GetAll(
                bc => bc.UserId == userId && (bc.BookStatus == BookStatus.Reading || bc.BookStatus==BookStatus.Read),
                bc => bc.Book, bc => bc.User);
            if (entities.Count <= -1) return new AppResult<UserBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            return entities.Count == 0
                ? new AppResult<UserBookListDto>().Warning(Messages.UserBook.NotFoundReadAndReadingByUser())
                : new AppResult<UserBookListDto>().Success(new UserBookListDto { UserBooks = entities });
        }
        public IAppResult<UserBookListDto> GetAllReadAndReadingByBook(int bookId)
        {
            var entities = UnitOfWork.GetRepository<UserBook>().GetAll(
                bc => bc.BookId == bookId && (bc.BookStatus == BookStatus.Reading || bc.BookStatus == BookStatus.Read),
                bc => bc.Book, bc => bc.User);
            if (entities.Count <= -1) return new AppResult<UserBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            return entities.Count == 0
                ? new AppResult<UserBookListDto>().Warning(Messages.UserBook.NotFoundReadAndReadingByBook())
                : new AppResult<UserBookListDto>().Success(new UserBookListDto { UserBooks = entities });
        }

        public IAppResult<UserBookListDto> SearchReadByText(string text, int userId)
        {
            var entities = UnitOfWork.GetRepository<UserBook>().GetAll(
                fb => fb.UserId == userId && fb.BookStatus==BookStatus.Read,
                fb => fb.Book, fb => fb.User);
            var books = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.Name.Contains(text) && u.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1 || books.Count <= -1)
                return new AppResult<UserBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            IList<UserBook> list = entities.Where(userBook => books.Any(book => book.Id == userBook.BookId)).ToList();
            return new AppResult<UserBookListDto>().Success(new UserBookListDto { UserBooks = list });
        }

        public IAppResult<UserBookListDto> SearchReadByWriterName(string text, int userId)
        {
            var entities = UnitOfWork.GetRepository<UserBook>().GetAll(
                fb => fb.UserId == userId && fb.BookStatus==BookStatus.Read,
                fb => fb.Book, fb => fb.User);
            var books = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.Writer.Name.Contains(text) && u.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1 || books.Count <= -1)
                return new AppResult<UserBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            IList<UserBook> list = entities.Where(userBook => books.Any(book => book.Id == userBook.BookId)).ToList();
            return new AppResult<UserBookListDto>().Success(new UserBookListDto { UserBooks = list });
        }

        public IAppResult<UserBookListDto> SearchWillReadByText(string text, int userId)
        {
            var entities = UnitOfWork.GetRepository<UserBook>().GetAll(
                fb => fb.UserId == userId && fb.BookStatus == BookStatus.WillRead,
                fb => fb.Book, fb => fb.User);
            var books = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.Name.Contains(text) && u.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1 || books.Count <= -1)
                return new AppResult<UserBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            IList<UserBook> list = entities.Where(userBook => books.Any(book => book.Id == userBook.BookId)).ToList();
            return new AppResult<UserBookListDto>().Success(new UserBookListDto { UserBooks = list });
        }

        public IAppResult<UserBookListDto> SearchWillReadByWriterName(string text, int userId)
        {
            var entities = UnitOfWork.GetRepository<UserBook>().GetAll(
                fb => fb.UserId == userId && fb.BookStatus == BookStatus.WillRead,
                fb => fb.Book, fb => fb.User);
            var books = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.Writer.Name.Contains(text) && u.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1 || books.Count <= -1)
                return new AppResult<UserBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            IList<UserBook> list = entities.Where(userBook => books.Any(book => book.Id == userBook.BookId)).ToList();
            return new AppResult<UserBookListDto>().Success(new UserBookListDto { UserBooks = list });
        }
    }
}