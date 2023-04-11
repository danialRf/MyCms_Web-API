namespace MyCmsWebApi2.Dtos.ImagesDto
{
    public class AddImageDto
    {
       // public Guid Id { get; set; }
        public string ImageName{ get; set; }
        internal string Base64 { get; set; }
        public int? NewsId { get; set; }
        public int? NewsGroupId { get; set; }

    }
}
