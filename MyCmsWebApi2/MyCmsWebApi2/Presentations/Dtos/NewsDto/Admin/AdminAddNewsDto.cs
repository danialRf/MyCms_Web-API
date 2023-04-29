namespace MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin
{
    public class AdminAddNewsDto
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public bool ShowInSlider { get; set; }
        public string Tags { get; set; }

    }
}
