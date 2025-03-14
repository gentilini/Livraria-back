using Livraria.Models;
using Livraria.ViewModels;

namespace Livraria.Interfaces.Repositories
{
    public interface ILivroRepository
    {
        Task<IEnumerable<LivroResponseViewModel>> GetAllAsync();
        Task<LivroResponseViewModel?> GetByIdAsync(int id);
        Task<int> CreateAsync(LivroModel model);
        Task<int> UpdateAsync(LivroModel model);
        Task<int> DeleteAsync(int id);
    }
}
