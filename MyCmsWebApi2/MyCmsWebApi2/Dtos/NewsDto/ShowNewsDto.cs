using MyCmsWebApi2.DataLayer.Model;
namespace MyCmsWebApi2.Dtos.NewsDto
{
    public class ShowNewsDto
    {
        public int Id { get; set; }
        public int NewsGroupId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Tags { get; set; } = String.Empty; public string Title { get; set; } = String.Empty;
        public string ShortDescription { get; set; } = String.Empty;
        public string Text { get; set; } = String.Empty;
        public int Visit { get; set; }


    }
}
