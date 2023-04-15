using Newtonsoft.Json;
using System.Collections;

namespace MyCmsWebApi2.Infrastructure.Exceptions.BaseException
{
    public abstract class PhoenixException : Exception
    {

        protected PhoenixException(int code, string message)
            : base(message)
        {
            Code = code;

        }

        protected PhoenixException(int code, string message, string helpLink)
            : base(message)
        {
            Code = code;
            HelpLink = helpLink;
        }
        public int Code { get; private set; }

        [JsonIgnore]
        public override string StackTrace { get; }

        [JsonIgnore]
        public override IDictionary Data { get; }

        [JsonIgnore]
        public override string Source { get; set; }
        [JsonIgnore] public new long HResult { get; set; }
        [JsonIgnore] public new Exception InnerException { get; set; }


    }
}
