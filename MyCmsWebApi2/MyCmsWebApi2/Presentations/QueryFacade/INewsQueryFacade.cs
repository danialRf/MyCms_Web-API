using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;

namespace MyCmsWebApi2.Presentations.QueryFacade
{
    public interface INewsQueryFacade
    {
        Task<AdminNewsDto> GetNewsById(int id);
    }
}
