using Microsoft.AspNetCore.Mvc;
using CafeEmployee.API.Models;


namespace CafeEmployee.API.Extensions
{
    public static class ApiBehaviorOptionsExtensions
    {
        public static void ConfigureCustomApiBehavior(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                       .Where(x => x.Value != null && x.Value.Errors.Count > 0) 
                        .SelectMany(x => x.Value!.Errors) 
                        .Select(x => x.ErrorMessage)
                        .ToList();

                    var errorResponse = new ErrorResponse(
                        StatusCodes.Status400BadRequest,
                        "Validation failed.",
                        errors,
                        context.HttpContext.Request.Path
                    );

                    return new BadRequestObjectResult(errorResponse);
                };
            });
        }
    }
}