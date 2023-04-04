using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.DataLayer.Context;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;

namespace MyCmsWebApi2.DataLayer.Services
{


    public class CommentService : ICommentRepository
    {
        private readonly CmsDbContext _context;

        public CommentRepository(CmsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comments>> GetAllAsync()
        {
            return await _context.comments.ToListAsync();
        }

        public async Task<Comments> GetCommentByIdAsync(int id)
        {
            return await _context.comments.FirstOrDefaultAsync(c => c.CommentId == id);
        }

        public async Task<Comments> InsertCommentAsync(Comments comment)
        {
            await _context.comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task UpdateCommentAsync(Comments comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentByIdAsync(int id)
        {
            _context.Remove(new Comments { CommentId = id });
            await _context.SaveChangesAsync();
        }
    }
}
