namespace MyCmsWebApi2.Dtos.CommentsDto
{
    public class AddCommentsDto
    {
        public string CommentName { get; set; } = string.Empty;
        public string CommentEmail { get; set; } = string.Empty;
        public string CommentSubject { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;

    }
}
