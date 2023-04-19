namespace MyCmsWebApi2.Presentations.Dtos.CommentsDto.User
{
    public class UserCommentsDto
    {
        public int Id { get; set; }   
        public string CommentWriterName { get; set; }
        public string CommentSubject { get; set; }
        public string CommentText { get; set; }
        public DateTime DateTime { get; set; }
        public int NewsId { get; set; }

    }
}
