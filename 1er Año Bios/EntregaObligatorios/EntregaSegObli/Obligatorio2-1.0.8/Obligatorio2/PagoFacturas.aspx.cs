using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class PagoFacturas : System.Web.UI.Page
    {
        // Evento para cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["Ventas"] == null)
                    {
                        List<Ventas> crearListadoVentas = new List<Ventas>();
                        Session["Ventas"] = crearListadoVentas;
                    }

                // Casteo de listado
                List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];

                List<Ventas> listadoVentasPendientes = new List<Ventas>();
                List<Ventas> listadoVentasFinalizadas = new List<Ventas>();

                // Si existen clientes registrados los muestra en la grilla
                if (listadoVentas.Count > 0)
                {
                    if (Convert.ToInt32(ddlTipoFactura.SelectedValue) == 0)
                        {
                            foreach (var venta in listadoVentas)
                                {
                                    if (venta.Pago == false)
                                        {
                                            listadoVentasPendientes.Add(venta);

                                            gridFacturaAgendadas.Visible = true;
                                            gridFacturaPagas.Visible = false;

                                            // Grid Desktop
                                            gridFacturaAgendadas.DataSource = listadoVentasPendientes;
                                            gridFacturaAgendadas.DataBind();

                                            // Grids Tablet
                                            gridTablet.DataSource = listadoVentasPendientes;
                                            gridTablet.DataBind();

                                            // Grids mobile
                                            gridPhone.DataSource = listadoVentasPendientes;
                                            gridPhone.DataBind();

                                            lbFacturaResultado.Visible = false;
                                        }
                                }

                            if (listadoVentasPendientes.Count == 0)
                                {
                                    foreach (var venta in listadoVentas)
                                        {
                                            if (venta.Pago == true)
                                                {
                                                    listadoVentasFinalizadas.Add(venta);
                                                    gridFacturaAgendadas.Visible = false;
                                                    gridFacturaPagas.Visible = true;
                                                    ddlTipoFactura.SelectedIndex = 1;

                                                    // Grid Desktop
                                                    gridFacturaPagas.DataSource = listadoVentasFinalizadas;
                                                    gridFacturaPagas.DataBind();

                                                    // Grids Tablet
                                                    gridTablet.DataSource = listadoVentasFinalizadas;
                                                    gridTablet.DataBind();

                                                    // Grids mobile
                                                    gridPhone.DataSource = listadoVentasFinalizadas;
                                                    gridPhone.DataBind();

                                                    lbFacturaResultado.Visible = false;
                                                }
                                        }
                                }
                            }   
                }

                else
                    {
                        lbFacturaResultado.Visible = true;
                        lbFacturaResultado.ForeColor = System.Drawing.Color.Black;
                        lbFacturaResultado.Text = "No existen facturas registradas.";
                    }            
        }
            }

            catch
            {
                lbFacturaResultado.Visible = true;
                lbFacturaResultado.ForeColor = System.Drawing.Color.Red;
                lbFacturaResultado.Text = "Ha ocurrido un error.";
            }
        }

        // Evento para volver al menu principal
        protected void btFacturaVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        // Evento para buscar factura pendiente
        protected void btFacturaBuscar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Casteo de listado
                List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];
                List<Ventas> listadoVentaBuscada = new List<Ventas>();
                List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];
                bool resultado = false;

                Session["VentaBuscada"] = null;

                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtFacturaBusqueda.Text == "" || txtFacturaBusqueda.Text == null)
                {

                    throw new Excepciones(numeroExcepcion = 5, campoExcepcion = "Búsqueda");
                }
                // Fin

                // Inicio "Chequeo [Tipo] de dato
                if (ValidacionTipoInt(txtFacturaBusqueda.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Búsqueda");
                }
                // Fin

                string ventaBuscada = txtFacturaBusqueda.Text;

                if (listadoVentas.Count != 0)
                {
                    // Grids desktop
                    gridFacturaAgendadas.Visible = true;
                    gridFacturaPagas.Visible = false;

                    // Grid tablet
                    gridTablet.Visible = true;

                    // Grid phone
                    gridPhone.Visible = true;

                    //Reseteo de grids
                    gridFacturaPagas.DataSource = null;
                    gridFacturaAgendadas.DataSource = null;
                    gridTablet.DataSource = null;
                    gridPhone.DataSource = null;

                    if (ventaBuscada.Length > 0 && ventaBuscada != null)
                    {
                        foreach (var venta in listadoVentas)
                        {
                            if (venta.NumeroVenta == Convert.ToInt64(ventaBuscada) && venta.Pago == false)
                            {
                                    listadoVentaBuscada.Add(venta);
                                    Session["VentaBuscada"] = listadoVentaBuscada;

                                    lbFacturaResultado.Visible = false;
                                    btFacturaPagar.Visible = true;

                                    // Grid pendientes                                   
                                    gridFacturaAgendadas.DataSource = listadoVentaBuscada;
                                    gridFacturaAgendadas.DataBind();

                                    // Grid tablet                                  
                                    gridTablet.DataSource = listadoVentaBuscada;
                                    gridTablet.DataBind();

                                    // Grid phone                                  
                                    gridPhone.DataSource = listadoVentaBuscada;
                                    gridPhone.DataBind();

                                if (DateTime.Now.AddDays(-30) <=  venta.FechaVenta)
                                    {
                                       foreach ( var cliente in listadoClientes)
                                        {
                                            if (cliente.Cédula == venta.DocumentoCliente)
                                            {
                                                resultado = true;
                                                double valorVenta = venta.TotalVenta; 
                                             
                                                if (cliente.Descuento > 0)
                                                {
                                                    valorVenta = Convert.ToDouble(venta.TotalVenta - ((venta.TotalVenta * cliente.Descuento) / 100));
                                                }
                                                
                                                lbFacturaResultado.Visible = true;
                                                lbFacturaResultado.ForeColor = System.Drawing.Color.Black;
                                                lbFacturaResultado.Text = "Se pagara un total de $" + valorVenta + " , con un " + Convert.ToString(cliente.Descuento) + "% de descuento." ;
                                            }
                                        } 
                                    }
                                else
                                {
                                    foreach (var cliente in listadoClientes)
                                    {
                                        if (cliente.Cédula == venta.DocumentoCliente)
                                        {
                                            resultado = true;
                                            lbFacturaResultado.ForeColor = System.Drawing.Color.Black;
                                            lbFacturaResultado.Visible = true;
                                            lbFacturaResultado.Text = "Se pagara un total de $" + venta.TotalVenta + ".";
                                        }
                                    }
                                }
                            }
                        }
                        if (resultado == false)
                        {
                            gridFacturaPagas.Visible = false;
                            gridFacturaAgendadas.Visible = false;
                            gridPhone.Visible = false;
                            gridTablet.Visible = false;
                            lbFacturaResultado.Visible = true;
                            lbFacturaResultado.ForeColor = System.Drawing.Color.Black;
                            lbFacturaResultado.Text = "No se ha encontrado factura pendiente.";
                        }
                    }
                    else
                    {
                        lbFacturaResultado.ForeColor = System.Drawing.Color.Black;
                        lbFacturaResultado.Text = "Debe ingresar un número de factura válido.";
                        lbFacturaResultado.Visible = true;
                        gridFacturaAgendadas.Visible = false;
                        gridFacturaPagas.Visible = false;
                        gridPhone.Visible = false;
                        gridTablet.Visible = false;
                        btFacturaPagar.Visible = false;
                    }
                }

                else
                {
                    lbFacturaResultado.ForeColor = System.Drawing.Color.Black;
                    lbFacturaResultado.Text = "No existen facturas registradas.";
                    lbFacturaResultado.Visible = true;
                    gridFacturaAgendadas.Visible = false;
                    gridFacturaPagas.Visible = false;
                    gridPhone.Visible = false;
                    gridTablet.Visible = false;
                    btFacturaPagar.Visible = false;
                }
            }

            catch (Excepciones)
            {
                lbFacturaResultado.Visible = true;
                lbFacturaResultado.ForeColor = System.Drawing.Color.Red;
                lbFacturaResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch
            {
                lbFacturaResultado.ForeColor = System.Drawing.Color.Red;
                lbFacturaResultado.Text = "Ha ocurrido un error.";
                lbFacturaResultado.Visible = true;
                gridFacturaAgendadas.Visible = false;
                gridFacturaPagas.Visible = false;
                gridPhone.Visible = false;
                gridTablet.Visible = false;
                btFacturaPagar.Visible = false;
            }
        }

        // Evento para pagar factura pendiente
        protected void btFacturaPagar_Click(object sender, EventArgs e)
        {
            try
            {
                // Casteo de listados
                List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];
                List<Ventas> facturaPagar = (List<Ventas>)Session["VentaBuscada"];
                List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];

                gridFacturaPagas.Visible = false;
                gridFacturaAgendadas.Visible = true;
                gridPhone.Visible = true;
                gridTablet.Visible = true;

                foreach (var venta in listadoVentas)
                        {
                            if (venta.NumeroVenta == facturaPagar[0].NumeroVenta)
                                {
                                    if (DateTime.Now.AddDays(-30) <= venta.FechaVenta)
                                        { 
                                         foreach (var cliente in listadoClientes)
                                          {
                                           if (cliente.Cédula == venta.DocumentoCliente)
                                            {
                                              if (venta.Pago == false)
                                                {
                                                if (cliente.Descuento < 1)
                                                    {                                                         
                                                        venta.FechaPago = DateTime.Now;
                                                        venta.Pago = true;
                                                        Session["Ventas"] = listadoVentas;
                                                    }
                                                else
                                                    {
                                                        venta.TotalVenta = (cliente.Descuento * venta.TotalVenta) / 100;
                                                        venta.FechaPago = DateTime.Now;
                                                        venta.Pago = true;
                                                        Session["Ventas"] = listadoVentas;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                        {
                                            venta.FechaPago = DateTime.Now;
                                            venta.Pago = true;
                                            Session["Ventas"] = listadoVentas;
                                        }
                                }

                            gridFacturaAgendadas.DataSource = null;
                            gridFacturaPagas.DataSource = null;
                            gridFacturaPagas.DataSource = listadoVentas;
                            gridFacturaPagas.DataBind();
                            lbFacturaResultado.Visible = false;

                            ddlTipoFactura.SelectedIndex = 1;

                            // Grid desktop
                            gridFacturaPagas.Visible = true;
                            gridFacturaAgendadas.Visible = false;

                            // Grid phone
                            gridPhone.DataSource = null;
                            gridPhone.DataSource = listadoVentas;
                            gridPhone.DataBind();
                            // Grid tablet
                            gridTablet.DataSource = null;
                            gridTablet.DataSource = listadoVentas;
                            gridTablet.DataBind();

                          }

                    Session["VentaBuscada"] = null;
                    btFacturaPagar.Visible = false;               
            }
            catch
            {
                lbFacturaResultado.ForeColor = System.Drawing.Color.Red;
                lbFacturaResultado.Text = "Ha ocurrido un error.";
                gridFacturaAgendadas.Visible = false;
                gridFacturaPagas.Visible = false;
                gridTablet.Visible = false;
                gridPhone.Visible = false;
                btFacturaPagar.Visible = false;
            }
        }

        // Evento para modificar listado a desplegar
        protected void ddlTipoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Casteo de listado
            List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];

            // Creo listados de ventas pendientes y finalizadas
            List<Ventas> listadoVentasPendientes = new List<Ventas>();
            List<Ventas> listadoVentasFinalizadas = new List<Ventas>();

            bool existenProductos = false;

            // Si existen clientes registrados los muestra en la grilla
            if (listadoVentas.Count > 0)
                {
                    if (Convert.ToInt32(ddlTipoFactura.SelectedValue) == 0)
                    {
                        foreach (var venta in listadoVentas)
                        {
                            if (venta.Pago == false)
                            {
                                listadoVentasPendientes.Add(venta);
                                existenProductos = true;
                                gridFacturaAgendadas.Visible = true;
                                gridFacturaPagas.Visible = false;

                                // Grid Desktop
                                gridFacturaAgendadas.DataSource = listadoVentasPendientes;
                                gridFacturaAgendadas.DataBind();

                                // Grids Tablet
                                gridTablet.DataSource = listadoVentasPendientes;
                                gridTablet.DataBind();

                                // Grids mobile
                                gridPhone.DataSource = listadoVentasPendientes;
                                gridPhone.DataBind();

                                lbFacturaResultado.Visible = false;
                            }
                        }
                    }

                    else if (Convert.ToInt32(ddlTipoFactura.SelectedValue) == 1)
                        {
                            foreach (var venta in listadoVentas)
                            {
                                if (venta.Pago == true)
                                {
                                    listadoVentasFinalizadas.Add(venta);
                                    existenProductos = true;
                                    gridFacturaAgendadas.Visible = false;
                                    gridFacturaPagas.Visible = true;

                                    // Grid Desktop
                                    gridFacturaPagas.DataSource = listadoVentasFinalizadas;
                                    gridFacturaPagas.DataBind();

                                    // Grids Tablet
                                    gridTablet.DataSource = listadoVentasFinalizadas;
                                    gridTablet.DataBind();

                                    // Grids mobile
                                    gridPhone.DataSource = listadoVentasFinalizadas;
                                    gridPhone.DataBind();

                                    lbFacturaResultado.Visible = false;
                                }
                            }
                        }
                    }

            // Verificacion para mostrar/ocultar grid
            if (existenProductos == true)
            {
                lbFacturaResultado.Visible = false;
            }

            else
            {
                gridFacturaPagas.Visible = false;
                gridFacturaAgendadas.Visible = false;
                gridPhone.Visible = false;
                gridTablet.Visible = false;
                lbFacturaResultado.Visible = true;
                lbFacturaResultado.ForeColor = System.Drawing.Color.Black;
                lbFacturaResultado.Text = "No existen facturas de este tipo registradas.";
            }
        }

        // Metodo VALIDACION TIPO INT
        static bool ValidacionTipoInt(string valor)
        {
            // Definicion de variables
            int numero = 0;
            string stringNumero = "";
            bool resultado = false;

            while (resultado == false)
            {
                stringNumero = valor;
                resultado = Int32.TryParse(stringNumero, out numero); // Si el string ingresado es un numero, entonces se pasa valor a numero.

                if (resultado == false)
                {
                    return false;
                }
            }
            return true;
        }
        // FIN       
    }
} 