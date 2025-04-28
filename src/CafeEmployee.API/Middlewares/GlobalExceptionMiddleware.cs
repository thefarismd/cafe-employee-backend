using System.Text.Json;
using CafeEmployee.API.Models;
using CafeEmployee.Core.Common;

namespace CafeEmployee.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
               private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Continue normal execution
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, context.Request.Path);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, PathString path)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            ErrorResponse errorResponse;

            if (exception is CustomValidationException validationException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                errorResponse = new ErrorResponse(
                    response.StatusCode,
                    "Validation failed.",
                    validationException.Errors,
                    path
                );
            }
            else
            {
                _logger.LogError(exception, "Unhandled server error occurred.");
                response.StatusCode = StatusCodes.Status500InternalServerError;
                errorResponse = new ErrorResponse(
                    response.StatusCode,
                    "An unexpected error occurred.",
                    null,
                    path
                );
            }

            var result = JsonSerializer.Serialize(errorResponse);
            await response.WriteAsync(result);
        }
    }
}