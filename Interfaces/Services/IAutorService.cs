using Livraria.Models;

namespace Livraria.Interfaces.Services
{
    public interface IAutorService
    {
        Task<IEnumerable<Autor>> GetAllAsync();
        Task<Autor> GetByIdAsync(int id);
        Task<int> CreateAsync(Autor autor);
        Task<bool> UpdateAsync(Autor autor);
        Task<bool> DeleteAsync(int id);
    }
}
