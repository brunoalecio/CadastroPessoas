using MediatR;

public class CreatePessoaFisicaCommand : IRequest<Guid>
{
    public string Nome { get; set; } = null!;
    public string CPF { get; set; } = null!;
    public string Cep { get; set; } = null!;
}