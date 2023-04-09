//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using MyCmsWebApi2.DataLayer.Repository;
//using MyCmsWebApi2.Dtos.ImagesDto;
//using MyCmsWebApi2.Dtos.NewsDto;
//using MyCmsWebApi2.Dtos.NewsGroupDto;

//namespace MyCmsWebApi2.Controllers.AdminControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImagesController : ControllerBase
//    {
//        private readonly IImageRepository _imageRepository;
//        private readonly IMapper _mapper;
//        private readonly string _imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
//        public class ImageService : IImageService
//        {
//            private readonly string _imagePath;

//            public ImageService(IWebHostEnvironment env, IConfiguration config)
//            {
//                _imagePath = Path.Combine(env.ContentRootPath, config["ImageSettings:ImagePath"]);
//            }

//            public ImagesController(IImageRepository imageRepository, IMapper mapper)
//        {
//            this._imageRepository = imageRepository;
//            _mapper = mapper;
//        }




//        [HttpGet("images/{imageName}")]
//        public IActionResult GetImage(string imageName)
//        {

//            var imagePath = Path.Combine(_imagePath, imageName);

//            if (!System.IO.File.Exists(imagePath))
//            {
//                return NotFound();
//            }

//            var imageFile = System.IO.File.OpenRead(imagePath);
//            return File(imageFile, "image/jpeg");
//        }


//    }

//}
