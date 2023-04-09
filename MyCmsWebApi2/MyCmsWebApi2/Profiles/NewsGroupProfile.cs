using AutoMapper;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Dtos.NewsGroupDto.Admin;

namespace MyCmsWebApi2.Profiles
{
    public class NewsGroupProfile : Profile
    {
        public NewsGroupProfile()
        {
            CreateMap<NewsGroup, MyCmsWebApi2.Dtos.NewsGroupDto.Admin.AdminShowNewsGroupDto>();
            CreateMap<AdminAddNewsGroupDto,NewsGroup>();
            CreateMap<AdminEditNewsGroupDto, NewsGroup>();
            CreateMap<NewsGroup, MyCmsWebApi2.Dtos.NewsGroupDto.Users.UserShowNewsGroupDto>();

        }
    }
}
