using Application.Interface;
using Domain.Entidades.Nutricionista.Clientes;
using Infra.InfraRepository;

namespace Application.Business
{
    public class ClienteBusiness : IClientes
    {
        private readonly INutriRepository _Nutri;
        public ClienteBusiness(INutriRepository nutri)
        {
            _Nutri = nutri;
        }
        public async Task<List<Clientes>> ObterClientes()
        {
            return await _Nutri.Get();
        }

        public void AdicionarClientes(Clientes cliente)
        {
              _Nutri.Post(cliente);
        }
    }
}
