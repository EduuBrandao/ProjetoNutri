using Application.Interface;
using Domain.Entidades.Login;
using Infra.InfraRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business
{
    public class LoginBusiness : ILogin
    {
        private readonly ILoginRepository _Login;
        public LoginBusiness(ILoginRepository login)
        {
            _Login = login;
        }
        public async Task<string> BuscarLoginCliente(User credenciais)
        {
            return await _Login.GetLogin(credenciais);
        }
    }
}
