using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.DataLayer.Context;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;

namespace MyCmsWebApi2.DataLayer.Services
{
    public class ImageService : IImageRepository
    {

        private readonly CmsDbContext _context;

        public ImageService(CmsDbContext context)
        {
            _context = context;
        }

        public async Task<Images> GetPageByIdAsync(int id)
        {
            return await _context.Images.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<List<Images>> GetAllAsync()
        {
            return await _context.Images.ToListAsync();
        }


        public async Task DeleteImageByIdAsync(int id)
        {
            _context.Remove(new Images { Id = id });
            await _context.SaveChangesAsync();
        }

     

        

        public async Task<bool> ImageExist(int id)
        {
            var result = await _context.Images.AnyAsync(p => p.Id == id);
            return result;
        }

        public async Task<Images> InsertImageAsync(Images images)
        {
            await _context.AddAsync(images);
            await _context.SaveChangesAsync();
            return images;
        }

        public async Task UpdateImageAsync(Images images)
        {
            _context.Entry(images).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
