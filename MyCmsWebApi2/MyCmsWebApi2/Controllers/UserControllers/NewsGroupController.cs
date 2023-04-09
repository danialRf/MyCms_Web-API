using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.Dtos.NewsGroupDto.Users;

namespace MyCmsWebApi2.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsGroupController : ControllerBase
    {
        private readonly INewsGroupRepository _newsGroupRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NewsGroupController> _logger;

        public NewsGroupController(INewsGroupRepository newsGroupRepository, IMapper mapper, ILogger<NewsGroupController> logger)
        {
            _newsGroupRepository = newsGroupRepository ?? throw new ArgumentNullException(nameof(newsGroupRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserShowNewsGroupDto>>> GetAllNewsGroupAsync()
        {
            var newsGroup = await _newsGroupRepository.GetAllAsync();
            if (newsGroup == null)
            {
                _logger.LogInformation($"There is not newsGroup");
                return NotFound();
            }
            return Ok(_mapper.Map<List<UserShowNewsGroupDto>>(newsGroup));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserShowNewsGroupDto>> GetNewsGroupByIdAsync(int id)
        {
            var newsGroup = await _newsGroupRepository.GetNewsGroupByIdAsync(id);
            if (newsGroup == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserShowNewsGroupDto>(newsGroup));
        }
    }
}
