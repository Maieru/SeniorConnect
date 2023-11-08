namespace Simulador_Pulseira
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btnStatus = new System.Windows.Forms.Button();
            this.gpbVizualisaJson = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAlertas = new System.Windows.Forms.TextBox();
            this.txtVizualisaJson = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gp1 = new System.Windows.Forms.GroupBox();
            this.ccbQueda = new System.Windows.Forms.CheckBox();
            this.ccbEmergencia = new System.Windows.Forms.CheckBox();
            this.pb2 = new System.Windows.Forms.GroupBox();
            this.ccbExercicio = new System.Windows.Forms.CheckBox();
            this.ccbDescanco = new System.Windows.Forms.CheckBox();
            this.gp3 = new System.Windows.Forms.GroupBox();
            this.txtBatimentos = new System.Windows.Forms.TextBox();
            this.pbQueda = new System.Windows.Forms.PictureBox();
            this.pbSosEnable = new System.Windows.Forms.PictureBox();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gpbVizualisaJson.SuspendLayout();
            this.gp1.SuspendLayout();
            this.pb2.SuspendLayout();
            this.gp3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSosEnable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ativar Simulação";
            // 
            // btnStatus
            // 
            this.btnStatus.BackColor = System.Drawing.Color.IndianRed;
            this.btnStatus.Location = new System.Drawing.Point(12, 43);
            this.btnStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(96, 34);
            this.btnStatus.TabIndex = 1;
            this.btnStatus.Text = "Off";
            this.btnStatus.UseVisualStyleBackColor = false;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // gpbVizualisaJson
            // 
            this.gpbVizualisaJson.Controls.Add(this.label3);
            this.gpbVizualisaJson.Controls.Add(this.txtAlertas);
            this.gpbVizualisaJson.Controls.Add(this.txtVizualisaJson);
            this.gpbVizualisaJson.Controls.Add(this.label2);
            this.gpbVizualisaJson.Location = new System.Drawing.Point(153, -2);
            this.gpbVizualisaJson.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbVizualisaJson.Name = "gpbVizualisaJson";
            this.gpbVizualisaJson.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbVizualisaJson.Size = new System.Drawing.Size(262, 331);
            this.gpbVizualisaJson.TabIndex = 2;
            this.gpbVizualisaJson.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 191);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Json de alertas";
            // 
            // txtAlertas
            // 
            this.txtAlertas.Location = new System.Drawing.Point(8, 214);
            this.txtAlertas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAlertas.Multiline = true;
            this.txtAlertas.Name = "txtAlertas";
            this.txtAlertas.ReadOnly = true;
            this.txtAlertas.Size = new System.Drawing.Size(251, 111);
            this.txtAlertas.TabIndex = 2;
            // 
            // txtVizualisaJson
            // 
            this.txtVizualisaJson.Location = new System.Drawing.Point(6, 46);
            this.txtVizualisaJson.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtVizualisaJson.Multiline = true;
            this.txtVizualisaJson.Name = "txtVizualisaJson";
            this.txtVizualisaJson.ReadOnly = true;
            this.txtVizualisaJson.Size = new System.Drawing.Size(251, 130);
            this.txtVizualisaJson.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Json de Dados";
            // 
            // gp1
            // 
            this.gp1.Controls.Add(this.ccbQueda);
            this.gp1.Controls.Add(this.ccbEmergencia);
            this.gp1.Location = new System.Drawing.Point(10, 168);
            this.gp1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gp1.Name = "gp1";
            this.gp1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gp1.Size = new System.Drawing.Size(135, 80);
            this.gp1.TabIndex = 3;
            this.gp1.TabStop = false;
            this.gp1.Text = "Simulações";
            // 
            // ccbQueda
            // 
            this.ccbQueda.AutoSize = true;
            this.ccbQueda.Location = new System.Drawing.Point(6, 47);
            this.ccbQueda.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ccbQueda.Name = "ccbQueda";
            this.ccbQueda.Size = new System.Drawing.Size(106, 19);
            this.ccbQueda.TabIndex = 1;
            this.ccbQueda.Text = "Possivel Queda";
            this.ccbQueda.UseVisualStyleBackColor = true;
            // 
            // ccbEmergencia
            // 
            this.ccbEmergencia.AutoSize = true;
            this.ccbEmergencia.Location = new System.Drawing.Point(6, 22);
            this.ccbEmergencia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ccbEmergencia.Name = "ccbEmergencia";
            this.ccbEmergencia.Size = new System.Drawing.Size(88, 19);
            this.ccbEmergencia.TabIndex = 0;
            this.ccbEmergencia.Text = "Emergencia";
            this.ccbEmergencia.UseVisualStyleBackColor = true;
            // 
            // pb2
            // 
            this.pb2.Controls.Add(this.ccbExercicio);
            this.pb2.Controls.Add(this.ccbDescanco);
            this.pb2.Location = new System.Drawing.Point(10, 254);
            this.pb2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb2.Name = "pb2";
            this.pb2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb2.Size = new System.Drawing.Size(135, 75);
            this.pb2.TabIndex = 2;
            this.pb2.TabStop = false;
            this.pb2.Text = "Heart Rate";
            // 
            // ccbExercicio
            // 
            this.ccbExercicio.AutoSize = true;
            this.ccbExercicio.Location = new System.Drawing.Point(6, 47);
            this.ccbExercicio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ccbExercicio.Name = "ccbExercicio";
            this.ccbExercicio.Size = new System.Drawing.Size(73, 19);
            this.ccbExercicio.TabIndex = 2;
            this.ccbExercicio.Text = "Exercicio";
            this.ccbExercicio.UseVisualStyleBackColor = true;
            // 
            // ccbDescanco
            // 
            this.ccbDescanco.AutoSize = true;
            this.ccbDescanco.Location = new System.Drawing.Point(6, 22);
            this.ccbDescanco.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ccbDescanco.Name = "ccbDescanco";
            this.ccbDescanco.Size = new System.Drawing.Size(76, 19);
            this.ccbDescanco.TabIndex = 1;
            this.ccbDescanco.Text = "Descanso";
            this.ccbDescanco.UseVisualStyleBackColor = true;
            // 
            // gp3
            // 
            this.gp3.BackColor = System.Drawing.Color.White;
            this.gp3.Controls.Add(this.txtBatimentos);
            this.gp3.Controls.Add(this.pbQueda);
            this.gp3.Controls.Add(this.pbSosEnable);
            this.gp3.Controls.Add(this.txtHora);
            this.gp3.Controls.Add(this.pictureBox1);
            this.gp3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gp3.Location = new System.Drawing.Point(430, -2);
            this.gp3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gp3.Name = "gp3";
            this.gp3.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.gp3.Size = new System.Drawing.Size(289, 331);
            this.gp3.TabIndex = 5;
            this.gp3.TabStop = false;
            // 
            // txtBatimentos
            // 
            this.txtBatimentos.BackColor = System.Drawing.Color.Black;
            this.txtBatimentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBatimentos.Font = new System.Drawing.Font("Showcard Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBatimentos.ForeColor = System.Drawing.Color.White;
            this.txtBatimentos.Location = new System.Drawing.Point(140, 138);
            this.txtBatimentos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBatimentos.Multiline = true;
            this.txtBatimentos.Name = "txtBatimentos";
            this.txtBatimentos.ReadOnly = true;
            this.txtBatimentos.Size = new System.Drawing.Size(71, 68);
            this.txtBatimentos.TabIndex = 9;
            this.txtBatimentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pbQueda
            // 
            this.pbQueda.Image = ((System.Drawing.Image)(resources.GetObject("pbQueda.Image")));
            this.pbQueda.Location = new System.Drawing.Point(41, 211);
            this.pbQueda.Name = "pbQueda";
            this.pbQueda.Size = new System.Drawing.Size(67, 78);
            this.pbQueda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQueda.TabIndex = 8;
            this.pbQueda.TabStop = false;
            this.pbQueda.Visible = false;
            // 
            // pbSosEnable
            // 
            this.pbSosEnable.Image = ((System.Drawing.Image)(resources.GetObject("pbSosEnable.Image")));
            this.pbSosEnable.Location = new System.Drawing.Point(104, 211);
            this.pbSosEnable.Name = "pbSosEnable";
            this.pbSosEnable.Size = new System.Drawing.Size(83, 78);
            this.pbSosEnable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSosEnable.TabIndex = 7;
            this.pbSosEnable.TabStop = false;
            this.pbSosEnable.Visible = false;
            // 
            // txtHora
            // 
            this.txtHora.BackColor = System.Drawing.Color.Black;
            this.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHora.Font = new System.Drawing.Font("Showcard Gothic", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHora.ForeColor = System.Drawing.Color.White;
            this.txtHora.Location = new System.Drawing.Point(56, 58);
            this.txtHora.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtHora.Multiline = true;
            this.txtHora.Name = "txtHora";
            this.txtHora.ReadOnly = true;
            this.txtHora.Size = new System.Drawing.Size(166, 74);
            this.txtHora.TabIndex = 6;
            this.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 301);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(44, 89);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 7;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(44, 123);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(100, 23);
            this.txtKey.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Key";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(732, 341);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gp3);
            this.Controls.Add(this.pb2);
            this.Controls.Add(this.gp1);
            this.Controls.Add(this.gpbVizualisaJson);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.gpbVizualisaJson.ResumeLayout(false);
            this.gpbVizualisaJson.PerformLayout();
            this.gp1.ResumeLayout(false);
            this.gp1.PerformLayout();
            this.pb2.ResumeLayout(false);
            this.pb2.PerformLayout();
            this.gp3.ResumeLayout(false);
            this.gp3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSosEnable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnStatus;
        private GroupBox gpbVizualisaJson;
        private TextBox txtVizualisaJson;
        private Label label2;
        private GroupBox gp1;
        private GroupBox pb2;
        public CheckBox ccbQueda;
        public CheckBox ccbEmergencia;
        public CheckBox ccbExercicio;
        public CheckBox ccbDescanco;
        private GroupBox gp3;
        private TextBox txtHora;
        private PictureBox pictureBox1;
        private PictureBox pbSosEnable;
        private PictureBox pbQueda;
        private TextBox txtBatimentos;
        private Label label3;
        private TextBox txtAlertas;
        private Label label4;
        private TextBox txtId;
        private TextBox txtKey;
        private Label label5;
    }
}