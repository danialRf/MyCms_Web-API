namespace MyCmsWebApi2.Infrastructure.Exceptions.BaseException
{
    public sealed class PhoenixGeneralException : PhoenixException
    {
        public PhoenixGeneralException() : base((int)ErrorCodes.GeneralException, "خطایی رخ داده است.")
        {

        }
        public PhoenixGeneralException(string message) : base((int)ErrorCodes.GeneralException, message)
        {
        }

        public PhoenixGeneralException(string message, string helpLink) : base((int)ErrorCodes.GeneralException, message, helpLink)
        {
        }
    }
}
