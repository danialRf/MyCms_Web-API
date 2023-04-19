using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Users;

namespace MyCmsWebApi2.Presentations.QueryFacade
{
    public interface INewsGroupQueryFacade
    {
        Task<IEnumerable<UserNewsGroupDto>> UserGetAllNewsGroup();
        Task<bool> Exist(int? id);

        Task<IEnumerable<AdminNewsGroupDto>> AdminGetAllNewsGroup();

        Task <AdminNewsGroupDto> AdminGetNewsGroupById(int id);
    }
}
