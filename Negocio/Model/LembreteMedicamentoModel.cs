using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    [Table("tbLembreteMedicamento")]
    public class LembreteMedicamentoModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("MedicamentoId")]
        [ForeignKey("MedicamentoModel")]
        public int MedicamentoId { get; set; }

        [Column("Horario")]
        public DateTime Horario { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }
    }
}
