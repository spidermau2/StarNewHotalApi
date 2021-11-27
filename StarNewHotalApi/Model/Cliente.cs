using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarNewHotalApi.Model
{

    [Table("tb_cliente")]
    public class Cliente
    {
        [Column("ID_Cliente")]
        public int IdCliente { get; set; }
        [Column("NM_Cliente")]
        public string Nome { get; set; }
        [Column("NR_RG")]
        public int Rg { get; set; }
        [Column("NR_CPF")]
        public long Cpf { get; set; }
    }
}
