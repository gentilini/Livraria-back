using Livraria.Models;

namespace Livraria.Interfaces.Services
{
    public interface IFormaCompraService
    {
        Task<IEnumerable<FormaCompra>> GetAllAsync();
        Task<FormaCompra> GetByIdAsync(int id);
    }
}
