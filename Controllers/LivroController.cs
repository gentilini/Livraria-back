using Livraria.Interfaces.Services;
using Livraria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroResponseViewModel>>> GetAll()
        {
            var livro = await _livroService.GetAllAsync();
            return Ok(livro);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroResponseViewModel>> GetById(int id)
        {
            var livro = await _livroService.GetByIdAsync(id);

            if (livro == null) return NotFound();

            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] LivroRequestViewModel livroRequestViewModel)
        {
            var id = await _livroService.CreateAsync(livroRequestViewModel);

            if (id > 0)
            {
                livroRequestViewModel.Livro.Codl = id;
                return CreatedAtAction(nameof(GetById), new { id = livroRequestViewModel.Livro.Codl }, livroRequestViewModel);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] LivroRequestViewModel livroRequestViewModel)
        {
            livroRequestViewModel.Livro.Codl = id;

            var success = await _livroService.UpdateAsync(livroRequestViewModel);

            if (success)
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _livroService.DeleteAsync(id);

            if (success)
                return NoContent();

            return NotFound();
        }
    }
}
