using Domain.Entidades.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.InfraRepository
{
    public interface ILoginRepository
    {
        Task<string> GetLogin(User credenciais);
    }
}
