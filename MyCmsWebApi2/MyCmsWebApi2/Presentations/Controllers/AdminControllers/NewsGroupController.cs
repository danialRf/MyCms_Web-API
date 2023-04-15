using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Admin;

namespace MyCmsWebApi2.Presentations.Controllers.AdminControllers
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
        public async Task<ActionResult<IEnumerable<AdminShowNewsGroupDto>>> GetAllNewsGroupAsync()
        {
            var newsGroup = await _newsGroupRepository.GetAllAsync();
            var result = _mapper.Map<List<AdminShowNewsGroupDto>>(newsGroup);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AdminShowNewsGroupDto>> GetNewsGroupById(int id)
        {
            if (await _newsGroupRepository.NewsGroupExistAsync(id) == false)
            {
                return NotFound();
            }


            var result = await _newsGroupRepository.GetNewsGroupByIdAsync(id);

            return Ok(_mapper.Map<AdminShowNewsGroupDto>(result));
        }


        [HttpPost]
        public async Task<ActionResult<AdminShowNewsGroupDto>> PostNewsGroupAsync([FromBody] AdminAddNewsGroupDto newsGroupDto)
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
        public async Task<ActionResult> PutPageGroupAsync([FromBody] AdminEditNewsGroupDto newsGroupDto)
        {
            if (await _newsGroupRepository.NewsGroupExistAsync(newsGroupDto.Id) == false)
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
            if (await _newsGroupRepository.NewsGroupExistAsync(id) == false)
            {
                return NotFound();
            }


            await _newsGroupRepository.DeleteNewsGroupByIdAsync(id);

            _logger.LogInformation($"The NewsGroup whit ID {id} was Deleted");
            return Accepted();

        }

    }
}
