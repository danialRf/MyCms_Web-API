using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Infrastructure;

namespace MyCmsWebApi2.Applications.Repository;


public interface ICommentRepository : IRepository<Comment,int>
{
    Task<List<Comment>> GetCommentsByNewsId(int newsId);
}

