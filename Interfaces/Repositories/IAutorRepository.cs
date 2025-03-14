using Livraria.Models;

namespace Livraria.Interfaces.Repositories
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAllAsync();
        Task<Autor?> GetByIdAsync(int id);
        Task<int> CreateAsync(Autor autor);
        Task<int> UpdateAsync(Autor autor);
        Task<int> DeleteAsync(int id);
    }
}
