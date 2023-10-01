using Domain.Entidades.Nutricionista.Clientes;

namespace Infra.InfraRepository
{
    public interface INutriRepository
    {
        Task<List<Clientes>> Get();

        Task<Clientes> GetById(int id);
        void Post(Clientes cliente);
        Task<Clientes> Put(Clientes cliente);
        Task<string> Delete(string cpf);
    }
}
