using MyCmsWebApi2.Domain.Enums;

namespace MyCmsWebApi2.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public int NewsId { get; set; }
    public virtual News News { get; set; }
    public string CommentWriterName { get; set; } = string.Empty;
    public string CommentWriterEmail { get; set; } = string.Empty;
    public string CommentSubject { get; set; } = string.Empty;
    public string CommentText { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public CommentStatus CommentStatus { get; set; }
    public DateTime ChangeStatusDate { get; set; }
    public Guid StatusChangerId { get; set; }

 

}