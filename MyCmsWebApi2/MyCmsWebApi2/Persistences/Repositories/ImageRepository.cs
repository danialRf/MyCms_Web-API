using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Infrastructure;
using MyCmsWebApi2.Persistences.EF;

namespace MyCmsWebApi2.Persistences.Repositories
{
    public class ImageRepository : IImageRepository
    {

        private readonly CmsDbContext _context;

        public ImageRepository(CmsDbContext context)
        {
            _context = context;
        }

        public async Task<Image> GetById(Guid id)
        {
            return await _context.Images.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<Guid> Delete(Guid id)
        {
            _context.Remove(new Image { Id = id });
            await _context.SaveChangesAsync();
            return id;
        }


        public async Task<bool> IsExist(Guid id)
        {
            var result = await _context.Images.AnyAsync(p => p.Id == id);
            return result;
        }

        public async Task<Guid> Create(Image image)
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
            return image.Id;
        }

        public async Task<Guid> Update(Image images)
        {
            _context.Entry(images).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return images.Id;
        }

        public Task<IList<Image>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
