using FluentValidation;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;

namespace MyCmsWebApi2.Presentations.Validator.News
{
    public class AdminAddNewsValidator : AbstractValidator<AdminAddNewsDto>
    {
        public AdminAddNewsValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("تیتر نمیتواند خالی باشد.");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("بیشتر از 50 کاراکتر قابل قبول نیست.");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("کمتر از 3 کاراکتر قابل قبول نیست.");
            RuleFor(x => x.Title).Matches("^[a-zA-Z\u0600-\u06FF]+$").WithMessage("نام کاربری باید فقط شامل حروف (انگلیسی و فارسی) باشد");

            RuleFor(x => x.ShortDescription).NotEmpty().WithMessage("توضیح مختصر نمیتواند خالی باشد.");
            RuleFor(x => x.ShortDescription).MaximumLength(200).WithMessage("بیشتر از 200 کاراکتر قابل قبول نیست.");
            RuleFor(x => x.ShortDescription).MinimumLength(10).WithMessage("کمتر از 10 کاراکتر قابل قبول نیست.");
            RuleFor(x => x.ShortDescription).Matches("^[a-zA-Z\u0600-\u06FF]+$").WithMessage("توضیحات باید فقط شامل حروف (انگلیسی و فارسی) باشد");

            RuleFor(x => x.Text).NotEmpty().WithMessage("متن نمیتواند خالی باشد.");
            RuleFor(x => x.Text).MaximumLength(5000).WithMessage("بیشتر از 5000 کاراکتر قابل قبول نیست.");
            RuleFor(x => x.Text).MinimumLength(50).WithMessage("کمتر از 50 کاراکتر قابل قبول نیست.");
            RuleFor(x => x.Text).Matches("^[a-zA-Z\u0600-\u06FF]+$").WithMessage("متن باید فقط شامل حروف (انگلیسی و فارسی) باشد");

            RuleFor(x => x.Tags).NotEmpty().WithMessage("تگ نمیتواند خالی باشد.");
            RuleFor(x => x.Tags).MaximumLength(100).WithMessage("بیشتر از 100 کاراکتر قابل قبول نیست.");
            RuleFor(x => x.Tags).MinimumLength(2).WithMessage("کمتر از 2 کاراکتر قابل قبول نیست.");
            RuleFor(x => x.Tags).Matches("^[a-zA-Z\u0600-\u06FF]+$").WithMessage("متن باید فقط شامل حروف (انگلیسی و فارسی) باشد");





        }
    }
}
