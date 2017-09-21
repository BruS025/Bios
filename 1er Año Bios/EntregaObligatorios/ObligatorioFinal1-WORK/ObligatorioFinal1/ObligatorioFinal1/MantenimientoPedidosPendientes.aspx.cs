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
    public partial class WebForm6 : System.Web.UI.Page
    {
        // Page Load
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

                    else if (Session["Usuario"] is Administrador)
                    {

                        Response.Redirect("BienvenidaAdministrador.aspx");
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
            Cliente cliente = new Cliente();
            cliente = (Cliente)Session["Usuario"];

            List<Pedido> listadoVentasPendientes = new List<Pedido>(LogicaPedido.Pendientes(cliente.Documento));
            GridPedidos.DataSource = listadoVentasPendientes;
            GridPedidos.DataBind();

        }

        // Cargar Lineas Pendientes
        protected void CargarLineasPedido(int id)
        {

            List<Linea> listadoLineasPendientes = new List<Linea>(LogicaLinea.Pendientes(id));
            List<Plato> platos = new List<Plato>();

            foreach (var lineaPendiente in listadoLineasPendientes)
            {
                Plato plato = new Plato();

                plato.Id = lineaPendiente.UnPlato.Id;
                plato.Nombre = lineaPendiente.UnPlato.Nombre;
                plato.Precio = lineaPendiente.UnPlato.Precio;
                plato.Foto = lineaPendiente.UnPlato.Foto;                

                platos.Add(plato);

            }

            Session["LineasPendientes"] = listadoLineasPendientes;
            GridLineas.DataSource = platos;
            GridLineas.DataBind();
        }

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.lineas.ServerClick += new System.EventHandler(this.verLineasClick);
            this.Load += new System.EventHandler(this.Page_Load);

        }

        // Ver grilla2
        protected void verLineasClick(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi();</script>");
        }

        // Paginado pedidos
        protected void GridPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridPedidos.PageIndex = e.NewPageIndex;
            CargarPedidosPendientes();
        }

        // Accion de grilla al seleccionar - cargar otra grillaLinea
        protected void GridPedidos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Session["IdVenta"] = Convert.ToInt32(this.GridPedidos.Rows[e.NewSelectedIndex].Cells[1].Text);
            CargarLineasPedido(Convert.ToInt32(this.GridPedidos.Rows[e.NewSelectedIndex].Cells[1].Text));

        }

        // Seleccionar lineas
        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                lineas.Visible = true;

            }

            catch (Exception ex)
            {

                lbError.Text = (ex.Message);
            }
        }

        // Paginado lineas
        protected void GridLineas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridLineas.PageIndex = e.NewPageIndex;
            CargarLineasPedido((int)Session["IdVenta"]);

        }

        // pasar valor de foto al modal utilizar sessiones
        protected void GridLineas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            // buscar foto del plato y cantidad y casa para cargar utilizando el id de la venta
            List<Linea> lineaSeleccionada = new List<Linea>();
            lineaSeleccionada = (List<Linea>)Session["LineasPendientes"];

            string foto = "/ImagenesPlato/" + this.GridLineas.Rows[e.NewSelectedIndex].Cells[4].Text;

            fotoPlato.Visible = true;
            fotoPlato.Src = foto;
            fotoPlato.DataBind();

            foreach (var linea in lineaSeleccionada)
            {
                if (linea.UnPlato.Id == Convert.ToInt32(GridLineas.Rows[e.NewSelectedIndex].Cells[1].Text))
                {
                    lbCasa.Visible = true;
                    lbCantidad.Visible = true;
                    nombreCasa.Text = linea.UnaCasa.Nombre;
                    cantidad.Text = Convert.ToString(linea.Cantidad);
                }
            }
        }

        // Activar boton para ver modal de foto del plato
        protected void btnSeleccionarLinea_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi();</script>");

        }
    }
}