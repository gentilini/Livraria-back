using Livraria.Models;

namespace Livraria.Interfaces.Services
{
    public interface ILivroFormaCompraService
    {
        Task<int> CreateAsync(LivroFormaCompra livroFormaCompra);
    }
}
