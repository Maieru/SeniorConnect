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
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(100, ErrorMessage = "A descrição não pode ultrapassar 100 caracteres")]
        public string Descricao { get; set; }
    }
}
