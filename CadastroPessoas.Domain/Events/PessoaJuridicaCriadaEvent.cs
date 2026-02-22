using MediatR;
using System;

public record PessoaJuridicaCriadaEvent(
    Guid Id,
    string Nome,
    string CNPJ
) : INotification;