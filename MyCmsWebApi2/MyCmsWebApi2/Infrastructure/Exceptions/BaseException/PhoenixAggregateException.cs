using Newtonsoft.Json;
using System.Collections;

namespace MyCmsWebApi2.Infrastructure.Exceptions.BaseException
{
    public class PhoenixAggregateException<TException> : Exception
            where TException : PhoenixException
    {
        public PhoenixAggregateException() : base()
        {

            Errors = new List<TException>();
            //Message = "";
        }
        public PhoenixAggregateException(IList<TException> errors) : base()
        {
            Errors = errors;
            //Message = "";
        }
        public IList<TException> Errors { get; private set; }

        [JsonIgnore]
        public override string StackTrace { get; }
        [JsonIgnore]
        public override IDictionary Data { get; }
        [JsonIgnore]
        public override string Message { get; }
        [JsonIgnore] public override string Source { get; set; }
        [JsonIgnore] public override string HelpLink { get; set; }

    }
}
