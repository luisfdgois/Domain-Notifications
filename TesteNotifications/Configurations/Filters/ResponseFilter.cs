using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using TesteNotifications.Application.Contracts;

namespace TesteNotifications.Configurations.Filters
{
    public class ResponseFilter : IAsyncResultFilter
    {
        private readonly ErrorRepository _errorRepository;

        public ResponseFilter(ErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_errorRepository.HasErrors())
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                string content = JsonConvert.SerializeObject(_errorRepository.GetErrors());
                await context.HttpContext.Response.WriteAsync(content);

                return;
            }

            await next();
        }
    }
}