using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    [Table("tbMedicamento")]
    public class MedicamentoModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("AssinaturaId")]
        [ForeignKey("AssinaturaModel")]
        public int AssinaturaId { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(100, ErrorMessage = "A descrição não pode ultrapassar 100 caracteres")]
        public string? Descricao { get; set; }

        [Column("Posicao")]
        [Required(ErrorMessage = "A posição é obrigatória")]
        [Range(1, 7, ErrorMessage = "A posição deve ser um valor entre 1 e 7")]
        public int PosicaoNaCaixaRemedio { get; set; }
    }
}
