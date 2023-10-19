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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaixaRemedio));
            this.cContainerRemedio1 = new Simulador_Caixa_de_Remedios.CContainerRemedio();
            this.cContainerRemedio2 = new Simulador_Caixa_de_Remedios.CContainerRemedio();
            this.cContainerRemedio3 = new Simulador_Caixa_de_Remedios.CContainerRemedio();
            this.cContainerRemedio4 = new Simulador_Caixa_de_Remedios.CContainerRemedio();
            this.cContainerRemedio5 = new Simulador_Caixa_de_Remedios.CContainerRemedio();
            this.cContainerRemedio6 = new Simulador_Caixa_de_Remedios.CContainerRemedio();
            this.cContainerRemedio7 = new Simulador_Caixa_de_Remedios.CContainerRemedio();
            this.lb_horaAtual = new System.Windows.Forms.Label();
            this.timer_Relogio = new System.Windows.Forms.Timer(this.components);
            this.pb_relogio = new System.Windows.Forms.PictureBox();
            this.timer_ContagemRegressiva = new System.Windows.Forms.Timer(this.components);
            this.lb_Temporizador = new System.Windows.Forms.Label();
            this.rtxt_DeviceKey = new System.Windows.Forms.RichTextBox();
            this.timer_Agendamento = new System.Windows.Forms.Timer(this.components);
            this.rtxt_StatusAbertura = new System.Windows.Forms.RichTextBox();
            this.gp_DadosEnviados = new System.Windows.Forms.GroupBox();
            this.lb_StatusAbertura = new System.Windows.Forms.Label();
            this.rtxt_DeviceId = new System.Windows.Forms.RichTextBox();
            this.lb_DeviceKey = new System.Windows.Forms.Label();
            this.lb_DeviceId = new System.Windows.Forms.Label();
            this.timer_EnviaDados = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_relogio)).BeginInit();
            this.gp_DadosEnviados.SuspendLayout();
            this.SuspendLayout();
            // 
            // cContainerRemedio1
            // 
            this.cContainerRemedio1.Aberto = false;
            this.cContainerRemedio1.LEDAceso = false;
            this.cContainerRemedio1.Location = new System.Drawing.Point(49, 134);
            this.cContainerRemedio1.Name = "cContainerRemedio1";
            this.cContainerRemedio1.Size = new System.Drawing.Size(76, 150);
            this.cContainerRemedio1.TabIndex = 0;
            // 
            // cContainerRemedio2
            // 
            this.cContainerRemedio2.Aberto = false;
            this.cContainerRemedio2.LEDAceso = false;
            this.cContainerRemedio2.Location = new System.Drawing.Point(125, 134);
            this.cContainerRemedio2.Name = "cContainerRemedio2";
            this.cContainerRemedio2.Size = new System.Drawing.Size(76, 150);
            this.cContainerRemedio2.TabIndex = 1;
            // 
            // cContainerRemedio3
            // 
            this.cContainerRemedio3.Aberto = false;
            this.cContainerRemedio3.LEDAceso = false;
            this.cContainerRemedio3.Location = new System.Drawing.Point(201, 134);
            this.cContainerRemedio3.Name = "cContainerRemedio3";
            this.cContainerRemedio3.Size = new System.Drawing.Size(76, 150);
            this.cContainerRemedio3.TabIndex = 2;
            // 
            // cContainerRemedio4
            // 
            this.cContainerRemedio4.Aberto = false;
            this.cContainerRemedio4.LEDAceso = false;
            this.cContainerRemedio4.Location = new System.Drawing.Point(277, 134);
            this.cContainerRemedio4.Name = "cContainerRemedio4";
            this.cContainerRemedio4.Size = new System.Drawing.Size(76, 150);
            this.cContainerRemedio4.TabIndex = 3;
            // 
            // cContainerRemedio5
            // 
            this.cContainerRemedio5.Aberto = false;
            this.cContainerRemedio5.LEDAceso = false;
            this.cContainerRemedio5.Location = new System.Drawing.Point(353, 134);
            this.cContainerRemedio5.Name = "cContainerRemedio5";
            this.cContainerRemedio5.Size = new System.Drawing.Size(76, 150);
            this.cContainerRemedio5.TabIndex = 4;
            // 
            // cContainerRemedio6
            // 
            this.cContainerRemedio6.Aberto = false;
            this.cContainerRemedio6.LEDAceso = false;
            this.cContainerRemedio6.Location = new System.Drawing.Point(429, 134);
            this.cContainerRemedio6.Name = "cContainerRemedio6";
            this.cContainerRemedio6.Size = new System.Drawing.Size(76, 150);
            this.cContainerRemedio6.TabIndex = 5;
            // 
            // cContainerRemedio7
            // 
            this.cContainerRemedio7.Aberto = false;
            this.cContainerRemedio7.LEDAceso = false;
            this.cContainerRemedio7.Location = new System.Drawing.Point(505, 134);
            this.cContainerRemedio7.Name = "cContainerRemedio7";
            this.cContainerRemedio7.Size = new System.Drawing.Size(76, 150);
            this.cContainerRemedio7.TabIndex = 6;
            // 
            // lb_horaAtual
            // 
            this.lb_horaAtual.AutoSize = true;
            this.lb_horaAtual.BackColor = System.Drawing.SystemColors.GrayText;
            this.lb_horaAtual.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lb_horaAtual.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lb_horaAtual.Location = new System.Drawing.Point(708, 19);
            this.lb_horaAtual.Name = "lb_horaAtual";
            this.lb_horaAtual.Size = new System.Drawing.Size(0, 15);
            this.lb_horaAtual.TabIndex = 8;
            // 
            // timer_Relogio
            // 
            this.timer_Relogio.Interval = 10000;
            // 
            // pb_relogio
            // 
            this.pb_relogio.Image = global::Simulador_Caixa_de_Remedios.Properties.Resources.relogio;
            this.pb_relogio.Location = new System.Drawing.Point(680, -2);
            this.pb_relogio.Name = "pb_relogio";
            this.pb_relogio.Size = new System.Drawing.Size(100, 50);
            this.pb_relogio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_relogio.TabIndex = 7;
            this.pb_relogio.TabStop = false;
            // 
            // timer_ContagemRegressiva
            // 
            this.timer_ContagemRegressiva.Interval = 1000;
            // 
            // lb_Temporizador
            // 
            this.lb_Temporizador.AutoSize = true;
            this.lb_Temporizador.BackColor = System.Drawing.Color.Transparent;
            this.lb_Temporizador.Font = new System.Drawing.Font("Yu Gothic UI", 25.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_Temporizador.ForeColor = System.Drawing.Color.Black;
            this.lb_Temporizador.Location = new System.Drawing.Point(231, 52);
            this.lb_Temporizador.Name = "lb_Temporizador";
            this.lb_Temporizador.Size = new System.Drawing.Size(58, 46);
            this.lb_Temporizador.TabIndex = 9;
            this.lb_Temporizador.Text = "59";
            // 
            // rtxt_DeviceKey
            // 
            this.rtxt_DeviceKey.BackColor = System.Drawing.Color.MistyRose;
            this.rtxt_DeviceKey.ForeColor = System.Drawing.Color.Black;
            this.rtxt_DeviceKey.Location = new System.Drawing.Point(6, 96);
            this.rtxt_DeviceKey.Name = "rtxt_DeviceKey";
            this.rtxt_DeviceKey.Size = new System.Drawing.Size(173, 41);
            this.rtxt_DeviceKey.TabIndex = 11;
            this.rtxt_DeviceKey.Text = "";
            // 
            // timer_Agendamento
            // 
            this.timer_Agendamento.Interval = 1000;
            // 
            // rtxt_StatusAbertura
            // 
            this.rtxt_StatusAbertura.BackColor = System.Drawing.Color.MistyRose;
            this.rtxt_StatusAbertura.ForeColor = System.Drawing.Color.Black;
            this.rtxt_StatusAbertura.Location = new System.Drawing.Point(6, 174);
            this.rtxt_StatusAbertura.Name = "rtxt_StatusAbertura";
            this.rtxt_StatusAbertura.Size = new System.Drawing.Size(173, 56);
            this.rtxt_StatusAbertura.TabIndex = 12;
            this.rtxt_StatusAbertura.Text = "";
            // 
            // gp_DadosEnviados
            // 
            this.gp_DadosEnviados.BackColor = System.Drawing.Color.Khaki;
            this.gp_DadosEnviados.Controls.Add(this.lb_StatusAbertura);
            this.gp_DadosEnviados.Controls.Add(this.rtxt_DeviceId);
            this.gp_DadosEnviados.Controls.Add(this.lb_DeviceKey);
            this.gp_DadosEnviados.Controls.Add(this.lb_DeviceId);
            this.gp_DadosEnviados.Controls.Add(this.rtxt_DeviceKey);
            this.gp_DadosEnviados.Controls.Add(this.rtxt_StatusAbertura);
            this.gp_DadosEnviados.Location = new System.Drawing.Point(627, 72);
            this.gp_DadosEnviados.Name = "gp_DadosEnviados";
            this.gp_DadosEnviados.Size = new System.Drawing.Size(200, 248);
            this.gp_DadosEnviados.TabIndex = 13;
            this.gp_DadosEnviados.TabStop = false;
            this.gp_DadosEnviados.Text = "Dados Enviados";
            // 
            // lb_StatusAbertura
            // 
            this.lb_StatusAbertura.AutoSize = true;
            this.lb_StatusAbertura.Location = new System.Drawing.Point(6, 156);
            this.lb_StatusAbertura.Name = "lb_StatusAbertura";
            this.lb_StatusAbertura.Size = new System.Drawing.Size(91, 15);
            this.lb_StatusAbertura.TabIndex = 17;
            this.lb_StatusAbertura.Text = "Status Abertura:";
            // 
            // rtxt_DeviceId
            // 
            this.rtxt_DeviceId.BackColor = System.Drawing.Color.MistyRose;
            this.rtxt_DeviceId.ForeColor = System.Drawing.Color.Black;
            this.rtxt_DeviceId.Location = new System.Drawing.Point(6, 37);
            this.rtxt_DeviceId.Name = "rtxt_DeviceId";
            this.rtxt_DeviceId.Size = new System.Drawing.Size(67, 28);
            this.rtxt_DeviceId.TabIndex = 16;
            this.rtxt_DeviceId.Text = "";
            // 
            // lb_DeviceKey
            // 
            this.lb_DeviceKey.AutoSize = true;
            this.lb_DeviceKey.Location = new System.Drawing.Point(6, 78);
            this.lb_DeviceKey.Name = "lb_DeviceKey";
            this.lb_DeviceKey.Size = new System.Drawing.Size(67, 15);
            this.lb_DeviceKey.TabIndex = 15;
            this.lb_DeviceKey.Text = "Device Key:";
            // 
            // lb_DeviceId
            // 
            this.lb_DeviceId.AutoSize = true;
            this.lb_DeviceId.Location = new System.Drawing.Point(6, 19);
            this.lb_DeviceId.Name = "lb_DeviceId";
            this.lb_DeviceId.Size = new System.Drawing.Size(58, 15);
            this.lb_DeviceId.TabIndex = 14;
            this.lb_DeviceId.Text = "Device Id:";
            // 
            // timer_EnviaDados
            // 
            this.timer_EnviaDados.Interval = 1000;
            this.timer_EnviaDados.Tick += new System.EventHandler(this.timer_EnviaDados_Tick);
            // 
            // CaixaRemedio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Simulador_Caixa_de_Remedios.Properties.Resources.background_color_forms1;
            this.ClientSize = new System.Drawing.Size(869, 362);
            this.Controls.Add(this.gp_DadosEnviados);
            this.Controls.Add(this.lb_Temporizador);
            this.Controls.Add(this.lb_horaAtual);
            this.Controls.Add(this.cContainerRemedio7);
            this.Controls.Add(this.cContainerRemedio6);
            this.Controls.Add(this.cContainerRemedio5);
            this.Controls.Add(this.cContainerRemedio4);
            this.Controls.Add(this.cContainerRemedio3);
            this.Controls.Add(this.cContainerRemedio2);
            this.Controls.Add(this.cContainerRemedio1);
            this.Controls.Add(this.pb_relogio);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CaixaRemedio";
            this.Text = "Simulador Caixa de Remédio";
            ((System.ComponentModel.ISupportInitialize)(this.pb_relogio)).EndInit();
            this.gp_DadosEnviados.ResumeLayout(false);
            this.gp_DadosEnviados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private RichTextBox rtxt_StatusAbertura;
        private GroupBox gp_DadosEnviados;
        private RichTextBox rtxt_DeviceId;
        private Label lb_DeviceKey;
        private Label lb_DeviceId;
        private Label lb_StatusAbertura;
        private System.Windows.Forms.Timer timer_EnviaDados;
    }
}