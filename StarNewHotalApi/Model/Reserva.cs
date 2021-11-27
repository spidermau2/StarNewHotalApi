using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarNewHotalApi.Model
{
    [Table("tb_reserva")]
    public class Reserva
    {
        [Column("ID_Reserva")]
        public int IdReserva { get; set; }
        [Column("QT_Reservas")]
        public int QuantidadeReserva { get; set; }
        [Column("HR_Entrada")]
        public TimeSpan HoraEntrada { get; set; }
        [Column("HR_Saida")]
        public TimeSpan HoraSaida { get; set; }
        [Column("ID_Cliente")]
        public int IdCliente { get; set; }
        [Column("ID_Pagamento")]
        public int IdPagamento { get; set; }
        [Column("ID_Quarto")]
        public int IdQuarto { get; set; }
        [Column("ID_Refeicao")]
        public int IdRefeicao { get; set; }
        [Column("Pago")]
        public string Pago { get; set; }
    }
}
