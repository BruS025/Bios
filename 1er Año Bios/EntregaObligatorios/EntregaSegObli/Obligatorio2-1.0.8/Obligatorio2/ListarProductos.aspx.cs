using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class ListarProductos : System.Web.UI.Page
    {
        // Evento para cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
                if (!IsPostBack)
                { 
                if (Session["Productos"] != null)
                    {
                        List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
                        List<ProductoCongelado> desplegarProductosCongelados = new List<ProductoCongelado>();
                        List<ProductoEnlatado> desplegarProductosEnlatados = new List<ProductoEnlatado>();

                    if (listadoProductos.Count > 0)
                            {                    
                                if (Convert.ToInt32(ddlTipoProductos.SelectedValue) == 0)
                                    {
                                        foreach (var producto in listadoProductos)
                                            {
                                                if (producto is ProductoCongelado)
                                                    {
                                                        gridEnlatados.Visible = false;
                                                        gridCongelados.Visible = true;

                                                        // Grids mobile
                                                        gridEnlatadosMobile.Visible = false;
                                                        gridCongeladosMobile.Visible = true;

                                                        desplegarProductosCongelados.Add(((ProductoCongelado)producto));
                                                        gridCongelados.DataSource = desplegarProductosCongelados;
                                                        gridCongelados.DataBind();

                                                        // Grids mobile
                                                        gridCongeladosMobile.DataSource = desplegarProductosCongelados;
                                                        gridCongeladosMobile.DataBind();

                                                        lbListadoProductosError.Visible = false;
                                                     }
                                            }

                                        if (desplegarProductosCongelados.Count == 0)
                                            {
                                                foreach (var producto in listadoProductos)
                                                    {
                                                        if (producto is ProductoEnlatado)
                                                            {
                                                                gridEnlatados.Visible = true;
                                                                gridCongelados.Visible = false;
                                                                ddlTipoProductos.SelectedIndex = 1;
                                                                desplegarProductosEnlatados.Add(((ProductoEnlatado)producto));
                                                                gridEnlatados.DataSource = desplegarProductosEnlatados;
                                                                gridEnlatados.DataBind();

                                                                // Grids mobile
                                                                gridEnlatadosMobile.Visible = true;
                                                                gridCongeladosMobile.Visible = false;
                                                                gridEnlatadosMobile.DataSource = desplegarProductosEnlatados;
                                                                gridEnlatadosMobile.DataBind();

                                                                lbListadoProductosError.Visible = false;
                                                             }
                                                    }
                                            }
                                    }
                            }

                            else
                                {
                                    ddlTipoProductos.Visible = false;
                                    lbTipoProductos.Visible = false;
                                    lbListadoProductosError.Visible = true;
                                    lbListadoProductosError.Text = "No existen productos registrados.";
                                }
                    }

                else
                {
                    ddlTipoProductos.Visible = false;
                    lbTipoProductos.Visible = false;
                    lbListadoProductosError.Visible = true;
                    lbListadoProductosError.Text = "No existen productos registrados.";
                }
            }
            }

            catch
            {
                lbListadoProductosError.Visible = true;
                lbListadoProductosError.Text = "Ha ocurrido un error.";
            }

        }

        // Evento para listar tipo de productos
        protected void ddlTipoProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
            List<ProductoCongelado> desplegarProductosCongelados = new List<ProductoCongelado>();
            List<ProductoEnlatado> desplegarProductosEnlatados = new List<ProductoEnlatado>();

            bool existenProductos = false; 

            if (Convert.ToInt32(ddlTipoProductos.SelectedValue) == 0)
            { 
            foreach (var producto in listadoProductos)
                {
                    if (producto is ProductoCongelado)
                    {
                        gridEnlatados.Visible = false;
                        gridCongelados.Visible = true;

                        existenProductos = true;
                        desplegarProductosCongelados.Add(((ProductoCongelado)producto));
                        gridCongelados.DataSource = desplegarProductosCongelados;
                        gridCongelados.DataBind();

                        // Grids mobile
                        gridEnlatadosMobile.Visible = false;
                        gridCongeladosMobile.Visible = true;
                        gridCongeladosMobile.DataSource = desplegarProductosCongelados;
                        gridCongeladosMobile.DataBind();

                    }
                }
            }

            else if (Convert.ToInt32(ddlTipoProductos.SelectedValue) == 1)
            {
                foreach (var producto in listadoProductos)
                {
                    if (producto is ProductoEnlatado)
                    {
                        gridEnlatados.Visible = true;
                        gridCongelados.Visible = false;

                        existenProductos = true;
                        desplegarProductosEnlatados.Add(((ProductoEnlatado)producto));
                        gridEnlatados.DataSource = desplegarProductosEnlatados;
                        gridEnlatados.DataBind();

                        // Grids mobile
                        gridEnlatadosMobile.Visible = true;
                        gridCongeladosMobile.Visible = false;
                        gridEnlatadosMobile.DataSource = desplegarProductosEnlatados;
                        gridEnlatadosMobile.DataBind();

                    }
                }
            }

            // Verificacion para mostrar/ocultar grid
            if (existenProductos == true)
            {
                lbListadoProductosError.Visible = false;
            }

            else
            {
                gridEnlatados.Visible = false;
                gridCongelados.Visible = false;
                lbListadoProductosError.Visible = true;
                lbListadoProductosError.Text = "No existen productos de este tipo registrado.";

                // Grids mobile
                gridEnlatadosMobile.Visible = false;
                gridCongeladosMobile.Visible = false;
            }
        }

        // Evento para volver al menu
        protected void btListarProductosVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}