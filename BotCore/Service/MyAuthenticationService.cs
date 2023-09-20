using BotCore.Service.Interfaces;
using System.Security.Claims;

namespace BotCore.Service
{
    public class MyAuthenticationService : IAuthenticationService
    {
        public bool IsAuthenticated(ClaimsPrincipal user)
        {
            // Verifica se o usuário está autenticado de acordo com as suas regras de negócio
            // ...

            return true; // ou false, dependendo do resultado da verificação
        }
    }
}
