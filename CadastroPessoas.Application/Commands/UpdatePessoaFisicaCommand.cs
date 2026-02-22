using MediatR;
using System;

public record UpdatePessoaFisicaCommand(
    Guid Id,
    string Nome,
    string CPF,
    string Cep
) : IRequest<bool>;