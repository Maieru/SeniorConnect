using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    [Table ("tbUsuario")]
    public class UsuarioModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Usuario")]
        public string Usuario { get; set; }

        [Column("Senha")]
        public string Senha { get; set; }

        [Column ("AssinaturaId")]
        [ForeignKey ("AssinaturaModel")]
        public int AssinaturaId { get; set; }
    }
}
