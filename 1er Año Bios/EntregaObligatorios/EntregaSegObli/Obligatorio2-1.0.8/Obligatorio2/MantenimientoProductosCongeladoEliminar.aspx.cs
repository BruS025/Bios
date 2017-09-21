using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class MantenimientoProductosCongeladoEliminar : System.Web.UI.Page
    {
        // Evento "Carga de pagina"
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Evento para ir a listado de productos congelados
        protected void btProductoCongeladoCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosCongelados.aspx");
        }

        protected void btProductoCongeladoAceptar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtManCongeladoEliminar.Text == "" || txtManCongeladoEliminar.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Código");
                }
                // Fin

                // Inicio "Chequeo [Tipo] de dato
                if (ValidacionTipoLong(txtManCongeladoEliminar.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Código");
                }
                // Fin

                // Casteo de listado
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
                List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];

                Producto productoEliminar = new Producto();
                Ventas ventaEj = new Ventas(); // Solo se utiliza para invocar metodo

                List<Ventas> nuevoListadoVentas = new List<Ventas>();

                foreach (var producto in listadoProductos)
                    {
                        if (productoEliminar.BuscarExistenciaProducto(Convert.ToInt64(txtManCongeladoEliminar.Text), listadoProductos) == true)
                            {
                                productoEliminar.Código = Convert.ToInt64(txtManCongeladoEliminar.Text);
                            }

                    if (Session["Ventas"] != null)
                    {
                        if (listadoVentas.Count > 0)
                        {
                            nuevoListadoVentas = ventaEj.VentasProducto(productoEliminar.Código, listadoVentas);
                            if (nuevoListadoVentas.Count > 0)
                            {
                                foreach (var venta in nuevoListadoVentas)
                                {
                                    listadoVentas.Remove(venta);
                                }
                            }
                        }
                    }
                    if (productoEliminar.Código != Convert.ToInt64(txtManCongeladoEliminar.Text))
                    {
                        lbManConEliminarResultado.ForeColor = System.Drawing.Color.Black;
                        lbManConEliminarResultado.Text = "Ingrese un producto registrado.";
                    }
                    else
                    {
                        Session["Productos"] = productoEliminar.Eliminar(listadoProductos, productoEliminar);
                        Session["Ventas"] = listadoVentas;
                        Response.Redirect("MantenimientoProductosCongelados.aspx");
                    }
                }
            }

            catch (Excepciones)
            {
                lbManConEliminarResultado.Visible = true;
                lbManConEliminarResultado.ForeColor = System.Drawing.Color.Red;
                lbManConEliminarResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch
            {
                lbManConEliminarResultado.ForeColor = System.Drawing.Color.Red;
                lbManConEliminarResultado.Text = "No ha sido posible eiminar producto.";
            }
        }

        // Metodo VALIDACION TIPO LONG
        static bool ValidacionTipoLong(string valor)
        {
            // Definicion de variables
            long numero = 0;
            string stringNumero = "";
            bool resultado = false;

            while (resultado == false)
            {
                stringNumero = valor;
                resultado = Int64.TryParse(stringNumero, out numero); // Si el string ingresado es un numero, entonces se pasa valor a numero.

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