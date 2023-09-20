using System.Security.Claims;

namespace BotCore.Service.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated(ClaimsPrincipal user);
    }
}
