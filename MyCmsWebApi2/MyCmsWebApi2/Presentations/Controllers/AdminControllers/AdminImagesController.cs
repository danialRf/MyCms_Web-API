using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Commands.Images;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Infrastructure.Extensions;
using MyCmsWebApi2.Persistences.Repositories;
using MyCmsWebApi2.Presentations.Dtos.ImagesDto.Admin;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyCmsWebApi2.Presentations.Controllers.AdminControllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AdminImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<AdminImagesController> _logger;

        public AdminImagesController(IImageRepository imageRepository, IMapper mapper, IMediator mediator, ILogger<AdminImagesController> logger)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            var image = await _imageRepository.GetById(id);

            if (image == null)
            {
                return NotFound();
            }
            return new FileContentResult(Convert.FromBase64String(image.Base64), image.ContentType);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SingleValue<Guid>), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddImage([FromForm] AdminAddImageDto imageDto)
        {
            var command = _mapper.Map<AddImageCommand>(imageDto);
            var result = await _mediator.Send(command);
            return new ObjectResult(new SingleValue<Guid>(result)) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut]
        [ProducesResponseType(typeof(SingleValue<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateImage([FromForm] AdminEditImageDto editImage)
        {

            var command = _mapper.Map<EditImageCommand>(editImage);
            var result = await _mediator.Send(command);
            return new ObjectResult(new SingleValue<Guid>(result)) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteImage(Guid id)
        {
            if (await _imageRepository.IsExist(id) == false)
                return NotFound();

            await _imageRepository.Delete(id);

            _logger.LogInformation($"The News whit ID {id} was Deleted");
            return Accepted();

        }
    }
}







