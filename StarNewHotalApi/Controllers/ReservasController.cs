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
    public class ReservasController : ControllerBase
    {
        private readonly DataContext _context;

        public ReservasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaAux>>> GetReserva()
        {
            List<ReservaAux> ret = new();
            var reservas = await _context.Reserva.ToListAsync();

            foreach(var item in reservas)
            {
                ReservaAux reserva = new()
                {
                    IdCliente = item.IdCliente,
                    IdPagamento = item.IdPagamento,
                    IdQuarto = item.IdQuarto,
                    IdRefeicao = item.IdRefeicao,
                    IdReserva = item.IdReserva,
                    QuantidadeReserva = item.QuantidadeReserva,
                    HoraEntrada = item.HoraEntrada.ToString(),
                    HoraSaida = item.HoraSaida.ToString(),
                    Pago = item.Pago
                };
                ret.Add(reserva);
            }
            return ret;
        }

        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        // PUT: api/Reservas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutReserva(ReservaAux reservaAux)
        {
            Reserva reserva = new()
            {
                HoraEntrada = TimeSpan.Parse(reservaAux.HoraEntrada),
                HoraSaida = TimeSpan.Parse(reservaAux.HoraSaida),
                IdCliente = reservaAux.IdCliente,
                IdPagamento = reservaAux.IdPagamento,
                IdQuarto = reservaAux.IdQuarto,
                IdRefeicao = reservaAux.IdRefeicao,
                QuantidadeReserva = reservaAux.QuantidadeReserva,
                Pago = reservaAux.Pago,
                IdReserva = reservaAux.IdReserva
            };

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(reserva.IdReserva))
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

        // POST: api/Reservas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(ReservaAux reservaAux)
        {
            Reserva reserva = new()
            {
                HoraEntrada = TimeSpan.Parse(reservaAux.HoraEntrada),
                HoraSaida = TimeSpan.Parse(reservaAux.HoraSaida),
                IdCliente = reservaAux.IdCliente,
                IdPagamento = reservaAux.IdPagamento,
                IdQuarto = reservaAux.IdQuarto,
                IdRefeicao = reservaAux.IdRefeicao,
                QuantidadeReserva = reservaAux.QuantidadeReserva,
                Pago = reservaAux.Pago
            };
            _context.Reserva.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReserva", new { id = reserva.IdReserva }, reserva);
        }

        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.IdReserva == id);
        }
    }
}
