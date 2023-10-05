using Negocio.TOs.IotMessage;
using Newtonsoft.Json;

namespace Simulador_Pulseira
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        StatusPulseiraTO dados = new StatusPulseiraTO(1, Guid.NewGuid().ToString());

        public bool statusSimulacao = false;

        private void btnStatus_Click(object sender, EventArgs e)
        {
            AlteraBotao();

            string json = CriaJson(GerenciaDados());

            txtVizualisaJson.Text = json;
        }

        public void AlteraBotao()
        {
            if (statusSimulacao)
            {
                statusSimulacao= false;
                btnStatus.BackColor = Color.IndianRed; btnStatus.ForeColor = Color.White;
                btnStatus.Text = "Off";
            }
            else
            {
                statusSimulacao = true;
                btnStatus.BackColor = Color.Olive; btnStatus.ForeColor = Color.White;
                btnStatus.Text = "On";
            }
        }

        public StatusPulseiraTO GerenciaDados()
        {

            dados.DeviceId= 1;
            dados.BatimentoCardiaco = 10;
            dados.QuedaDetectada = false;
            dados.BotaoEmergenciaPressionada = false;

            return dados;
        }

        public string CriaJson(StatusPulseiraTO dados)
        {
            return JsonConvert.SerializeObject(dados, Formatting.Indented);
        }
    }
}