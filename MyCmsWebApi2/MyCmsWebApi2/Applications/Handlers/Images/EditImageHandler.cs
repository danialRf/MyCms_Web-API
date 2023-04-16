using MediatR;
using MyCmsWebApi2.Applications.Commands.Images;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Infrastructure.Convertor;
using MyCmsWebApi2.Infrastructure.Exceptions.BaseException;
using System.Buffers.Text;
using System.Net;

namespace MyCmsWebApi2.Applications.Handlers.Images
{
    public class EditImageHandler : IRequestHandler<EditImageCommand, Guid>
    {

        private readonly IImageRepository _imageRepository;

        public EditImageHandler(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<Guid> Handle(EditImageCommand request, CancellationToken cancellationToken)
        {
            if (request.ImageFile == null || request.ImageFile.Length == 0)
                throw new PhoenixGeneralException("حاجی یه عکسی انتخاب کن ناموصا");

            var image = await _imageRepository.GetById(request.Id);
            if (image == null)
            {
                throw new PhoenixGeneralException("حاجی همچین عکسی نداریم");
            }

            image.Update(request.ImageFile.ImageToBase64());
            var result = await _imageRepository.Update(image);
            return result;
        }
    }
}
