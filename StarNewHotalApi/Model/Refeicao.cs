using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarNewHotalApi.Model
{
    [Table("tb_refeicao")]
    public class Refeicao
    {
        [Column("ID_Refeicao")]
        public int IdRefeicao { get; set; }
        [Column("DS_Refeicao")]
        public string Descricao { get; set; }
        [Column("VL_Refeicao")]
        public double Valor { get; set; }
    }
}
