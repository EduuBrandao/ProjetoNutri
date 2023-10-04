using Domain.Entidades;
using Domain.Entidades.Correio;
using Domain.Interfaces;
using System.Net.Http.Json;

namespace Domain.Service
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;

        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Endereco> ObterEnderecoPorCEPAsync(string cep)
        {
            try
            {
                cep = new string(cep.Where(char.IsDigit).ToArray());

                if (cep.Length != 8)
                {
                    throw new ArgumentException("CEP inválido");
                }

                var response = await _httpClient.GetFromJsonAsync<CEPRespondeDTO>($"https://viacep.com.br/ws/{cep}/json/");

                if (response != null)
                {
                    var endereco = new Endereco
                    {
                        Logradouro = response.Logradouro,
                        Bairro = response.Bairro,
                        Cidade = response.Localidade,
                        Estado = response.Uf,
                    };

                    return endereco;
                }
                else
                {
                    throw new Exception("Não foi possível obter os dados do endereço.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter endereço: {ex.Message}");
            }
        }
        public void GetAddress(string cep)
        {
            throw new NotImplementedException();
        }
    }
}
