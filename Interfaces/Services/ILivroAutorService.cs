using Livraria.Models;

namespace Livraria.Interfaces.Services
{
    public interface ILivroAutorService
    {
        Task<int> CreateAsync(LivroAutor livroAutor);
    }
}
