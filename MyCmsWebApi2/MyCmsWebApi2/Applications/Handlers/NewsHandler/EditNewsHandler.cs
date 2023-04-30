using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyCmsWebApi2.Applications.Commands.NewsCommand;
using MyCmsWebApi2.Applications.Repository;

namespace MyCmsWebApi2.Applications.Handlers.NewsHandler
{
    public class EditNewsHandler : IRequestHandler<EditNewsCommand, int>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<EditNewsHandler> _logger;

        public EditNewsHandler(INewsRepository newsRepository, IMapper mapper, IMemoryCache memoryCache, ILogger<EditNewsHandler> logger)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _logger = logger;
        }
        public async Task<int> Handle(EditNewsCommand request, CancellationToken cancellationToken)
        {

            var existingNews = await _newsRepository.GetById(request.Id);
            if (existingNews == null)
            {
                throw new Exception("حاجی ناموصا همچین خبری اصلا وجود نداره تو چجوری میخوای ادیتش کنی ؟!");
            }
            existingNews.UpdateNews(request.Id, request.NewsGroupId, request.Title, request.ShortDescription, request.Text, request.ShowInSlider, request.Tags);

            await _newsRepository.Update(existingNews);
            _logger.LogInformation($"NewsGroup whit id {request.Id} was edited");
            return existingNews.Id;
        }
    }
}
