using Livraria.Interfaces.Services;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaCompraController : ControllerBase
    {
        private readonly IFormaCompraService _formaCompraService;

        public FormaCompraController(IFormaCompraService formaCompraService)
        {
            _formaCompraService = formaCompraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormaCompra>>> GetAll()
        {
            var formaCompra = await _formaCompraService.GetAllAsync();

            return Ok(formaCompra);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FormaCompra>> GetById(int id)
        {
            var formaCompra = await _formaCompraService.GetByIdAsync(id);

            if (formaCompra == null) return NotFound();

            return Ok(formaCompra);
        }
    }
}
