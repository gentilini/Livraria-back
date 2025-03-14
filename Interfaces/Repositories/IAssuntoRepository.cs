using Livraria.Models;

namespace Livraria.Interfaces.Repositories
{
    public interface IAssuntoRepository
    {
        Task<IEnumerable<Assunto>> GetAllAsync();
        Task<Assunto?> GetByIdAsync(int id);
        Task<int> CreateAsync(Assunto assunto);
        Task<int> UpdateAsync(Assunto assunto);
        Task<int> DeleteAsync(int id);
    }
}
