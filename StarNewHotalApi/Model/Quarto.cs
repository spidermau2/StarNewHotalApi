using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarNewHotalApi.Model
{
    [Table("tb_quarto")]
    public class Quarto
    {
        [Column("ID_Quarto")]
        public int IdQuarto { get; set; }
        [Column("DS_Quarto")]
        public string Descricao { get; set; }
        [Column("Valor")]
        public float Valor { get; set; }
    }
}
