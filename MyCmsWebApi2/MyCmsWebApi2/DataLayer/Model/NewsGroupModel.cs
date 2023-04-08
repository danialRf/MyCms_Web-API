namespace MyCmsWebApi2.DataLayer.Model;

public class NewsGroup
{
    public int Id { get; set; }
    public string GroupTitle { get; set; } = String.Empty;
    public virtual ICollection<News> News { get; set; }
    
    public virtual Images Images { get; set; }
}