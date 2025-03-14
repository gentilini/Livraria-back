using Livraria.Interfaces.Repositories;
using Livraria.Interfaces.Services;
using Livraria.Models;

namespace Livraria.Services
{
    public class LivrosPorAutorViewService : ILivrosPorAutorViewService
    {
        private readonly ILivrosPorAutorViewRepository _livrosPorAutorViewRepository;

        public LivrosPorAutorViewService(ILivrosPorAutorViewRepository livrosPorAutorViewRepository)
        {
            _livrosPorAutorViewRepository = livrosPorAutorViewRepository;
        }

        public async Task<IEnumerable<LivrosPorAutorView>> GetAllAsync()
        {
            return await _livrosPorAutorViewRepository.GetAllAsync();
        }
    }
}
