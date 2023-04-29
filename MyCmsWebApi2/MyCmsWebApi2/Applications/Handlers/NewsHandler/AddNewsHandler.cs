using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyCmsWebApi2.Applications.Commands.NewsCommand;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Applications.Handlers.NewsHandler
{
    public class AddNewsHandler : IRequestHandler<AddNewsCommand, int>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public AddNewsHandler(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddNewsCommand request, CancellationToken cancellationToken)
        {
            
            var news = _mapper.Map<News>(request);
            var result = await _newsRepository.Create(news);
            _memoryCache.Remove("topNews");
            return result;

        }
    }
}