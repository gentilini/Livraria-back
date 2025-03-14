using Livraria.Models;

namespace Livraria.Interfaces.Repositories
{
    public interface ILivroAutorRepository
    {
        Task<int> CreateAsync(LivroAutor livroAutor);
        Task<int> DeleteAsync(int id);
    }
}
