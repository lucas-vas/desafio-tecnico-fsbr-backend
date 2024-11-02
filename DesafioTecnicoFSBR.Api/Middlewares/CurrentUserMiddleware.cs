using DesafioTecnicoFSBR.Infra.Configuration.User;
using System.Security.Claims;

namespace DesafioTecnicoFSBR.Api.Middlewares
{
    public sealed class CurrentUserMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            string userIdString = context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            Guid userId = Guid.TryParse(userIdString, out var id) ? id : Guid.Empty;

            if (userId != Guid.Empty)
            {
                CurrentUser.SetUserId(userId);
            }

            await _next(context);
        }
    }
}
