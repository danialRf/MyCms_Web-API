using MyCmsWebApi2.Domain.Enums;

namespace MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin
{
    public class AdminCommentsDto
    {
        public int Id { get; set; } 
        public string CommentWriterName { get; set; }
        public string CommentSubject { get; set; }
        public string CommentText { get; set; } 
        public DateTime DateTime { get; set; }
        public int NewsId { get; set; }
        public string CommentWriterEmail { get; set; } 
        public DateTime CreateDate { get; set; }
        public DateTime ChangeStatusDate { get; set; }
        internal CommentStatus CommentStatus { get; set; }
        internal Guid StatusChangerId { get; set; }
    }
}
