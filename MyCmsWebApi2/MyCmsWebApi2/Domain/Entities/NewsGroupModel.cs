namespace MyCmsWebApi2.Domain.Entities;

public class NewsGroup
{
    public int Id { get; set; }
    public string GroupTitle { get; set; } = string.Empty;
    public virtual ICollection<News> News { get; set; }

    public virtual ICollection<Images> Images { get; set; }
}