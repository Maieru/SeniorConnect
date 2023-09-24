using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class MedicamentoModel
    {
        [Key]
        public int Id { get; set; }
        
        public int AssinaturaId { get; set; }
        
        public string Descricao { get; set; }
        
        public int PosicaoNaCaixaRemedio { get; set; }
    }
}
