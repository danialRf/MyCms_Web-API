namespace MyCmsWebApi2.DataLayer.Model;

public class PageGroup
{
    public int PageGroupId { get; set; }
    public string GroupTitle { get; set; } = String.Empty;
    public virtual ICollection<Page> page { get; set; }
    
    public virtual Images images { get; set; }
}