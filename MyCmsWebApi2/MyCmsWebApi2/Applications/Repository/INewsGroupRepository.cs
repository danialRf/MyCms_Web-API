using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Applications.Repository;

public interface INewsGroupRepository
{
    Task<List<NewsGroup>> GetAllAsync();
    Task<NewsGroup> GetNewsGroupByIdAsync(int id);
    Task<NewsGroup> InsertNewsGroupAsync(NewsGroup newsGroup);
    Task UpdateNewsGroupAsync(NewsGroup newsGroup);
    Task DeleteNewsGroupByIdAsync(int id);
    Task<bool> NewsGroupExistAsync(int id);

    Task<NewsGroup> GetGroupByNewsId(int newsId);
}