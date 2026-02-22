public class Endereco
{
    public string Cep { get; private set; }
    public string Logradouro { get; private set; }
    public string Cidade { get; private set; }
    public string UF { get; private set; }

    public Endereco(string cep, string logradouro, string cidade, string uf)
    {
        Cep = cep;
        Logradouro = logradouro;
        Cidade = cidade;
        UF = uf;
    }
}