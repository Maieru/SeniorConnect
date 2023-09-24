using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class LembreteMedicamentoModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MedicamentoModel")]
        public int MedicamentoId { get; set; }

        public DateTime Horario { get; set; }
        public string Descricao { get; set; }
    }
}
