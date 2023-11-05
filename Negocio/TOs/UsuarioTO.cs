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

        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength(500, ErrorMessage = "O usuário não pode ultrapassar 500 caracteres")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "O email não está em um formato correto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [Compare("ConfirmacaoSenha", ErrorMessage = "A senha e a confirmação de senha não são iguais")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "É necessário preencher a confirmação de senha")]       
        public string ConfirmacaoSenha { get; set; }
    }
}
