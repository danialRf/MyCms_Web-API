namespace MyCmsWebApi2.Domain.Entities;

public class Image
{
    public Guid Id { get; set; }
    public string ImageName { get; set; } = string.Empty;
    public string Base64 { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public string ContentType { get; set; }
    public virtual News News { get; set; }
    public int? NewsId { get; set; }
    public int? NewsGroupId { get; set; }
    public virtual NewsGroup NewsGroup { get; set; }
    public void Update(string base64)
    {
        Base64 = base64;
    }

}