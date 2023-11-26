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
        [Required(ErrorMessage = "É necessário preencher o horário")]
        public DateTime Horario { get; set; }

        [Column ("Descricao")]
        [Required (ErrorMessage = "É necessário preencher a descrição")]
        [MaxLength(100, ErrorMessage = "A descrição não pode ter mais do que 100 caracteres")]
        public string Descricao { get; set; }

        [NotMapped]
        public List<int> DispositivosAssociados { get; set; }
    }
}
