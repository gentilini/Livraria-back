using Livraria.Interfaces.Services;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuntoController : ControllerBase
    {
        private readonly IAssuntoService _assuntoService;

        public AssuntoController(IAssuntoService assuntoService)
        {
            _assuntoService = assuntoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assunto>>> GetAll()
        {
            var assunto = await _assuntoService.GetAllAsync();
            return Ok(assunto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assunto>> GetById(int id)
        {
            var assunto = await _assuntoService.GetByIdAsync(id);

            if (assunto == null) return NotFound();

            return Ok(assunto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Assunto assunto)
        {
            var id = await _assuntoService.CreateAsync(assunto);

            if (id > 0)
            {
                assunto.CodAs = id;

                return CreatedAtAction(nameof(GetById), new { id = assunto.CodAs }, assunto);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Assunto assunto)
        {
            assunto.CodAs = id;

            var success = await _assuntoService.UpdateAsync(assunto);

            if (success)
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _assuntoService.DeleteAsync(id);

            if (success)
                return NoContent();

            return NotFound();
        }
    }
}
