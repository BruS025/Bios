using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using CapaLogica;

namespace _3Capas
{
    public partial class ModificarAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkbVolverMoficar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Defacul.aspx");
        }

        protected void btBuscarMod_Click(object sender, EventArgs e)
        {     
            
            Alumno alumno= LogicaAlumno.MostrarDatos(Convert.ToInt32(txtCiModificar.Text));
            txtGeneracionModificar.Text = alumno.Generacion.ToString();
            txtNombreModificar.Text = alumno.Nombre;
            txtNomCalleModificar.Text = alumno.NomCalle;
            txtNroPuertaModificar.Text = alumno.NroPuerta.ToString();
        }

        protected void btGuardarMod_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumnomod = new Alumno();
                alumnomod.CiAlumno = Convert.ToInt32(txtCiModificar.Text);
                alumnomod.Nombre = txtNombreModificar.Text;
                alumnomod.Generacion = Convert.ToInt32(txtGeneracionModificar.Text);
                alumnomod.NomCalle = txtNomCalleModificar.Text;
                alumnomod.NroPuerta = Convert.ToInt32(txtNroPuertaModificar.Text);

                int devolver = LogicaAlumno.Modificar(alumnomod);

                if (devolver == 1)
                {
                    lbResultadoModificar.Text = "Se modifico";
                }
            }
            catch (Exception ex)
            {

                lbResultadoModificar.Text = "Error" + ex.Message;
            }
        }
    }
}