using System;

public abstract class PessoaBase : EntityBase
{
    public Guid Id { get; protected set; }
    public string Nome { get; protected set; } = null!;
    public Endereco Endereco { get; protected set; } = null!;

    protected PessoaBase() { }

    protected PessoaBase(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }

    
}