using AutoMapper;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Dtos;

namespace MyCmsWebApi2.Profiles
{
    public class NewsGroupProfile : Profile
    {
        public NewsGroupProfile()
        {
            CreateMap<NewsGroup, NewsGroupDto>();
            CreateMap<NewsGroupDto,NewsGroup>();
        }
    }
}
