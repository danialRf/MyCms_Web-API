using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.BussinessLayer.Convertor;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.DataLayer.Services;
using MyCmsWebApi2.Dtos.ImagesDto;
using MyCmsWebApi2.Dtos.NewsDto;
using MyCmsWebApi2.Dtos.NewsDto.Admin;
using MyCmsWebApi2.Dtos.NewsGroupDto;


namespace MyCmsWebApi2.Controllers.AdminControllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;


        public ImagesController(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;

        }


        #region Get

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminShowImagesDto>> GetImageById(Guid id)
        {
            if (await _imageRepository.ImageExist(id) == false)
            {
                return NotFound();
            }
            var imageresult = await _imageRepository.GetImageByIdAsync(id);

            var showImagesDto = _mapper.Map<AdminShowImagesDto>(imageresult);
           
            
            return Ok(showImagesDto);


        }

        #endregion


        #region Post
        [HttpPost]
        public async Task<IActionResult> PostImageAsync([FromForm] AddImageDto imageDto, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            imageDto.Base64 = file.ImageToBase64();
            var image = _mapper.Map<Images>(imageDto);
            var result = await _imageRepository.InsertImageAsync(image);

            return CreatedAtAction(nameof(GetImageById), new { id = image.Id }, image);
        }
        #endregion
    }
}