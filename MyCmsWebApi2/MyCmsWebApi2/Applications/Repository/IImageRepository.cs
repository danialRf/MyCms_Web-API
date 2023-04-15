using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Applications.Repository
{
    public interface IImageRepository
    {
        Task<Image> GetImageByIdAsync(Guid id);
        Task<Image> InsertImageAsync(Image image);
        Task UpdateImageAsync(Image images);
        Task DeleteImageByIdAsync(Guid id);
        Task<bool> ImageExist(Guid id);
    }
}
