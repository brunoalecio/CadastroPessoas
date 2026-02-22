using CadastroPessoas.Domain.Entities;
using System.Threading.Tasks;

namespace CadastroPessoas.Application.Interfaces
{
    public interface IViaCepService
    {
        Task<Endereco> ConsultarCepAsync(string cep);
    }
}