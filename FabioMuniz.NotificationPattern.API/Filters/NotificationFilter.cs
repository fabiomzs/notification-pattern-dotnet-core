using FabioMuniz.NotificationPattern.Domain.Notifications;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace FabioMuniz.NotificationPattern.API.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationHandler _notificationContext;

        public NotificationFilter(NotificationHandler notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = System.Text.Json.JsonSerializer.Serialize(_notificationContext.Notifications);
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await next();
        }
    }
}