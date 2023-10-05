using Negocio.TOs.IotMessage;
using Newtonsoft.Json;
using Timer = System.Windows.Forms.Timer;

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

        private async void btnStatus_Click(object sender, EventArgs e)
        {
            AlteraBotao();
            do
            {
                string json = CriaJson(GerenciaDados());
                txtVizualisaJson.Text = json;

                await Task.Delay(5000);
            } while (statusSimulacao);
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
            dados.BatimentoCardiaco = GeraBatimentos();

            dados.BotaoEmergenciaPressionada = ccbEmergencia.Checked;
            dados.QuedaDetectada = ccbQueda.Checked;

            return dados;
        }

        public int GeraBatimentos()
        {
            Random random= new Random();
            if (ccbDescanco.Checked)
            {
                return random.Next(30, 50);
            }

            if(ccbExercicio.Checked)
            {
                return random.Next(80, 120);
            }

            return random.Next(50, 80);
        }


        public string CriaJson(StatusPulseiraTO dados)
        {
            return JsonConvert.SerializeObject(dados, Formatting.Indented);
        }
    }
}