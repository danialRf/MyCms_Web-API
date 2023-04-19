using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Persistences.EF;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Users;
using MyCmsWebApi2.Presentations.QueryFacade;

namespace MyCmsWebApi2.Persistences.QueryFacade
{
    public class NewsQueryFacade : INewsQueryFacade
    {
        private readonly IMapper _mapper;
        private readonly CmsDbContext _context;

        public NewsQueryFacade(CmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminNewsDto>> AdminGetAllNews()
        {
            return await _context.News.AsNoTracking().Include(x => x.Images).ProjectTo<AdminNewsDto>(_mapper.ConfigurationProvider).ToListAsync();
        
        }

        public async Task<IEnumerable<UserNewsDto>> UserGetAllNews()
        {
            return await _context.News.AsNoTracking().Include(x => x.Images).ProjectTo<UserNewsDto>(_mapper.ConfigurationProvider).ToListAsync();

        }

        public async Task<IEnumerable<AdminNewsDto>> AdminGetNewsByGroupId(int id)
        {
            return await _context.News.AsNoTracking().Include(x => x.Images).Where(x=>x.NewsGroupId == id).ProjectTo<AdminNewsDto>(_mapper.ConfigurationProvider).ToListAsync();

        }
        public async Task<IEnumerable<UserNewsDto>> UserGetNewsByGroupId(int id)
        {
            return await _context.News.AsNoTracking().Include(x => x.Images).Where(x => x.NewsGroupId == id).ProjectTo<UserNewsDto>(_mapper.ConfigurationProvider).ToListAsync();

        }

        public async Task<AdminNewsDto> AdminGetNewsById(int id)
        {
            return await _context.News.AsNoTracking().Include(x => x.Images).ProjectTo<AdminNewsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
          
        }
        public async Task<UserNewsDto> UserGetNewsById(int id)
        {
            return await _context.News.AsNoTracking().Include(x => x.Images).ProjectTo<UserNewsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<bool> Exist(int id)
        {
            return await _context.News.AsNoTracking().AnyAsync(x => x.Id == id);
        }
    }
}
