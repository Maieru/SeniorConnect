using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.TOs
{
    public class AlertaTO
    {
        public DateTime Horario { get; set; }
        public string Mensagem { get; set; }

        public AlertaTO() { }
        public AlertaTO(DateTime horario, string mensagem)
        {
            Horario = horario;
            Mensagem = mensagem;
        }
    }
}
