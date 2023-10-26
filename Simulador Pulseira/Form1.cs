using Negocio.Helpers;
using Negocio.TOs;
using Negocio.TOs.IotMessage;
using Newtonsoft.Json;
using System.Text;
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
                if (txtId.Text != null && txtKey != null)
                {
                    string json = CriaJson(GerenciaDados());
                    txtVizualisaJson.Text = json;
                }
                GerenciaAlertas();
                FazSolicitacaoHttp();

                if (txtId.Text != null && txtKey != null)
                    FazSolicitacaoHttp();

                await Task.Delay(30000);
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
            dados.DeviceId = Convert.ToInt32(txtId.Text);
            dados.DeviceKey = txtKey.Text;
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

        public void FazSolicitacaoHttp()
        {
            // Precisa ser feito ANTES de executar o método GetWebsiteUrl()
            UrlHelper.SetAmbiente("Development");

            // Opções de ambiente: 
            // Production
            // Development
            // Local

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(UrlHelper.GetIoTGatewayUrl());
                var request = new HttpRequestMessage(HttpMethod.Post, $"/IotMessage/v1/AtualizaDadosPulseira");

                var conteudoRequisicao = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");
                request.Content = conteudoRequisicao;

                var resposta = httpClient.Send(request);
                var respostaString = resposta.Content.ReadAsStringAsync().Result;
            }
        }

        public void RequsitaAlertasHttp()
        {
            // Precisa ser feito ANTES de executar o método GetWebsiteUrl()
            UrlHelper.SetAmbiente("Development");

            // Opções de ambiente: 
            // Production
            // Development
            // Local

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(UrlHelper.GetIoTGatewayUrl());
                var request = new HttpRequestMessage(HttpMethod.Get, $"/IotMessage/v1/GetDadosPulseira");

                var objetoASerEnviado = new StatusPulseiraTO(Convert.ToInt32(txtId.Text), txtKey.Text);
                var conteudoRequisicao = new StringContent(JsonConvert.SerializeObject(objetoASerEnviado), Encoding.UTF8, "application/json");
                request.Content = conteudoRequisicao;

                var resposta = httpClient.Send(request);
                var respostaString = resposta.Content.ReadAsStringAsync().Result;

                var respostaObjeto = JsonConvert.DeserializeObject<ApiResponseTO<EnviarPulseiraTO>>(respostaString);

                if (respostaObjeto != null && respostaObjeto.Sucesso)
                    txtAlertas.Text = JsonConvert.SerializeObject(respostaObjeto.Dados);
            }
        }

    }
}