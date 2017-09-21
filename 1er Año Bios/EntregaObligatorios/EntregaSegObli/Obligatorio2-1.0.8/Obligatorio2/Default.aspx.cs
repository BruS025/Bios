using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class Default : System.Web.UI.Page
    {
        // Evento al cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Al iniciar, chequeo para ocultar campos
                if (Session["Empresa"] == null)
                {
                    // Ocultar botones
                    btMenuMantenimientoClientes.Visible = false;
                    btMenuMantenimientoProductosEnlatados.Visible = false;
                    btMenuMantenimientoProductosCongelados.Visible = false;
                    btMenuCalcularTotalMensual.Visible = false;
                    btMenuCalcularTotalXproducto.Visible = false;
                    btMenuListarProductos.Visible = false;
                    btMenuPagoFactura.Visible = false;
                    btMenuVentaDeProducto.Visible = false;

                    // Ocultar labels
                    lbClientes.Visible = false;
                    lbProductos.Visible = false;
                    lbGanancias.Visible = false;
                    lbVentas.Visible = false;
                }
            }

                // Chequeo para ocultar botones
                if (Session["Empresa"] != null)
                {
                    if (Session["Clientes"] == null || Session["Productos"] == null)
                    {
                        btMenuVentaDeProducto.Visible = false;
                        btMenuPagoFactura.Visible = false;
                        lbVentas.Visible = false;
                    }

                    // Chequeo para desplegar "Venta de productos" y "Pago de facturas"
                    int verificador = 0;

                    // 1 Verificar si "Clientes" no esta vacio
                    if (Session["Clientes"] != null)
                    {
                        List<Cliente> crearListadoClientes = new List<Cliente>();
                        crearListadoClientes = (List<Cliente>)Session["Clientes"];


                        if (crearListadoClientes == null  || crearListadoClientes.Count == 0)
                        {
                            btMenuVentaDeProducto.Visible = false;
                            btMenuPagoFactura.Visible = false;
                            lbVentas.Visible = false;
                        }
                        else
                        {
                            verificador = verificador + 1;
                        }

                    }

                    // 2  Verificar si "Productos" no esta vacio
                    if (Session["Productos"] != null)
                    {
                        List<Producto> crearListadoProductos = new List<Producto>();
                        crearListadoProductos = (List<Producto>)Session["Productos"];


                        if (crearListadoProductos == null || crearListadoProductos.Count == 0)
                        {
                            btMenuVentaDeProducto.Visible = false;
                            btMenuPagoFactura.Visible = false;
                            lbVentas.Visible = false;
                        }

                        else
                        {
                            verificador = verificador + 1;
                        }

                    }

                    // 3  Desplegar boton dependiendo del numero verificador
                    if (verificador != 2)
                    {                      
                            btMenuVentaDeProducto.Visible = false;
                            btMenuPagoFactura.Visible = false;
                            lbVentas.Visible = false;
                    }

                    verificador = 0; // Reiniciamos valor

                    // Chequeo de ventas para ocultarlo
                        if (Session["Ventas"] == null)
                        {
                            btMenuPagoFactura.Visible = false;
                        }

                    // Chequeo de ventas para ocultarlo si esta vacio
                    if (Session["Ventas"] != null)
                        {
                            List<Ventas> crearListadoVentas = new List<Ventas>();
                            crearListadoVentas = (List<Ventas>)Session["Ventas"];

                            if (crearListadoVentas == null || crearListadoVentas.Count == 0)
                                {
                                    btMenuPagoFactura.Visible = false;
                                }
                        }
                }                          
        }

        // Eventos "Click" en botones
        protected void btMenuDatosEmpresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("DatosEmpresa.aspx");
        }

        protected void btMenuMantenimientoClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoCliente.aspx");
        }

        protected void btMenuMantenimientoProductosEnlatados_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosEnlatados.aspx");
        }

        protected void btMenuMantenimientoProductosCongelados_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosCongelados.aspx");
        }

        protected void btMenuVentaDeProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("VentaProductos.aspx");
        }

        protected void btMenuPagoFactura_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagoFacturas.aspx");
        }

        protected void btMenuListarProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarProductos.aspx"); 
        }

        protected void btMenuCalcularTotalXproducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("CalcularTotalXproducto.aspx");
        }

        protected void btMenuCalcularTotalMensual_Click(object sender, EventArgs e)
        {    
            Response.Redirect("CalcularTotalMensual.aspx");
        }
    }
}