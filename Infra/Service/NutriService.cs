using AutoMapper;
using Domain.Entidades.Nutricionista.Clientes;
using Infra.Data;
using Infra.InfraRepository;
using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Service
{
    public class NutriService : BaseRepository<ClientesConfig>, INutriRepository
    {
        private readonly IMapper _mapper;
        public NutriService(NutriContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<Clientes>> Get()
        {
            var document = Context.DadosClientes.ToList();

            return Mapper<List<Clientes>>(document);
        }

        protected T Mapper<T>(Object data)
        {
            return _mapper.Map<T>(data);
        }
    }
}
