using AutoMapper;
using Domain.Entidades.Login;
using Domain.Entidades.Nutricionista.Clientes;
using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientesResponseDTO, ClientesConfig>();
                cfg.CreateMap<ClientesConfig, ClientesResponseDTO>();
                cfg.CreateMap<ClientesRequestDTO, ClientesConfig>();
                cfg.CreateMap<ClientesConfig, ClientesRequestDTO>();
                cfg.CreateMap<EnderecoDTO, EnderecoConfig>();
                cfg.CreateMap<EnderecoConfig, EnderecoDTO>();
                cfg.CreateMap<User, LoginConfig>();
            }
           );
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
