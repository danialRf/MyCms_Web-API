using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCmsWebApi2.DataLayer.Repository;

namespace MyCmsWebApi2.Controllers.AdminControllers;
[ApiController]
[Route("api/admin/[controller]")]

public class PageController:ControllerBase
{
    
    private readonly IPageRepository _pageRepository;

    public PageController(IPageRepository pageRepository)
    {
        _pageRepository = pageRepository;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Page>>> GetAllPagesAsync()
    {
        var result = await _pageRepository.GetAllAsync();

        return Ok(result);
    }

    [HttpGet ("{id}")]
    public async Task<ActionResult> GetPageByIdAsync (int id)
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
    public async Task<ActionResult<MyCmsWebApi2.DataLayer.Model.Page>> AddNewPageAsync(MyCmsWebApi2.DataLayer.Model.Page page)
    {
        var result = await _pageRepository.InsertPageAsync(page);
        return CreatedAtAction("GetPage",new { id = page.PageId }, page);

    }



}