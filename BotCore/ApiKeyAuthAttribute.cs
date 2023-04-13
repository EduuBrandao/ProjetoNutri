using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;

namespace BotCore
{
    public class ApiKeyAuthAttribute : Attribute, IAuthorizationFilter
    {
        private const string API_KEY_HEADER_NAME = "B0F512C5-110D-460B-AA78-B05DD666C2D5";
        private readonly string _apiKey;

        public ApiKeyAuthAttribute(IConfiguration config)
        {
            _apiKey = config.GetValue<string>("ApiKey");
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var apiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!_apiKey.Equals(apiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}