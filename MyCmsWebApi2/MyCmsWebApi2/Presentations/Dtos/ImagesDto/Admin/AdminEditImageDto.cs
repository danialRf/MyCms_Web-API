namespace MyCmsWebApi2.Presentations.Dtos.ImagesDto.Admin
{
    public class AdminEditImageDto
    {
        public Guid Id { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
