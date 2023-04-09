using AutoMapper;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Dtos.CommentsDto;

namespace MyCmsWebApi2.Profiles
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<Comments, ShowCommentsDto>();
            CreateMap<AddCommentsDto,Comments> ();

        }
    }
}
