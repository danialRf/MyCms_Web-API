using MediatR;

namespace MyCmsWebApi2.Applications.Commands.Images
{
    public class EditImageCommand: IRequest<Guid>
    {
        public Guid Id { get; set; }    
        public IFormFile? ImageFile { get; set; }
    }
}
