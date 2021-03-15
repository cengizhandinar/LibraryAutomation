using Library.Core.Result.Abstract;
using Library.Entities.Entities.Dtos.CommentDto;

namespace Library.Services.Abstract
{
    public interface ICommentService
    {
        IAppResult HardDelete(int id, bool isUser);
        IAppResult<CommentGetDto> Get(int id);
        IAppResult<CommentListDto> GetAllDeleted();
        IAppResult Update(CommentUpdateDto entity);
        IAppResult Delete(int id, string updatedByName);
        IAppResult<CommentListDto> GetAllNonDeleted();
        IAppResult Approve(int id, string updatedByName);
        IAppResult<CommentListDto> GetAllNonApproved();
        IAppResult UndoDelete(int id, string updatedByName);
        IAppResult<CommentListDto> GetAllByUserId(int userId);
        IAppResult Add(CommentAddDto entity, string createdByName);
        IAppResult<CommentListDto> GetAllNonDeletedByBookId(int bookId);
        IAppResult<CommentListDto> FindCommentsByUserName(string text);
        IAppResult<CommentListDto> FindDeletedCommentsByText(string text);
        IAppResult<CommentListDto> FindCommentsByBookName(string bookName);
    }
}
