using Livraria.Models;

namespace Livraria.Interfaces.Repositories
{
    public interface ILivroFormaCompraRepository
    {
        Task<int> CreateAsync(LivroFormaCompra livroFormaCompra);
        Task<int> DeleteAsync(int id);
    }
}
