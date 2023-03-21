using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TestingAndCalibrationLabs.Web.UI.Common
{

    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            


            switch (exception)
            {
                case ApplicationException ex:

                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                    break;
                default:
                    context.Response.StatusCode = (int)StatusCodes.Status404NotFound;
                   
                    break;
            }
            context.Response.Redirect($"/ErrorPage/Index?statuscode={exception.Message}");
            _logger.LogError(exception.Message);
            var result = JsonSerializer.Serialize("hkkjhkjl");
            
        }
    }
}