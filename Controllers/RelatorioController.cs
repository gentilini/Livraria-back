using Livraria.Interfaces.Services;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly ILivrosPorAutorViewService _livrosPorAutorViewService;

        public RelatorioController(ILivrosPorAutorViewService livrosPorAutorViewService)
        {
            _livrosPorAutorViewService = livrosPorAutorViewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivrosPorAutorView>>> GetAll()
        {
            var livros = await _livrosPorAutorViewService.GetAllAsync();

            return Ok(livros);
        }
    }
}
