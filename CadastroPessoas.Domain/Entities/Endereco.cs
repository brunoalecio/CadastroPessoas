public class Endereco
{
    public string Cep { get; private set; } = null!;
    public string Logradouro { get; private set; } = null!;
    public string Cidade { get; private set; } = null!;
    public string UF { get; private set; } = null!;

    protected Endereco() { }
    public Endereco(string cep, string logradouro, string cidade, string uf)
    {
        Cep = cep;
        Logradouro = logradouro;
        Cidade = cidade;
        UF = uf;
    }
}