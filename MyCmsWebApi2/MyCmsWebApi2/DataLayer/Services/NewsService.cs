using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.DataLayer.Context;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.Dtos;

namespace MyCmsWebApi2.DataLayer.Services;

public class NewsService:INewsRepository
{
    private readonly CmsDbContext _context;
   

    public NewsService(CmsDbContext context)
    {
        _context = context;
    }

    public async Task<List<News>> GetAllAsync()
    {
        return await _context.News.ToListAsync();
    }

    public async Task<News> GetNewsByIdAsync(int id)
    {
        return await _context.News.Include(x=>x.Images)
            .FirstOrDefaultAsync(p => p.Id == id);

    }

   

    public async Task<News> InsertNewsAsync(News news)
    {
        await _context.AddAsync(news);
        await _context.SaveChangesAsync();
        return news;
    }

    public async Task UpdateNewsAsync(News news)
    {
        _context.Entry(news).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNewsByIdAsync(int id)
    {
        //_context.Entry(id).State = EntityState.Deleted;
        _context.Remove(new News { Id = id });
        await _context.SaveChangesAsync();
    }

    public async Task<bool> NewsExist(int id)
    {
        var result = await _context.News.AnyAsync(p => p.Id == id);
        return result;
    }

   

    
}

