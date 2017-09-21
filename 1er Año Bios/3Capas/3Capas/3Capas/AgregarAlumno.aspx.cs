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
    public partial class AgregarAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btGuardarAlumno_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumno = new Alumno();

                alumno.CiAlumno = Convert.ToInt32(txtCiAlumno.Text);
                alumno.Nombre = txtNombreAlumno.Text;
                alumno.Generacion = Convert.ToInt32(txtGeneracionAlumno.Text);
                alumno.NomCalle = txtNombreCalleAlumno.Text;
                alumno.NroPuerta = Convert.ToInt32(txtNroPuertaAlumno.Text);

                int validar = LogicaAlumno.Agregar(alumno);

                if (validar == 1)
                {
                    lbResultadoGuardarAlumno.Text = "Se agrego";
                }
            }
            catch (Exception ex)
            {
                lbResultadoGuardarAlumno.Text = "Error " + ex.Message;
            }        
        }

        protected void lnkbVolverAgregarAlumno_Click(object sender, EventArgs e)
        {
            Response.Redirect("defacul.aspx");
        }
    }
}