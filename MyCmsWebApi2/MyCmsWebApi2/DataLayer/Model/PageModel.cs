namespace MyCmsWebApi2.DataLayer.Model;

public class Page
{
    public int PageId { get; set; }
    public int pageGroupId { get; set; }
    public virtual PageGroup pageGroup { get; set; } 
    public string Title { get; set; } = String.Empty;
    public string ShortDescription { get; set; } = String.Empty;
    public string Text { get; set; } = String.Empty;
    public int Visit { get; set; }
    public bool ShowInSlider { get; set; }
    public DateTime CreateDate { get; set; }
    public string Tags { get; set; } = String.Empty;
   // public  int ImagesId { get; set; }
    public virtual ICollection<Images>  images { get; set; }
    public virtual Comments comments { get; set; }
}