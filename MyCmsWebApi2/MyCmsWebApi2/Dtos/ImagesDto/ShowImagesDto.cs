namespace MyCmsWebApi2.Dtos.ImagesDto
{
    public class ShowImagesDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int NewsId { get; set; }
        public int NewsGroupId { get; set; }
        public string ImageName { get; set; } = String.Empty;

    }
}
