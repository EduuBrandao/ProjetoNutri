using BotCoreApplication.ApplicationService;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BotCoreApplication.Service
{
   
        public class JwtService : IJwtService
        {
            private readonly IConfiguration _config;
            private readonly string _secret;

            public JwtService(IConfiguration config)
            {
                _config = config;
                _secret = _config.GetValue<string>("JwtSecret");
            }

            public string GenerateToken(Guid accountContextKey)
            
            {
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("JwtSecret")));
            //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //    var token = new JwtSecurityToken(
            //        issuer: _config["AppSettings:JwtIssuer"],
            //        audience: _config["AppSettings:JwtAudience"],
            //        expires: DateTime.Now.AddMinutes(30),
            //        signingCredentials: creds);

            //    return new JwtSecurityTokenHandler().WriteToken(token);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("JwtSecret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Accountcontextkey", accountContextKey.ToString())
            }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Gere o token JWT
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        

            public bool ValidateToken(string token)
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_secret);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


    }
