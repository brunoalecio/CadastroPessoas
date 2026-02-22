public class PessoaFisica : PessoaBase
{
    public string CPF { get; private set; } = null!;

    protected PessoaFisica() { }
    public PessoaFisica(string nome, string cpf) : base(nome)
    {
        CPF = cpf;

        AddDomainEvent(new PessoaFisicaCriadaEvent(Id, Nome, CPF));
    }
}