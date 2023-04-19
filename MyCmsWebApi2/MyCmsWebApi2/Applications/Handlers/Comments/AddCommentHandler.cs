using MediatR;
using MyCmsWebApi2.Applications.Commands.Comments;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Domain.Enums;
using MyCmsWebApi2.Infrastructure.Exceptions.BaseException;
using MyCmsWebApi2.Persistences.Repositories;
using MyCmsWebApi2.Presentations.QueryFacade;

namespace MyCmsWebApi2.Applications.Handlers.Comments
{
    public class AddCommentHandler : IRequestHandler<AddCommentCommand, int>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly INewsQueryFacade _newsQueryFacade;
        public AddCommentHandler(ICommentRepository commentRepository, INewsQueryFacade newsQueryFacade)
        {
            _commentRepository = commentRepository;
            _newsQueryFacade = newsQueryFacade;
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
            if (!await _newsQueryFacade.Exist(request.NewsId))
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
                CommentStatus = CommentStatus.Checking,
                //ChangeStatusDate
                //StatusChangerId
            };
            var result = await _commentRepository.Create(comment);
            return result;

        }
    }
}
