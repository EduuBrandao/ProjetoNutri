using Application.Business;
using Application.Interface;
using AutoMapper;
using BotCoreApplication.ApplicationService;
using BotCoreApplication.Service;
using Domain.Entidades.Nutricionista.Clientes;
using Domain.Interfaces;
using Domain.Service;
using Infra.Data;
using Infra.InfraRepository;
using Infra.Models;
using Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace BotCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<INutriRepository, NutriService>();
            services.AddScoped<ICep, CepBusiness>();
            services.AddScoped<IClientes, ClienteBusiness>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddDbContext<NutriContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Clientes, ClientesConfig>();
                cfg.CreateMap<ClientesConfig, Clientes>();
            }
            );
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddHttpClient<ICepService, CepService>(client =>
            {
                client.BaseAddress = new Uri("https://viacep.com.br/");
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
            });

            var key = Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JwtSecret"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.Use(async (context, next) =>
            {
                // Obter o JWT do cabeçalho de autorização
                var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                if (authHeader != null && authHeader.StartsWith("Bearer "))
                {
                    var token = authHeader.Substring("Bearer ".Length).Trim();

                    // Validar e decodificar o JWT
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(Configuration["JwtSecret"]);
                    var tokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    try
                    {
                        var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
                        var guidClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "Accountcontextkey");
                        if (guidClaim != null && Guid.TryParse(guidClaim.Value, out var accountContextKey))
                        {
                            // Adicionar o GUID como um item no contexto da solicitação
                            context.Items["Accountcontextkey"] = accountContextKey;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Lidar com erros de validação do JWT
                    }
                }

                await next.Invoke();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
