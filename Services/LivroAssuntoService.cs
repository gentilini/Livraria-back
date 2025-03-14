using Livraria.Interfaces.Repositories;
using Livraria.Interfaces.Services;
using Livraria.Models;

namespace Livraria.Services
{
    public class LivroAssuntoService : ILivroAssuntoService
    {
        private readonly ILivroAssuntoRepository _livroAssuntoRepository;

        public LivroAssuntoService(ILivroAssuntoRepository livroAssuntoRepository)
        {
            _livroAssuntoRepository = livroAssuntoRepository;
        }

        public async Task<int> CreateAsync(LivroAssunto livroAssunto)
        {
            return await _livroAssuntoRepository.CreateAsync(livroAssunto);
        }
    }
}
