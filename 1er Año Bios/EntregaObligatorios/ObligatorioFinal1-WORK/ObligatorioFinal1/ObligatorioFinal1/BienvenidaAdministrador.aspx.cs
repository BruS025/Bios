using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

namespace ObligatorioFinal1
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            else if (Session["Usuario"] is Cliente)
            {

                Response.Redirect("MantenimientoRealizarPedido.aspx");
            }
        }

        protected void btCasa_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoCasas.aspx");
        }
        protected void btPlato_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoPlatos.aspx");
        }

        protected void btAdministradores_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoAdmins.aspx");
        }

        protected void btListarPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoPedidos.aspx");
        }

        protected void btEntrega_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoEntrega.aspx");
        }

        protected void btSalir_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}