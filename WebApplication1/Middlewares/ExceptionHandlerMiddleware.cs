using System.Net;
using System.Text.Json;

using Application.Exceptions;

namespace NewsAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (Exception e)
            {
                await HandleExceptionsAsync(e, context);
            }
        }

        public async Task HandleExceptionsAsync(Exception e, HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = e switch
            {
                ItemNotFoundException => (int)HttpStatusCode.NotFound,
                BadRequestException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var exceptionModel = new ExceptionModel
            {
                Message = e.Message,
                StatusCode = response.StatusCode
            };

            await response.WriteAsJsonAsync(exceptionModel);

        }

    }
}
