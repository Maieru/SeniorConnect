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
            txtHora.Font = new Font("DS-Digital", 40, FontStyle.Regular);
            txtBatimentos.Font = new Font("DS-Digital", 30, FontStyle.Regular);

            AlteraBotao();
            do
            {
                string json = CriaJson(GerenciaDados());
                txtVizualisaJson.Text = json;

                GerenciaAlertas();

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

        public void GerenciaAlertas()
        {
            txtHora.Text = DateTime.Now.ToString("HH:mm");
            txtBatimentos.Text = dados.BatimentoCardiaco.ToString();

            if (ccbQueda.Checked)
            {
                pbQueda.Visible = true;
            }
            else
                pbQueda.Visible = false;

            if (ccbEmergencia.Checked)
            {
                pbSosEnable.Visible = true;
            }
            else
                pbSosEnable.Visible = false;
        }

        public int GeraBatimentos()
        {
            Random random= new Random();
            if (ccbDescanco.Checked)
            {
                return random.Next(40, 70);
            }

            if(ccbExercicio.Checked)
            {
                return random.Next(100, 130);
            }

            return random.Next(70, 90);
        }


        public string CriaJson(StatusPulseiraTO dados)
        {
            return JsonConvert.SerializeObject(dados, Formatting.Indented);
        }

        private void txtHora_TextChanged(object sender, EventArgs e)
        {

        }

        private void ccbQueda_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}