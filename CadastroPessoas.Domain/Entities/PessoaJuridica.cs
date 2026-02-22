using System;

namespace CadastroPessoas.Domain.Entities
{
    public class PessoaJuridica : PessoaBase
    {
        public string CNPJ { get; private set; } = null!;
        protected PessoaJuridica() { } 

        public PessoaJuridica(string nome, string cnpj)
            : base(nome)
        {
            CNPJ = cnpj;

            AddDomainEvent(new PessoaJuridicaCriadaEvent(
                Id,
                Nome,
                CNPJ
            ));
        }
    }
}