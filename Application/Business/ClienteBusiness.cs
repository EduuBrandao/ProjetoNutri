using Application.Interface;
using Domain.Entidades.Nutricionista.Clientes;
using Infra.InfraRepository;

namespace Application.Business
{
    public class ClienteBusiness : IClientes
    {
        private readonly INutriRepository _Nutri;
        private readonly IEnderecoRepository _endereco;
        public ClienteBusiness(INutriRepository nutri, IEnderecoRepository endereco)
        {
            _Nutri = nutri;
            _endereco = endereco;
        }
        public async Task<List<ClienteInfo>> ObterClientes()
        {
            var endereco = await _endereco.Get();
            var clientes = await _Nutri.Get();

            return ClienteAdapter(endereco, clientes);
        }
        public void AdicionarClientes(ClientesRequestDTO cliente)
        {
            _Nutri.Post(cliente);
        }

        public async Task<ClientesResponseDTO> AtualizarClientes(ClientesRequestDTO cliente)
        {
            return await _Nutri.Put(cliente);
        }

        public async Task<string> DeletarCliente(string cpf)
        {
            return await _Nutri.Delete(cpf);
        }


        private List<ClienteInfo> ClienteAdapter(List<EnderecoResponseDTO> endereco, List<ClientesResponseDTO> clientes)
        {
            var clientesInfos = new List<ClienteInfo>();


            foreach (var cliente in clientes)
            {
                var clienteInfo = new ClienteInfo
                {
                    Altura = cliente.altura,
                    Cpf = cliente.cpf,
                    Peso = cliente.peso,
                    Idade = cliente.idade,
                    Nome = cliente.nome,
                    Sexo = cliente.sexo,
                    Endereco = endereco.Where(x => x.ClientId == cliente.Id).FirstOrDefault()
                };

                clientesInfos.Add(clienteInfo);
            }
            return clientesInfos;
        }
    }
}
