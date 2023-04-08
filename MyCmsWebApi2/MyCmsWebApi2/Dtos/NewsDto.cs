namespace MyCmsWebApi2.Dtos
{
    public class NewsDto
    {
        public int? Id { get; set; }
        public int NewsGroupId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public int Visit { get; set; }
        public bool ShowInSlider { get; set; }
        public string Tags { get; set; }
           
    }
}
