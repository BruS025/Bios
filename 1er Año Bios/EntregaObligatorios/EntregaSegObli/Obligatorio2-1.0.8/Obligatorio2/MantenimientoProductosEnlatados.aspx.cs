using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class MantenimientoProductosEnlatados : System.Web.UI.Page
    {
        // Evento carga de pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Productos"] == null)
                {
                    List<Producto> crearListadoProductos = new List<Producto>();
                    Session["Productos"] = crearListadoProductos;
                }

                // Casteo de listado
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
                List<ProductoEnlatado> listadoProductosDesplegar = new List<ProductoEnlatado>();

                // Si existen productos registrados los muestra en la grilla

                if (listadoProductos.Count > 0)                  
                {
                    foreach (var producto in listadoProductos)
                    {
                        if (producto is ProductoEnlatado)
                        {

                            listadoProductosDesplegar.Add(((ProductoEnlatado)producto));
                            gridListadoProductosEnlatados.Visible = true;
                            gridListadoProductosEnlatados.DataSource = null;
                            gridListadoProductosEnlatados.DataSource = listadoProductosDesplegar;
                            gridListadoProductosEnlatados.DataBind();

                            // Grid mobile
                            gridListadoProductosEnlatadosMobile.Visible = true;
                            gridListadoProductosEnlatadosMobile.DataSource = null;
                            gridListadoProductosEnlatadosMobile.DataSource = listadoProductosDesplegar;
                            gridListadoProductosEnlatadosMobile.DataBind();

                        }
                    }

                    if (listadoProductosDesplegar.Count < 1)
                    {
                        lbGestionEnlatadosResultado.Visible = true;
                        lbGestionEnlatadosResultado.Text = "No existen productos enlatados registrados.";
                    }
                }

                else
                {
                    lbGestionEnlatadosResultado.Visible = true;
                    lbGestionEnlatadosResultado.Text = "No existen productos registrados.";
                }                    
            }

            catch
            {
                lbGestionEnlatadosResultado.ForeColor = System.Drawing.Color.Red;
                lbGestionEnlatadosResultado.Text = "Ha ocurrido un error.";
            }
        }

        // Evento para buscar producto
        protected void btGestionEnlatadosBuscar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtManProdEnlatados.Text == "" || txtManProdEnlatados.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 5, campoExcepcion = "Buscar producto");
                }

                // Casteo de listado
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
                List<ProductoEnlatado> listadoProductosBuscados = new List<ProductoEnlatado>();

                if (listadoProductos.Count > 0)  
                    {
                        gridListadoProductosEnlatados.DataSource = null;

                        // Grid phone    
                        gridListadoProductosEnlatadosMobile.DataSource = null;

                        foreach (var producto in listadoProductos)
                            {
                                listadoProductosBuscados = producto.BuscarEnlatado(txtManProdEnlatados.Text, listadoProductos);
                                lbGestionEnlatadosResultado.Visible = false;
                                gridListadoProductosEnlatados.Visible = true;
                                gridListadoProductosEnlatados.DataSource = listadoProductosBuscados;
                                gridListadoProductosEnlatados.DataBind();

                                // Grid phone
                                gridListadoProductosEnlatadosMobile.Visible = true;
                                gridListadoProductosEnlatadosMobile.DataSource = listadoProductosBuscados;
                                gridListadoProductosEnlatadosMobile.DataBind();
                            }                                  
                    }

                if (listadoProductosBuscados.Count < 1)
                    {
                        lbGestionEnlatadosResultado.ForeColor = System.Drawing.Color.Black;
                        lbGestionEnlatadosResultado.Text = "No se han encontrado coincidencias.";
                        lbGestionEnlatadosResultado.Visible = true;
                        gridListadoProductosEnlatados.Visible = false;

                        // Grid phone
                        gridListadoProductosEnlatadosMobile.Visible = false;
                    }                 
                else
                    {
                        lbGestionEnlatadosResultado.Text = "No existen productos registrados.";
                    }
            }

            catch (Excepciones)
            {
                lbGestionEnlatadosResultado.Visible = true;
                lbGestionEnlatadosResultado.ForeColor = System.Drawing.Color.Red;
                lbGestionEnlatadosResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch
            {
                lbGestionEnlatadosResultado.ForeColor = System.Drawing.Color.Red;
                lbGestionEnlatadosResultado.Text = "Ha ocurrido un error.";
            }
        }

        // Evento para volver al menu
        protected void btMantenimientosProductosEnlatadosVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        // Evento para agregar producto
        protected void btGestionEnlatadosAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosEnlatadosAgregar.aspx");
        }

        // Evento para modificar producto
        protected void btMantenimientoProductosEnlatadosModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosEnlatadosModificar.aspx");
        }

        // Evento para eliminar producto
        protected void btMantenimientoEnlatadosEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosEnlatadosEliminar.aspx");
        }
    }
}