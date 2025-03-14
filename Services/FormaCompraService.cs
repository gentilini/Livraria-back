using Livraria.Interfaces.Repositories;
using Livraria.Interfaces.Services;
using Livraria.Models;

namespace Livraria.Services
{
    public class FormaCompraService : IFormaCompraService
    {
        private readonly IFormaCompraRepository _formaCompraRepository;

        public FormaCompraService(IFormaCompraRepository formaCompraRepository)
        {
            _formaCompraRepository = formaCompraRepository;
        }

        public async Task<IEnumerable<FormaCompra>> GetAllAsync()
        {
            return await _formaCompraRepository.GetAllAsync();
        }

        public async Task<FormaCompra> GetByIdAsync(int id)
        {
            return await _formaCompraRepository.GetByIdAsync(id);
        }
    }
}
