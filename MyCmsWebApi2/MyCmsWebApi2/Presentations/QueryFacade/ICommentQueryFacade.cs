using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.User;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;

namespace MyCmsWebApi2.Presentations.QueryFacade
{
    public interface ICommentQueryFacade
    {
        Task<AdminCommentsDto> AdminGetCommentById(int id);
        Task<IEnumerable<AdminCommentsDto>> AdminGetCommentByNewsId (int id);
        Task<IEnumerable<AdminCommentsDto>> AdminGetAllComments();
        Task<UserCommentsDto> UserGetCommentById(int id);

        Task<IEnumerable<UserCommentsDto>> UserGetAllComments();
        Task<IEnumerable<AdminCommentsDto>> AdminGetAllUnverifiedComments();
    }
}
