using Domain.Entidades.Nutricionista.Clientes;

namespace Infra.InfraRepository
{
    public interface INutriRepository
    {
        Task<List<Clientes>> Get();
        void Post(Clientes cliente);
    }
}
