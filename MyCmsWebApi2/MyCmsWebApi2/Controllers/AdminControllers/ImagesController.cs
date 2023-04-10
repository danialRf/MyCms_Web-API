using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.BussinessLayer.Convertor;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.DataLayer.Services;
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
            _imageRepository = imageRepository;
            _mapper = mapper;

        }

        [HttpPost("image")]
        public async Task<ActionResult> PostImageAsync(IFormFile file)
        {
            
            return Ok(await _imageRepository.InsertImageAsync(new Images
            {
                ImageName = file.Name,
                Base64 = file.ImageToBase64()
            }));
        }

    }
}