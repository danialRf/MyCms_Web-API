using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Domain.Enums;
using System.Security.Permissions;

namespace MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin
{
    public class AdminAddCommentsDto
    {
        public string CommentWriterName { get; set; } = string.Empty;
        public string CommentWriterEmail { get; set; } = string.Empty;
        public string CommentSubject { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;
        //internal CommentStatus commentStatus { get; set; }
        //public AdminAddCommentsDto()
        //{
        //    commentStatus = CommentStatus.Accepted;   
        //}
    }

}
