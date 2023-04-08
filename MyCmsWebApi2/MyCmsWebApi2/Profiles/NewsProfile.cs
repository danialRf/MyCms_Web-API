using AutoMapper;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Dtos;


namespace MyCmsWebApi2.Profiles
{
    public class NewsProfile: Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsDto>();
            CreateMap<NewsDto, News>();
        }
    }
}
