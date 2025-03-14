using Livraria.Models;

namespace Livraria.Interfaces.Services
{
    public interface ILivroAssuntoService
    {
        Task<int> CreateAsync(LivroAssunto livroAssunto);
    }
}
