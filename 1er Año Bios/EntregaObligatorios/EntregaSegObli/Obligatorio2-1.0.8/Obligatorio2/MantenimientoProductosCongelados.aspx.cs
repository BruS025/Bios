using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class MantenimientoProductosCongelados : System.Web.UI.Page
    {
        // Evento carga inicial
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
                List<ProductoCongelado> listadoProductosDesplegar = new List<ProductoCongelado>();

                // Si existen productos registrados los muestra en la grilla

                if (listadoProductos.Count > 0)
                {
                    foreach (var producto in listadoProductos)
                    {
                        if (producto is ProductoCongelado)
                        {
                            listadoProductosDesplegar.Add(((ProductoCongelado)producto));
                            gridProdCongelados.Visible = true;
                            gridProdCongelados.DataSource = null;
                            gridProdCongelados.DataSource = listadoProductosDesplegar;
                            gridProdCongelados.DataBind();

                            // Grid phone
                            gridProdCongeladosPhone.Visible = true;
                            gridProdCongeladosPhone.DataSource = null;
                            gridProdCongeladosPhone.DataSource = listadoProductosDesplegar;
                            gridProdCongeladosPhone.DataBind();
                        }
                    }

                if (listadoProductosDesplegar.Count < 1)
                    {
                        lbManConResultado.Visible = true;
                        lbManConResultado.Text = "No existen productos congelados registrados.";
                    }
                }

                else
                {
                    lbManConResultado.Visible = true;
                    lbManConResultado.Text = "No existen productos registrados.";
                }
            }

            catch
            {
                lbManConResultado.ForeColor = System.Drawing.Color.Red;
                lbManConResultado.Text = "Ha ocurrido un error.";
            }
        }

        // Evento para buscar producto
        protected void btGestionMantProdCongBuscar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtManProdCongelados.Text == "" || txtManProdCongelados.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 5, campoExcepcion = "Buscar producto");
                }

                // Casteo de listado
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
                List<ProductoCongelado> listadoProductosBuscados = new List<ProductoCongelado>();

                if (listadoProductos.Count > 0)
                {
                    gridProdCongelados.DataSource = null;

                    // Grid phone
                    gridProdCongeladosPhone.DataSource = null;

                    foreach (var producto in listadoProductos)
                    {
                        if (producto is ProductoEnlatado)
                        {
                            listadoProductosBuscados = producto.BuscarCongelado(txtManProdCongelados.Text, listadoProductos);
                            lbManConResultado.Visible = false;
                            gridProdCongelados.Visible = true;
                            gridProdCongelados.DataSource = listadoProductosBuscados;
                            gridProdCongelados.DataBind();

                            // Grid phone
                            gridProdCongeladosPhone.Visible = true;
                            gridProdCongeladosPhone.DataSource = listadoProductosBuscados;
                            gridProdCongeladosPhone.DataBind();
                        }
                    }

                    if (listadoProductosBuscados.Count < 1)
                    {
                        lbManConResultado.ForeColor = System.Drawing.Color.Black;
                        lbManConResultado.Text = "No se han encontrado coincidencias.";
                        lbManConResultado.Visible = true;
                        gridProdCongelados.Visible = false;

                        // Grid phone
                        gridProdCongeladosPhone.Visible = false;
                    }
                }

                else
                {
                    lbManConResultado.Text = "No existen productos registrados.";
                }
            }

            catch (Excepciones)
            {
                lbManConResultado.Visible = true;
                lbManConResultado.ForeColor = System.Drawing.Color.Red;
                lbManConResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch
            {
                lbManConResultado.ForeColor = System.Drawing.Color.Red;
                lbManConResultado.Text = "Ha ocurrido un error.";
            }
        }

        // Evento para volver a pagina de inicio
        protected void btManteniminetoProductosCongeladosVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        // Evento para agregar producto congelado
        protected void btGestionMantProdCongAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosCongeladosAgregar.aspx");
        }

        // Evento para modificar producto congelado
        protected void btMantenimientoProductosCongeladosMoificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosCongeladoModificar.aspx");
        }

        // Evento para eliminar producto congelado
        protected void btManConEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosCongeladoEliminar.aspx");
        }
    }
}