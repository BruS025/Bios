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
    public partial class AgregarMateria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btAgregarMateria_Click(object sender, EventArgs e)
        {
            Materias materia = new Materias();

            materia.IdMateria = Convert.ToInt32(txtId.Text);
            materia.Nombre = txtNombre.Text;
            materia.CargaHoraria = Convert.ToInt32(txtCargaHoraria.Text);

            int devolver =LogicaMaterias.Agregar(materia);

            if (devolver==1)
            {
                lbResultadoAgregarMateria.Text = "Se agrego";
            }
            else
            {
                lbResultadoAgregarMateria.Text = "No se agrego";
            }
        }

        protected void lnkbVolverAgregarMateria_Click(object sender, EventArgs e)
        {
            Response.Redirect("Defacul.aspx");
        }
    }
}