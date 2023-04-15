using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Commands;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Infrastructure.Extensions;
using MyCmsWebApi2.Presentations.Dtos.ImagesDto.User;

namespace MyCmsWebApi2.Presentations.Controllers.AdminControllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ImagesController(IImageRepository imageRepository, IMapper mapper, IMediator mediator)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
            _mediator = mediator;
        }


        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            var image = await _imageRepository.GetImageByIdAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            try
            {
                return new FileContentResult(Convert.FromBase64String(image.Base64), image.ContentType);
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }


        }

        #endregion


        #region Post
        [HttpPost]
        [ProducesResponseType(typeof(SingleValue<Guid>), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddImage([FromForm] AddImageDto imageDto)
        {
            var command = _mapper.Map<AddImageCommand>(imageDto);
            var result = await _mediator.Send(command);
            return new ObjectResult(new SingleValue<Guid>(result)) { StatusCode = StatusCodes.Status201Created };
        }
        #endregion
    }
}