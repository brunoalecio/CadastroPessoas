using MediatR;
using System.Collections.Generic;

public record GetPessoasQuery() : IRequest<List<PessoaReadModel>>;