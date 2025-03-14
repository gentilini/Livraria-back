using Livraria.Models;

namespace Livraria.Interfaces.Repositories
{
    public interface IFormaCompraRepository
    {
        Task<IEnumerable<FormaCompra>> GetAllAsync();
        Task<FormaCompra?> GetByIdAsync(int id);
    }
}
