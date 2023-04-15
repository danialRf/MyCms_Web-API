namespace MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin
{
    public class AdminCommentsDto
    {

        public string CommentName { get; set; } = string.Empty;
        public string CommentSubject { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }
}
