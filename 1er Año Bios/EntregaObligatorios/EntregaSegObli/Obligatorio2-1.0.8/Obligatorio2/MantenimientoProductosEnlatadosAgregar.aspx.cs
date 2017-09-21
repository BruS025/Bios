using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class MantenimientoProductosEnlatadosAgregar : System.Web.UI.Page
    {
        // Evento para cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        // Evento para volver al listado de productos
        protected void btMantenimientoProductosEnlatadosCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosEnlatados.aspx");
        }

        // Evento para agregar producto enlatado
        protected void btMantenimientoProductosEnlatadosAgregar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtManEnACod.Text == "" || txtManEnACod.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Código");
                }

                if (txtManEnANom.Text == "" || txtManEnANom.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Nombre");
                }

                if (txtManEnAPrecio.Text == "" || txtManEnAPrecio.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Precio");
                }
                // Fin 

                // Inicio "Chequeo [Tipo] de datos"
                if (ValidacionTipoLong(txtManEnACod.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Código");
                }

                if (ValidacionTipoDouble(txtManEnAPrecio.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Precio");
                }
                // Fin

                // Fin inicio "Chequeo [Fecha vencimiento]
                if (calAEnlatado.SelectedDate < DateTime.Now)
                {
                    throw new Excepciones(numeroExcepcion = 6, campoExcepcion = "Fecha vencimiento");
                }
                // Fin inicio "Chequeo [Fecha vencimiento]

                //Inicio "Chequeo cantidad minima"
                if (txtManEnACod.Text.Length < 12)
                {
                    minimo = 12;
                    throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "Codigo de barras");
                }
                if (txtManEnANom.Text.Length < 3)
                {
                    minimo = 3;
                    throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "Nombre");
                }
                
                //Inicio chequeo minimo valor
                if(txtManEnAPrecio.Text == Convert.ToString(0))
                {
                    minimo = 1;
                    throw new Excepciones(numeroExcepcion = 7, campoExcepcion = "Precio");
                }

                //Fin

                // Casteo de listado
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];

                ProductoEnlatado productoAgregar = new ProductoEnlatado(Convert.ToInt64(txtManEnACod.Text), txtManEnANom.Text, Convert.ToDateTime(calAEnlatado.SelectedDate), Convert.ToDouble(txtManEnAPrecio.Text),Convert.ToBoolean(ddlManEnATipo.Text));

                if (productoAgregar.BuscarExistenciaProducto(productoAgregar.Código,listadoProductos) == false)
                {
                    Session["Productos"] = productoAgregar.Agregar(listadoProductos, productoAgregar);
                    Response.Redirect("MantenimientoProductosEnlatados.aspx");
                }

                else
                {
                    throw new Excepciones(numeroExcepcion = 3, campoExcepcion = "Código");
                }

            }

            catch (Excepciones)
            {
                lbManEnlatadosResultado.Visible = true;
                lbManEnlatadosResultado.ForeColor = System.Drawing.Color.Red;
                lbManEnlatadosResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch
            {
                lbManEnlatadosResultado.ForeColor = System.Drawing.Color.Red;
                lbManEnlatadosResultado.Text = "No ha sido posible crear nuevo producto.";
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

        // Metodo VALIDACION TIPO INT
        static bool ValidacionTipoDouble(string valor)
        {
            // Definicion de variables
            double numero = 0;
            string stringNumero = "";
            bool resultado = false;

            while (resultado == false)
            {
                stringNumero = valor;
                resultado = Double.TryParse(stringNumero, out numero); // Si el string ingresado es un numero, entonces se pasa valor a numero.

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
 