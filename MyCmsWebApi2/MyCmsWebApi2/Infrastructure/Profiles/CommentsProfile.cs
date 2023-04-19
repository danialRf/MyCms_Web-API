using AutoMapper;
using MyCmsWebApi2.Applications.Commands.Comments;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.User;

namespace MyCmsWebApi2.Infrastructure.Profiles
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<Comment, AdminCommentsDto>();
            CreateMap<AdminCommentsDto, Comment>();

            CreateMap<AdminAddCommentsDto, Comment>();

            CreateMap<AdminAddCommentsDto, AddCommentCommand>();
            CreateMap<UserCommentsDto, Comment>();

            CreateMap<Comment, UserCommentsDto>();

            CreateMap<UserAddCommentDto, Comment>();
            CreateMap<Comment, UserAddCommentDto>();

            CreateMap<UserAddCommentDto,AddCommentCommand>();
            CreateMap<AddCommentCommand, UserAddCommentDto>();
            
        }
    }
}
