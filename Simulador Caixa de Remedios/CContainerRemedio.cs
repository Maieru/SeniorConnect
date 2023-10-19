﻿using System;
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

        public int NumeroContainer { get; set; }
        private void bt_Abrir_Click(object sender, EventArgs e)
        {
            Aberto = !Aberto;
        }

        public bool Aberto
        {
            get { return _Aberto; }

            set
            {
                _Aberto = value;
                FazControleImagem();
            }
        }

        public bool LEDAceso
        {
            get { return _LEDAceso; }

            set
            {
                _LEDAceso = value;
                FazControleImagem();
            }
        }

        private void FazControleImagem()
        {
            if (Aberto)
            {
                pb_container.Image = Image.FromFile("img\\container aberto.jpg");
                return;
            }

            if (LEDAceso)
            {
                pb_container.Image = Image.FromFile("img\\container led acesso.jpg");
                return;
            }

            pb_container.Image = Image.FromFile("img\\container.jpg");
        }

       
    }
}