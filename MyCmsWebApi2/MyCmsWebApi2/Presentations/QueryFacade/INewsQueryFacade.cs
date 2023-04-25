using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Users;

namespace MyCmsWebApi2.Presentations.QueryFacade
{
    public interface INewsQueryFacade
    {
        Task<AdminNewsDto> AdminGetNewsById(int id);
        Task<bool> Exist(int id);
        Task<IEnumerable<AdminNewsDto>> AdminGetAllNews();
        Task<IEnumerable<UserNewsDto>> UserGetAllNews();
        Task<UserNewsDto> UserGetNewsById(int id);
        Task<IEnumerable<AdminNewsDto>> AdminGetNewsByGroupId(int id);
        Task<IEnumerable<UserNewsDto>> UserGetNewsByGroupId(int id);
        Task<IList<TopNewsDto>> GetTopNews();




    }
}
