using FluentValidation;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.Admin;

namespace MyCmsWebApi2.Presentations.Validator.Comment
{
    public class ChangeCommentStatusValidator:AbstractValidator<AdminChangeCommentStatusDto>
    {
        public ChangeCommentStatusValidator()
        {
            RuleFor(x => x.CommentStatus).IsInEnum().WithMessage("وضعیت نمیتواند خالی باشد.");
        }
    }
}
