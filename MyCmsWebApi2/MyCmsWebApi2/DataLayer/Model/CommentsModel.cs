namespace MyCmsWebApi2.DataLayer.Model;

public class Comments
{
    public int CommentId { get; set; }
    public int PageId { get; set; }
    public virtual Page page { get; set; }
    public string CommentName { get; set; } = String.Empty;
    public string CommentEmail { get; set; } = String.Empty;
    public string CommentSubject { get; set; } = String.Empty;
    public string CommentText { get; set; } = String.Empty;
    public DateTime CreateDate { get; set; }
}