using Negocio.Helpers;
using Negocio.TOs.IotMessage;
using Newtonsoft.Json;
using System.Text;
using System.Windows.Forms;

namespace Simulador_Caixa_de_Remedios
{
    public partial class CaixaRemedio : Form
    {
        public CaixaRemedio()
        {
            InitializeComponent();
            lb_2.Text = "";
            timerRelogio.Enabled = true;
        }

        #region Abre Compartimento
        private void bt_Abrir1_Click(object sender, EventArgs e)
        {
            pb_caixaRemedios.Image = Image.FromFile("img\\abertos\\1_aberto.jpg");
        }

        private void bt_Abrir2_Click(object sender, EventArgs e)
        {
            pb_caixaRemedios.Image = Image.FromFile("img\\abertos\\2_aberto.jpg");
        }

        private void bt_Abrir3_Click(object sender, EventArgs e)
        {
            pb_caixaRemedios.Image = Image.FromFile("img\\abertos\\3_aberto.jpg");
        }

        private void bt_Abrir4_Click(object sender, EventArgs e)
        {
            pb_caixaRemedios.Image = Image.FromFile("img\\abertos\\4_aberto.jpg");
        }

        private void bt_Abrir5_Click(object sender, EventArgs e)
        {
            pb_caixaRemedios.Image = Image.FromFile("img\\abertos\\5_aberto.jpg");
        }

        private void bt_Abrir6_Click(object sender, EventArgs e)
        {
            pb_caixaRemedios.Image = Image.FromFile("img\\abertos\\6_aberto.jpg");
        }

        private void bt_Abrir7_Click(object sender, EventArgs e)
        {
            pb_caixaRemedios.Image = Image.FromFile("img\\abertos\\7_aberto.jpg");
        }
        #endregion Abre Compartimento

        /// <summary>
        /// este método é responsável por comparar a hora atual com a hora cadastrada da medicação.
        /// Se os horários forem equivalentes, o respectivo led irá iluminar
        /// para indicar que a medicação precisa ser consumida.
        /// </summary>
        private void hora_Remedio(object sender, EventArgs e)
        {
            int horarioAtual = DateTime.Now.Hour;
            HorarioMedicacao horarioMedicacao = new HorarioMedicacao();

            //faz o mapeamento dos compartimentos para as imagen
            Dictionary<int, string> caminhosDeImagemPorCompartimento = new Dictionary<int, string>
                 {
                      { 1, "img\\acesos\\1_aceso.jpg" },
                      { 2, "img\\acesos\\2_aceso.jpg" },
                      { 3, "img\\acesos\\3_aceso.jpg" },
                      { 4, "img\\acesos\\4_aceso.jpg" },
                      { 5, "img\\acesos\\5_aceso.jpg" },
                      { 6, "img\\acesos\\6_aceso.jpg" },
                      { 7, "img\\acesos\\7_aceso.jpg" }
            };

            //verifica se o compartimento atual existe no dicionário.
            if (caminhosDeImagemPorCompartimento.ContainsKey(horarioAtual))
            {
                //define a imagem com base no caminho do dicionário.
                pb_caixaRemedios.Image = Image.FromFile(caminhosDeImagemPorCompartimento[horarioAtual]);
            }
            else
            {
                //caso o compartimento não exista, os leds se mantém todos apagados
                pb_caixaRemedios.Image = Image.FromFile("img\\caixinha fechada tudo apagado.jpg");
            }


            //if ()
            //{
            //    string mensagem = "Atenção! A medicação não foi tomada no horário correto.";
            //    MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

        }

        private void timerRelogio_Tick(object sender, EventArgs e)
        {
            lb_2.Text = DateTime.Now.ToString("HH:mm:ss");
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
                var request = new HttpRequestMessage(HttpMethod.Get, $"/IotMessage/v1/GetDadosCaixaRemedio");

                var objetoASerEnviado = new IotMessageTO(1, Guid.NewGuid().ToString()); //parametro da requisicao
                var conteudoRequisicao = new StringContent(JsonConvert.SerializeObject(objetoASerEnviado), Encoding.UTF8, "application/json");
                request.Content = conteudoRequisicao;

                var resposta = httpClient.Send(request);
                var respostaString = resposta.Content.ReadAsStringAsync().Result;
            }
        }

    }
}

