using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vagas.API.Data;
using Vagas.API.InputModels;
using Vagas.API.Entities;

namespace Vagas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VagasController : ControllerBase
    {
        private readonly VagasDbContext _context;
        public VagasController(VagasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vagas = await _context.Vagas
                .AsNoTracking()
                .ToListAsync();

            return Ok(vagas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaga = await _context.Vagas
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.IdVaga == id);

            if (vaga is null)
                return NotFound();

            return Ok(vaga);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVagaInputModel input)
        {
            Vaga vaga = new();
            vaga.Create(input);

            await _context.Vagas.AddAsync(vaga);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = vaga.IdVaga }, vaga); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateVagaInputModel input)
        {
            var vaga = await _context.Vagas.SingleOrDefaultAsync(x => x.IdVaga == id);
            if (vaga is null)
                return NotFound();

            vaga.Update(input);

            _context.Vagas.Update(vaga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vaga = await _context.Vagas.SingleOrDefaultAsync(x => x.IdVaga == id);
            if (vaga is null)
                return NotFound();

            _context.Remove(vaga);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
