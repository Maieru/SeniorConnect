using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    [Table ("tbLembrete")]
    public class LembreteModel
    {
        [Key]
        [Column ("Id")]
        public int Id { get; set; }

        [Column ("AssinaturaId")]
        [ForeignKey ("AssinaturaModel")]
        public int AssinaturaId { get; set; }

        [Column ("Horario")]
        public DateTime Horario { get; set; }

        [Column ("Descricao")]
        public string Descricao { get; set; }
    }
}
