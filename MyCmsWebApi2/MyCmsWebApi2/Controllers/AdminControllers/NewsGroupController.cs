using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.Dtos.NewsGroupDto;
using MyCmsWebApi2.Dtos.NewsGroupDto.NewsGroupDto;
using Serilog;
using Serilog.Core;

namespace MyCmsWebApi2.Controllers.AdminControllers
{
    [Route("api/admin/[controller]")]
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
        public async Task<ActionResult<IEnumerable<ShowNewsGroupDto>>> GetAllNewsGroupAsync()
        {
            var newsGroup = await _newsGroupRepository.GetAllAsync();
            var result = _mapper.Map<List<ShowNewsGroupDto>>(newsGroup);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ShowNewsGroupDto>> GetNewsGroupById(int id)
        {
            if (await _newsGroupRepository.NewsGroupExist(id) == false)
            {
                return NotFound();
            }
                

            var result = await _newsGroupRepository.GetNewsGroupByIdAsync(id);

            return Ok(_mapper.Map<ShowNewsGroupDto>(result));
        }


        [HttpPost]
        public async Task<ActionResult<ShowNewsGroupDto>> PostNewsGroupAsync([FromBody] AddNewsGroupDto newsGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newsGroup = _mapper.Map<NewsGroup>(newsGroupDto);
            var result = await _newsGroupRepository.InsertNewsGroupAsync(newsGroup);

            _logger.LogInformation($"Create NewsGroup whit id {newsGroup.Id} ");
            return CreatedAtAction(nameof(GetNewsGroupById), new { id = newsGroup.Id }, newsGroup);
        }

        [HttpPut]
        public async Task<ActionResult> PutPageGroupAsync([FromBody] EditNewsGroupDto newsGroupDto)
        {
            if (await _newsGroupRepository.NewsGroupExist(newsGroupDto.Id) == false)
            {
                _logger.LogInformation($"GroupTitle '{newsGroupDto.GroupTitle}' Not Found.");
                return NotFound();
            }


            if (newsGroupDto == null)
                return BadRequest();

            var newsGroup = _mapper.Map<NewsGroup>(newsGroupDto);
            var result = _newsGroupRepository.UpdateNewsGroupAsync(newsGroup);

            _logger.LogInformation($"NewsGroup whit id {newsGroupDto.Id} was edited");
            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNewsGroupAsync(int id)
        {
            if (await _newsGroupRepository.NewsGroupExist(id) == false)
            {
                return NotFound();
            }
                

            await _newsGroupRepository.DeleteNewsGroupByIdAsync(id);

            _logger.LogInformation($"The NewsGroup whit ID {id} was Deleted");
            return Accepted();

        }

    }
}
