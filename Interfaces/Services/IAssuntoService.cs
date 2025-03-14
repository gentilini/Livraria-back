using Livraria.Models;

namespace Livraria.Interfaces.Services
{
    public interface IAssuntoService
    {
        Task<IEnumerable<Assunto>> GetAllAsync();
        Task<Assunto> GetByIdAsync(int id);
        Task<int> CreateAsync(Assunto assunto);
        Task<bool> UpdateAsync(Assunto assunto);
        Task<bool> DeleteAsync(int id);
    }
}
