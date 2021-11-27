using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarNewHotalApi.Model
{
    [Table("resumo")]
    public class Resumo
    {
        public int Reserva { get; set; }
        public TimeSpan Entrada { get; set; }
        public TimeSpan Saida { get; set; }
        public string Cliente { get; set; }
        public string Pagamento { get; set; }
        public string Quarto { get; set; }
        public string Refeicao { get; set; }
        public float ValorQuarto { get; set; }
        public float ValorRefeicao { get; set; }
        public string Pago { get; set; }
        public int Quantidade { get; set; }
    }
}
