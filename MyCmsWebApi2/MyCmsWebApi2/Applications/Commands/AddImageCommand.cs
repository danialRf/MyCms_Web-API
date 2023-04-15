using MediatR;

namespace MyCmsWebApi2.Applications.Commands
{
    public class AddImageCommand : IRequest<Guid>
    {
        public IFormFile ImageFile { get; set; }
        public int? NewsId { get; set; }
        public int? NewsGroupId { get; set; }
    }
}
