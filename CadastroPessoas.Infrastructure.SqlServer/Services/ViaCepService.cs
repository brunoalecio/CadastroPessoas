using CadastroPessoas.Application.Interfaces;
using CadastroPessoas.Domain.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CadastroPessoas.Infrastructure.SqlServer.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Endereco> ConsultarCepAsync(string cep)
        {
            var response = await _httpClient.GetFromJsonAsync<ViaCepResponse>(
                $"https://viacep.com.br/ws/{cep}/json/");

            if (response == null || response.erro == true)
                throw new Exception("CEP inválido");

            return new Endereco(
                response.cep,
                response.logradouro,
                response.localidade,
                response.uf
            );
        }
    }
}