using MediatR;
using System;

public record DeletePessoaCommand(Guid Id) : IRequest<bool>;