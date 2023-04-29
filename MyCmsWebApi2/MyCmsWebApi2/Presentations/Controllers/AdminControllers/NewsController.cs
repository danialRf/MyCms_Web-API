using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Notifications;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.QueryFacade;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;
using Microsoft.Extensions.Caching.Memory;
using MyCmsWebApi2.Infrastructure.Extensions;
using MyCmsWebApi2.Applications.Commands.NewsCommand;

namespace MyCmsWebApi2.Presentations.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/admin/[controller]")]

    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NewsController> _logger;
        private readonly INewsGroupRepository _newsGroupRepository;
        private readonly INewsQueryFacade _newsQueryFacade;
        private readonly IMediator _mediator;
        private readonly ICommentQueryFacade _commentQueryFacade;
        private readonly IMemoryCache _memoryCache;
        public NewsController(INewsRepository newsRepository, IMapper mapper, ILogger<NewsController> logger, ICommentRepository commentRepository,
            INewsGroupRepository newsGroupRepository, INewsQueryFacade newsQueryFacade, IMediator mediator, ICommentQueryFacade commentQueryFacade, IMemoryCache memoryCache)
        {
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commentRepository = commentRepository;
            _newsGroupRepository = newsGroupRepository;
            _newsQueryFacade = newsQueryFacade;
            _mediator = mediator;
            _commentQueryFacade = commentQueryFacade;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminNewsDto>>> GetAllNews()
        {

            var news = await _newsQueryFacade.AdminGetAllNews();
            if (news == null)
            {
                _logger.LogInformation($"There is not news");
                return NotFound();
            }
            var newsDto = _mapper.Map<List<AdminNewsDto>>(news);

            return Ok(newsDto);



        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminNewsDto>> GetNewsById(int id)
        {
            var result = await _newsQueryFacade.AdminGetNewsById(id);
            if (result == null)
            {
                return NotFound();
            }
            await _mediator.Publish(new AddNewsVisitNotification() { NewsId = id });
            return Ok(result);

        }

        [HttpGet("{id}/comments")]
        public async Task<ActionResult<List<AdminCommentsDto>>> GetCommentsByNewsId(int id)
        {
            var comment = await _commentQueryFacade.AdminGetCommentByNewsId(id);
            return Ok(comment);
        }

        [HttpGet("{id}/newsgroup")]
        public async Task<ActionResult<AdminNewsDto>> GetNewsByGroupIdAsync(int id)
        {
            return Ok(await _newsQueryFacade.AdminGetNewsByGroupId(id));

        }

        [HttpPost]
        public async Task<IActionResult> PostNews([FromBody] AdminAddNewsDto newsDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var news = _mapper.Map<News>(newsDto);
            //var result = await _newsRepository.Create(news);
            //_memoryCache.Remove("topNews");
            //_logger.LogInformation($"Create News whit id {news.Id} ");
            //return CreatedAtAction(nameof(GetNewsById), new { id = news.Id }, news);

            var command = _mapper.Map<AddNewsCommand>(newsDto);
            var result = await _mediator.Send(command);
            _logger.LogInformation($"Create Comment with resultId = {result} ");
            return new ObjectResult(new SingleValue<int>(result)) { StatusCode = StatusCodes.Status201Created };

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNews(int id)
        {
            if (await _newsRepository.IsExist(id) == false)
                return NotFound();

            await _newsRepository.Delete(id);

            _logger.LogInformation($"The News whit ID {id} was Deleted");
            return Accepted();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNews(int id, [FromBody] AdminEditNewsDto newsDto)
        {
            var existingNews = await _newsRepository.GetById(id);
            if (existingNews == null)
            {
                return NotFound();
            }
            existingNews.UpdateNews(id, newsDto.Id, newsDto.Title, newsDto.ShortDescription, newsDto.Text, newsDto.ShowInSlider, newsDto.Tags);

            await _newsRepository.Update(existingNews);
            _logger.LogInformation($"NewsGroup whit id {id} was edited");
            return Ok();

        }
    }
}
