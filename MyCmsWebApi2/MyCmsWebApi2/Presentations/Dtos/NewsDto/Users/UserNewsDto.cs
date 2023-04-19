namespace MyCmsWebApi2.Presentations.Dtos.NewsDto.Users
{
    public class UserNewsDto
    {
        public int Id { get; set; }
        public int NewsGroupId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public int Visit { get; set; }
        public IList<string>? Images { get; set; }

    }
}

