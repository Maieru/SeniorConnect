using Microsoft.EntityFrameworkCore;
using Negocio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    [Table("tbAlerta")]
    public class AlertaModel
    {
        [Column]
        public int Id { get; set; }

        [Column]
        public EnumTipoAlerta TipoAlerta { get; set; }

        [Column]
        public int IdUsuario { get; set; }

        [Column]
        public DateTime Data { get; set; }
    }
}
