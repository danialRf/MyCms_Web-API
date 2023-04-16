using MediatR;
using MyCmsWebApi2.Applications.Notifications;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Infrastructure.Exceptions.SpecialExceptions;

namespace MyCmsWebApi2.Applications.NotificationHandlers
{
    public class AddNewsVisitNotificationHandler : INotificationHandler<AddNewsVisitNotification>
    {
        private readonly INewsRepository _newsRepository;

        public AddNewsVisitNotificationHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task Handle(AddNewsVisitNotification notification, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.GetById(notification.NewsId);
            if (news == null)
            {
                return;
            }
            news.Visited();
            await _newsRepository.Update(news);
        }
    }
}
