using Application.Interface;
using Domain.Entidades;
using Domain.Interfaces;
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
        public CepBusiness(ICepService cepService)
        {
            _CepService = cepService;
        }
        public async Task<Endereco> GetAddress(string cep)
        {
            return await _CepService.ObterEnderecoPorCEPAsync(cep);
        }
    }
}
