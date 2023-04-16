using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Notifications;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.QueryFacade;

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
        public NewsController(INewsRepository newsRepository, IMapper mapper, ILogger<NewsController> logger, ICommentRepository commentRepository,
            INewsGroupRepository newsGroupRepository, INewsQueryFacade newsQueryFacade,IMediator mediator)
        {
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commentRepository = commentRepository;
            _newsGroupRepository = newsGroupRepository;
            _newsQueryFacade = newsQueryFacade;
            _mediator = mediator;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetAllNewsAsync()
        {
            //try
            //{
            var news = await _newsQueryFacade.GetAllNews();
            if (news == null)
            {
                _logger.LogInformation($"There is not news");
                return NotFound();
            }
            var newsDtos = _mapper.Map<List<NewsDto>>(news);

            return Ok(newsDtos);
            //}
            // catch (Exception ex)
            //{
            //  _logger.LogError(ex.Message);
            //return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred .... getting all News");
            //}

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDto>> GetNewsById(int id)
        {
            var result = await _newsQueryFacade.GetNewsById(id);
            if (result == null)
            {
                return NotFound();
            }
            await _mediator.Publish(new AddNewsVisitNotification() {NewsId = id });
            return Ok(result);

        }
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<List<Comment>>> GetCommentsByNewsId(int id)
        {
            return await _commentRepository.GetCommentsByNewsId(id);
        }

        [HttpGet("{id}/newsgroup")]
        public async Task<ActionResult<NewsGroup>> GetGroupByNewsId(int id)
        {
            return await _newsGroupRepository.GetGroupByNewsId(id);
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<IActionResult> PostNewsAsync([FromBody] AdminAddNewsDto newsDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var news = _mapper.Map<News>(newsDto);
                var result = await _newsRepository.Create(news);

                _logger.LogInformation($"Create News whit id {news.Id} ");
                return CreatedAtAction(nameof(GetNewsById), new { id = news.Id }, news);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNews(int id)
        {
            if (await _newsRepository.IsExist(id) == false)
                return NotFound();

            await _newsRepository.Delete(id);

            _logger.LogInformation($"The News whit ID {id} was Deleted");
            return Accepted();

        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNewsAsync(int id, [FromBody] AdminEditNewsDto newsDto)
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


            #endregion
        }
    }
}
