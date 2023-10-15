using Domain.Entidades.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ILogin
    {
        Task<string> BuscarLoginCliente(User credenciais);
    }
}
