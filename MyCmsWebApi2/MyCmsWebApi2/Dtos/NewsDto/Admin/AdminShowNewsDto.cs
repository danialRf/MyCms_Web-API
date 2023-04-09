using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.Dtos.NewsDto.Admin
{
    public class AdminShowNewsDto
    {
        public int Id { get; set; }
        public int NewsGroupId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Tags { get; set; } = string.Empty; public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int Visit { get; set; }


    }
}
