using FluentValidation;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Admin;

namespace MyCmsWebApi2.Presentations.Validator.NewsGroup
{
    public class EditNewsGroupValidator:AbstractValidator<AdminEditNewsGroupDto>
    {
        public EditNewsGroupValidator()
        {
            RuleFor(x => x.GroupTitle).NotEmpty().WithMessage("گروه خبری نمیتواند خالی باشد.");
            RuleFor(x => x.GroupTitle).MaximumLength(50).WithMessage("بیشتر از 50 کاراکتر قابل قبول نیست.");
            RuleFor(x => x.GroupTitle).MinimumLength(3).WithMessage("کمتر از 3 کاراکتر قابل قبول نیست.");
            RuleFor(x => x.GroupTitle).Matches("^[a-zA-Z\u0600-\u06FF]+$").WithMessage("نام کاربری باید فقط شامل حروف (انگلیسی و فارسی) باشد");
        }
    }
}
