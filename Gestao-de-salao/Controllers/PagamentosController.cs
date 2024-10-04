using Gestao_de_salao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestao_de_salao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PagamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Pagamentos.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Pagamento model)
        {
        
            var salaoExists = await _context.Saloes.AnyAsync(s => s.Id == model.SalaoId);
            if (!salaoExists)
            {
                return BadRequest("SalaoId não existe.");
            }
    
            _context.Pagamentos.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Pagamentos
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Pagamento model)
        {
            if (id != model.Id) return BadRequest();

            var modeloDb = await _context.Pagamentos.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.Pagamentos.Update(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Pagamentos.FindAsync(id);

            if (model == null) return NotFound();

            _context.Pagamentos.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
