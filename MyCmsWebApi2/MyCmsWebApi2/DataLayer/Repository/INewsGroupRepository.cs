using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.Repository;

public interface INewsGroupRepository
{
    Task<List<NewsGroup>> GetAllAsync();
    Task<NewsGroup> GetNewsGroupByIdAsync(int id);
    Task<NewsGroup> InsertNewsGroupAsync(NewsGroup newsGroup);
    Task UpdateNewsGroupAsync(NewsGroup newsGroup);
    Task DeleteNewsGroupByIdAsync(int id);
    Task<bool> NewsGroupExist(int id);
}