using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCmsWebApi2.Infrastructure.Exceptions.BaseException;

namespace MyCmsWebApi2.Infrastructure.Extensions
{
    public static class ModelStateExtension
    {
        public static PhoenixAggregateException<PhoenixException> ToPhoenixException(this ModelStateDictionary states)
        {
            var aggregateException = new PhoenixAggregateException<PhoenixException>();
            foreach (var item in states.Where(x => x.Value.ValidationState == ModelValidationState.Invalid))
            {
                aggregateException.Errors.Add(new PhoenixGeneralException($"{item.Value.Errors.FirstOrDefault()?.ErrorMessage ?? ""}"));
            }

            return aggregateException;
        }
    }
}
