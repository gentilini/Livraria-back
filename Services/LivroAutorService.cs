using Livraria.Interfaces.Repositories;
using Livraria.Interfaces.Services;
using Livraria.Models;

namespace Livraria.Services
{
    public class LivroAutorService : ILivroAutorService
    {
        private readonly ILivroAutorRepository _livroAutorRepository;

        public LivroAutorService(ILivroAutorRepository livroAutorRepository)
        {
            _livroAutorRepository = livroAutorRepository;
        }

        public async Task<int> CreateAsync(LivroAutor livroAutor)
        {
            return await _livroAutorRepository.CreateAsync(livroAutor);
        }
    }
}
