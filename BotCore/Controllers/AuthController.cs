using BotCoreApplication.ApplicationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace BotCore.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IJwtService _jwtService;

        public AuthController(IConfiguration config, IJwtService jwtService)
        {
            _config = config;
            _jwtService = jwtService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate()
        {
            var apiKey = Request.Headers["X-API-KEY"];
            var validApiKey = _config.GetValue<string>("ApiKey");

            if (apiKey != validApiKey)
            {
                return Unauthorized();
            }

            var token = _jwtService.GenerateToken(Guid.NewGuid());


                return Ok(token);
            }

    }

}



