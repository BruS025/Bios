using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

namespace ObligatorioFinal1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["Usuario"] == null)
                    {
                        Response.Redirect("Default.aspx");
                    }

                    else if (Session["Usuario"] is Cliente)
                    {

                        Response.Redirect("MantenimientoRealizarPedido.aspx");
                    }

                    CargarPedidosPendientes();
                }

                catch (Exception ex)
                {
                    lbError.Text = ex.Message;
                }
            }
        }

        // Cargar Pedidos Pendientes
        protected void CargarPedidosPendientes()
        {
            try
            {
                List<Pedido> listadoVentasPendientes = new List<Pedido>(LogicaPedido.PendientesTodos());
                GridPedidos.DataSource = listadoVentasPendientes;
                GridPedidos.DataBind();
            }
            catch (Exception)
            {

                throw;
            }          
        }

        protected void GridPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridPedidos.PageIndex = e.NewPageIndex;
            CargarPedidosPendientes();
        }

        protected void GridPedidos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Session["IdVenta"] = Convert.ToInt32(this.GridPedidos.Rows[e.NewSelectedIndex].Cells[1].Text);
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            confirmar.Visible = true;
        }

        protected void confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // Pasar fecha actual y idPedido
                LogicaPedido.Confirmar((int)Session["IdVenta"],DateTime.Now);
                CargarPedidosPendientes();
                lbError.Text = "Pedido entregado..";

            }

            catch (Exception)
            {

                throw;
            }            
        }
    }
}