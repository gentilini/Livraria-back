using Livraria.Models;
using Livraria.ViewModels;

namespace Livraria.Interfaces.Repositories
{
    public interface ILivroRepository
    {
        Task<IEnumerable<LivroResponseViewModel>> GetAllAsync();
        Task<LivroResponseViewModel?> GetByIdAsync(int id);
        Task<int> CreateAsync(Livro livro);
        Task<int> UpdateAsync(Livro livro);
        Task<int> DeleteAsync(int id);
    }
}
