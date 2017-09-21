using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class CalcularTotalXproducto : System.Web.UI.Page
    {
        // Evento cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Productos"] != null)
                    {
                        List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
                        List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];
                        List<long> listaProductosDDL = new List<long>();

                        if (listadoProductos.Count > 0)
                            {
                                if (Session["Ventas"] != null)
                                    { 
                                        if (listadoVentas.Count > 0)
                                            {                                                                 
                                                foreach (var producto in listadoProductos)
                                                    {
                                                        listaProductosDDL.Add(producto.Código);
                                                        
                                                    }

                                                if (Session["ProductosListados"] == null)
                                                    {
                                                        Session["ProductosListados"] = listaProductosDDL;
                                                        ddlProductos.DataSource = listaProductosDDL;
                                                        ddlProductos.DataBind();

                                    // inicio
                                    int cantidad = 0;
                                    double ganancias = 0;

                                    foreach (var producto in listadoProductos)
                                    {
                                        if (producto.Código == Convert.ToInt64(ddlProductos.SelectedValue))
                                        {
                                            lbCalculoProductoNombre.Text = producto.Nombre;
                                            foreach (var venta in listadoVentas)
                                            {
                                                if (venta.CodigoBarra == Convert.ToInt64(ddlProductos.SelectedValue))
                                                {

                                                    cantidad = cantidad + venta.CantidadProducto;
                                                    ganancias = ganancias + venta.TotalVenta;
                                                }
                                            }
                                        }
                                    }

                                    lbCalcularTotalXproductoMostrarCantidad.Text = Convert.ToString(cantidad);
                                    lbCalcularTotalXproductoMostrarCalculo.Text = Convert.ToString(ganancias);
                                    // fin
                                }           
                                            }
                                        else
                                            {
                                                mostrarCamposError();
                                                lbGananciasError.Text = "No existen ventas registradas.";
                                            }
                                    }
                                else 
                                    {
                                        mostrarCamposError();
                                        lbGananciasError.Text = "No existen ventas registradas.";
                                    }
                            }
                        else
                            {
                                mostrarCamposError();
                                lbGananciasError.Text = "No existen productos registrados.";
                            }
                   }
                else
                {
                    mostrarCamposError();
                    lbGananciasError.Text = "No existen productos registrados.";
                }
            }

            catch
            {
                mostrarCamposError();
                lbGananciasError.Text = "Ha ocurrido un error.";
            }
        }

        // Evento para volver al menu
        protected void btCalculoProductoVolver_Click(object sender, EventArgs e)
        {
            Session["ProductosListados"] = null;
            Response.Redirect("Default.aspx");
        }
        
        // Evento calcular
        protected void ddlProductos_SelectedIndexChanged1(object sender, EventArgs e)
        {
            List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
            List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];

            int cantidad = 0;
            double ganancias = 0;

            foreach ( var producto in listadoProductos)
            {
                if (producto.Código == Convert.ToInt64(ddlProductos.SelectedValue))
                {
                    lbCalculoProductoNombre.Text = producto.Nombre;
                    foreach (var venta in listadoVentas)
                {
                    if ( venta.CodigoBarra == Convert.ToInt64(ddlProductos.SelectedValue))
                    {
                                                  
                        cantidad = cantidad + venta.CantidadProducto;
                        ganancias = ganancias + venta.TotalVenta;                           
                    }
                }
            }
          }
            
            lbCalcularTotalXproductoMostrarCantidad.Text = Convert.ToString(cantidad);
            lbCalcularTotalXproductoMostrarCalculo.Text = Convert.ToString(ganancias);
        }

        // Evento para mostrar error
        protected void mostrarCamposError()
        {
            lbCalcularTotalXproductoBuscar.Visible = false;
            ddlProductos.Visible = false;
            lbCalculoNombre.Visible = false;
            lbCalculoProductoNombre.Visible = false;
            lbCalculoCantidad.Visible = false;
            lbCalcularTotalXproductoMostrarCantidad.Visible = false;
            lbCalculoGanancia.Visible = false;
            lbCalcularTotalXproductoMostrarCalculo.Visible = false;
            lbGananciasError.Visible = true;

        }
    }
}