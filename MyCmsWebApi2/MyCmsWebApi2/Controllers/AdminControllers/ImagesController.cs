using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.Dtos.ImagesDto;
using MyCmsWebApi2.Dtos.NewsDto;
using MyCmsWebApi2.Dtos.NewsGroupDto;

namespace MyCmsWebApi2.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImagesController(IImageRepository imageRepository, IMapper mapper)
        {
            this._imageRepository = imageRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowImagesDto>>> GetAllImagesAsync()
        {
            try
            {
                var news = await _imageRepository.GetAllAsync();
                if (news == null)
                {
                    return NotFound();
                }
                var imagesDtos = _mapper.Map<List<ShowImagesDto>>(news);

                return Ok(imagesDtos);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred during getting all pagesasync");
            }



            [HttpGet("{id}")]
            public async Task<ActionResult<ShowImagesDto>> GetImagesByIdAsync(int id)
            {
                if (await _imageRepository.ImageExist(id) == false)
                    return NotFound();

                var result = await _imageRepository.GetImageByIdAsync(id);

                return Ok(_mapper.Map<ShowImagesDto>(result));
            }
        }
    }
}
