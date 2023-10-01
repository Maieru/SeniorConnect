using System.ComponentModel.DataAnnotations;

namespace Negocio.TOs.IotMessage
{
    public class StatusCaixaRemedioTO : IotMessageTO
    {
        [Required(ErrorMessage = "É necessário preencher o campo de container abertos")]
        public List<bool> ContainerAbertos { get; set; }
    }
}
