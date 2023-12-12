using Microsoft.AspNetCore.Http;
using ReminderApp.Application.Extensions;
using Serilog;
using System.Net;

namespace ReminderApp.Infrastructure.Middlewares
{
    public class ErrorHandlingMiddleware

    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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
            Log.Error("ERROR MESSAGE : " + ex.Message);

            var code = HttpStatusCode.InternalServerError;
            var result = (new { error = "Error appeared when maked process ! => " + ex.Message }).SerialJson();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
