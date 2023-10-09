using Negocio.Helpers;
using Negocio.TOs.IotMessage;
using Negocio.TOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Simulador_Caixa_de_Remedios
{
    public partial class CaixaRemedio : Form
    {
        public CaixaRemedio()
        {
            InitializeComponent();
            lb_horaAtual.Text = " ";
            lb_Temporizador.Visible = false;
            timer_Relogio.Enabled = true;
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

                foreach (var horario in objetoAgendamentos.Dados.Agendamentos)
                {
                    if (horario == DateTime.Now)
                    {
                        cContainerRemedio1.LEDAceso = true;
                        lb_Temporizador.Visible = true;
                        timer_ContagemRegressiva.Start();
                    }

                }

            }
        }

        private void timer_Relogio_Tick(object sender, EventArgs e)
        {
            lb_horaAtual.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void timer_ContagemRegressiva_Tick(object sender, EventArgs e)
        {

            lb_Temporizador.Text = (Convert.ToInt32(lb_Temporizador.Text) - 1).ToString();
            if (lb_Temporizador.Text == "0")
            {
                timer_ContagemRegressiva.Stop();
                lb_Temporizador.Visible = false;
            }
        }
    }
}
