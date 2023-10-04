using BotCore.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BotCore
{
    public class AuthMiddleware : IMiddleware
    {
        private readonly ILogger<AuthMiddleware> _logger;
        private readonly IAuthenticationService _authenticationService;

        public AuthMiddleware(ILogger<AuthMiddleware> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!_authenticationService.IsAuthenticated(context.User))
            {
                context.Response.Redirect("/Auth");
                return;
            }

            await next(context);
        }
    }

}