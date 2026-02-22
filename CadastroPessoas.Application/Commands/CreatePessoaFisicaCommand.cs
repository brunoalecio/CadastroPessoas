using MediatR;
using System;

public record CreatePessoaFisicaCommand(
    string Nome,
    string CPF,
    string Cep,
    string Logradouro,
    string Cidade,
    string UF
) : IRequest<Guid>;