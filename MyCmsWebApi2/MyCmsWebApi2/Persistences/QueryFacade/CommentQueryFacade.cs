using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Persistences.EF;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.User;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.QueryFacade;

namespace MyCmsWebApi2.Persistences.QueryFacade
{
    public class CommentQueryFacade : ICommentQueryFacade
    {
        private readonly IMapper _mapper;
        private readonly CmsDbContext _context;

        public CommentQueryFacade(CmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AdminCommentsDto>> AdminGetAllComments()
        {
            return await _context.Comments.AsNoTracking().ProjectTo<AdminCommentsDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<IEnumerable<AdminCommentsDto>> AdminGetCommentByNewsId(int id)
        {
            return await _context.Comments.AsNoTracking().Include(x => x.News).Where(x=>x.NewsId==id).ProjectTo<AdminCommentsDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<AdminCommentsDto> AdminGetCommentById(int id)
        {
            return await _context.Comments.AsNoTracking().ProjectTo<AdminCommentsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<UserCommentsDto>> UserGetAllComments()
        {
            return await _context.Comments.AsNoTracking().ProjectTo<UserCommentsDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<UserCommentsDto> UserGetCommentById(int id)
        {
            return await _context.Comments.AsNoTracking().ProjectTo<UserCommentsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
