using AutoMapper;
using Domain.Entidades.Nutricionista.Clientes;
using Infra.Data;
using Infra.InfraRepository;
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Service
{
    public class NutriService : BaseRepository<ClientesConfig>, INutriRepository
    {
        private readonly IMapper _mapper;
        public NutriService(NutriContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<string> Delete(string cpf)
        {
            try
            {
                var document = await Context.DadosClientes.Where(x => x.cpf == cpf).FirstOrDefaultAsync();

                if (document == null)
                    throw new ArgumentException("Cliente não encontrado no banco de dados.", nameof(cpf));

                Context.DadosClientes.Remove(document);
                Context.SaveChanges();
                return $"Usuario do CPF: {cpf} deletado da base de dados!!";
            }
            catch (Exception)
            {
                throw new ArgumentException("Algo deu errado", nameof(cpf));
                return $"Não foi possivel deletar o cliente do cpf: {cpf}";
            }
        }

        public async Task<List<Clientes>> Get()
        {
            var document = Context.DadosClientes.ToList();

            return Mapper<List<Clientes>>(document);
        }

        public async Task<Clientes> GetById(int id)
        {
            var document = await Context.DadosClientes.Where(x => x.id == id).FirstOrDefaultAsync();

            return Mapper<Clientes>(document);
        }

        public void Post(Clientes cliente)
        {
            ClientesConfig clientesConfig = Mapper<ClientesConfig>(cliente);
            Context.DadosClientes.Add(clientesConfig);
            Context.SaveChanges();
        }

        public async Task<Clientes> Put(Clientes cliente)
        {
            var document = await Context.DadosClientes.Where(x => x.cpf == cliente.cpf).FirstOrDefaultAsync();

            if (document == null)
                throw new ArgumentException("Cliente não encontrado no banco de dados.", nameof(cliente.cpf));

            document.idade = cliente.idade;
            document.nome = cliente.nome;

            Context.DadosClientes.Update(document);
            Context.SaveChanges();
            return Mapper<Clientes>(document);
        }

        protected T Mapper<T>(Object data)
        {
            return _mapper.Map<T>(data);
        }
    }
}
