using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.Repository
{
    public interface IImageRepository
    {
        Task<Images> GetImageByIdAsync(int id);
        Task<Images> InsertImageAsync(Images images);
        Task UpdateImageAsync(Images images);
        Task DeleteImageByIdAsync(int id);
        Task<bool> ImageExist(int id);
    }
}
