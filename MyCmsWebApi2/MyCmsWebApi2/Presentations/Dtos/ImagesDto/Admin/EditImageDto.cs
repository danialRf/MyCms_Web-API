namespace MyCmsWebApi2.Presentations.Dtos.ImagesDto.Admin
{
    public class EditImageDto
    {
        public Guid Id { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
