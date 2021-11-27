using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarNewHotalApi.Data;
using StarNewHotalApi.Model;

namespace StarNewHotalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefeicoesController : ControllerBase
    {
        private readonly DataContext _context;

        public RefeicoesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Refeicaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Refeicao>>> GetRefeicao()
        {
            return await _context.Refeicao.ToListAsync();
        }

        // GET: api/Refeicaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Refeicao>> GetRefeicao(int id)
        {
            var refeicao = await _context.Refeicao.FindAsync(id);

            if (refeicao == null)
            {
                return NotFound();
            }

            return refeicao;
        }

        // PUT: api/Refeicaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefeicao(int id, Refeicao refeicao)
        {
            if (id != refeicao.IdRefeicao)
            {
                return BadRequest();
            }

            _context.Entry(refeicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefeicaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Refeicaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Refeicao>> PostRefeicao(Refeicao refeicao)
        {
            _context.Refeicao.Add(refeicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRefeicao", new { id = refeicao.IdRefeicao }, refeicao);
        }

        // DELETE: api/Refeicaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefeicao(int id)
        {
            var refeicao = await _context.Refeicao.FindAsync(id);
            if (refeicao == null)
            {
                return NotFound();
            }

            _context.Refeicao.Remove(refeicao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RefeicaoExists(int id)
        {
            return _context.Refeicao.Any(e => e.IdRefeicao == id);
        }
    }
}
