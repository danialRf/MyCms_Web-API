namespace MyCmsWebApi2.DataLayer.Model;

public class News
{
    public int Id { get; set; }
    public int NewsGroupId { get; set; }
    public virtual NewsGroup NewsGroup { get; set; }
    public string Title { get; set; } = String.Empty;
    public string ShortDescription { get; set; } = String.Empty;
    public string Text { get; set; } = String.Empty;
    public int Visit { get; set; }
    public bool ShowInSlider { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public string Tags { get; set; } = String.Empty;
    // public  int ImagesId { get; set; }
    public virtual ICollection<Images> Images { get; set; }
    public virtual ICollection<Comments> Comments { get; set; }


}