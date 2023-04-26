using MyCmsWebApi2.Domain.Enums;

namespace MyCmsWebApi2.Presentations.Dtos.CommentsDto.User
{
    public class UserAddCommentDto
    {
        public string CommentWriterName { get; set; } 
        public string CommentWriterEmail { get; set; }
        public string CommentSubject { get; set; } 
        public string CommentText { get; set; }
        internal CommentStatus commentStatus { get; set; }
        public UserAddCommentDto()
        {
            commentStatus = CommentStatus.Checking;
        }
    }
}
