using Negocio.TOs.IotMessage;

namespace Negocio.Model.IotMessage
{
    public class StatusCaixaRemedioModel : IotMessageModel
    {
        public List<bool> ContainerAbertos { get; set; }

        public StatusCaixaRemedioModel() { }

        public StatusCaixaRemedioModel(StatusCaixaRemedioTO to) : base(to)
        {
            ContainerAbertos = to.ContainerAbertos;
        }
    }
}
