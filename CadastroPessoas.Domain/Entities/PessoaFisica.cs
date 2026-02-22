public class PessoaFisica : PessoaBase
{
    public string CPF { get; private set; } = null!;

    protected PessoaFisica() { }
    public PessoaFisica(string nome, string cpf) : base(nome)
    {
        CPF = cpf;

        AddDomainEvent(new PessoaFisicaCriadaEvent(Id, Nome, CPF));

    }

    public void DefinirEndereco(Endereco endereco)
    {
        Endereco = endereco;
    }

    public void AtualizarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser vazio.");

        Nome = nome;
    }

    public void AtualizarCPF(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("CPF não pode ser vazio.");

        CPF = cpf;
    }
}