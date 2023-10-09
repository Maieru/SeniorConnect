using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulador_Caixa_de_Remedios
{
    public partial class CContainerRemedio : UserControl
    {
        public CContainerRemedio()
        {
            InitializeComponent();
        }

        private bool _Aberto = false;
        private bool _LEDAceso = false;

        private void bt_Abrir_Click(object sender, EventArgs e)
        {
            Aberto = true;
        }

        public bool Aberto
        {
            get { return _Aberto; }

            set
            {
                pb_container.Image = Image.FromFile("img\\container aberto.jpg");
                _Aberto = value;
            }
        }

        public bool LEDAceso
        {
            get { return _LEDAceso; }

            set
            {
                pb_container.Image = Image.FromFile("img\\container led acesso.jpg");
                _LEDAceso = value;
            }
        }
    }
}
