using AutoMapper;
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
                cfg.CreateMap<EnderecoResponseDTO, EnderecoConfig>();
                cfg.CreateMap<EnderecoConfig, EnderecoResponseDTO>();
            }
           );
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
