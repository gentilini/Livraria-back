using Livraria.Models;

namespace Livraria.Interfaces.Services
{
    public interface ILivrosPorAutorViewService
    {
        Task<IEnumerable<LivrosPorAutorView>> GetAllAsync();
    }
}
