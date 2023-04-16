using AutoMapper;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;

namespace MyCmsWebApi2.Infrastructure.Profiles
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<Comment, AdminCommentsDto>();
            CreateMap<AdminAddCommentsDto, Comment>();

        }
    }
}
