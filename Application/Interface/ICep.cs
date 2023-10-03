using Domain.Entidades;
using Domain.Entidades.Nutricionista.Clientes;

namespace Application.Interface
{
    public interface ICep
    {
        Task<Endereco> ObterEnderecoPorCep(string cep);

        Task<List<ClientesResponseDTO>> ObterClientes();
        
    }
}
