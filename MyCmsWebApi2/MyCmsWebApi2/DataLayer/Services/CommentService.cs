using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.DataLayer.Context;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.DataLayer.Repository;

namespace MyCmsWebApi2.DataLayer.Services
{


    public class CommentService : ICommentRepository
    {
        private readonly CmsDbContext _context;

        public CommentService(CmsDbContext context)
        {
             _context = context;


        }

        public async Task<List<Comments>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comments> GetCommentByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comments> InsertCommentAsync(Comments comment)
        {
            await _context.Comments.AddAsync(comment);
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
            _context.Remove(new Comments { Id = id });
            await _context.SaveChangesAsync();
        }
    }
}
