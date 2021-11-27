using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarNewHotalApi.Model
{
    public class ReservaAux
    {
        public int IdReserva { get; set; }
        public int QuantidadeReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdPagamento { get; set; }
        public int IdQuarto { get; set; }
        public int IdRefeicao { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSaida { get; set; }
        public string Pago { get; set; }

    }
}
