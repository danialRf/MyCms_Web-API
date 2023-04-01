using Azure;
using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.DataLayer.Context;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;

namespace MyCmsWebApi2.DataLayer.Services;

public class PageService:IPageRepository
{
    private readonly CmsDbContext _context;

    public PageService(CmsDbContext context)
    {
        _context = context;
    }


    public async Task<List<Page>> GetAllAsync()
    {
        return await _context.page.ToListAsync();
    }

    public async Task<Page> GetPageByIdAsync(int id)
    {
        return await _context.page.FirstOrDefaultAsync(p => p.PageId == id);

    }

    public async Task<Page> InsertPageAsync(Page page)
    {
        await _context.AddAsync(page);
        await _context.SaveChangesAsync();
        return page;
    }

    public async Task UpdatePageAsync(Page page)
    {
        _context.Entry(page).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletePageByIdAsync(int id)
    {
        //_context.Entry(id).State = EntityState.Deleted;
        _context.Remove(new Page { PageId = id });
        await _context.SaveChangesAsync();
    }

    public async Task<bool> PageExist(int id)
    {
        var result = await _context.page.AnyAsync(p => p.PageId == id);
        return result;
    }
}