using MediatR;
using MyCmsWebApi2.Applications.Commands.CommentsCommand;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Domain.Enums;
using MyCmsWebApi2.Infrastructure.Exceptions.BaseException;

namespace MyCmsWebApi2.Applications.Handlers.CommentsHandler
{
    public class AddCommentHandler : IRequestHandler<AddCommentCommand, int>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly INewsRepository _newsRepository;
        public AddCommentHandler(ICommentRepository commentRepository, INewsRepository newsRepository)
        {
            _commentRepository = commentRepository;
            _newsRepository = newsRepository;
        }

        public async Task<int> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            if (request.CommentWriterName == null || request.CommentWriterEmail == null)
            {
                throw new PhoenixGeneralException("حاجی اسمت و ایمیلت رو کامل بنویس ناموصا");

            }

            if (request.CommentText == null || request.CommentSubject == null)
            {
                throw new PhoenixGeneralException("حاجی یه متنی بنویس ناموصا");

            }
            if (!await _newsRepository.IsExist(request.NewsId))
            {
                throw new PhoenixGeneralException("حاجی چجوری رو اخباری که وجود نداره داری کامنت میذاری ناموصا ؟");
            }

            var comment = new Comment()
            {
                NewsId = request.NewsId,
                CommentWriterEmail = request.CommentWriterEmail,
                CommentWriterName = request.CommentWriterName,
                CommentSubject = request.CommentSubject,
                CommentText = request.CommentText,
                CommentStatus = request.CommentStatus,
                //ChangeStatusDate
                //StatusChangerId
            };
            var result = await _commentRepository.Create(comment);
            return result;

            

        }
    }
}
