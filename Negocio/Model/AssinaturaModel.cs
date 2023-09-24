using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class AssinaturaModel
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public int PlanoId { get; set; }
    }
}
