using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empleado"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        else
        {
            Empleado empleado = (Empleado)Session["Empleado"];
            lbNombre.Text = "Usuario: " + empleado.NombreLogueo;

        }
    }

    // SALIR
    protected void btSalir_Click1(object sender, EventArgs e)
    {
        Session["Empleado"] = null;

        Response.Redirect("Default.aspx");
    }
}
