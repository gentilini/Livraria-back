using Livraria.Interfaces.Repositories;
using Livraria.Interfaces.Services;
using Livraria.Models;

namespace Livraria.Services
{
    public class AssuntoService : IAssuntoService
    {
        private readonly IAssuntoRepository _assuntoRepository;

        public AssuntoService(IAssuntoRepository assuntoRepository)
        {
            _assuntoRepository = assuntoRepository;
        }

        public async Task<int> CreateAsync(Assunto assunto)
        {
            return await _assuntoRepository.CreateAsync(assunto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _assuntoRepository.DeleteAsync(id);

            return result > 0;
        }

        public async Task<IEnumerable<Assunto>> GetAllAsync()
        {
            return await _assuntoRepository.GetAllAsync();
        }

        public async Task<Assunto> GetByIdAsync(int id)
        {
            return await _assuntoRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Assunto assunto)
        {
            var result = await _assuntoRepository.UpdateAsync(assunto);

            return result > 0;
        }
    }
}
