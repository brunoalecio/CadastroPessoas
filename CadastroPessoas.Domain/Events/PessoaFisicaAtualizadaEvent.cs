using MediatR;
using System;

public record PessoaFisicaAtualizadaEvent(
    Guid Id,
    string Nome,
    string CPF
) : INotification;