using AutoMapper;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Dtos.NewsGroupDto;
using MyCmsWebApi2.Dtos.NewsGroupDto.NewsGroupDto;

namespace MyCmsWebApi2.Profiles
{
    public class NewsGroupProfile : Profile
    {
        public NewsGroupProfile()
        {
            CreateMap<NewsGroup, ShowNewsGroupDto>();
            CreateMap<AddNewsGroupDto,NewsGroup>();
            CreateMap<EditNewsGroupDto, NewsGroup>();
            

        }
    }
}
