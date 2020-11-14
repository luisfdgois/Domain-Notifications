using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using TesteNotifications.Data.Repositories.Notifications;

namespace TesteNotifications.Configurations.Filters
{
    public class ResponseFilter : IAsyncResultFilter
    {
        private readonly RepositoryNotification _repositoryNotification;

        public ResponseFilter(RepositoryNotification repositoryNotification)
        {
            _repositoryNotification = repositoryNotification;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_repositoryNotification.HasNotifications())
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                string content = JsonConvert.SerializeObject(_repositoryNotification.GetNotifications());
                await context.HttpContext.Response.WriteAsync(content);

                return;
            }

            await next();
        }
    }
}