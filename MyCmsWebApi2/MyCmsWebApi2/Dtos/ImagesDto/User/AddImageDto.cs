namespace MyCmsWebApi2.Dtos.ImagesDto
{
    public class AddImageDto
    {
       // public Guid Id { get; set; }
        public string ImageName{ get; set; }
        public IFormFile File { get; set; }
        public int? NewsId { get; set; }
        public int? NewsGroupId { get; set; }

    }
}
