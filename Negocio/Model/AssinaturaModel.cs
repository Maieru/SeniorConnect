using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    [Table("tbAssinatura")]
    public class AssinaturaModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        [Column("PlanoId")]
        public int PlanoId { get; set; }
    }
}
