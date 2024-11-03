using System.Net;
using DesafioTecnicoFSBR.Domain.Exceptions;
using DesafioTecnicoFSBR.Application.Utils.Wrappers;

namespace DesafioTecnicoFSBR.Api.Middlewares
{
    public class ErrorHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

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

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            (HttpStatusCode statusCode, string message) = ex switch
            {
                DomainException domainEx => (HttpStatusCode.BadRequest, domainEx.Message),
                _ => (HttpStatusCode.InternalServerError, "Ocorreu um erro inesperado")
            };

            context.Response.StatusCode = (int)statusCode;
            var response = Response<string>.Fail(message);

            await context.Response.WriteAsJsonAsync(response);
        }
    }

}
