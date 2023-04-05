namespace MyCmsWebApi2.Dtos
{
    public class PageDto
    {
        public int? PageId { get; set; }
        public int PageGroupId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public int Visit { get; set; }
        public bool ShowInSlider { get; set; }
        public string Tags { get; set; }

    }
}
