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
    public class EnderecoService : BaseRepository<EnderecoConfig>, IEnderecoRepository
    {
        private readonly IMapper _mapper;
        public EnderecoService(NutriContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<EnderecoResponseDTO>> Get()
        {
            var document = Context.EnderecoClientes.ToList();

            return Mapper<List<EnderecoResponseDTO>>(document);
        }

        protected T Mapper<T>(Object data)
        {
            return _mapper.Map<T>(data);
        }
    }
}
