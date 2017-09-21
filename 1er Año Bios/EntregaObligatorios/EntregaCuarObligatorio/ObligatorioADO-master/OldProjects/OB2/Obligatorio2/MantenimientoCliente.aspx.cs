using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class MantenimientoClientes : System.Web.UI.Page
    {
        // Evento para cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Clientes"] == null)
                {
                    List<Cliente> crearListadoClientes = new List<Cliente>();
                    Session["Clientes"] = crearListadoClientes;
                }

                // Casteo de listado
                List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];

                // Si existen clientes registrados los muestra en la grilla
                if (listadoClientes.Count > 0)
                {
                    gridListadoClientes.Visible = true;
                    gridListadoClientes.DataSource = null;
                    gridListadoClientes.DataSource = listadoClientes;
                    gridListadoClientes.DataBind();

                    // Grid para vista mobile
                    gridListadoClientesMobile.Visible = true;
                    gridListadoClientesMobile.DataSource = null;
                    gridListadoClientesMobile.DataSource = listadoClientes;
                    gridListadoClientesMobile.DataBind();                 
                }

                else
                {            
                    lbMantenimientoClientesResultado.Text = "No existen clientes registrados.";
                }
            }

            catch (Exception ex)
            {
                lbMantenimientoClientesResultado.ForeColor = System.Drawing.Color.Red;
                lbMantenimientoClientesResultado.Text = "Ha ocurrido un error."+ ex.Message;
            }
        }

        // Evento para volver a pagina de inicio
        protected void btMantenimientoClientesVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        // Evento para ingresar a pagina "Agregar cliente"
        protected void btGestionClientesAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoClienteAgregar.aspx");
        }

        // Evento para ingresar a pagina "Eliminar cliente"
        protected void btGestionClientesEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoClienteEliminar.aspx");
        }

        // Evento para "Buscar clientes"
        protected void btGestionClientesBuscar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtClientesBuscar.Text == "" || txtClientesBuscar.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 5, campoExcepcion = "Buscar cliente");
                }

                // Casteo de listado
                List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];
                List<Cliente> listadoClientesBuscados = new List<Cliente>();

                if (listadoClientes.Count > 0)
                {
                    gridListadoClientes.DataSource = null;

                    // Grid mobile
                    gridListadoClientesMobile.DataSource = null;

                    foreach (var cliente in listadoClientes)
                        {
                            listadoClientesBuscados = cliente.BuscarExistencia(txtClientesBuscar.Text, listadoClientes);
                            lbMantenimientoClientesResultado.Visible = false;
                            gridListadoClientes.Visible = true;                                  
                            gridListadoClientes.DataSource = listadoClientesBuscados;
                            gridListadoClientes.DataBind();

                            // Grid mobile
                            gridListadoClientesMobile.Visible = true;
                            gridListadoClientesMobile.DataSource = listadoClientesBuscados;
                            gridListadoClientesMobile.DataBind();
                        }

                    if (listadoClientesBuscados.Count < 1)
                        {
                            lbMantenimientoClientesResultado.ForeColor = System.Drawing.Color.Black;
                            lbMantenimientoClientesResultado.Text = "No se han encontrado coincidencias.";
                            lbMantenimientoClientesResultado.Visible = true;
                            gridListadoClientes.Visible = false;

                            // Grid mobile
                            gridListadoClientesMobile.Visible = false;
                        }                        
                }

                else
                {
                    lbMantenimientoClientesResultado.ForeColor = System.Drawing.Color.Black;
                    lbMantenimientoClientesResultado.Text = "No existen clientes registrados.";
                }
            }

            catch (Excepciones)
            {
                lbMantenimientoClientesResultado.Visible = true;
                lbMantenimientoClientesResultado.ForeColor = System.Drawing.Color.Red;
                lbMantenimientoClientesResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch (Exception ex)
            {
                lbMantenimientoClientesResultado.ForeColor = System.Drawing.Color.Red;
                lbMantenimientoClientesResultado.Text = "Ha ocurrido un error." + ex.Message;
            }
        }

        // Evento para ingresar a pagina "Modificar cliente"
        protected void btMantenimientoClienteModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoClienteModificar.aspx");
        }
        // FIN
    }
}