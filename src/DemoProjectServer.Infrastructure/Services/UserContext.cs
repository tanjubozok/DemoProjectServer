using DemoProjectServer.Application.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DemoProjectServer.Infrastructure.Services;

internal sealed class UserContext(HttpContextAccessor httpContextAccessor) : IUserContext
{
    public Guid GetUserId()
    {
        var httpContext = httpContextAccessor.HttpContext;
        var claims = httpContext?.User.Claims;
        string? userIdString = claims?.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
        {
            throw new InvalidOperationException("Kullanıcı kimliği geçerli bağlamda mevcut değil.");
        }
        return userId;
    }
}
