using Livraria.Interfaces.Repositories;
using Livraria.Interfaces.Services;
using Livraria.Models;

namespace Livraria.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<int> CreateAsync(Autor autor)
        {
            return await _autorRepository.CreateAsync(autor);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _autorRepository.DeleteAsync(id);

            return result > 0;
        }

        public async Task<IEnumerable<Autor>> GetAllAsync()
        {
            return await _autorRepository.GetAllAsync();
        }

        public async Task<Autor> GetByIdAsync(int id)
        {
            return await _autorRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Autor autor)
        {
            var result = await _autorRepository.UpdateAsync(autor);

            return result > 0;
        }
    }
}
