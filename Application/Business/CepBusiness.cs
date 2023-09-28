using Application.Interface;
using Domain.Entidades;
using Domain.Entidades.Nutricionista.Clientes;
using Domain.Interfaces;
using Infra.InfraRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<Clientes>> ObterClientes()
        {
            return await _Nutri.Get();
        }

    }
}
