using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMSShared.Infrastructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;


        public NewsQueryFacade(CmsDbContext context, IMapper mapper, IMemoryCache memoryCache)
        {
            _context = context;
            _mapper = mapper;
            _memoryCache = memoryCache;
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
            return await _context.News.AsNoTracking().Include(x => x.Images).Where(x => x.NewsGroupId == id).ProjectTo<AdminNewsDto>(_mapper.ConfigurationProvider).ToListAsync();

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


        public async Task<IList<TopNewsDto>> GetTopNews()
        {
            var topNews = await _memoryCache.GetOrCreateAsync(CacheKeys.GetTopNewsKeys(), async entry =>
            {
                DateTime yesterday = DateTime.Today.AddDays(-1);
                const double CommentScore = 1;
                const double VisitScore = 3;
                var news = await _context.News
                    .Where(n => n.CreateDate >= yesterday)
                    .OrderByDescending(n => VisitScore * n.Visit + CommentScore * n.Comments.Count)
                    .Take(10)
                    .ToListAsync();
                var topNewsDto = _mapper.Map<List<TopNewsDto>>(news);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(6);
                return topNewsDto;
            });

            return topNews;
        }


    }
}


