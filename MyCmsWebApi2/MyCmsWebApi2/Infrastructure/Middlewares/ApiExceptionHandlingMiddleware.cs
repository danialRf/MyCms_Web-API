using MyCmsWebApi2.Infrastructure.Exceptions.BaseException;
using MyCmsWebApi2.Infrastructure.Extensions;
using System.Net;

namespace MyCmsWebApi2.Infrastructure.Middlewares
{
    public class ApiExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IHostEnvironment _hostEnvironment;

        public ApiExceptionHandlingMiddleware(RequestDelegate next,IHostEnvironment hostEnvironment )
        {
            _next = next;
            _hostEnvironment = hostEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            string serializedException;

            switch (ex)
            {
                case PhoenixException phoenixException:
                    {
                        var aggregateException =
                        new PhoenixAggregateException<PhoenixException>(new List<PhoenixException>(new[] { phoenixException }));
                        serializedException = aggregateException.ToJsonString();
                        break;
                    }

                case PhoenixAggregateException<PhoenixException> aggregateException:
                    {
                        serializedException = aggregateException.ToJsonString();
                        break;
                    }
                default:
                    {
                        Console.WriteLine(ex.ToString());
                        var aggregateException =
                        new PhoenixAggregateException<PhoenixException>(new List<PhoenixException>(new[] { new PhoenixGeneralException("خطایی رخ داده است.") }));
                        serializedException = aggregateException.ToJsonString();
                    }

                    break;
            }

            return context.Response.WriteAsync(serializedException);
        }
    }
}
