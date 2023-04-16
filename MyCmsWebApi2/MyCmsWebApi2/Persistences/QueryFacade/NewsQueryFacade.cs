using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Persistences.EF;
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

        public async Task<IEnumerable<NewsDto>> GetAllNews()
        {
            return await _context.News.Include(x => x.Images).ProjectTo<NewsDto>(_mapper.ConfigurationProvider).ToListAsync();
        ;
        }

        //public async Task<IEnumerable<UserAllNewsDto>> GetAllNews()
        //{
        //    return await _context.News.Include(x=>x.Images) .ProjectTo<UserAllNewsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.)
        //}

        public async Task<NewsDto> GetNewsById(int id)
        {
            return await _context.News
                .AsNoTracking().Include(x => x.Images)
                .ProjectTo<AdminNewsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
            return await _context.News.Include(x => x.Images)
                .ProjectTo<NewsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}
