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
using MyCmsWebApi2.Profiles;
using System.IO;


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
        public async Task<ActionResult> GetImageById(Guid id)
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
        public async Task<IActionResult> PostImageAsync([FromForm] AddImageDto imageDto)
        {
            if (imageDto.File == null || imageDto.File.Length == 0)
                return BadRequest("No file uploaded.");
            if (imageDto.NewsGroupId==null && imageDto.NewsId == null)
            {
                return BadRequest("No Owner Seleted");
            }     
            else if (imageDto.NewsGroupId!=null && imageDto.NewsId != null)
            {
                return BadRequest("Can't select two owners");
            }
            var image = new Images()
            {
                Base64 = imageDto.File.ImageToBase64(),
                CreateDate = DateTime.Now,
                Id = Guid.NewGuid(),
                ImageName = imageDto.File.Name,
                NewsGroupId = imageDto.NewsGroupId,
                NewsId = imageDto.NewsId,
                ContentType = imageDto.File.ContentType
            };
            var result = await _imageRepository.InsertImageAsync(image);

            return CreatedAtAction(nameof(GetImageById), new { id = image.Id }, image);
        }
        #endregion
    }
}