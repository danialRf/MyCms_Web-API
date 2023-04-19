using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Persistences.EF;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Users;
using MyCmsWebApi2.Presentations.QueryFacade;

namespace MyCmsWebApi2.Persistences.QueryFacade
{
    public class NewsGroupQueryFacade : INewsGroupQueryFacade
    {
        private readonly IMapper _mapper;
        private readonly CmsDbContext _context;

        public NewsGroupQueryFacade(CmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminNewsGroupDto>> AdminGetAllNewsGroup()
        =>
            await _context.NewsGroup.AsNoTracking().ProjectTo<AdminNewsGroupDto>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<AdminNewsGroupDto> AdminGetNewsGroupById(int id)
        {
            return await _context.NewsGroup.AsNoTracking().ProjectTo<AdminNewsGroupDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<bool> Exist(int? id)
        {

            var newsgroup = await _context.NewsGroup.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (newsgroup == null)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<UserNewsGroupDto>> UserGetAllNewsGroup()
        =>
            await _context.NewsGroup.AsNoTracking().Include(x => x.News).ProjectTo<UserNewsGroupDto>(_mapper.ConfigurationProvider).ToListAsync();


    }
}
