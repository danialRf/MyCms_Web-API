using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Infrastructure;

namespace MyCmsWebApi2.Applications.Repository;

public interface INewsGroupRepository : IRepository<NewsGroup,int>
{
    Task<NewsGroup> GetGroupByNewsId(int newsId);
}