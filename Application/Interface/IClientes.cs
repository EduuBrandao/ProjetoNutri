using Domain.Entidades.Nutricionista.Clientes;

namespace Application.Interface
{
    public interface IClientes
    {
        Task<List<Clientes>> ObterClientes();

        void AdicionarClientes(Clientes cliente);

        Task<Clientes> AtualizarClientes(Clientes cliente);
    }
}
