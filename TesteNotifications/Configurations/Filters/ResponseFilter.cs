using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using TesteNotifications.Domain.Global.Structure.Queues.Error;

namespace TesteNotifications.Configurations.Filters
{
    public class ResponseFilter : IAsyncResultFilter
    {
        private readonly IErrorQueue _errorQueue;

        public ResponseFilter(IErrorQueue errorQueue)
        {
            _errorQueue = errorQueue;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_errorQueue.HasError)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                string content = JsonConvert.SerializeObject(_errorQueue.ReadErrors());
                await context.HttpContext.Response.WriteAsync(content);

                return;
            }

            await next();
        }
    }
}