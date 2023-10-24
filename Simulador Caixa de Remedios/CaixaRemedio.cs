using Microsoft.IdentityModel.Tokens;
using Negocio.Helpers;
using Negocio.TOs;
using Negocio.TOs.IotMessage;
using Newtonsoft.Json;
using System.Text;
using System.Linq;

namespace Simulador_Caixa_de_Remedios
{
    public partial class CaixaRemedio : Form
    {
        #region Fields
        private int segundosRestantes;
        private EnviarCaixaRemedioTO DadosRecebidos { get; set; }
        private TimeOnly HoraAtual { get; set; }
        private List<int> ContainersPendentes { get; set; } = new List<int>();
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
            UrlHelper.SetAmbiente("Development");

            // Opções de ambiente: 
            // Production
            // Development
            // Local

            if (rtxt_DeviceId.Text.IsNullOrEmpty() || rtxt_DeviceKey.Text.IsNullOrEmpty())
                return;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(UrlHelper.GetIoTGatewayUrl());
                var request = new HttpRequestMessage(HttpMethod.Get, $"/IotMessage/v1/GetDadosCaixaRemedio");

                var objetoASerEnviado = new IotMessageTO(Convert.ToInt32(rtxt_DeviceId.Text), rtxt_DeviceKey.Text); //parametro da requisicao
                var conteudoRequisicao = new StringContent(JsonConvert.SerializeObject(objetoASerEnviado), Encoding.UTF8, "application/json");
                request.Content = conteudoRequisicao;

                var resposta = httpClient.Send(request);
                var respostaString = resposta.Content.ReadAsStringAsync().Result;

                var objetoAgendamentos = JsonConvert.DeserializeObject<ApiResponseTO<EnviarCaixaRemedioTO>>(respostaString);

                if (objetoAgendamentos.Sucesso)
                {
                    DadosRecebidos = objetoAgendamentos.Dados;
                }
            }
        }

        /// <summary>
        /// Envia os dados da caixa de remédios para o gateway
        /// </summary>
        private void EnviaDadosHttp()
        {

            if (rtxt_DeviceId.Text.IsNullOrEmpty() || rtxt_DeviceKey.Text.IsNullOrEmpty())
                return;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(UrlHelper.GetIoTGatewayUrl());
                var request = new HttpRequestMessage(HttpMethod.Post, $"/IoTMessage/v1/AtualizaDadosCaixaRemedio");

                StatusCaixaRemedioTO objetoASerEnviado = new StatusCaixaRemedioTO();
                objetoASerEnviado.DeviceId = Convert.ToInt32(rtxt_DeviceId.Text);
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
            HoraAtual = HoraAtual.AddMinutes(1); //Incrementa 1 min 
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

                if (ContainersPendentes.Any())
                {
                    MessageBox.Show("Medicação não consumida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ContainersPendentes.Clear();
                }
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
            if (DadosRecebidos == null || DadosRecebidos.Agendamentos == null)
                return;

            for (int i = 0; i < DadosRecebidos.Agendamentos.Count; i++)
            {
                var item = DadosRecebidos.Agendamentos[i];

                if (item == null)
                    continue;

                if (item.Any(a => HoraAtual.CompareTo(TimeOnly.FromDateTime(a.AddMinutes(-1))) >= 1 &&
                                  HoraAtual.CompareTo(TimeOnly.FromDateTime(a.AddMinutes(1))) <= 1))
                {
                    foreach (var controle in Controls)
                    {
                        if (controle is CContainerRemedio containerRemedio && (containerRemedio).NumeroContainer == i)
                        {
                            containerRemedio.LEDAceso = true;
                            lb_Temporizador.Visible = true;
                            timer_ContagemRegressiva.Start();
                            ContainersPendentes.Add(containerRemedio.NumeroContainer);
                        }
                    }
                }
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

        private void cContainerRemedio1_OnEstadoAlterado(object sender, EventArgs e)
        {
            EnviaDadosHttp();

            if (sender is CContainerRemedio container && container.Aberto && ContainersPendentes.Contains(container.NumeroContainer))
                ContainersPendentes.Remove(container.NumeroContainer);
        }

        private void timer_FazSolicitacaoHttp_Tick(object sender, EventArgs e)
        {
            FazSolicitacaoHttp();
        }
    }
}
