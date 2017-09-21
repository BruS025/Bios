using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class VentaDeProducto : System.Web.UI.Page
    {
        // Evento cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Ventas"] == null)
                {
                    List<Ventas> crearListadoVentas = new List<Ventas>();
                    Session["Ventas"] = crearListadoVentas;
                }

                // Casteo de listados Productos y Clientes
                List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];

                // Se crean listados para dropDownList
                List<int> listadoClientesDDL = new List<int>();
                List<long> listaProductosDDL = new List<long>();
                              
                // Listar clientes
                foreach (var cliente in listadoClientes)
                    {
                        listadoClientesDDL.Add(cliente.Cédula);
                    }

                 if (Session["ClientesListados"] == null)
                    {
                        Session["ClientesListados"] = listadoClientes;
                        ddlVentaProductosClientes.DataSource = listadoClientesDDL;
                        ddlVentaProductosClientes.DataBind();
                    }

                  // Listar productos
                  foreach (var producto in listadoProductos)
                    {
                        listaProductosDDL.Add(producto.Código);
                    }

                  if (Session["ProductosListados"] == null)
                    {
                        Session["ProductosListados"] = listadoProductos;
                        ddlVentaProductosProducto.DataSource = listaProductosDDL;
                        ddlVentaProductosProducto.DataBind();
                    }
             
                  // Desplegar datos
                  foreach (var cliente in listadoClientes)
                        {
                            if (cliente.Cédula == Convert.ToInt32(ddlVentaProductosClientes.SelectedValue))
                                {
                                    lbVentaProductosDescuentoResultado.Text = Convert.ToString(cliente.Descuento);                    
                                }
                        }

                  foreach (var producto in listadoProductos)
                        {
                            if (producto.Código == Convert.ToInt64(ddlVentaProductosProducto.SelectedValue))
                                {
                                    lbVentaProductosNombreProductoResultado.Text = producto.Nombre;
                                    lbVentaProductoPrecioResultado.Text = Convert.ToString(producto.Precio);
                                    precioTotalCantidad.Text = Convert.ToString(producto.Precio);

                                    if (producto is ProductoEnlatado)
                                    {
                                        lbVentaProductosExtra.Text = "Abrefácil: ";
                                        lbVentaProductosExtraKg.Visible = false;
                                        bool tipoProducto = ((ProductoEnlatado)producto).Abrefácil;

                                        if (tipoProducto == true)
                                            {
                                                lbVentaProductosExtraResultado.Text = "Si";
                                            }

                                        else
                                        {
                                            lbVentaProductosExtraResultado.Text = "No";
                                        }
                                    }

                                    if (producto is ProductoCongelado)
                                    {
                                        double peso = ((ProductoCongelado)producto).Peso;

                                        lbVentaProductosExtra.Text = "Peso: ";
                                        lbVentaProductosExtraResultado.Text = Convert.ToString(peso);
                                        lbVentaProductosExtraKg.Visible = true;
                                    }
                                }
                        }                          
            }

            catch
            {
                lbventaProdError.Visible = true;
                lbventaProdError.Text = "Ha ocurrido un error.";
            }
        }

        // Evento para cancelar formulario
        protected void btVentaProductosCancelar_Click(object sender, EventArgs e)
        {
            // Reseteamos sessiones para proximo ingreso
            Session["ClientesListados"] = null;
            Session["ProductosListados"] = null;

            Response.Redirect("Default.aspx");
        }

        // Evento para agendar venta
        protected void btVentaProductosAceptar_Click(object sender, EventArgs e)
        {
            try
            {          
            // Casteo de listados
            List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];
            List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
            List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];

            // Datos ticket
            int numeroVentaAuto = 0;
            int documentoCliente = Convert.ToInt32(ddlVentaProductosClientes.SelectedValue);
            long codigoProducto = Convert.ToInt64(ddlVentaProductosProducto.SelectedValue);
            DateTime fechaVenta = DateTime.Now;
            DateTime fechaPago = Convert.ToDateTime("01-01-2000");
            double totalVenta = 0;
            bool pagarAhora = false;

                // Creacion codigo de factura
                if (listadoVentas.Count == 0)
                {
                    Random rnd = new Random();
                    numeroVentaAuto = rnd.Next(1, 999999999);
                }
              
                if (listadoVentas.Count != 0)
                {
                    Random rnd = new Random();
                    numeroVentaAuto = rnd.Next(1, 999999999);
                }

                else
                {
                    foreach (var venta in listadoVentas)
                    {
                        while (venta.BuscarExistenciaNumeroVenta(numeroVentaAuto, listadoVentas) == true && numeroVentaAuto == 0)
                        {
                            Random rnd = new Random();
                            numeroVentaAuto = rnd.Next(1, 999999999);
                        }
                    }
                }

                // Asignacino de precio del producto
                foreach (var producto in listadoProductos)
                {
                    if (producto.Código == codigoProducto)
                    {
                        totalVenta = producto.Precio * Convert.ToInt32(cantidadProducto.Text);
                    }
                }

            // Agregamos venta al listado y a session de ventas.
            Ventas ventaAgregar = new Ventas(numeroVentaAuto, documentoCliente, codigoProducto, fechaVenta, fechaPago, totalVenta, Convert.ToInt32(cantidadProducto.Text), pagarAhora);
            Session["Ventas"] = ventaAgregar.Agregar(listadoVentas, ventaAgregar);

            // Reseteamos sessiones para proximo ingreso
            Session["ClientesListados"] = null;
            Session["ProductosListados"] = null;

            Response.Redirect("Default.aspx");

            } 
            catch
            {
                lbventaProdError.Visible = true;
                lbventaProdError.Text = "Ha ocurrido un error.";
            }

        }

        // Evento para actualizar LABEL "Cliente"
        protected void ddlVentaProductosClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];

            foreach (var cliente in listadoClientes)
            {
                if (cliente.Cédula == Convert.ToInt32(ddlVentaProductosClientes.SelectedValue))
                {
                    lbVentaProductosDescuentoResultado.Text = Convert.ToString(cliente.Descuento);
                }
            }
        }

        // Evento paara actualizar LABELS "Producto"
        protected void ddlVentaProductosProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Producto> listadoProductos = (List<Producto>)Session["Productos"];

            foreach (var producto in listadoProductos)
            {
                if (producto.Código == Convert.ToInt64(ddlVentaProductosProducto.SelectedValue))
                {
                    lbVentaProductosNombreProductoResultado.Text = producto.Nombre;
                    lbVentaProductoPrecioResultado.Text = Convert.ToString(producto.Precio);
                    precioTotalCantidad.Text = Convert.ToString(producto.Precio);
                    cantidadProducto.Text = "1";

                    if ( producto is ProductoEnlatado)
                {
                    lbVentaProductosExtra.Text = "Abrefácil: ";
                    lbVentaProductosExtraKg.Visible = false;
                    bool tipoProducto = ((ProductoEnlatado)producto).Abrefácil;

                    if (tipoProducto == true)
                    {
                        lbVentaProductosExtraResultado.Text = "Si";
                    }

                    else
                    {
                        lbVentaProductosExtraResultado.Text = "No";
                    }                   
                 }

                if (producto is ProductoCongelado)
                {
                    double peso = ((ProductoCongelado)producto).Peso;

                    lbVentaProductosExtra.Text = "Peso: ";
                    lbVentaProductosExtraResultado.Text = Convert.ToString(peso);
                    lbVentaProductosExtraKg.Visible = true;                    
                }
              }
            }
        }

        // Evento para realizar venta y pagar factura
        protected void btVentaProductosAceptarPagada_Click(object sender, EventArgs e)
        {
            try
            {
                // Casteo de listados
                List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
                List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];

                int numeroVentaAuto = 0;
                int documentoCliente = Convert.ToInt32(ddlVentaProductosClientes.SelectedValue);
                long codigoProducto = Convert.ToInt64(ddlVentaProductosProducto.SelectedValue);
                DateTime fechaVenta = DateTime.Now;
                DateTime fechaPago = DateTime.Now;
                double descuentoCliente = Convert.ToDouble(lbVentaProductosDescuentoResultado.Text);
                bool pagarAhora = true;
                double totalVenta = 0;

                // Creacion codigo de factura
                if (listadoVentas.Count == 0)
                {
                    Random rnd = new Random();
                    numeroVentaAuto = rnd.Next(1, 999999999);
                }

                if (listadoVentas.Count != 0)
                {
                    Random rnd = new Random();
                    numeroVentaAuto = rnd.Next(1, 999999999);
                }

                else
                {
                    foreach (var venta in listadoVentas)
                    {
                        while (venta.BuscarExistenciaNumeroVenta(numeroVentaAuto, listadoVentas) == true && numeroVentaAuto == 0)
                        {
                            Random rnd = new Random();
                            numeroVentaAuto = rnd.Next(1, 999999999);
                        }
                    }
                }

                // Asignacion de precio
                foreach (var producto in listadoProductos)
                    {
                        if (producto.Código == codigoProducto)
                        {
                            totalVenta = producto.Precio * Convert.ToInt32(cantidadProducto.Text);
                        }
                    }

                    if (descuentoCliente > 0)
                        {
                            totalVenta = (descuentoCliente * totalVenta) / 100;
                        }                       

                    Ventas ventaAgregar = new Ventas(numeroVentaAuto, documentoCliente, codigoProducto, fechaVenta, fechaPago, totalVenta, Convert.ToInt32(cantidadProducto.Text), pagarAhora);
                    Session["Ventas"] = ventaAgregar.Agregar(listadoVentas, ventaAgregar);

                // Reseteamos sessiones para proximo ingreso
                Session["ClientesListados"] = null;
                Session["ProductosListados"] = null;

                Response.Redirect("Default.aspx");
            }

            catch (Exception ex)
            {
                lbventaProdError.Visible = true;
                lbventaProdError.Text = "Ha ocurrido un error."+ ex.Message;
            }
        }

        // Evento para sumar cantidades
        protected void Sumar_Click(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(cantidadProducto.Text);
            cantidad = cantidad + 1;            
            double precio = Convert.ToDouble(lbVentaProductoPrecioResultado.Text);
            double precioTotalDesplegar = cantidad * precio;

            cantidadProducto.Text = Convert.ToString(cantidad);
            precioTotalCantidad.Text = Convert.ToString(precioTotalDesplegar);
        }

        // Evento para restar cantidades
        protected void restar_Click(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(cantidadProducto.Text);
            
            if (cantidad > 0)
            {
                cantidad = cantidad - 1;
                double precio = Convert.ToDouble(lbVentaProductoPrecioResultado.Text);
                
                // Se agrega control para que no sea posible comprar de a cantidad cero.               
                if ( cantidad < 1)
                {
                    cantidad = 1;
                }

                double precioTotalDesplegar = cantidad * precio;

                cantidadProducto.Text = Convert.ToString(cantidad);
                precioTotalCantidad.Text = Convert.ToString(precioTotalDesplegar);               
            }

            else
            {
                lbventaProdError.Text = "La cantidad mínima de ventas es uno.";
            }            
        }
    }
}