using Application.Business;
using Application.Interface;
using Infra.InfraRepository;
using Infra.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INutriRepository, NutriService>();
            services.AddScoped<IEnderecoRepository, EnderecoService>();
            services.AddScoped<ILoginRepository, LoginService>();
            services.AddScoped<ICep, CepBusiness>();
            services.AddScoped<IClientes, ClienteBusiness>();
            services.AddScoped<ILogin, LoginBusiness>();

            return services;
        }
    }
}
