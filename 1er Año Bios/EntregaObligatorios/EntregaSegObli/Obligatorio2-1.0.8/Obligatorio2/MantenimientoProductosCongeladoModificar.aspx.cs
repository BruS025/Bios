using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class MantenimientoProductosCongeladoModificar1 : System.Web.UI.Page
    {
        // Evento carga de pagina
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Evento para buscar producto enlatado
        protected void btlbModificarProductoCongeladoBotonBuscar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtManConModBuscar.Text == "" || txtManConModBuscar.Text == null)
                {
                    deshabilitarElementos();
                    throw new Excepciones(numeroExcepcion = 5, campoExcepcion = "Buscar producto");
                }
                // Fin

                // Casteo de listado
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];

                // Chequeo si existe el prodcto a buscar
                bool productoExistente = false;

                foreach (var producto in listadoProductos)
                {
                    if (producto is ProductoCongelado)
                    {
                        if (producto.Código == Convert.ToInt64(txtManConModBuscar.Text) == true)
                        {
                            productoExistente = true;

                            Session["ModificarProductoCongelado"] = producto;

                            lbModConCod.Visible = true;
                            txtModConCod.Visible = true;
                            txtModConCod.Text = Convert.ToString(producto.Código);

                            lbModConNom.Visible = true;
                            txtModConNom.Visible = true;
                            txtModConNom.Text = producto.Nombre;

                            lbModModPrecio.Visible = true;
                            txtModEnPrecio.Visible = true;
                            txtModEnPrecio.Text = Convert.ToString(producto.Precio);

                            lbModConPeso.Visible = true;
                            txtModConPeso.Visible = true;
                            txtModConPeso.Text = Convert.ToString(((ProductoCongelado)producto).Peso);

                            lbModConFecha.Visible = true;
                            calModCongelado.Visible = true;
                            calModCongelado.SelectedDate = producto.Vencimiento;
                            calModCongelado.DataBind();

                            btManConModificar.Visible = true;

                        }
                    }
                }

                if (productoExistente == false)
                {
                    deshabilitarElementos();
                    lbManConResultado.ForeColor = System.Drawing.Color.Black;
                    lbManConResultado.Text = "No se han encontrado coincidencias.";
                    lbManConResultado.Visible = true;
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

        // Evento para volver al listado de productos congelados
        protected void btMantenimientoProductosCongeladosCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoProductosCongelados.aspx");
        }

        // Evento para modificar producto congelado
        protected void btManteniminetoProductosCongeladosModificar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtModConCod.Text == "" || txtModConCod.Text == null)
                {
                    deshabilitarElementos();
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Código");
                }

                if (txtModConNom.Text == "" || txtModConNom.Text == null)
                {
                    deshabilitarElementos();
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Nombre");
                }

                if (txtModEnPrecio.Text == "" || txtModEnPrecio.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Precio");
                }

                if (txtModConPeso.Text == "" || txtModConPeso.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Peso");
                }
                // Fin

                // Inicio "Chequeo [Tipo] de dato
                if (ValidacionTipoLong(txtManConModBuscar.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Código");
                }

                if (ValidacionTipoDouble(txtModEnPrecio.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Precio");
                }

                if (ValidacionTipoDouble(txtModConPeso.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Peso");
                }
                // Fin

                // Fin inicio "Chequeo [Fecha vencimiento]
                if (calModCongelado.SelectedDate < DateTime.Now)
                {
                    throw new Excepciones(numeroExcepcion = 6, campoExcepcion = "Fecha vencimiento");
                }
                // Fin inicio "Chequeo [Fecha vencimiento]

                //Inicio chequeo minimo
                if (txtModConPeso.Text == Convert.ToString(0))
                {
                    minimo = 1;
                    throw new Excepciones(numeroExcepcion = 7, campoExcepcion = "Peso");
                }
 
                if (txtModEnPrecio.Text == Convert.ToString(0))
                {
                    minimo = 1;
                    throw new Excepciones(numeroExcepcion = 7, campoExcepcion = "Precio");
                }
                //Fin chequeo minimo

                // Casteo de listado
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
                ProductoCongelado productoModificar = (ProductoCongelado)Session["ModificarProductoCongelado"];

                // Asignacion de ingresos
                productoModificar.Código = Convert.ToInt64(txtModConCod.Text);
                productoModificar.Nombre = txtModConNom.Text;
                productoModificar.Precio = Convert.ToDouble(txtModEnPrecio.Text);
                productoModificar.Peso = Convert.ToDouble(txtModConPeso);
                productoModificar.Vencimiento = Convert.ToDateTime(calModCongelado.SelectedDate);

                Session["Productos"] = productoModificar.Modificar(listadoProductos, productoModificar);

                Response.Redirect("MantenimientoProductosCongelados.aspx");
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
                lbManConResultado.Visible = true;
            }
        }

        // Metodo para ocultar elementos
        protected void deshabilitarElementos()
        {
            lbModConCod.Visible = false;
            txtModConCod.Visible = false;
            lbModConNom.Visible = false;
            txtModConNom.Visible = false;
            lbModConPeso.Visible = false;
            txtModConPeso.Visible = false;
            lbModModPrecio.Visible = false;
            txtModEnPrecio.Visible = false;
            lbModConFecha.Visible = false;
            calModCongelado.Visible = false;
            btManConModificar.Visible = false;
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