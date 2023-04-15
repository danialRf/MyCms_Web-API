using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.Applications.Repository;

public interface INewsRepository
{
    Task<List<News>> GetAllAsync();
    Task<News> GetNewsByIdAsync(int id);
    Task<News> InsertNewsAsync(News news);
    Task UpdateNewsAsync(News news);
    Task DeleteNewsByIdAsync(int id);
    Task<bool> NewsExist(int id);

}