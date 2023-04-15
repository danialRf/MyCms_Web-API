using MyCmsWebApi2.Dtos.ImagesDto;
using MyCmsWebApi2.Dtos.NewsDto.Admin;

namespace MyCmsWebApi2.DataLayer.QueryFacade
{
    public interface INewsQueryFacade
    {
        Task<AdminNewsDto> GetNewsById(int id);
    }
}
