using FluentValidation;
using MyCmsWebApi2.Presentations.Dtos.ImagesDto.Admin;

namespace MyCmsWebApi2.Presentations.Validator.Image
{
    public class AdminAddImageValidator : AbstractValidator<AdminAddImageDto>
    {

        public AdminAddImageValidator()
        {
            RuleFor(x => x.ImageFile).NotNull().WithMessage("حاجی یه عکسی انتخاب کن ناموصا");
            RuleFor(x => x.ImageFile).Must(IsValidImageFormat).WithMessage("فرمت فایل ارسالی معتبر نیست. لطفاً یک عکس با فرمت معتبر انتخاب کنید.");
        }

        private bool IsValidImageFormat(IFormFile file)
        {
            if (file == null)
            {
                return false;
            }

            var allowedContentTypes = new List<string>
        {
            "image/jpeg",
            "image/png",
            "image/gif",
            "image/bmp"
        };

            return allowedContentTypes.Contains(file.ContentType.ToLowerInvariant());
        }
    }

}

