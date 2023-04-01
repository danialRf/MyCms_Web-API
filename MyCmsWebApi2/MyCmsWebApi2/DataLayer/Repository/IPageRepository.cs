using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.Repository;

public interface IPageRepository
{
    Task<List<Page>> GetAllAsync();
    Task<Page> GetPageByIdAsync(int id);
    Task<Page> InsertPageAsync(Page page);
    Task UpdatePageAsync(Page page);
    Task DeletePageByIdAsync(int id);
    Task<bool> PageExist(int id);
}