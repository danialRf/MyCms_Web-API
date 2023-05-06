using AutoMapper;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Users;

namespace MyCmsWebApi2.Infrastructure.Profiles
{
    public class NewsGroupProfile : Profile
    {
        public NewsGroupProfile()
        {
            CreateMap<NewsGroup, AdminNewsGroupDto>();
            CreateMap<AdminAddNewsGroupDto, NewsGroup>();

            CreateMap<AdminEditNewsGroupDto, NewsGroup>();
            
            CreateMap<NewsGroup, UserNewsGroupDto>();
            CreateMap<UserNewsGroupDto, NewsGroup>();
        }
    }
}
