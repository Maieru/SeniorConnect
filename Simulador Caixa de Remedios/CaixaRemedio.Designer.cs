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
            ((System.ComponentModel.ISupportInitialize)pb_relogio).BeginInit();
            SuspendLayout();
            // 
            // cContainerRemedio1
            // 
            cContainerRemedio1.Location = new Point(49, 134);
            cContainerRemedio1.Name = "cContainerRemedio1";
            cContainerRemedio1.Size = new Size(76, 150);
            cContainerRemedio1.TabIndex = 0;
            // 
            // cContainerRemedio2
            // 
            cContainerRemedio2.Location = new Point(125, 134);
            cContainerRemedio2.Name = "cContainerRemedio2";
            cContainerRemedio2.Size = new Size(76, 150);
            cContainerRemedio2.TabIndex = 1;
            // 
            // cContainerRemedio3
            // 
            cContainerRemedio3.Location = new Point(201, 134);
            cContainerRemedio3.Name = "cContainerRemedio3";
            cContainerRemedio3.Size = new Size(76, 150);
            cContainerRemedio3.TabIndex = 2;
            // 
            // cContainerRemedio4
            // 
            cContainerRemedio4.Location = new Point(277, 134);
            cContainerRemedio4.Name = "cContainerRemedio4";
            cContainerRemedio4.Size = new Size(76, 150);
            cContainerRemedio4.TabIndex = 3;
            // 
            // cContainerRemedio5
            // 
            cContainerRemedio5.Location = new Point(353, 134);
            cContainerRemedio5.Name = "cContainerRemedio5";
            cContainerRemedio5.Size = new Size(76, 150);
            cContainerRemedio5.TabIndex = 4;
            // 
            // cContainerRemedio6
            // 
            cContainerRemedio6.Location = new Point(429, 134);
            cContainerRemedio6.Name = "cContainerRemedio6";
            cContainerRemedio6.Size = new Size(76, 150);
            cContainerRemedio6.TabIndex = 5;
            // 
            // cContainerRemedio7
            // 
            cContainerRemedio7.Location = new Point(505, 134);
            cContainerRemedio7.Name = "cContainerRemedio7";
            cContainerRemedio7.Size = new Size(76, 150);
            cContainerRemedio7.TabIndex = 6;
            // 
            // lb_horaAtual
            // 
            lb_horaAtual.AutoSize = true;
            lb_horaAtual.BackColor = SystemColors.GrayText;
            lb_horaAtual.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lb_horaAtual.ForeColor = Color.LightSeaGreen;
            lb_horaAtual.Location = new Point(273, 20);
            lb_horaAtual.Name = "lb_horaAtual";
            lb_horaAtual.Size = new Size(0, 15);
            lb_horaAtual.TabIndex = 8;
            // 
            // timer_Relogio
            // 
            timer_Relogio.Interval = 1000;
            timer_Relogio.Tick += timer_Relogio_Tick;
            // 
            // pb_relogio
            // 
            pb_relogio.Image = Properties.Resources.relogio;
            pb_relogio.Location = new Point(253, -1);
            pb_relogio.Name = "pb_relogio";
            pb_relogio.Size = new Size(100, 50);
            pb_relogio.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_relogio.TabIndex = 7;
            pb_relogio.TabStop = false;
            // 
            // timer_ContagemRegressiva
            // 
            timer_ContagemRegressiva.Tick += timer_ContagemRegressiva_Tick;
            // 
            // lb_Temporizador
            // 
            lb_Temporizador.AutoSize = true;
            lb_Temporizador.BackColor = Color.Transparent;
            lb_Temporizador.Font = new Font("Yu Gothic UI", 25.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Temporizador.ForeColor = Color.LightSeaGreen;
            lb_Temporizador.Location = new Point(273, 52);
            lb_Temporizador.Name = "lb_Temporizador";
            lb_Temporizador.Size = new Size(58, 46);
            lb_Temporizador.TabIndex = 9;
            lb_Temporizador.Text = "60";
            // 
            // CaixaRemedio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_color_forms;
            ClientSize = new Size(637, 362);
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
    }
}