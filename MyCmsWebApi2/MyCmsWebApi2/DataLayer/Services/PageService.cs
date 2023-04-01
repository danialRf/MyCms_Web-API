using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.DataLayer.Context;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;

namespace MyCmsWebApi2.DataLayer.Services;

public class PageService:IPageRepository
{
    public Task<List<Page>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Page> GetPageByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Page> InsertPageAsync(Page page)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePageAsync(Page page)
    {
        throw new NotImplementedException();
    }

    public Task DeletePageByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PageExist(int id)
    {
        throw new NotImplementedException();
    }
}