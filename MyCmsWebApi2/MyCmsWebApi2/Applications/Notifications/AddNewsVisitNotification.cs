using MediatR;

namespace MyCmsWebApi2.Applications.Notifications
{
    public class AddNewsVisitNotification : INotification
    {
        public int NewsId { get; set; }
    }
}
