using MediatR;
using System;

public record PessoaFisicaCriadaEvent(
    Guid Id,
    string Nome,
    string CPF
) : INotification;