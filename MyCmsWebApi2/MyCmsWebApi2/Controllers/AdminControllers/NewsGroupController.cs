using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.Dtos;

namespace MyCmsWebApi2.Controllers.AdminControllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class NewsGroupController : ControllerBase
    {
        private readonly INewsGroupRepository _newsGroupRepository;
        private readonly IMapper _mapper;

        public NewsGroupController(INewsGroupRepository newsGroupRepository, IMapper mapper)
        {
            _newsGroupRepository = newsGroupRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsGroupDto>>> GetAllNewsGroupAsync()
        {
            var newsGroup= await _newsGroupRepository.GetAllAsync();
            var result = _mapper.Map<List<NewsGroupDto>>(newsGroup);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<NewsGroupDto>> GetNewsGroupById(int id)
        {
            if (await _newsGroupRepository.NewsGroupExist(id) == false)
                return NotFound();

            var result = await _newsGroupRepository.GetNewsGroupByIdAsync(id);

            return Ok(_mapper.Map<NewsGroupDto>(result));
        }


        [HttpPost]
        public async Task<ActionResult<NewsGroupDto>> PostNewsGroupAsync([FromBody] NewsGroupDto newsGroupDto)
        {
            var newsGroup = _mapper.Map<NewsGroup>(newsGroupDto);
            var result = await _newsGroupRepository.InsertNewsGroupAsync(newsGroup);

            return CreatedAtAction(nameof(GetNewsGroupById), new { id = newsGroup.Id }, newsGroup);
        }

        [HttpPut]
        public async Task<ActionResult<NewsGroupDto>> PutPageGroupAsync([FromBody] NewsGroupDto newsGroupDto)
        {
            if (await _newsGroupRepository.NewsGroupExist(newsGroupDto.Id) == false) 
                return NotFound();

            if (newsGroupDto == null)
                return BadRequest();

            var newsGroup = _mapper.Map<NewsGroup>(newsGroupDto);
            var result = _newsGroupRepository.UpdateNewsGroupAsync(newsGroup);
            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsGroupDto>> DeleteNewsGroupAsync(int id)
        {
            if (await _newsGroupRepository.NewsGroupExist(id) == false)
                return NotFound();

            await _newsGroupRepository.DeleteNewsGroupByIdAsync(id);
            return Accepted();

        }

    }
}
