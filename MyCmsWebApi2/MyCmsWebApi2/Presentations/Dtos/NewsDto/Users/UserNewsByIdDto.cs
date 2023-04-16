namespace MyCmsWebApi2.Presentations.Dtos.NewsDto.Users
{
    public class UserNewsByIdDto
    {
        public int Id { get; set; }
        public int NewsGroupId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public IList<string>? Images { get; set; }
    }
}
