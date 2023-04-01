using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.DataLayer.Context;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;

namespace MyCmsWebApi2.DataLayer.Services;

public class PageGroupService:IPageGroupRepository
{
    private readonly CmsDbContext _context;

    public PageGroupService(CmsDbContext context)
    {
        _context = context;
    }

    public async Task<List<PageGroup>> GetAllAsync()
    {
       return await _context.pageGroup.ToListAsync();
    }

    public async Task<PageGroup> GetPageGroupByIdAsync(int id)
    {
        return await _context.pageGroup.FirstOrDefaultAsync(p => p.PageGroupId == id);
    }

    public async Task<PageGroup> InsertPageGroupAsync(PageGroup pageGroup)
    {
        await _context.AddAsync(pageGroup);
        return pageGroup;
    }

    public async Task UpdatePageGroupAsync(PageGroup pageGroup)
    { 
        _context.Entry(pageGroup).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletePageGroupByIdAsync(int id)
    {
         _context.Remove(new PageGroup { PageGroupId = id });
         await _context.SaveChangesAsync();
    }
}