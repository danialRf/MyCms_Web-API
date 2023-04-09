using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.Dtos;
using MyCmsWebApi2.Dtos.NewsDto;

namespace MyCmsWebApi2.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/admin/[controller]")]

    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NewsController> _logger;

        public NewsController(INewsRepository newsRepository, IMapper mapper, ILogger<NewsController> logger)
        {
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowNewsDto>>> GetAllNewsAsync()
        {
            try
            {
                var news = await _newsRepository.GetAllAsync();
                if (news == null)
                {
                    _logger.LogInformation($"There is not news");
                    return NotFound();
                }
                var newsDtos = _mapper.Map<List<ShowNewsDto>>(news);

                return Ok(newsDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred during getting all pagesasync");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowNewsDto>> GetNewsById(int id)
        {
            var result = await _newsRepository.GetNewsByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpPost]
        public async Task<ActionResult<AddNewsDto>> PostNewNewsAsync([FromBody] AddNewsDto newsDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var news = _mapper.Map<News>(newsDto);
                var result = await _newsRepository.InsertNewsAsync(news);
                newsDto.Id = result.Id;

                _logger.LogInformation($"Create News whit id {newsDto.Id} ");
                return CreatedAtAction(nameof(GetNewsById), new { id = news.Id }, news);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EditNewsDto>> DeleteNews(int id)
        {
            if (await _newsRepository.NewsExist(id) == false)
                return NotFound();

            await _newsRepository.DeleteNewsByIdAsync(id);

            _logger.LogInformation($"The News whit ID {id} was Deleted");
            return Accepted();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EditNewsDto>> UpdateNewsAsync(int id, [FromBody] EditNewsDto newsDto)
        {
            var existingNews = await _newsRepository.GetNewsByIdAsync(id);
            if (existingNews == null)
            {
                return NotFound();
            }

            var updatedNews = _mapper.Map<News>(newsDto);
            updatedNews.Id = id;

            await _newsRepository.UpdateNewsAsync(updatedNews);
            _logger.LogInformation($"NewsGroup whit id {newsDto.Id} was edited");
            return Ok(_mapper.Map<EditNewsDto>(updatedNews));
        }
    }
}
