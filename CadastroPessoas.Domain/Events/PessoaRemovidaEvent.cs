using MediatR;
using System;

namespace CadastroPessoas.Domain.Events
{
    public record PessoaRemovidaEvent(Guid Id) : INotification;
}