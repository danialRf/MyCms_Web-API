namespace MyCmsWebApi2.Presentations.Dtos.CommentsDto.User
{
    public class UserAddCommentDto
    {
        public int NewsId { get; set; }
        public string CommentWriterName { get; set; } = string.Empty;
        public string CommentWriterEmail { get; set; } = string.Empty;
        public string CommentSubject { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;
    }
}
