using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.Repository;


    public interface ICommentRepository
    {
        Task<List<Comments>> GetAllAsync();  
        Task<Comments> GetCommentByIdAsync(int id);
        Task<Comments> InsertCommentAsync(Comments comment);
        Task DeleteCommentByIdAsync(int id);
        Task<bool> CommentExist(int id);
        Task<List<Comments>> GetCommentsByNewsId(int newsId);
}

