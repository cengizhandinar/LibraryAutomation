using System;
using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Core.Result.Concrete;
using Library.Data.Abstract;
using Library.Entities.Entities.Concrete;
using Library.Entities.Entities.Dtos.CommentDto;
using Library.Services.Abstract;
using Library.Services.Utilities;

namespace Library.Services.Concrete
{
    /// <summary>
    /// Yorumlar tablosu işlemleri için kullanılacak sınıf.
    /// </summary>
    public class CommentManager : ManagerBase, ICommentService
    {
        public CommentManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IAppResult HardDelete(int id, bool isUser)
        {
            var entity = UnitOfWork.GetRepository<Comment>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var userName = entity.User.UserName;
            if (isUser && entity.GeneralStatus==GeneralStatus.Active)
            {
                entity.Book.NumberOfComments -= 1;
                var comments = UnitOfWork.GetRepository<Comment>().GetAll(c => c.BookId == entity.BookId && c.GeneralStatus == GeneralStatus.Active);
                if (comments == null) return new AppResult().Fail(new ArgumentNullException().Message);
                var bookCommentNumber = comments.Count;
                var oldRating = entity.Book.RatingAverage;
                if (bookCommentNumber == 1)
                    entity.Book.RatingAverage = 0;
                else
                {
                    var newRating = ((oldRating * bookCommentNumber) - entity.Rating) / (bookCommentNumber - 1);
                    entity.Book.RatingAverage = newRating;
                }
            }
            UnitOfWork.GetRepository<Comment>().Delete(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Comment.HardDelete(userName, isUser));
        }
        public IAppResult<CommentGetDto> Get(int id)
        {
            var entity = UnitOfWork.GetRepository<Comment>().Get(
                c => c != null && c.Id == id,
                c => c.User, c => c.Book);
            return entity != null
                ? new AppResult<CommentGetDto>().Success(new CommentGetDto { Comment = entity })
                : new AppResult<CommentGetDto>().Warning(Messages.Comment.NotFound());
        }
        public IAppResult<CommentListDto> GetAllDeleted()
        {
            var entities = UnitOfWork.GetRepository<Comment>().GetAll(
                c => c != null && c.GeneralStatus != GeneralStatus.Active,
                c => c.User, c => c.Book);
            if (entities.Count <= -1)
            {
                return new AppResult<CommentListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<CommentListDto>().Warning(Messages.Comment.NotFoundDeleted())
                : new AppResult<CommentListDto>().Success(new CommentListDto { Comments = entities });
        }
        public IAppResult Update(CommentUpdateDto entity)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var oldEntity = UnitOfWork.GetRepository<Comment>().Get(c => c.Id == entity.Id);
            if (oldEntity.GeneralStatus == GeneralStatus.Active)
            {
                oldEntity.Book.NumberOfComments -= 1;
                var comments = UnitOfWork.GetRepository<Comment>().GetAll(
                    c => c.BookId == oldEntity.BookId && c.GeneralStatus == GeneralStatus.Active);
                if (comments == null) return new AppResult().Fail(new ArgumentNullException().Message);
                var bookCommentNumber = comments.Count;
                var oldRating = oldEntity.Book.RatingAverage;
                if (bookCommentNumber == 1) oldEntity.Book.RatingAverage = 0;
                else
                {
                    var newRating = ((oldRating * bookCommentNumber) - oldEntity.Rating) / (bookCommentNumber - 1);
                    oldEntity.Book.RatingAverage = newRating;
                }
            }
            oldEntity.UpdatedDate=DateTime.Now;
            oldEntity.GeneralStatus = GeneralStatus.WaitingApproval;
            oldEntity.Rating = entity.Rating;
            oldEntity.CommentText = entity.CommentText;
            UnitOfWork.GetRepository<Comment>().Update(oldEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Comment.Update(oldEntity.User.UserName));
        }
        public IAppResult Delete(int id, string updatedByName)
        {
            var entity = UnitOfWork.GetRepository<Comment>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            if (entity.GeneralStatus == GeneralStatus.Active)
            {
                entity.Book.NumberOfComments -= 1;
                var comments = UnitOfWork.GetRepository<Comment>().GetAll(c => c.BookId == entity.BookId && c.GeneralStatus == GeneralStatus.Active);
                if (comments == null) return new AppResult().Fail(new ArgumentNullException().Message);
                var bookCommentNumber = comments.Count;
                var oldRating = entity.Book.RatingAverage;
                if (bookCommentNumber == 1)
                    entity.Book.RatingAverage = 0;
                else
                {
                    var newRating = ((oldRating * bookCommentNumber) - entity.Rating) / (bookCommentNumber - 1);
                    entity.Book.RatingAverage = newRating;
                }
            }
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedByName = updatedByName;
            entity.GeneralStatus = GeneralStatus.Deleted;
            UnitOfWork.GetRepository<Comment>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Comment.Delete(entity.User.UserName));
        }
        public IAppResult<CommentListDto> GetAllNonDeleted()
        {
            var entities = UnitOfWork.GetRepository<Comment>().GetAll(
                c => c != null && c.GeneralStatus == GeneralStatus.Active,
                c => c.User, c => c.Book);
            if (entities.Count <= -1)
            {
                return new AppResult<CommentListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<CommentListDto>().Warning(Messages.Comment.NotFoundActive())
                : new AppResult<CommentListDto>().Success(new CommentListDto { Comments = entities });
        }
        public IAppResult Approve(int id, string updatedByName)
        {
            var entity = UnitOfWork.GetRepository<Comment>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            if (entity.GeneralStatus == GeneralStatus.Active) return new AppResult().Info(Messages.Comment.Approved(entity.User.UserName));
            var comments = UnitOfWork.GetRepository<Comment>().GetAll(c => c.BookId == entity.BookId && c.GeneralStatus == GeneralStatus.Active);
            if (comments == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var bookCommentNumber = comments.Count;
            var oldRating = entity.Book.RatingAverage;
            var newRating = ((oldRating * bookCommentNumber) + entity.Rating) / (bookCommentNumber + 1);
            entity.Book.RatingAverage = newRating;
            entity.Book.NumberOfComments += 1;
            entity.GeneralStatus = GeneralStatus.Active;
            UnitOfWork.GetRepository<Comment>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Comment.Approve(entity.User.UserName));
        }
        public IAppResult<CommentListDto> GetAllNonApproved()
        {
            var entities = UnitOfWork.GetRepository<Comment>().GetAll(
                c => c != null && c.GeneralStatus == GeneralStatus.WaitingApproval,
                c => c.User, c => c.Book);
            if (entities.Count <= -1)
            {
                return new AppResult<CommentListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<CommentListDto>().Warning(Messages.Comment.NotFoundNonApproved())
                : new AppResult<CommentListDto>().Success(new CommentListDto { Comments = entities });
        }
        public IAppResult UndoDelete(int id, string updatedByName)
        {
            var entity = UnitOfWork.GetRepository<Comment>().Find(id);
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedByName = updatedByName;
            entity.GeneralStatus = GeneralStatus.WaitingApproval;
            UnitOfWork.GetRepository<Comment>().Update(entity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Comment.UndoDelete(entity.User.UserName));
        }
        public IAppResult<CommentListDto> GetAllByUserId(int userId)
        {
            var entities = UnitOfWork.GetRepository<Comment>().GetAll(
                c => c != null && c.UserId == userId,
                c => c.User, c => c.Book);
            var user = UnitOfWork.GetRepository<User>().Find(userId);
            if (entities.Count <= -1)
            {
                return new AppResult<CommentListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<CommentListDto>().Warning(Messages.Comment.NotFoundComment(user.UserName))
                : new AppResult<CommentListDto>().Success(new CommentListDto { Comments = entities });
        }
        public IAppResult Add(CommentAddDto entity, string createdByName)
        {
            if (entity == null) return new AppResult().Fail(new ArgumentNullException().Message);
            var newEntity = Mapper.Map<Comment>(entity);
            newEntity.CreatedByName = createdByName;
            newEntity.UpdatedByName = createdByName;
            UnitOfWork.GetRepository<Comment>().Add(newEntity);
            UnitOfWork.SaveChanges();
            return new AppResult().Success(Messages.Comment.Add(newEntity.User.UserName));
        }
        public IAppResult<CommentListDto> GetAllNonDeletedByBookId(int bookId)
        {
            var entities = UnitOfWork.GetRepository<Comment>().GetAll(
                c => c != null && c.GeneralStatus == GeneralStatus.Active && c.BookId == bookId,
                c => c.User, c => c.Book);
            if (entities.Count <= -1)
            {
                return new AppResult<CommentListDto>().Fail(new ArgumentOutOfRangeException().Message);
            }
            return entities.Count == 0
                ? new AppResult<CommentListDto>().Warning(Messages.Comment.NotFoundActive())
                : new AppResult<CommentListDto>().Success(new CommentListDto { Comments = entities });
        }
        public IAppResult<CommentListDto> FindCommentsByUserName(string text)
        {
            var entities = UnitOfWork.GetRepository<Comment>().GetAll(
                c => (c.User.FirstName.Contains(text) || c.User.LastName.Contains(text) || c.User.UserName.Contains(text)) 
                     && c.GeneralStatus == GeneralStatus.Active,
                c => c.User, c => c.Book);
            return entities.Count > -1
                ? new AppResult<CommentListDto>().Success(new CommentListDto { Comments = entities })
                : new AppResult<CommentListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
        public IAppResult<CommentListDto> FindDeletedCommentsByText(string text)
        {
            var entities = UnitOfWork.GetRepository<Comment>().GetAll(
                c => (c.User.FirstName.Contains(text) 
                      || c.User.LastName.Contains(text) 
                      || c.User.UserName.Contains(text) 
                      || c.Book.Name.Contains(text)) &&
                     c.GeneralStatus != GeneralStatus.Active,
                c => c.Book, c => c.User);
            return entities.Count > -1
                ? new AppResult<CommentListDto>().Success(new CommentListDto { Comments = entities })
                : new AppResult<CommentListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
        public IAppResult<CommentListDto> FindCommentsByBookName(string bookName)
        {
            var entities = UnitOfWork.GetRepository<Comment>().GetAll(
                c => c.Book.Name.Contains(bookName) && c.GeneralStatus == GeneralStatus.Active,
                c => c.Book, c => c.User);
            return entities.Count > -1
                ? new AppResult<CommentListDto>().Success(new CommentListDto { Comments = entities })
                : new AppResult<CommentListDto>().Fail(new ArgumentOutOfRangeException().Message);
        }
    }
}