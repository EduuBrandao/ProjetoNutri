using Domain.Entidades;

namespace Domain.Interfaces
{
    public interface ICepService
    {
        void GetAddress(string cep);

        Task<Endereco> ObterEnderecoPorCEPAsync(string cep);
    }
}
