using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    [Table("tbPlano")]
    public class PlanoModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Valor")]
        public double Valor { get; set; }
    }
}
