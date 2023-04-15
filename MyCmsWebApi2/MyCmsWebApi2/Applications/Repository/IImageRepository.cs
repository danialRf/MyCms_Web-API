using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Infrastructure;

namespace MyCmsWebApi2.Applications.Repository
{
    public interface IImageRepository : IRepository<Image,Guid>
    {
    }
}
