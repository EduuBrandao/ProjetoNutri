using BotCore.Service.Interfaces;
using System.Security.Claims;

namespace BotCore.Service
{
    public class MyAuthenticationService : IAuthenticationService
    {
        public bool IsAuthenticated(ClaimsPrincipal user)
        {
            return true;
        }
    }
}
