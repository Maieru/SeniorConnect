using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model.IotMessage
{
    public class EnviarCaixaRemedioModel : IotMessageModel
    {
        public List<LembreteMedicamentoModel> Agendamentos { get; set; }
    }
}
