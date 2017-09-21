using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion
{
    public partial class FrmCicloVida : Form
    {
        public FrmCicloVida()
        {
            InitializeComponent();
        }

        private void FrmCicloVida_Activated(object sender, EventArgs e)
        {
            // se produce cuando el formulario vuelve a obtener el foco - se activa
            //lugar ideal para refrescar informacion, pero jamas se debera tener interaccion con el usuario
            LblActivated.Text = DateTime.Now.ToString("dd - MM - yy   HH:mm:ss");

            //si saco comentarios de la siguiente linea queda en loop
            //MessageBox.Show("Quedo en loop");
        }

        private void FrmCicloVida_Load(object sender, EventArgs e)
        {
            //lugar ideal para iniciallizar datos
            LblLoad.Text = "Entro en el Load";
        }

        private void FrmCicloVida_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cuando se le indica al formulario que se cierre mediante la operacion CLOSE()
            //se genera este evento.
            if ((MessageBox.Show("Esta Seguro que desea Cerrar","Cancelar salida", MessageBoxButtons.YesNo)) == DialogResult.No)
                e.Cancel = true;
        }

    }
}
