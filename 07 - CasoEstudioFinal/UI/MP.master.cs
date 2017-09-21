using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MP : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //verifico q el usuario tenga permiso de ingreso
            if (!(Session["Usuario"] is EntidadesCompartidas.Usuario))
                Response.Redirect("Default.aspx");
        }
        catch
        {
            Response.Redirect("Default.aspx");
        }
    }
}
