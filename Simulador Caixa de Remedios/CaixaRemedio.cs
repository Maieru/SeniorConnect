using Negocio.Helpers;
using Negocio.TOs;
using Negocio.TOs.IotMessage;
using Newtonsoft.Json;
using System.Text;

namespace Simulador_Caixa_de_Remedios
{
    public partial class CaixaRemedio : Form
    {
        #region Fields
        private int segundosRestantes;
        private EnviarCaixaRemedioTO DadosRecebidos { get; set; }
        private TimeOnly HoraAtual { get; set; }
        private TimeOnly HoraEnviaDados { get; set; }
        #endregion

        public CaixaRemedio()
        {
            InitializeComponent();

            #region Temporizador
            lb_Temporizador.Visible = false;
            lb_Temporizador.Text = "00:00:" + segundosRestantes.ToString("D2"); //dois dígitos
            segundosRestantes = 59;
            #endregion

            #region Relógio 
            HoraAtual = TimeOnly.FromDateTime(DateTime.Now);
            timer_Relogio.Tick += timer_Relogio_Tick;
            timer_Relogio.Start();
            #endregion

            FazSolicitacaoHttp();
        }

        /// <summary>
        /// este método captura os dados do gateway, recebidos pela pulseira
        /// </summary>
        private void FazSolicitacaoHttp()
        {
            // Precisa ser feito ANTES de executar o método GetWebsiteUrl()
            UrlHelper.SetAmbiente("Local");

            // Opções de ambiente: 
            // Production
            // Development
            // Local

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(UrlHelper.GetIoTGatewayUrl());
                var request = new HttpRequestMessage(HttpMethod.Get, $"/IotMessage/v1/GetDadosCaixaRemedio");

                var objetoASerEnviado = new IotMessageTO(1, Guid.NewGuid().ToString()); //parametro da requisicao
                var conteudoRequisicao = new StringContent(JsonConvert.SerializeObject(objetoASerEnviado), Encoding.UTF8, "application/json");
                request.Content = conteudoRequisicao;

                var resposta = httpClient.Send(request);
                var respostaString = resposta.Content.ReadAsStringAsync().Result;

                var objetoAgendamentos = JsonConvert.DeserializeObject<ApiResponseTO<EnviarCaixaRemedioTO>>(respostaString);
            }
        }

        /// <summary>
        /// Envia os dados da caixa de remédios para o gateway
        /// </summary>
        private void EnviaDadosHttp()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(UrlHelper.GetIoTGatewayUrl());
                var request = new HttpRequestMessage(HttpMethod.Post, $"/IoTMessage/v1/AtualizaDadosCaixaRemedio");

                StatusCaixaRemedioTO objetoASerEnviado = new StatusCaixaRemedioTO();
                objetoASerEnviado.DeviceId = Convert.ToInt32(rtxt_DeviceKey.Text);
                objetoASerEnviado.DeviceKey = rtxt_DeviceKey.Text;
                objetoASerEnviado.ContainerAbertos = verificaStatusContainer();

                var conteudoRequisicao = new StringContent(JsonConvert.SerializeObject(objetoASerEnviado), Encoding.UTF8, "application/json");
                request.Content = conteudoRequisicao;

                var resposta = httpClient.Send(request);
                var respostaString = resposta.Content.ReadAsStringAsync().Result;

                var objetoAgendamentos = JsonConvert.DeserializeObject<ApiResponseTO<EnviarCaixaRemedioTO>>(respostaString);

            }
        }

        /// <summary>
        /// Simula um relógio próprio para o sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Relogio_Tick(object sender, EventArgs e)
        {
            HoraAtual = HoraAtual.AddHours(0.5); //Incrementa 1h
            lb_horaAtual.Text = HoraAtual.ToString();
        }

        /// <summary>
        /// Temporizador para indicar tempo restante para ingestão do medicamento antes
        /// do envio do alerta ao responsável
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_ContagemRegressiva_Tick(object sender, EventArgs e)
        {

            segundosRestantes--;

            if (segundosRestantes >= 0)
            {
                lb_Temporizador.Text = "00:00:" + segundosRestantes.ToString("D2");
            }
            else
            {
                timer_ContagemRegressiva.Stop();
                lb_Temporizador.Visible = false;
            }
        }

        /// <summary>
        /// Valida se o horário atual condiz com o agendamento cadastrado para indicar
        /// se a medicação precisa ser ingerida (LED aceso)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Agendamento_Tick(object sender, EventArgs e)
        {
            if (DadosRecebidos.Agendamentos.Any(a => a.GetValueOrDefault().CompareTo(DateTime.Now) > 1 && a.GetValueOrDefault().CompareTo(DateTime.Now.AddMinutes(1)) < 1))
            {
                cContainerRemedio1.LEDAceso = true;
                lb_Temporizador.Visible = true;
                timer_ContagemRegressiva.Start();
            }
        }

        /// <summary>
        /// Verifica se o container foi aberto
        /// </summary>
        /// <returns></returns>
        public List<bool> verificaStatusContainer()
        {
            List<bool> listaStatus = new List<bool>();

            foreach (var item in Controls)
            {
                if (item is CContainerRemedio)
                    listaStatus.Add((item as CContainerRemedio).Aberto);
            }
            return listaStatus;
        }

        /// <summary>
        /// Temporizador para controlar a rotina de envios dos dados para o gateway
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_EnviaDados_Tick(object sender, EventArgs e)
        {
            HoraEnviaDados = HoraEnviaDados.AddHours(5);
            EnviaDadosHttp();

        }
    }
}
