using Application.Interface;
using Domain.Entidades;
using Domain.Entidades.Nutricionista.Clientes;
using Domain.Interfaces;
using Infra.InfraRepository;

namespace Application.Business
{
    public class CepBusiness : ICep
    {
        readonly ICepService _CepService;
        private readonly INutriRepository _Nutri;
        public CepBusiness(ICepService cepService, INutriRepository nutri)
        {
            _CepService = cepService;
            _Nutri = nutri;
        }
        public async Task<Endereco> ObterEnderecoPorCep(string cep)
        {
            var teste = await _Nutri.Get();
            return await _CepService.ObterEnderecoPorCEPAsync(cep);
        }

        public async Task<List<ClientesResponseDTO>> ObterClientes()
        {
            return await _Nutri.Get();
        }

    }
}
