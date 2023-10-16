using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    [Table ("tbMedicamento")]
    public class MedicamentoModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("AssinaturaId")]
        [ForeignKey ("AssinaturaModel")]
        public int AssinaturaId { get; set; }

        [Column ("Descricao")]
        public string Descricao { get; set; }

        [Column ("Posicao")]
        public int PosicaoNaCaixaRemedio { get; set; }
    }
}
