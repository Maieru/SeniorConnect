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
            this.label1 = new System.Windows.Forms.Label();
            this.btnStatus = new System.Windows.Forms.Button();
            this.gpbVizualisaJson = new System.Windows.Forms.GroupBox();
            this.txtVizualisaJson = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ccbQueda = new System.Windows.Forms.CheckBox();
            this.ccbEmergencia = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ccbDescanco = new System.Windows.Forms.CheckBox();
            this.ccbExercicio = new System.Windows.Forms.CheckBox();
            this.gpbVizualisaJson.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ativar Simulação";
            // 
            // btnStatus
            // 
            this.btnStatus.BackColor = System.Drawing.Color.IndianRed;
            this.btnStatus.Location = new System.Drawing.Point(12, 43);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(96, 34);
            this.btnStatus.TabIndex = 1;
            this.btnStatus.Text = "Off";
            this.btnStatus.UseVisualStyleBackColor = false;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // gpbVizualisaJson
            // 
            this.gpbVizualisaJson.Controls.Add(this.txtVizualisaJson);
            this.gpbVizualisaJson.Controls.Add(this.label2);
            this.gpbVizualisaJson.Location = new System.Drawing.Point(164, 4);
            this.gpbVizualisaJson.Name = "gpbVizualisaJson";
            this.gpbVizualisaJson.Size = new System.Drawing.Size(263, 280);
            this.gpbVizualisaJson.TabIndex = 2;
            this.gpbVizualisaJson.TabStop = false;
            // 
            // txtVizualisaJson
            // 
            this.txtVizualisaJson.Location = new System.Drawing.Point(8, 46);
            this.txtVizualisaJson.Multiline = true;
            this.txtVizualisaJson.Name = "txtVizualisaJson";
            this.txtVizualisaJson.ReadOnly = true;
            this.txtVizualisaJson.Size = new System.Drawing.Size(249, 228);
            this.txtVizualisaJson.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Json de Dados";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ccbQueda);
            this.groupBox1.Controls.Add(this.ccbEmergencia);
            this.groupBox1.Location = new System.Drawing.Point(12, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Botões";
            // 
            // ccbQueda
            // 
            this.ccbQueda.AutoSize = true;
            this.ccbQueda.Location = new System.Drawing.Point(6, 47);
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
            this.ccbEmergencia.Name = "ccbEmergencia";
            this.ccbEmergencia.Size = new System.Drawing.Size(88, 19);
            this.ccbEmergencia.TabIndex = 0;
            this.ccbEmergencia.Text = "Emergencia";
            this.ccbEmergencia.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ccbExercicio);
            this.groupBox2.Controls.Add(this.ccbDescanco);
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Atividade";
            // 
            // ccbDescanco
            // 
            this.ccbDescanco.AutoSize = true;
            this.ccbDescanco.Location = new System.Drawing.Point(6, 22);
            this.ccbDescanco.Name = "ccbDescanco";
            this.ccbDescanco.Size = new System.Drawing.Size(77, 19);
            this.ccbDescanco.TabIndex = 1;
            this.ccbDescanco.Text = "Descanço";
            this.ccbDescanco.UseVisualStyleBackColor = true;
            // 
            // ccbExercicio
            // 
            this.ccbExercicio.AutoSize = true;
            this.ccbExercicio.Location = new System.Drawing.Point(6, 47);
            this.ccbExercicio.Name = "ccbExercicio";
            this.ccbExercicio.Size = new System.Drawing.Size(73, 19);
            this.ccbExercicio.TabIndex = 2;
            this.ccbExercicio.Text = "Exercicio";
            this.ccbExercicio.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 285);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpbVizualisaJson);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.gpbVizualisaJson.ResumeLayout(false);
            this.gpbVizualisaJson.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnStatus;
        private GroupBox gpbVizualisaJson;
        private TextBox txtVizualisaJson;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        public CheckBox ccbQueda;
        public CheckBox ccbEmergencia;
        public CheckBox ccbExercicio;
        public CheckBox ccbDescanco;
    }
}