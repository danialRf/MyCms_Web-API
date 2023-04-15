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

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment> InsertCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;

        }

        public async Task DeleteCommentByIdAsync(int id)
        {
            _context.Remove(new Comment { Id = id });
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CommentExist(int id)
        {
            var result = await _context.Comments.AnyAsync(c => c.Id == id);
            return result;
        }

        public async Task<List<Comment>> GetCommentsByNewsId(int newsId)
        {
            return await _context.Comments.Where(x => x.NewsId == newsId).ToListAsync();

        }
    }
}
