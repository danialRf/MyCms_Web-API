using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Persistences.EF;

namespace MyCmsWebApi2.Persistences.Repositories
{


    public class CommentRepository : ICommentRepository
    {
        private readonly CmsDbContext _context;

        public CommentRepository(CmsDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> Create(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment.Id;

        }

        public async Task<int> Delete(int id)
        {
            _context.Remove(new Comment { Id = id });
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<bool> IsExist(int id)
        {
            var result = await _context.Comments.AnyAsync(c => c.Id == id);
            return result;
        }

        public async Task<List<Comment>> GetCommentsByNewsId(int newsId)
        {
            return await _context.Comments.Where(x => x.NewsId == newsId).ToListAsync();

        }

        public Task<int> Update(Comment model)
        {
            throw new NotImplementedException();
        }
    }
}
