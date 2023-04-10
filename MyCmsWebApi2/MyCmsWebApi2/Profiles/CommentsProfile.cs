using AutoMapper;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Dtos.CommentsDto.Admin;

namespace MyCmsWebApi2.Profiles
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<Comments, AdminCommentsDto>();
            CreateMap<AdminAddCommentsDto,Comments> ();

        }
    }
}
