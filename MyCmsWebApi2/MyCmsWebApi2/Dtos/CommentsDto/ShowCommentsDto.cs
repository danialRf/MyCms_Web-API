namespace MyCmsWebApi2.Dtos.CommentsDto
{
    public class ShowCommentsDto
    {

        public string CommentName { get; set; } = string.Empty;
        public string CommentSubject { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }
}
