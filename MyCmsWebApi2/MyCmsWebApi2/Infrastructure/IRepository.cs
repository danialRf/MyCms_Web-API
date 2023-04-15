namespace MyCmsWebApi2.Infrastructure
{
    public interface IRepository <TModel,TId>
    {
        Task<TModel> GetById (TId id);
        Task<IList<TModel>> GetAll();
        Task<TId> Create(TModel model);
        Task<TId> Update(TModel model);
        Task<TId> Delete(TId id);
        Task<bool> IsExist(TId id);

    }
}
