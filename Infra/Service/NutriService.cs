using AutoMapper;
using Domain.Entidades.Nutricionista.Clientes;
using Infra.Data;
using Infra.InfraRepository;
using Infra.Models;

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

        public void Post(Clientes cliente)
        {
            ClientesConfig clientesConfig = Mapper<ClientesConfig>(cliente);
            Context.DadosClientes.Add(clientesConfig);
            Context.SaveChanges();
        }

        protected T Mapper<T>(Object data)
        {
            return _mapper.Map<T>(data);
        }
    }
}
