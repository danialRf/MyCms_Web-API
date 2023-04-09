namespace MyCmsWebApi2.DataLayer.Model;

public class Images
{
    public int Id { get; set; }
    public string ImageName { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public virtual News News { get; set; }
    public int  NewsId { get; set; }
    public int NewsGroupId { get; set; }
    public virtual NewsGroup NewsGroup { get; set; }
}