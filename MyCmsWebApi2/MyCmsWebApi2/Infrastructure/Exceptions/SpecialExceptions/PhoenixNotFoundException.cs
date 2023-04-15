using MyCmsWebApi2.Infrastructure.Exceptions.BaseException;

namespace MyCmsWebApi2.Infrastructure.Exceptions.SpecialExceptions
{
    public sealed class PhoenixNotFoundException : PhoenixException
    {

        public PhoenixNotFoundException() : base((int)ErrorCodes.NotFound, "پاسخ مناسب برای درخواست شما یافت نشد.")
        {
        }

        public PhoenixNotFoundException(string message) : base((int)ErrorCodes.NotFound, message)
        {
        }

        public PhoenixNotFoundException(string message, string helpLink) : base((int)ErrorCodes.NotFound, message, helpLink)
        {
        }
    }
}
