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

        public async Task<List<EnderecoDTO>> Get()
        {
            var document = Context.EnderecoClientes.ToList();

            return Mapper<List<EnderecoDTO>>(document);
        }

        public void Post(List<EnderecoDTO> enderecos)
        {
            foreach (var endereco in enderecos)
            {
                EnderecoConfig enderecoConfig = Mapper<EnderecoConfig>(endereco);
                Context.EnderecoClientes.Add(enderecoConfig);
                Context.SaveChanges();
            }

        }

        protected T Mapper<T>(Object data)
        {
            return _mapper.Map<T>(data);
        }
    }
}
