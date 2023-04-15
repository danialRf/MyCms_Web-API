using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Persistences.EF;

namespace MyCmsWebApi2.Persistences.Repositories
{
    public class ImageService : IImageRepository
    {

        private readonly CmsDbContext _context;

        public ImageService(CmsDbContext context)
        {
            _context = context;
        }

        public async Task<Images> GetImageByIdAsync(Guid id)
        {
            return await _context.Images.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task DeleteImageByIdAsync(Guid id)
        {
            _context.Remove(new Images { Id = id });
            await _context.SaveChangesAsync();
        }


        public async Task<bool> ImageExist(Guid id)
        {
            var result = await _context.Images.AnyAsync(p => p.Id == id);
            return result;
        }

        public async Task<Images> InsertImageAsync(Images image)
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task UpdateImageAsync(Images images)
        {
            _context.Entry(images).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


    }
}
