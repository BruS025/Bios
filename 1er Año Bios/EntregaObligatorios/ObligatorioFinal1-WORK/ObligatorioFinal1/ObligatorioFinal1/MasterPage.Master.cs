using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

namespace ObligatorioFinal1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            else if (Session["Usuario"] is Administrador)
            {
                Administrador admin = new Administrador();
                admin = (Administrador)Session["Usuario"];
                masterNombreUsuario.Text = admin.Nombre;

                menuCliente.Visible = false;
                menuAdmin.Visible = true;
            }

            else if (Session["Usuario"] is Cliente)
            {
                Cliente cliente = new Cliente();
                cliente = (Cliente)Session["Usuario"];
                masterNombreUsuario.Text = cliente.Nombre;

                menuCliente.Visible = true;
                menuAdmin.Visible = false;
            }
        }

        protected void btSalir_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Session["LineaVenta"] = null;
            Session["Carrito"] = null;
            Session["Platos"] = null;
            Session["Casas"] = null;

            Response.Redirect("Default.aspx");
        }
    }
}