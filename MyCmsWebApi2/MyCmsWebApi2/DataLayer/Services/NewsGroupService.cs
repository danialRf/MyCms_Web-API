using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.DataLayer.Context;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;

namespace MyCmsWebApi2.DataLayer.Services;

public class NewsGroupService:INewsGroupRepository
{
    private readonly CmsDbContext _context;

    public NewsGroupService(CmsDbContext context)
    {
        _context = context;
    }

    public async Task<List<NewsGroup>> GetAllAsync()
    {
       return await _context.NewsGroup.ToListAsync();
    }

    public async Task<NewsGroup> GetNewsGroupByIdAsync(int id)
    {
        return await _context.NewsGroup.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<NewsGroup> InsertNewsGroupAsync(NewsGroup newsGroup)
    {
        await _context.AddAsync(newsGroup);
        await _context.SaveChangesAsync();
        return newsGroup;
    }

    public async Task UpdateNewsGroupAsync(NewsGroup newsGroup)
    { 
        _context.Entry(newsGroup).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNewsGroupByIdAsync(int id)
    {
         _context.Remove(new NewsGroup { Id = id });
         await _context.SaveChangesAsync();
    }

    public async Task<bool> NewsGroupExistAsync(int id)
    {
        var result = await _context.NewsGroup.AnyAsync(p=>p.Id== id);
        return result;
    }
}