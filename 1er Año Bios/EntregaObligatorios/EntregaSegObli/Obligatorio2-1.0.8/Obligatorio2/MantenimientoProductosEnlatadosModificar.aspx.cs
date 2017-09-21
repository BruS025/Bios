using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class MantenimientoProductosEnlatadosModificar : System.Web.UI.Page
    {
        // Evento carga de pagina
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Evento para buscar producto enlatado
        protected void btModificarEnlatadoBuscar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtModEnBuscar.Text == "" || txtModEnBuscar.Text == null)
                {
                    deshabilitarElementos();
                    throw new Excepciones(numeroExcepcion = 5, campoExcepcion = "Buscar producto");
                }
                // Fin
                //Inicio chequeo para minimo
                if (txtModEnPrecio.Text == Convert.ToString(0))
                {
                    minimo = 1;
                    throw new Excepciones(numeroExcepcion = 7, campoExcepcion = "Precio");
                }
                //Fin 

                // Casteo de listado
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];

                // Chequeo si existe el prodcto a buscar
                bool productoExistente = false;

                    foreach (var producto in listadoProductos)
                    {
                        if (producto is ProductoEnlatado)
                        {
                            if (producto.Código == Convert.ToInt64(txtModEnBuscar.Text) == true)
                            {
                                productoExistente = true;

                                Session["ModificarProductoEnlatado"] = producto;

                                lbModificarEnlatadoCodigo.Visible = true;
                                txtModEnCod.Visible = true;
                                txtModEnCod.Text = Convert.ToString(producto.Código);

                                lbModificarEnlatadoNombre.Visible = true;
                                txtModEnNom.Visible = true;
                                txtModEnNom.Text = producto.Nombre;

                                lbModificarEnlatadosPrecio.Visible = true;
                                txtModEnPrecio.Visible = true;
                                txtModEnPrecio.Text = Convert.ToString(producto.Precio);

                                lbModificarEnlatadosTipo.Visible = true;
                                ddlModEnTipo.Visible = true;
                                ddlModEnTipo.SelectedIndex = Convert.ToInt32(((ProductoEnlatado)producto).Abrefácil);                            

                                lbModificarEnlatadosVencimiento.Visible = true;
                                calModEnlatado.Visible = true;
                                calModEnlatado.SelectedDate = producto.Vencimiento;
                                calModEnlatado.DataBind();

                                btModEnModificar.Visible = true;

                            }                    
                        }
                }

                if (productoExistente == false)
                    {
                        deshabilitarElementos();
                        lbModificarEnlatadosResultado.ForeColor = System.Drawing.Color.Black;
                        lbModificarEnlatadosResultado.Text = "No se han encontrado coincidencias.";
                        lbModificarEnlatadosResultado.Visible = true;
                }
            }

            catch (Excepciones)
            {
                lbModificarEnlatadosResultado.Visible = true;
                lbModificarEnlatadosResultado.ForeColor = System.Drawing.Color.Red;
                lbModificarEnlatadosResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch
            {
                lbModificarEnlatadosResultado.ForeColor = System.Drawing.Color.Red;
                lbModificarEnlatadosResultado.Text = "Ha ocurrido un error.";
            }
        }

        // Evento para modificar producto enlatado
        protected void btMantenimientoProductosEnlatadosModificar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtModEnCod.Text == "" || txtModEnCod.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Código");
                }

                if (txtModEnNom.Text == "" || txtModEnNom.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Nombre");
                }

                if (txtModEnPrecio.Text == "" || txtModEnPrecio.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Precio");
                }
                // Fin

                // Inicio "Chequeo [Tipo] de dato
                if (ValidacionTipoLong(txtModEnBuscar.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Código");
                }

                if (ValidacionTipoDouble(txtModEnPrecio.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Precio");
                }
                // Fin

                // Fin inicio "Chequeo [Fecha vencimiento]
                if (calModEnlatado.SelectedDate < DateTime.Now)
                {
                    throw new Excepciones(numeroExcepcion = 6, campoExcepcion = "Fecha vencimiento");
                }
                // Fin inicio "Chequeo [Fecha vencimiento]

                // Casteo de listado
                List<Producto> listadoProductos = (List<Producto>)Session["Productos"];
                ProductoEnlatado productoModificar = (ProductoEnlatado)Session["ModificarProductoEnlatado"];

                // Asignacion de ingresos
                productoModificar.Código = Convert.ToInt64(txtModEnCod.Text);
                productoModificar.Nombre = txtModEnNom.Text;
                productoModificar.Precio = Convert.ToDouble(txtModEnPrecio.Text);
                productoModificar.Vencimiento = Convert.ToDateTime(calModEnlatado.SelectedDate);
                productoModificar.Abrefácil = Convert.ToBoolean(ddlModEnTipo.SelectedIndex);

                Session["Productos"] = productoModificar.Modificar(listadoProductos, productoModificar);

                Response.Redirect("MantenimientoProductosEnlatados.aspx");
            }

            catch (Excepciones)
            {
                lbModificarEnlatadosResultado.Visible = true;
                lbModificarEnlatadosResultado.ForeColor = System.Drawing.Color.Red;
                lbModificarEnlatadosResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch
            {
                lbModificarEnlatadosResultado.ForeColor = System.Drawing.Color.Red;
                lbModificarEnlatadosResultado.Text = "Ha ocurrido un error.";
                lbModificarEnlatadosResultado.Visible = true;
            }
        }

        // Evento para volver a listado de producto enlatados
        protected void btMantenimientoProductosEnlatadosCancelar_Click(object sender, EventArgs e)
        {
            Session["ProductoModificar"] = null;
            Response.Redirect("MantenimientoProductosEnlatados.aspx");
        }

        // Metodo para deshabilitar elementos
        protected void deshabilitarElementos()
        {
            lbModificarEnlatadoNombre.Visible = false;
            txtModEnNom.Visible = false;
            lbModificarEnlatadoCodigo.Visible = false;
            txtModEnCod.Visible = false;
            txtModEnPrecio.Visible = false;
            lbModificarEnlatadosPrecio.Visible = false;
            lbModificarEnlatadosTipo.Visible = false;
            ddlModEnTipo.Visible = false;
            lbModificarEnlatadosVencimiento.Visible = false;
            calModEnlatado.Visible = false;
            btModEnModificar.Visible = false;
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