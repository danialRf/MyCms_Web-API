using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.Dtos;
using Page = MyCmsWebApi2.DataLayer.Model.Page;

namespace MyCmsWebApi2.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/admin/[controller]")]

    public class PageController : ControllerBase
    {

        private readonly IPageRepository _pageRepository;
        private readonly IMapper _mapper;

        public PageController(IPageRepository pageRepository, IMapper mapper)
        {
            _pageRepository = pageRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageDto>>> GetAllPagesAsync()
        {
            try
            {
                var pages = await _pageRepository.GetAllAsync();
                if (pages == null)
                {
                    return NotFound();
                }
                var pageDtos = _mapper.Map<List<PageDto>>(pages);

                return Ok(pageDtos);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred during getting all pagesasync");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PageDto>> GetPageById(int id)
        {
            var result = await _pageRepository.GetPageByIdAsync(id);
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
        public async Task<ActionResult<PageDto>> PostNewPageAsync([FromBody] PageDto pageDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var page = _mapper.Map<Page>(pageDto);
                var result = await _pageRepository.InsertPageAsync(page);
                pageDto.PageId = result.PageId;
                return CreatedAtAction(nameof(GetPageById), new { id = page.PageId }, page);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PageGroup>> DeletePage(int id)
        {
            if (await _pageRepository.PageExist(id) == false)
                return NotFound();

            await _pageRepository.DeletePageByIdAsync(id);
            return Accepted();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PageDto>> UpdatePageAsync(int id, [FromBody] PageDto pageDto)
        {
            var existingPage = await _pageRepository.GetPageByIdAsync(id);
            if (existingPage == null)
            {
                return NotFound();
            }

            var updatedPage = _mapper.Map<Page>(pageDto);
            updatedPage.PageId = id;

            await _pageRepository.UpdatePageAsync(updatedPage);

            return Ok(_mapper.Map<PageDto>(updatedPage));
        }



    }
}
