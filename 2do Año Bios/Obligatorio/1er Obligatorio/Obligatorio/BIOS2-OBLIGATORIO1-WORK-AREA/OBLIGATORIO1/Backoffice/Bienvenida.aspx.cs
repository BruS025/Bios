using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bienvenida : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btEmpleados_Click(object sender, EventArgs e)
    {
        Response.Redirect("Empleados.aspx");
    }

    protected void btApartamentos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Apartamentos.aspx");
    }

    protected void btCasas_Click(object sender, EventArgs e)
    {
        Response.Redirect("Casas.aspx");
    }

    protected void btLocales_Click(object sender, EventArgs e)
    {
        Response.Redirect("Locales.aspx");
    }

    protected void btZonas_Click(object sender, EventArgs e)
    {
        Response.Redirect("Zonas.aspx");
    }
}