using FluentValidation;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.User;

namespace MyCmsWebApi2.Presentations.Validator
{
    public class CommentValidator:AbstractValidator<UserAddCommentDto>
    {
        public CommentValidator()
        {
            RuleFor(x => x.CommentWriterName).NotEmpty().MinimumLength(3).WithMessage("حاجی نمیتونی اسم کوتاه تر از 3 حرف وارد کنی ناموسا....");
            RuleFor(x => x.CommentWriterName).NotEmpty().MaximumLength(100).WithMessage("حاجی نمیتونی اسم بلند تر از 100 حرف وارد کنی ناموسا....");

            RuleFor(x => x.CommentSubject).NotEmpty().MinimumLength(3).WithMessage("حاجی نمیتونی تیتر کوتاه تر از 3 حرف وارد کنی ناموسا....");
            RuleFor(x => x.CommentSubject).NotEmpty().MaximumLength(150).WithMessage("حاجی نمیتونی تیتر بلند تر از 150 حرف وارد کنی ناموسا....");
            
            RuleFor(x => x.CommentWriterEmail).Empty().EmailAddress().WithMessage("حاجی ادام تکین ایمل وارد کن ناموسا....");
            RuleFor(x => x.CommentWriterEmail).NotEmpty().MinimumLength(8).WithMessage("حاجی نمیتونی ایمل کوتاه تر از 8 حرف وارد کنی ناموسا....");
            RuleFor(x => x.CommentWriterEmail).NotEmpty().MaximumLength(150).WithMessage("حاجی نمیتونی ایمل بلند تر از 150 حرف وارد کنی ناموسا....");
            RuleFor(x => x.CommentWriterEmail).NotEmpty().EmailAddress().WithMessage("حاجی ادام تکین ایمل وارد کن ناموسا....");

            RuleFor(x => x.CommentText).NotEmpty().MinimumLength(3).WithMessage("حاجی ناموسن خبر وارد کن.....");
            RuleFor(x => x.CommentText).NotEmpty().MaximumLength(500).WithMessage("چه خبرع دایی ناموسا.....");
        } 
    }
}
