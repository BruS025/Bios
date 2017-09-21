using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Empleado"] = null;
        }
    }

    // LOGIN
    protected void BTLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtNombre.Text != null && TxtContraseña.Text != null)
            {
                ILogicaEmpleado LEmpleado = FabricaLogica.getLogicaEmpleado();
                bool login = LEmpleado.Login(TxtNombre.Text, TxtContraseña.Text);

                if (login == true)
                {
                    Empleado empleado = new Empleado(TxtNombre.Text, TxtContraseña.Text, true);
                    Session["Empleado"] = empleado;
                    Response.Redirect("Bienvenida.aspx");
                }

                else
                {
                    TxtContraseña.Text = "";
                    LBResultado.Text = "Sus credenciales no son validas..";
                }
            }

            else
            {
                LBResultado.Text = "Debe ingresar credenciales..";

            }
        }

        catch (Exception ex)
        {
            LBResultado.Text = ex.Message;
        }
    }
}