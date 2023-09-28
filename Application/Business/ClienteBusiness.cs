using Application.Interface;
using Domain.Entidades.Nutricionista.Clientes;
using Infra.InfraRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
