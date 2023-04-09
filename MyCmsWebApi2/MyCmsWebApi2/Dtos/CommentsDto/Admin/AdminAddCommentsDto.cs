namespace MyCmsWebApi2.Dtos.CommentsDto.Admin
{
    public class AdminAddCommentsDto
    {
        public string CommentName { get; set; } = string.Empty;
        public string CommentEmail { get; set; } = string.Empty;
        public string CommentSubject { get; set; } = string.Empty;
        public string CommentText { get; set; } = string.Empty;

    }
}
