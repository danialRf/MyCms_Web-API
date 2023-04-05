using AutoMapper;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Dtos;


namespace MyCmsWebApi2.Profiles
{
    public class PageProfile: Profile
    {
        public PageProfile()
        {
            CreateMap<Page,PageDto>();
            CreateMap<PageDto, Page>();
        }
    }
}
