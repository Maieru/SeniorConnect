using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.TOs
{
    public class UsuarioTO
    {
        [Required(ErrorMessage = "O usuário é obrigatório")]
        [MaxLength(200, ErrorMessage = "O usuário não pode ultrapassar 200 caracteres")]
        public string Usuario { get; set; }

        [Column("Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}
