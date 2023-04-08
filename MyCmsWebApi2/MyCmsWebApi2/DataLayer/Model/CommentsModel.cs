namespace MyCmsWebApi2.DataLayer.Model;

public class Comments
{
    public int Id { get; set; }
    public int NewsId { get; set; }
    public virtual News News { get; set; }
    public string CommentName { get; set; } = String.Empty;
    public string CommentEmail { get; set; } = String.Empty;
    public string CommentSubject { get; set; } = String.Empty;
    public string CommentText { get; set; } = String.Empty;
    public DateTime CreateDate { get; set; }
}