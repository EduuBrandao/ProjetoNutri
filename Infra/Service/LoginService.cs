using AutoMapper;
using Domain.Entidades.Login;
using Infra.Data;
using Infra.InfraRepository;
using Infra.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Service
{
    public class LoginService : BaseRepository<LoginConfig>, ILoginRepository
    {
        private readonly IMapper _mapper;
        public LoginService(NutriContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<string> GetLogin(User credenciais)
        {
            var credenciaisLogin = await Context.LoginClientes.Where(x => x.Email == credenciais.Email).FirstOrDefaultAsync();

            if (credenciaisLogin == null)
                return "Usuário não existe na nossa base de dados";

            return credenciaisLogin.Password == credenciais.Password ?
                   "Usuário autenticado" : "Usuário não existe na nossa base de dados";
        }

        protected T Mapper<T>(Object data)
        {
            return _mapper.Map<T>(data);
        }
    }
}
