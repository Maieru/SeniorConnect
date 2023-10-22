namespace Simulador_Caixa_de_Remedios
{
    partial class CaixaRemedio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaixaRemedio));
            cContainerRemedio1 = new CContainerRemedio();
            cContainerRemedio2 = new CContainerRemedio();
            cContainerRemedio3 = new CContainerRemedio();
            cContainerRemedio4 = new CContainerRemedio();
            cContainerRemedio5 = new CContainerRemedio();
            cContainerRemedio6 = new CContainerRemedio();
            cContainerRemedio7 = new CContainerRemedio();
            lb_horaAtual = new Label();
            timer_Relogio = new System.Windows.Forms.Timer(components);
            pb_relogio = new PictureBox();
            timer_ContagemRegressiva = new System.Windows.Forms.Timer(components);
            lb_Temporizador = new Label();
            rtxt_DeviceKey = new RichTextBox();
            timer_Agendamento = new System.Windows.Forms.Timer(components);
            gp_DadosEnviados = new GroupBox();
            rtxt_DeviceId = new RichTextBox();
            lb_DeviceKey = new Label();
            lb_DeviceId = new Label();
            timer_FazSolicitacaoHttp = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pb_relogio).BeginInit();
            gp_DadosEnviados.SuspendLayout();
            SuspendLayout();
            // 
            // cContainerRemedio1
            // 
            cContainerRemedio1.Aberto = false;
            cContainerRemedio1.LEDAceso = false;
            cContainerRemedio1.Location = new Point(49, 134);
            cContainerRemedio1.Name = "cContainerRemedio1";
            cContainerRemedio1.NumeroContainer = 0;
            cContainerRemedio1.Size = new Size(76, 150);
            cContainerRemedio1.TabIndex = 0;
            cContainerRemedio1.OnEstadoAlterado += cContainerRemedio1_OnEstadoAlterado;
            // 
            // cContainerRemedio2
            // 
            cContainerRemedio2.Aberto = false;
            cContainerRemedio2.LEDAceso = false;
            cContainerRemedio2.Location = new Point(125, 134);
            cContainerRemedio2.Name = "cContainerRemedio2";
            cContainerRemedio2.NumeroContainer = 1;
            cContainerRemedio2.Size = new Size(76, 150);
            cContainerRemedio2.TabIndex = 1;
            cContainerRemedio2.OnEstadoAlterado += cContainerRemedio1_OnEstadoAlterado;
            // 
            // cContainerRemedio3
            // 
            cContainerRemedio3.Aberto = false;
            cContainerRemedio3.LEDAceso = false;
            cContainerRemedio3.Location = new Point(201, 134);
            cContainerRemedio3.Name = "cContainerRemedio3";
            cContainerRemedio3.NumeroContainer = 2;
            cContainerRemedio3.Size = new Size(76, 150);
            cContainerRemedio3.TabIndex = 2;
            cContainerRemedio3.OnEstadoAlterado += cContainerRemedio1_OnEstadoAlterado;
            // 
            // cContainerRemedio4
            // 
            cContainerRemedio4.Aberto = false;
            cContainerRemedio4.LEDAceso = false;
            cContainerRemedio4.Location = new Point(277, 134);
            cContainerRemedio4.Name = "cContainerRemedio4";
            cContainerRemedio4.NumeroContainer = 3;
            cContainerRemedio4.Size = new Size(76, 150);
            cContainerRemedio4.TabIndex = 3;
            cContainerRemedio4.OnEstadoAlterado += cContainerRemedio1_OnEstadoAlterado;
            // 
            // cContainerRemedio5
            // 
            cContainerRemedio5.Aberto = false;
            cContainerRemedio5.LEDAceso = false;
            cContainerRemedio5.Location = new Point(353, 134);
            cContainerRemedio5.Name = "cContainerRemedio5";
            cContainerRemedio5.NumeroContainer = 4;
            cContainerRemedio5.Size = new Size(76, 150);
            cContainerRemedio5.TabIndex = 4;
            cContainerRemedio5.OnEstadoAlterado += cContainerRemedio1_OnEstadoAlterado;
            // 
            // cContainerRemedio6
            // 
            cContainerRemedio6.Aberto = false;
            cContainerRemedio6.LEDAceso = false;
            cContainerRemedio6.Location = new Point(429, 134);
            cContainerRemedio6.Name = "cContainerRemedio6";
            cContainerRemedio6.NumeroContainer = 5;
            cContainerRemedio6.Size = new Size(76, 150);
            cContainerRemedio6.TabIndex = 5;
            cContainerRemedio6.OnEstadoAlterado += cContainerRemedio1_OnEstadoAlterado;
            // 
            // cContainerRemedio7
            // 
            cContainerRemedio7.Aberto = false;
            cContainerRemedio7.LEDAceso = false;
            cContainerRemedio7.Location = new Point(505, 134);
            cContainerRemedio7.Name = "cContainerRemedio7";
            cContainerRemedio7.NumeroContainer = 6;
            cContainerRemedio7.Size = new Size(76, 150);
            cContainerRemedio7.TabIndex = 6;
            cContainerRemedio7.OnEstadoAlterado += cContainerRemedio1_OnEstadoAlterado;
            // 
            // lb_horaAtual
            // 
            lb_horaAtual.AutoSize = true;
            lb_horaAtual.BackColor = SystemColors.GrayText;
            lb_horaAtual.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lb_horaAtual.ForeColor = Color.LightSeaGreen;
            lb_horaAtual.Location = new Point(708, 19);
            lb_horaAtual.Name = "lb_horaAtual";
            lb_horaAtual.Size = new Size(0, 15);
            lb_horaAtual.TabIndex = 8;
            // 
            // timer_Relogio
            // 
            timer_Relogio.Enabled = true;
            timer_Relogio.Tick += timer_Relogio_Tick;
            // 
            // pb_relogio
            // 
            pb_relogio.Image = Properties.Resources.relogio;
            pb_relogio.Location = new Point(680, -2);
            pb_relogio.Name = "pb_relogio";
            pb_relogio.Size = new Size(100, 50);
            pb_relogio.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_relogio.TabIndex = 7;
            pb_relogio.TabStop = false;
            // 
            // timer_ContagemRegressiva
            // 
            timer_ContagemRegressiva.Enabled = true;
            timer_ContagemRegressiva.Interval = 1000;
            timer_ContagemRegressiva.Tick += timer_ContagemRegressiva_Tick;
            // 
            // lb_Temporizador
            // 
            lb_Temporizador.AutoSize = true;
            lb_Temporizador.BackColor = Color.Transparent;
            lb_Temporizador.Font = new Font("Yu Gothic UI", 25.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Temporizador.ForeColor = Color.Black;
            lb_Temporizador.Location = new Point(231, 52);
            lb_Temporizador.Name = "lb_Temporizador";
            lb_Temporizador.Size = new Size(58, 46);
            lb_Temporizador.TabIndex = 9;
            lb_Temporizador.Text = "59";
            // 
            // rtxt_DeviceKey
            // 
            rtxt_DeviceKey.BackColor = Color.MistyRose;
            rtxt_DeviceKey.ForeColor = Color.Black;
            rtxt_DeviceKey.Location = new Point(6, 96);
            rtxt_DeviceKey.Name = "rtxt_DeviceKey";
            rtxt_DeviceKey.Size = new Size(173, 41);
            rtxt_DeviceKey.TabIndex = 11;
            rtxt_DeviceKey.Text = "";
            // 
            // timer_Agendamento
            // 
            timer_Agendamento.Enabled = true;
            timer_Agendamento.Tick += timer_Agendamento_Tick;
            // 
            // gp_DadosEnviados
            // 
            gp_DadosEnviados.BackColor = Color.Khaki;
            gp_DadosEnviados.Controls.Add(rtxt_DeviceId);
            gp_DadosEnviados.Controls.Add(lb_DeviceKey);
            gp_DadosEnviados.Controls.Add(lb_DeviceId);
            gp_DadosEnviados.Controls.Add(rtxt_DeviceKey);
            gp_DadosEnviados.Location = new Point(627, 72);
            gp_DadosEnviados.Name = "gp_DadosEnviados";
            gp_DadosEnviados.Size = new Size(200, 152);
            gp_DadosEnviados.TabIndex = 13;
            gp_DadosEnviados.TabStop = false;
            gp_DadosEnviados.Text = "Dados Enviados";
            // 
            // rtxt_DeviceId
            // 
            rtxt_DeviceId.BackColor = Color.MistyRose;
            rtxt_DeviceId.ForeColor = Color.Black;
            rtxt_DeviceId.Location = new Point(6, 37);
            rtxt_DeviceId.Name = "rtxt_DeviceId";
            rtxt_DeviceId.Size = new Size(67, 28);
            rtxt_DeviceId.TabIndex = 16;
            rtxt_DeviceId.Text = "";
            // 
            // lb_DeviceKey
            // 
            lb_DeviceKey.AutoSize = true;
            lb_DeviceKey.Location = new Point(6, 78);
            lb_DeviceKey.Name = "lb_DeviceKey";
            lb_DeviceKey.Size = new Size(67, 15);
            lb_DeviceKey.TabIndex = 15;
            lb_DeviceKey.Text = "Device Key:";
            // 
            // lb_DeviceId
            // 
            lb_DeviceId.AutoSize = true;
            lb_DeviceId.Location = new Point(6, 19);
            lb_DeviceId.Name = "lb_DeviceId";
            lb_DeviceId.Size = new Size(58, 15);
            lb_DeviceId.TabIndex = 14;
            lb_DeviceId.Text = "Device Id:";
            // 
            // timer_FazSolicitacaoHttp
            // 
            timer_FazSolicitacaoHttp.Enabled = true;
            timer_FazSolicitacaoHttp.Interval = 10000;
            timer_FazSolicitacaoHttp.Tick += timer_FazSolicitacaoHttp_Tick;
            // 
            // CaixaRemedio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_color_forms1;
            ClientSize = new Size(869, 362);
            Controls.Add(gp_DadosEnviados);
            Controls.Add(lb_Temporizador);
            Controls.Add(lb_horaAtual);
            Controls.Add(cContainerRemedio7);
            Controls.Add(cContainerRemedio6);
            Controls.Add(cContainerRemedio5);
            Controls.Add(cContainerRemedio4);
            Controls.Add(cContainerRemedio3);
            Controls.Add(cContainerRemedio2);
            Controls.Add(cContainerRemedio1);
            Controls.Add(pb_relogio);
            Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CaixaRemedio";
            Text = "Simulador Caixa de Remédio";
            ((System.ComponentModel.ISupportInitialize)pb_relogio).EndInit();
            gp_DadosEnviados.ResumeLayout(false);
            gp_DadosEnviados.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CContainerRemedio cContainerRemedio1;
        private CContainerRemedio cContainerRemedio2;
        private CContainerRemedio cContainerRemedio3;
        private CContainerRemedio cContainerRemedio4;
        private CContainerRemedio cContainerRemedio5;
        private CContainerRemedio cContainerRemedio6;
        private CContainerRemedio cContainerRemedio7;
        private Label lb_horaAtual;
        private System.Windows.Forms.Timer timer_Relogio;
        private PictureBox pb_relogio;
        private System.Windows.Forms.Timer timer_ContagemRegressiva;
        private Label lb_Temporizador;
        private RichTextBox rtxt_DeviceKey;
        private System.Windows.Forms.Timer timer_Agendamento;
        private GroupBox gp_DadosEnviados;
        private RichTextBox rtxt_DeviceId;
        private Label lb_DeviceKey;
        private Label lb_DeviceId;
        private System.Windows.Forms.Timer timer_FazSolicitacaoHttp;
    }
}