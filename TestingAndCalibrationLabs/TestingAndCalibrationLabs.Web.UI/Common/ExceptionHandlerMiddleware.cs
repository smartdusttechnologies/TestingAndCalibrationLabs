using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TestingAndCalibrationLabs.Web.UI.Common
{
    /// <summary>
    /// Handling Exceptions
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
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
        /// <summary>
        /// Handle the exception of this pipeline and redirect to ruled url with message
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var message =  exception.Message;
            switch (exception)
            {
                case UnauthorizedAccessException ex:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    break;
                default:
                    context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;
                    message = "Unable To Process Your Request  Please Contact To Admin";
                    break;
            }
            context.Response.Redirect($"/ErrorPage/Index?message={message}");
        }
    }
}