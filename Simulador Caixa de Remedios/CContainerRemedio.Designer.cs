namespace Simulador_Caixa_de_Remedios
{
    partial class CContainerRemedio
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            pb_container = new PictureBox();
            bt_Abrir = new Button();
            ((System.ComponentModel.ISupportInitialize)pb_container).BeginInit();
            SuspendLayout();
            // 
            // pb_container
            // 
            pb_container.Image = Properties.Resources.container;
            pb_container.InitialImage = Properties.Resources.container;
            pb_container.Location = new Point(0, 0);
            pb_container.Name = "pb_container";
            pb_container.Size = new Size(76, 150);
            pb_container.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_container.TabIndex = 0;
            pb_container.TabStop = false;
            // 
            // bt_Abrir
            // 
            bt_Abrir.BackColor = Color.Khaki;
            bt_Abrir.Location = new Point(12, 57);
            bt_Abrir.Name = "bt_Abrir";
            bt_Abrir.Size = new Size(49, 23);
            bt_Abrir.TabIndex = 1;
            bt_Abrir.Text = "Abrir";
            bt_Abrir.UseVisualStyleBackColor = false;
            bt_Abrir.Click += bt_Abrir_Click;
            // 
            // CContainerRemedio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bt_Abrir);
            Controls.Add(pb_container);
            Name = "CContainerRemedio";
            Size = new Size(76, 150);
            ((System.ComponentModel.ISupportInitialize)pb_container).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_container;
        private Button bt_Abrir;
    }
}
