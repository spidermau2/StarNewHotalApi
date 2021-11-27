using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarNewHotalApi.Model
{
    [Table("tb_formapagamento")]
    public class FormaPagamento
    {
        [Column("ID_Pagamento")]
        public int IdFormaPagamento { get; set; }
        [Column("DS_Pagamento")]
        public string Descricao { get; set; }
    }
}
