using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class MantenimientoProductosAgregar : System.Web.UI.Page
    {
        // Evento para cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Evento para agregar producto congelado
        protected void btMantenimientoProductosAgregarBotonAgregar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtManCoAgCodBarras.Text == "" || txtManCoAgCodBarras.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Código");
                }

                if (txtManConANom.Text == "" || txtManConANom.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Nombre");
                }

                if (txtManConAPrecio.Text == "" || txtManConAPrecio.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Precio");
                }

                if (txtManConAPeso.Text == "" || txtManConAPeso.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Peso");
                }

                // Fin 

                // Inicio "Chequeo [Tipo] de dato
                if (ValidacionTipoLong(txtManCoAgCodBarras.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Código");
                }

                if (ValidacionTipoDouble(txtManConAPrecio.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Precio");
                }

                if (ValidacionTipoDouble(txtManConAPeso.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Peso");
                }
                // Fin

                // Fin inicio "Chequeo [Fecha vencimiento]
                if (calAgregarCongelado.SelectedDate < DateTime.Now)
                {
                    throw new Excepciones(numeroExcepcion = 6, campoExcepcion = "Fecha vencimiento");
                }
                // Fin inicio "Chequeo [Fecha vencimiento]

                //Inicio "Chequeo minimo"
                if (txtManCoAgCodBarras.Text.Length<12)
                {
                    minimo = 12;
                    throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "Codigo de barras");
                }
                if (txtManConANom.Text.Length < 3)
                {
                    minimo = 3;
                    throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "Nombre");
                }
                if (txtManConAPrecio.Text == Convert.ToString(0))
                {
                    minimo = 1;
                    throw new Excepciones(numeroExcepcion = 7, campoExcepcion = "Precio");
                }

                if (txtManConAPeso.Text == Convert.ToString(0))
                {
                    minimo = 1;
                    throw new Excepciones(numeroExcepcion = 7, campoExcepcion = "Peso");
                }
                //Fin

                // Casteo de listado
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];

                ProductoCongelado productoAgregar = new ProductoCongelado(Convert.ToInt64(txtManCoAgCodBarras.Text), txtManConANom.Text, Convert.ToDateTime(calAgregarCongelado.SelectedDate), Convert.ToDouble(txtManConAPrecio.Text), Convert.ToDouble(txtManConAPeso.Text));

                if (productoAgregar.BuscarExistenciaProducto(productoAgregar.Código, listadoProductos) == false)
                {
                    Session["Productos"] = productoAgregar.Agregar(listadoProductos, productoAgregar);
                    Response.Redirect("MantenimientoProductosCongelados.aspx");
                }

                else
                {
                    throw new Excepciones(numeroExcepcion = 3, campoExcepcion = "Código");
                }

            }

            catch (Excepciones)
            {
                lbManConAgregarResultado.Visible = true;
                lbManConAgregarResultado.ForeColor = System.Drawing.Color.Red;
                lbManConAgregarResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch
            {
                lbManConAgregarResultado.ForeColor = System.Drawing.Color.Red;
                lbManConAgregarResultado.Text = "No ha sido posible crear nuevo producto.";
            }
        }    

        // Evento para volver al listado de productos
        protected void btMantenimientoProductosCongeladosVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosCongelados.aspx");
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

        // Metodo VALIDACION TIPO DOUBLE
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