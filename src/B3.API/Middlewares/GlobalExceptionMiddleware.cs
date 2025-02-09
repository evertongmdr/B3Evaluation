using B3.Common.API;
using System.Net;
using System.Text.Json;

namespace B3.API.Middlewares
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

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro inesperado no sistema, detalhes foram registrados.");

                await ProcessErrorResponse(httpContext, ex);

            }
        }

        private async Task ProcessErrorResponse(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var response = new ApiResponse
            {
                Success = false,
                Errors = new List<string>() { "Ocorreu um erro inesperado no sisetma. Por favor, tente novamente mais tarde " +
                "se o problema persistir entre em contato com o time de suporte." }

            };

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var jsonResponse = JsonSerializer.Serialize(response, jsonOptions);

            await httpContext.Response.WriteAsync(jsonResponse);
        }

    }
}
