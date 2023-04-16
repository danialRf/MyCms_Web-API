using AutoMapper;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;

namespace MyCmsWebApi2.Infrastructure.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, AdminAddNewsDto>();
            CreateMap<News, NewsDto>()
                .ForMember(x => x.Images, opt =>
                opt.MapFrom(src => src.Images.Select(x => "/api/admin/Images/" + x.Id.ToString())));
            CreateMap<AdminEditNewsDto, News>();
            CreateMap<News, AdminEditNewsDto>();
            CreateMap<AdminAddNewsDto, News>();
        }
    }
}
