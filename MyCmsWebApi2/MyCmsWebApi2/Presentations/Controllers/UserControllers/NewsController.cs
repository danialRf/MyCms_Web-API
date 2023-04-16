using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Presentations.Controllers.AdminControllers;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;
using MyCmsWebApi2.Presentations.QueryFacade;

namespace MyCmsWebApi2.Presentations.Dtos.NewsDto.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<Controllers.AdminControllers.NewsController> _logger;
        private readonly INewsGroupRepository _newsGroupRepository;
        private readonly INewsQueryFacade _newsQueryFacade;
        public NewsController(INewsRepository newsRepository, IMapper mapper, ILogger<Controllers.AdminControllers.NewsController> logger, ICommentRepository commentRepository, INewsGroupRepository newsGroupRepository, INewsQueryFacade newsQueryFacade)
        {
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commentRepository = commentRepository;
            _newsGroupRepository = newsGroupRepository;
            _newsQueryFacade = newsQueryFacade;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetAllNewsAsync()
        {
            try
            {
                var news = await _newsQueryFacade.GetAllNews();
                if (news == null)
                {
                    _logger.LogInformation($"There is not news");
                    return NotFound();
                }
                var newsDtos = _mapper.Map<List<NewsDto>>(news);

                return Ok(newsDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred during getting all pagesasync");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserNewsByIdDto>> GetNewsById(int id)
        {
            var result = await _newsQueryFacade.GetNewsById(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<List<Comment>>> GetCommentsByNewsId(int id)
        {
            return await _commentRepository.GetCommentsByNewsId(id);
        }
    }
}
