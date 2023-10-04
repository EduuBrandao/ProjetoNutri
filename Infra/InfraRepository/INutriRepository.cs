using Domain.Entidades.Nutricionista.Clientes;

namespace Infra.InfraRepository
{
    public interface INutriRepository
    {
        Task<List<ClientesResponseDTO>> Get();

        Task<ClientesResponseDTO> GetById(int id);
        ClientesResponseDTO Post(ClientesRequestDTO cliente);
        Task<ClientesResponseDTO> Put(ClientesRequestDTO cliente);
        Task<string> Delete(string cpf);
    }
}
