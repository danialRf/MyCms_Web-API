using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Persistences.EF;

namespace MyCmsWebApi2.Persistences.Repositories;

public class NewsRepository : INewsRepository
{
    private readonly CmsDbContext _context;


    public NewsRepository(CmsDbContext context)
    {
        _context = context;
    }

    public async Task<IList<News>> GetAll()
    {
        return await _context.News.ToListAsync();
    }

    public async Task<News> GetById(int id)
    {
        return await _context.News.Include(x => x.Images)
            .FirstOrDefaultAsync(p => p.Id == id);

    }



    public async Task<int> Create(News news)
    {
        await _context.AddAsync(news);
        await _context.SaveChangesAsync();
        return news.Id;
    }

    public async Task<int> Update(News news)
    {
        _context.Entry(news).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return news.Id;
    }

    public async Task<int> Delete(int id)
    {
        var news = await _context.News.Include(n => n.Images).FirstOrDefaultAsync(n => n.Id == id);
      
            _context.Images.RemoveRange(news.Images);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return id;
        
    }

    public async Task<bool> IsExist(int id)
    {
        var result = await _context.News.AnyAsync(p => p.Id == id);
        return result;
    }
}

