using AutoMapper;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Dtos;
using MyCmsWebApi2.Dtos.NewsDto.Admin;

namespace MyCmsWebApi2.Profiles
{
    public class NewsProfile: Profile
    {
        public NewsProfile()
        {
            CreateMap<News, AdminAddNewsDto>();
            CreateMap<AdminEditNewsDto, News>();
            CreateMap<AdminAddNewsDto, News>();
        }
    }
}
