using Livraria.Interfaces.Repositories;
using Livraria.Interfaces.Services;
using Livraria.Models;

namespace Livraria.Services
{
    public class LivroFormaCompraService : ILivroFormaCompraService
    {
        private readonly ILivroFormaCompraRepository _livroFormaCompraRepository;

        public LivroFormaCompraService(ILivroFormaCompraRepository livroFormaCompraRepository)
        {
            _livroFormaCompraRepository = livroFormaCompraRepository;
        }

        public async Task<int> CreateAsync(LivroFormaCompra livroFormaCompra)
        {
            return await _livroFormaCompraRepository.CreateAsync(livroFormaCompra);
        }
    }
}
