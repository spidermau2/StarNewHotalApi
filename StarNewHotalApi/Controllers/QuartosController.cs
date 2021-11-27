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
    public class QuartosController : ControllerBase
    {
        private readonly DataContext _context;

        public QuartosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Quartos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quarto>>> GetQuarto()
        {
            return await _context.Quarto.ToListAsync();
        }

        [HttpGet]
        [Route("Ocupados")]
        public async Task<List<Quarto>> GetQuartosOcupados()
        {
            var quartos = await _context.Quarto.ToListAsync();
            var reservas = await _context.Reserva.Where(e => e.Pago == "N").Select(e => e.IdQuarto).ToListAsync();

            return quartos.Where(q => reservas.Contains(q.IdQuarto)).ToList();

        }

        // GET: api/Quartos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quarto>> GetQuarto(int id)
        {
            var quarto = await _context.Quarto.FindAsync(id);

            if (quarto == null)
            {
                return NotFound();
            }

            return quarto;
        }

        // PUT: api/Quartos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuarto(int id, Quarto quarto)
        {
            if (id != quarto.IdQuarto)
            {
                return BadRequest();
            }

            _context.Entry(quarto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuartoExists(id))
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

        // POST: api/Quartos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quarto>> PostQuarto(Quarto quarto)
        {
            _context.Quarto.Add(quarto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuarto", new { id = quarto.IdQuarto }, quarto);
        }

        // DELETE: api/Quartos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuarto(int id)
        {
            var quarto = await _context.Quarto.FindAsync(id);
            if (quarto == null)
            {
                return NotFound();
            }

            _context.Quarto.Remove(quarto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuartoExists(int id)
        {
            return _context.Quarto.Any(e => e.IdQuarto == id);
        }
    }
}
