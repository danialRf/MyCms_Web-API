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
        public async Task<ActionResult<IEnumerable<PageGroup>>> GetAllPageGroupAsync()
        {
            var result = await _pageGroupRepository.GetAllAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PageGroup>> GetPageGroupById(int id)
        {
            if (await _pageGroupRepository.PageGroupExist(id) == false)
                return NotFound();

            return Ok(await _pageGroupRepository.GetPageGroupByIdAsync(id));
        }


        [HttpPost]
        public async Task<ActionResult<PageGroup>> PostPageGroupAsync([FromBody] PageGroupDto pageGroupDto)
        {
            var pageGroup = _mapper.Map<PageGroup>(pageGroupDto);
            var result = await _pageGroupRepository.InsertPageGroupAsync(pageGroup);

            return CreatedAtAction(nameof(GetPageGroupById), new { id = pageGroup.PageGroupId }, pageGroup);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult<PageGroup>> DeletePageGroupAsync


        [HttpDelete("{id}")]
        public async Task<ActionResult<PageGroup>> DeletePageGroupAsync(int id)
        {
            if (await _pageGroupRepository.PageGroupExist(id) == false)
                return NotFound();

            await _pageGroupRepository.DeletePageGroupByIdAsync(id);
            return Accepted();

        }

    }
}
