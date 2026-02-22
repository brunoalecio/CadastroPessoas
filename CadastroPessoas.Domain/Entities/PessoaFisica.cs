public class PessoaFisica : PessoaBase
{
    public string CPF { get; private set; }

    public PessoaFisica(string nome, string cpf) : base(nome)
    {
        CPF = cpf;

        AddDomainEvent(new PessoaFisicaCriadaEvent(Id, Nome, CPF));
    }
}