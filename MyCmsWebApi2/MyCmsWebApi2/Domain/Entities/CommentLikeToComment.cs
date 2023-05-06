using Microsoft.AspNetCore.Identity;

namespace MyCmsWebApi2.Domain.Entities
{
    public class CommentLikeToComment
    {
        public Guid UserId { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
