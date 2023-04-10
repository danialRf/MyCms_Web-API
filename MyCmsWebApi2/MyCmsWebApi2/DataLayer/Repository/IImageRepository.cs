using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.Repository
{
    public interface IImageRepository
    {
        Task<Images> GetImageByIdAsync(Guid id);
        Task<Images> InsertImageAsync(Images image);
        Task UpdateImageAsync(Images images);
        Task DeleteImageByIdAsync(Guid id);
        Task<bool> ImageExist(Guid id);
    }
}
