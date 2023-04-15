using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MyCmsWebApi2.Infrastructure.Extensions
{
    public static class StringExtension
    {
        public static string ToJsonString(this object obj)
        {
            try
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                return JsonConvert.SerializeObject(obj, Formatting.Indented, serializerSettings);
            }
            catch (Exception)
            {
                return "Bad Data,Could Not Be Serialized.";
            }
        }
    }
}
