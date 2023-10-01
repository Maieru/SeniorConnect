using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.TOs
{
    public class ApiResponseTO
    {
        public bool Sucesso { get; set; }
        public string? Mensagem { get; set; }
        public object? Dados { get; set; }

        private ApiResponseTO (bool sucesso, string? mensagem, object? dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public static ApiResponseTO CreateSucesso(object dados) => new ApiResponseTO(true, null, dados);
        public static ApiResponseTO CreateFalha(string mensagem) => new ApiResponseTO(true, mensagem, null);
    }
}
