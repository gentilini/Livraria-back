using Livraria.ViewModels;

namespace Livraria.Interfaces.Services
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroResponseViewModel>> GetAllAsync();
        Task<LivroResponseViewModel> GetByIdAsync(int id);
        Task<int> CreateAsync(LivroRequestViewModel livroRequestViewModel);
        Task<bool> UpdateAsync(LivroRequestViewModel livroRequestViewModel);
        Task<bool> DeleteAsync(int id);
    }
}
