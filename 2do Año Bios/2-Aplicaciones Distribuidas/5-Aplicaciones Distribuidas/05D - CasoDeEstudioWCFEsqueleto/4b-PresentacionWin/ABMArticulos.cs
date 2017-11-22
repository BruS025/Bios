﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PresentacionWin
{
    public partial class ABMArticulos : Form
    {
        

        public ABMArticulos()
        {
            InitializeComponent();
        }

        private void ABMArticulos_Load(object sender, EventArgs e)
        {
            
        }

        private void TxtCodigo_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo acepto numeros y teclas de control
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) 
                e.Handled = true;

        }

        private void BtnAlta_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            (new ListarArticulos()).ShowDialog();
        }

        private void BtnDeshacer_Click(object sender, EventArgs e)
        {
        }
       
    }
}
