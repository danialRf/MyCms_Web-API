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
    public class PageGroupController : ControllerBase
    {
        private readonly IPageGroupRepository _pageGroupRepository;
        private readonly IMapper _mapper;

        public PageGroupController(IPageGroupRepository pageGroupRepository, IMapper mapper)
        {
            _pageGroupRepository = pageGroupRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageGroupDto>>> GetAllPageGroupAsync()
        {
            var pageGroup= await _pageGroupRepository.GetAllAsync();
            var result = _mapper.Map<List<PageGroupDto>>(pageGroup);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PageGroupDto>> GetPageGroupById(int id)
        {
            if (await _pageGroupRepository.PageGroupExist(id) == false)
                return NotFound();

            var result = await _pageGroupRepository.GetPageGroupByIdAsync(id);

            return Ok(_mapper.Map<PageGroupDto>(result));
        }


        [HttpPost]
        public async Task<ActionResult<PageGroupDto>> PostPageGroupAsync([FromBody] PageGroupDto pageGroupDto)
        {
            var pageGroup = _mapper.Map<PageGroup>(pageGroupDto);
            var result = await _pageGroupRepository.InsertPageGroupAsync(pageGroup);

            return CreatedAtAction(nameof(GetPageGroupById), new { id = pageGroup.PageGroupId }, pageGroup);
        }

        [HttpPut]
        public async Task<ActionResult<PageGroupDto>> PutPageGroupAsync([FromBody] PageGroupDto pageGroupDto)
        {
            if (await _pageGroupRepository.PageGroupExist(pageGroupDto.PageGroupId) == false) 
                return NotFound();

            if (pageGroupDto == null)
                return BadRequest();

            var pageGroup = _mapper.Map<PageGroup>(pageGroupDto);
            var result = _pageGroupRepository.UpdatePageGroupAsync(pageGroup);
            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<PageGroupDto>> DeletePageGroupAsync(int id)
        {
            if (await _pageGroupRepository.PageGroupExist(id) == false)
                return NotFound();

            await _pageGroupRepository.DeletePageGroupByIdAsync(id);
            return Accepted();

        }

    }
}
