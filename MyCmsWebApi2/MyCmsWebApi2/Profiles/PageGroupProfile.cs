using AutoMapper;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Dtos;

namespace MyCmsWebApi2.Profiles
{
    public class PageGroupProfile : Profile
    {
        public PageGroupProfile()
        {
            CreateMap<PageGroupDto,PageGroup>();
        }
    }
}
