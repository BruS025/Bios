using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using EntidadesCompartidas;
using Logica;
using System.IO;

namespace ObligatorioFinal1
{
    public partial class WebForm1 : System.Web.UI.Page
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

                    Calendar1.SelectedDate = DateTime.Now;
                    PedidosPendientes();

                }

                catch (Exception ex)
                {
                    lbError.Text = ex.Message;

                }
            }
        }

        protected void PedidosPendientes()
        {
            try
            {
                DataSet ds = new DataSet("Archivo");
                DataTable tabla = ds.Tables.Add("Pedidos entregados");

                DataColumn Hora = new DataColumn("Hora", typeof(DateTime));
                DataColumn CasaComida = new DataColumn("CasaComidas", typeof(Int64));
                DataColumn Plato = new DataColumn("Plato", typeof(Int32));
                DataColumn Cantidad = new DataColumn("Cantidad", typeof(Int32));
                DataColumn DireccionEntrega = new DataColumn("DireccionEntrega", typeof(String));

                tabla.Columns.Add(Hora);
                tabla.Columns.Add(CasaComida);
                tabla.Columns.Add(Plato);
                tabla.Columns.Add(Cantidad);
                tabla.Columns.Add(DireccionEntrega);

                ds = LogicaPedido.XML(Calendar1.SelectedDate);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridPedidos.Visible = true;
                    GridPedidos.DataSource = ds;
                    GridPedidos.DataBind();
                    ds.WriteXml(Server.MapPath("~/XML/Archivo.xml"));
                    lbError.Text = "";
                }

                else
                {
                    lbError.Text = "No existen pedidos entregados en fecha seleccionada..";
                    GridPedidos.Visible = false;
                }                    
            }

            catch (Exception)
            {

                throw;
            }               
        }

        protected void GridPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridPedidos.PageIndex = e.NewPageIndex;
            // Aca falta un actualizar grilla
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            PedidosPendientes();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //creo dataset
                DataSet dsR = new DataSet("Archivo");

                //leo el dataset que se encuentra en el servidor
                dsR.ReadXml(Server.MapPath("~/XML/Archivo.xml"));

                if (dsR.Tables[0].Rows.Count > 0)
                {
                    //Cargo el dataset dentro de la grilla
                    GridPedidos.DataSource = dsR;
                    GridPedidos.DataBind();

                    GridPedidos.Visible = true;
                    lbError.Text = "";

                }

                else
                {
                    lbError.Text = "No existen pedidos entregados en fecha seleccionada..";
                    GridPedidos.Visible = false;

                }                                       
            }

            catch  (FileNotFoundException)
            {
                lbError.Text = "No existe archivo XML cargado..";
            }

            catch (Exception)
            {
                lbError.Text = "Ha ocurrido un error..";
            
            }
        }
    }
    
}