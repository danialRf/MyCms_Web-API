using MyCmsWebApi2.Domain.Enums;
namespace MyCmsWebApi2.Domain.Entities

{
    public class CommentLike
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Comment Comment{ get; set; }
        public int CommentId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CeatedTime { get; set; }

    }
}
