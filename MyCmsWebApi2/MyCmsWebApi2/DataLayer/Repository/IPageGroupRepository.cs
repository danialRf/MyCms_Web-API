using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.Repository;

public interface IPageGroupRepository
{
    Task<List<PageGroup>> GetAllAsync();
    Task<PageGroup> GetPageGroupByIdAsync(int id);
    Task<PageGroup> InsertPageGroupAsync(PageGroup pageGroup);
    Task UpdatePageGroupAsync(PageGroup pageGroup);
    Task DeletePageGroupByIdAsync(int id);
    Task<bool> PageGroupExist(int id);
}