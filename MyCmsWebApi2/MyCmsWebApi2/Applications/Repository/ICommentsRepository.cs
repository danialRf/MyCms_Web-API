using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Applications.Repository;


public interface ICommentRepository
{
    Task<List<Comments>> GetAllAsync();
    Task<Comments> GetCommentByIdAsync(int id);
    Task<Comments> InsertCommentAsync(Comments comment);
    Task DeleteCommentByIdAsync(int id);
    Task<bool> CommentExist(int id);
    Task<List<Comments>> GetCommentsByNewsId(int newsId);
}

