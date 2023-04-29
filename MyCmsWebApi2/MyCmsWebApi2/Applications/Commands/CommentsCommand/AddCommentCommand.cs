using MediatR;
using MyCmsWebApi2.Domain.Enums;

namespace MyCmsWebApi2.Applications.Commands.CommentsCommand
{
    public class AddCommentCommand : IRequest<int>
    {

        public int NewsId { get; set; }
        public string CommentWriterName { get; set; }
        public string CommentWriterEmail { get; set; }
        public string CommentSubject { get; set; }
        public string CommentText { get; set; }
        public CommentStatus CommentStatus { get; set; }
        public DateTime ChangeStatusDate { get; set; }
        public Guid StatusChangerId { get; set; }



    }
}
