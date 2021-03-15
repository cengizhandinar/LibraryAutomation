using System;
using System.Collections.Generic;
using System.Linq;
using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Core.Result.Concrete;
using Library.Data.Abstract;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.BookCategoryDto;
using Library.Entities.Entities.Dtos.BookDto;
using Library.Services.Abstract;
using Library.Services.Utilities;

namespace Library.Services.Concrete
{
    /// <summary>
    /// Kitap-Kategori tablosu işlemleri için kullanılacak sınıf.
    /// </summary>
    public class BookCategoryManager : ManagerBase, IBookCategoryService
    {
        public BookCategoryManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IAppResult Add(BookCategoryAddDto entity)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var book = UnitOfWork.GetRepository<Book>().Find(entity.BookId);
            if (book == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var category = UnitOfWork.GetRepository<Book>().Find(entity.BookId);
            if (category == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var isThere = UnitOfWork.GetRepository<BookCategory>().Any(
                bc => bc.BookId == entity.BookId && bc.CategoryId == entity.CategoryId);
            if (isThere) return new AppResult().Warning(Messages.BookCategories.IsThere());
            var newEntity = Mapper.Map<BookCategory>(entity);
            UnitOfWork.GetRepository<BookCategory>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.BookCategories.Add(book.Name, category.Name));
        }
        public IAppResult HardDelete(int categoryId, int bookId)
        {
            var entity = UnitOfWork.GetRepository<BookCategory>()
                .Get(bc => bc.CategoryId == categoryId && bc.BookId == bookId);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var bookName = entity.Book.Name;
            var categoryName = entity.Category.Name;
            UnitOfWork.GetRepository<BookCategory>().Delete(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.BookCategories.HardDelete(bookName, categoryName));
        }
        public IAppResult HardDeleteByCategoryId(int categoryId)
        {
            var getDeleting = UnitOfWork.GetRepository<BookCategory>().GetAll(bc => bc.CategoryId == categoryId);
            if (getDeleting == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var categoryName = getDeleting[0].Category.Name;
            foreach (var bookCategory in getDeleting)
            {
                UnitOfWork.GetRepository<BookCategory>().Delete(bookCategory);
            }
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.BookCategories.HardDeleteByCategory(categoryName));
        }
        public IAppResult<BookListDto> GetAllBookByNonCategory()
        {
            var entities = UnitOfWork.GetRepository<BookCategory>().GetAll(
                null,
                bc => bc.Book, bc => bc.Category);
            var books = UnitOfWork.GetRepository<Book>().GetAll(
                b => b.GeneralStatus == GeneralStatus.Active,
                b => b.Publisher, b => b.Writer);
            if (entities.Count <= -1 || books.Count <= -1) return new AppResult<BookListDto>().Fail(new ArgumentOutOfRangeException().Message);
            IList<Book> list = books.Where(book => entities.All(bc => bc.BookId != book.Id)).ToList();
            return list.Count==0 
                ? new AppResult<BookListDto>().Warning(Messages.BookCategories.NotFoundBook()) 
                : new AppResult<BookListDto>().Success(new BookListDto { Books = list });
        }
    }
}