using Livraria.Models;

namespace Livraria.Interfaces.Repositories
{
    public interface ILivrosPorAutorViewRepository
    {
        Task<IEnumerable<LivrosPorAutorView>> GetAllAsync();
    }
}
