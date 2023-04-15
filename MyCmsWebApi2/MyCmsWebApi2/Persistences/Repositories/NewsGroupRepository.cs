using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Persistences.EF;

namespace MyCmsWebApi2.Persistences.Repositories;

public class NewsGroupRepository : INewsGroupRepository
{
    private readonly CmsDbContext _context;

    public NewsGroupRepository(CmsDbContext context)
    {
        _context = context;
    }

    public async Task<IList<NewsGroup>> GetAll()
    {
        return await _context.NewsGroup.ToListAsync();
    }

    public async Task<NewsGroup> GetById(int id)
    {
        return await _context.NewsGroup.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<int> Create(NewsGroup newsGroup)
    {
        await _context.AddAsync(newsGroup);
        await _context.SaveChangesAsync();
        return newsGroup.Id;
    }

    public async Task<int> Update(NewsGroup newsGroup)
    {
        _context.Entry(newsGroup).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return newsGroup.Id;
    }

    public async Task<int> Delete(int id)
    {
        _context.Remove(new NewsGroup { Id = id });
        await _context.SaveChangesAsync();
        return id;
    }

    public async Task<bool> IsExist(int id)
    {
        var result = await _context.NewsGroup.AnyAsync(p => p.Id == id);
        return result;
    }

    public async Task<NewsGroup> GetGroupByNewsId(int newsId)
    {
        var result = await _context.NewsGroup
                              .Include(g => g.News)
                              .FirstOrDefaultAsync(g => g.News.Any(n => n.Id == newsId));

        return result;
    }
}