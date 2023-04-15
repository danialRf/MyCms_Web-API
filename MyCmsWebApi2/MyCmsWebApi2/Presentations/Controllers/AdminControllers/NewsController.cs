﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;
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
        public NewsController(INewsRepository newsRepository, IMapper mapper, ILogger<NewsController> logger, ICommentRepository commentRepository, INewsGroupRepository newsGroupRepository, INewsQueryFacade newsQueryFacade)
        {
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commentRepository = commentRepository;
            _newsGroupRepository = newsGroupRepository;
            _newsQueryFacade = newsQueryFacade;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminNewsDto>>> GetAllNewsAsync()
        {
            try
            {
                var news = await _newsRepository.GetAll();
                if (news == null)
                {
                    _logger.LogInformation($"There is not news");
                    return NotFound();
                }
                var newsDtos = _mapper.Map<List<AdminNewsDto>>(news);

                return Ok(newsDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred during getting all pagesasync");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminNewsDto>> GetNewsById(int id)
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

        [HttpGet("{id}/newsgroup")]
        public async Task<ActionResult<NewsGroup>> GetGroupByNewsId(int id)
        {
            return await _newsGroupRepository.GetGroupByNewsId(id);
        }


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
        public async Task<ActionResult<AdminEditNewsDto>> UpdateNewsAsync(int id, [FromBody] AdminEditNewsDto newsDto)
        {
            var existingNews = await _newsRepository.GetById(id);
            if (existingNews == null)
            {
                return NotFound();
            }

            var updatedNews = _mapper.Map<News>(newsDto);
            updatedNews.Id = id;

            await _newsRepository.Update(updatedNews);
            _logger.LogInformation($"NewsGroup whit id {newsDto.Id} was edited");
            return Ok(_mapper.Map<AdminEditNewsDto>(updatedNews));
        }
    }
}
