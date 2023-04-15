namespace MyCmsWebApi2.Domain.Entities;

public class Comments
{
    public int Id { get; set; }
    public int NewsId { get; set; }
    public virtual News News { get; set; }
    public string CommentName { get; set; } = string.Empty;
    public string CommentEmail { get; set; } = string.Empty;
    public string CommentSubject { get; set; } = string.Empty;
    public string CommentText { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; } = DateTime.Now;
}