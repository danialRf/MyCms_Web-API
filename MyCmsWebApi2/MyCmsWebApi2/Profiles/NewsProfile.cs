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
            CreateMap<News, AdminNewsDto>()
                .ForMember(x=>x.Images,opt=>
                opt.MapFrom(src=>src.Images.Select(x=> "/api/admin/Images/"+x.Id.ToString())));
            CreateMap<AdminEditNewsDto, News>();
            CreateMap<AdminAddNewsDto, News>();
        }
    }
}
