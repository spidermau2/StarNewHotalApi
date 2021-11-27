using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarNewHotalApi.Data;
using StarNewHotalApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarNewHotalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumoController : ControllerBase
    {
        private readonly DataContext _context;

        public ResumoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Resumo
        [HttpGet]
        public async Task<ActionResult<List<ResumoAux>>> GetClientes()
        {
            var resumo = await _context.Resumos.ToListAsync();
            List<ResumoAux> ret = new();
            foreach(var item in resumo)
            {
                ResumoAux resumoAux = new()
                {
                    Reserva = item.Reserva,
                    Cliente = item.Cliente,
                    Pagamento = item.Pagamento,
                    Quarto = item.Quarto,
                    Refeicao = item.Refeicao,
                    Entrada = item.Entrada.ToString(),
                    Saida = item.Saida.ToString(),
                    Pago = item.Pago,
                    ValorQuarto = item.ValorQuarto,
                    ValorRefeicao = item.ValorRefeicao,
                    Quantidade = item.Quantidade
                };
                ret.Add(resumoAux);
            }
            return ret;
        }

        // GET: api/Resumo/IdReserva
        [HttpGet("{id}")]
        public async Task<ActionResult<Resumo>> GetCliente(int id)
        {
            var resumo = await _context.Resumos.FirstOrDefaultAsync(r => r.Reserva == id);

            if (resumo == null)
            {
                return NotFound();
            }

            return resumo;
        }
    }
}
