using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Persistences.EF;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;
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

        public async Task<AdminNewsDto> GetNewsById(int id)
        {
            return await _context.News.Include(x => x.Images)
                .ProjectTo<AdminNewsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}
