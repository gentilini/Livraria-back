using Livraria.Models;

namespace Livraria.Interfaces.Repositories
{
    public interface ILivroAssuntoRepository
    {
        Task<int> CreateAsync(LivroAssunto livroAssunto);
        Task<int> DeleteAsync(int id);
    }
}
