namespace CadastroPessoas.Infrastructure.SqlServer.Services
{
    public class ViaCepResponse
    {
        public string cep { get; set; } = null!;
        public string logradouro { get; set; } = null!;
        public string localidade { get; set; } = null!;
        public string uf { get; set; } = null!;
        public bool erro { get; set; }
    }
}