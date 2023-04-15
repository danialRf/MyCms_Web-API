using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Applications.Repository;


public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
    Task<Comment> GetCommentByIdAsync(int id);
    Task<Comment> InsertCommentAsync(Comment comment);
    Task DeleteCommentByIdAsync(int id);
    Task<bool> CommentExist(int id);
    Task<List<Comment>> GetCommentsByNewsId(int newsId);
}

