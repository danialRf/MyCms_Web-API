using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Users;

namespace MyCmsWebApi2.Presentations.Controllers.UserControllers
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
        public async Task<ActionResult<IEnumerable<UserNewsGroupDto>>> GetAllNewsGroupAsync()
        {
            var newsGroup = await _newsGroupRepository.GetAll();
            if (newsGroup == null)
            {
                _logger.LogInformation($"There is not newsGroup");
                return NotFound();
            }
            return Ok(_mapper.Map<List<UserNewsGroupDto>>(newsGroup));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserNewsGroupDto>> GetNewsGroupByIdAsync(int id)
        {
            var newsGroup = await _newsGroupRepository.GetById(id);
            if (newsGroup == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserNewsGroupDto>(newsGroup));
        }

    }
}
