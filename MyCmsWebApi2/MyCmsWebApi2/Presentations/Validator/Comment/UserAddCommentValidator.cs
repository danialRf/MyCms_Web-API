using FluentValidation;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.User;

namespace MyCmsWebApi2.Presentations.Validator.Comment
{
    public class UserAddCommentValidator : AbstractValidator<UserAddCommentDto>
    {
        public UserAddCommentValidator()
        {
            RuleFor(x => x.CommentWriterName).NotEmpty().WithMessage("نام نمیتواند خالی باشد...");
            RuleFor(x => x.CommentWriterName).MinimumLength(3).WithMessage("حاجی نمیتونی اسم کوتاه تر از 3 حرف وارد کنی ناموسا....");
            RuleFor(x => x.CommentWriterName).MaximumLength(100).WithMessage("حاجی نمیتونی اسم بلند تر از 100 حرف وارد کنی ناموسا....");

            RuleFor(x => x.CommentSubject).NotEmpty().WithMessage("تیتر نمیتواند خالی باشد...");
            RuleFor(x => x.CommentSubject).MinimumLength(3).WithMessage("حاجی نمیتونی تیتر کوتاه تر از 3 حرف وارد کنی ناموسا....");
            RuleFor(x => x.CommentSubject).MaximumLength(150).WithMessage("حاجی نمیتونی تیتر بلند تر از 150 حرف وارد کنی ناموسا....");

            RuleFor(x => x.CommentWriterEmail).NotEmpty().WithMessage("ایمیل نمیتواند خالی باشد....");
            RuleFor(x => x.CommentWriterEmail).MinimumLength(8).WithMessage("حاجی نمیتونی ایمل کوتاه تر از 8 حرف وارد کنی ناموسا....");
            RuleFor(x => x.CommentWriterEmail).MaximumLength(150).WithMessage("حاجی نمیتونی ایمل بلند تر از 150 حرف وارد کنی ناموسا....");
            RuleFor(x => x.CommentWriterEmail).EmailAddress().WithMessage("حاجی ادام تکین ایمل وارد کن ناموسا....");

            RuleFor(x => x.CommentText).NotEmpty().WithMessage("نظر نمیتواند خالی باشد....");
            RuleFor(x => x.CommentText).MinimumLength(3).WithMessage("حاجی ناموسن خبر وارد کن.....");
            RuleFor(x => x.CommentText).MaximumLength(500).WithMessage("چه خبرع دایی ناموسا.....");
        }
    }
}
