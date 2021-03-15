using System;
using System.Collections.Generic;
using System.Linq;
using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Core.Result.Concrete;
using Library.Data.Abstract;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.FavoriteBookDto;
using Library.Services.Abstract;
using Library.Services.Utilities;

namespace Library.Services.Concrete
{
    /// <summary>
    /// Favori Kitaplar tablosu işlemleri için kullanılacak sınıf.
    /// </summary>
    public class FavoriteBookManager : ManagerBase, IFavoriteBookService
    {
        public FavoriteBookManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IAppResult Add(FavoriteBookAddDto entity)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var book = UnitOfWork.GetRepository<Book>().Find(entity.BookId);
            var user = UnitOfWork.GetRepository<User>().Find(entity.UserId);
            if (book == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var newEntity = Mapper.Map<FavoriteBook>(entity);
            if (UnitOfWork.GetRepository<FavoriteBook>()
                .Any(u => u.BookId == entity.BookId && u.UserId == entity.UserId))
                return new AppResult().Warning(Messages.FavoriteBook.IsThere(user.UserName, book.Name));
            book.NumberOfFavorites += 1;
            UnitOfWork.GetRepository<FavoriteBook>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.FavoriteBook.Add(user.UserName, book.Name));
        }
        public IAppResult HardDelete(FavoriteBookGetDto entity)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var userName = entity.FavoriteBook.User.UserName;
            var bookName = entity.FavoriteBook.Book.Name;
            entity.FavoriteBook.Book.NumberOfFavorites -= 1;
            UnitOfWork.GetRepository<FavoriteBook>().Delete(entity.FavoriteBook);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.FavoriteBook.HardDelete(userName, bookName));
        }
        public IAppResult<FavoriteBookListDto> GetAll(int userId)
        {
            var entities = UnitOfWork.GetRepository<FavoriteBook>().GetAll(
                fb => fb.UserId == userId,
                fb => fb.Book, fb => fb.User,fb=>fb.Book.Writer, fb => fb.Book.Publisher);
            if (entities.Count <= -1) return new AppResult<FavoriteBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            return entities.Count == 0
                ? new AppResult<FavoriteBookListDto>().Warning(Messages.FavoriteBook.NotFoundFavorite())
                : new AppResult<FavoriteBookListDto>().Success(new FavoriteBookListDto { FavoriteBooks = entities });
        }
        public IAppResult<FavoriteBookGetDto> Get(int bookId, int userId)
        {
            var entity = UnitOfWork.GetRepository<FavoriteBook>().Get(
                u => u.BookId == bookId && u.UserId == userId,
                fb=>fb.Book,fb=>fb.User);
            return entity != null 
                ? new AppResult<FavoriteBookGetDto>().Success(new FavoriteBookGetDto { FavoriteBook = entity }) 
                : new AppResult<FavoriteBookGetDto>().Warning(Messages.FavoriteBook.NotFound());
        }

        public IAppResult<FavoriteBookListDto> SearchByFavoriteByText(string text, int userId)
        {
            var entities = UnitOfWork.GetRepository<FavoriteBook>().GetAll(
                fb => fb.UserId == userId,
                fb => fb.Book, fb => fb.User);
            var books = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.Name.Contains(text) && u.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1 || books.Count <= -1)
                return new AppResult<FavoriteBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            IList<FavoriteBook> list = entities.Where(favoriteBook => books.Any(book => book.Id == favoriteBook.BookId)).ToList();
            return new AppResult<FavoriteBookListDto>().Success(new FavoriteBookListDto { FavoriteBooks = list});
        }

        public IAppResult<FavoriteBookListDto> SearchByFavoriteByWriterName(string text, int userId)
        {
            var entities = UnitOfWork.GetRepository<FavoriteBook>().GetAll(
                fb => fb.UserId == userId,
                fb => fb.Book, fb => fb.User);
            var books = UnitOfWork.GetRepository<Book>().GetAll(
                u => u.Writer.Name.Contains(text) && u.GeneralStatus == GeneralStatus.Active);
            if (entities.Count <= -1 || books.Count <= -1)
                return new AppResult<FavoriteBookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            IList<FavoriteBook> list = entities.Where(favoriteBook => books.Any(book => book.Id == favoriteBook.BookId)).ToList();
            return new AppResult<FavoriteBookListDto>().Success(new FavoriteBookListDto { FavoriteBooks = list });
        }
    }
}