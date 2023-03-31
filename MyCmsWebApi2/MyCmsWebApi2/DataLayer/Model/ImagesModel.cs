namespace MyCmsWebApi2.DataLayer.Model;

public class Images
{
    public int ImagesId { get; set; }
    public string ImageName { get; set; } = String.Empty;
    public DateTime CreateDate { get; set; }
    public int PageId { get; set; }
    public virtual Page page { get; set; }
    public int PageGrupId { get; set; }
    public virtual PageGroup pageGroup { get; set; }
}