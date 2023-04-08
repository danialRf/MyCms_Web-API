using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.Dtos;

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
            _newsRepository = newsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetAllNewsAsync()
        {
            try
            {
                var news = await _newsRepository.GetAllAsync();
                if (news == null)
                {
                    return NotFound();
                }
                var newsDtos = _mapper.Map<List<NewsDto>>(news);

                return Ok(newsDtos);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred during getting all pagesasync");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDto>> GetNewsById(int id)
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
        public async Task<ActionResult<NewsDto>> PostNewNewsAsync([FromBody] NewsDto newsDto)
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
                return CreatedAtAction(nameof(GetNewsById), new { id = news.Id }, news);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsGroup>> DeleteNews(int id)
        {
            if (await _newsRepository.NewsExist(id) == false)
                return NotFound();

            await _newsRepository.DeleteNewsByIdAsync(id);
            return Accepted();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NewsDto>> UpdateNewsAsync(int id, [FromBody] NewsDto newsDto)
        {
            var existingNews = await _newsRepository.GetNewsByIdAsync(id);
            if (existingNews == null)
            {
                return NotFound();
            }

            var updatedNews = _mapper.Map<News>(newsDto);
            updatedNews.Id = id;

            await _newsRepository.UpdateNewsAsync(updatedNews);

            return Ok(_mapper.Map<NewsDto>(updatedNews));
        }



    }
}
