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
    public class FormaPagamentosController : ControllerBase
    {
        private readonly DataContext _context;

        public FormaPagamentosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FormaPagamentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormaPagamento>>> GetFormaPagamento()
        {
            return await _context.FormaPagamento.ToListAsync();
        }

        // GET: api/FormaPagamentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormaPagamento>> GetFormaPagamento(int id)
        {
            var formaPagamento = await _context.FormaPagamento.FindAsync(id);

            if (formaPagamento == null)
            {
                return NotFound();
            }

            return formaPagamento;
        }

        // PUT: api/FormaPagamentoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormaPagamento(int id, FormaPagamento formaPagamento)
        {
            if (id != formaPagamento.IdFormaPagamento)
            {
                return BadRequest();
            }

            _context.Entry(formaPagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormaPagamentoExists(id))
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

        // POST: api/FormaPagamentoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormaPagamento>> PostFormaPagamento(FormaPagamento formaPagamento)
        {
            _context.FormaPagamento.Add(formaPagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormaPagamento", new { id = formaPagamento.IdFormaPagamento }, formaPagamento);
        }

        // DELETE: api/FormaPagamentoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormaPagamento(int id)
        {
            var formaPagamento = await _context.FormaPagamento.FindAsync(id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            _context.FormaPagamento.Remove(formaPagamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormaPagamentoExists(int id)
        {
            return _context.FormaPagamento.Any(e => e.IdFormaPagamento == id);
        }
    }
}
