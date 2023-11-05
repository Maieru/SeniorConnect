using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.TOs
{
    public class ApiResponseTO<T>
    {
        public bool Sucesso { get; set; }
        public string? Mensagem { get; set; }
        public T Dados { get; set; }

        public ApiResponseTO() { }

        public ApiResponseTO(bool sucesso, string? mensagem, T dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public static ApiResponseTO<T> CreateSucesso(T dados) => new ApiResponseTO<T>(true, null, dados);
        public static ApiResponseTO<T> CreateFalha(string mensagem) => new ApiResponseTO<T>(false, mensagem, default);
    }
}
