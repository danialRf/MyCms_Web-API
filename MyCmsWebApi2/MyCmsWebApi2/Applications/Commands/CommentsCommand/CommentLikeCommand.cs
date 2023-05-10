namespace MyCmsWebApi2.Applications.Commands.CommentsCommand
{
    public class CommentLikeCommand
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string UserId { get; set; }



    }
}