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
        [Required(ErrorMessage = "O usuário é obrigatório")]
        public string Usuario { get; set; }

        [Column("Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }

        [Column ("AssinaturaId")]
        [ForeignKey ("AssinaturaModel")]
        public int AssinaturaId { get; set; }

        [NotMapped]
        public string SenhaPlain { get; set; }
    }
}
