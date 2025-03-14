using Livraria.Interfaces.Services;
using Livraria.Models;
using Livraria.Services;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAll()
        {
            var autor = await _autorService.GetAllAsync();
            return Ok(autor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetById(int id)
        {
            var autor = await _autorService.GetByIdAsync(id);

            if (autor == null) return NotFound();

            return Ok(autor);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Autor autor)
        {
            var id = await _autorService.CreateAsync(autor);

            if (id > 0)
            {
                autor.CodAu = id;

                return CreatedAtAction(nameof(GetById), new { id = autor.CodAu }, autor);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Autor autor)
        {
            var success = await _autorService.UpdateAsync(autor);

            if (success)
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _autorService.DeleteAsync(id);

            if (success)
                return NoContent();

            return NotFound();
        }
    }
}
