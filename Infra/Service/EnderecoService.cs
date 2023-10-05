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

        public void Delete(int clientId)
        {
            try
            {
                var enderecos = Context.EnderecoClientes.Where(x => x.ClientId == clientId).ToList();

                if (enderecos == null)
                    throw new ArgumentException("Endereco não encontrado no banco de dados.", nameof(clientId));

                foreach (var endereco in enderecos)
                {
                    Context.EnderecoClientes.Remove(endereco);
                    Context.SaveChanges();
                }
            }

            catch
            {
                throw new ArgumentException("Algo deu errado", nameof(clientId));
            }
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
