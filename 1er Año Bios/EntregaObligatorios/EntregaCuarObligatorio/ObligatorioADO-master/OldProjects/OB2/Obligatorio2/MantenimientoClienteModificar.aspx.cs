using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class ClienteModificar : System.Web.UI.Page
    {
        // Evento carga de pagina
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Evento para modificar "Cliente"
        protected void btModificarClienteAceptar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
                {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtModClienteTel.Text == "" || txtModClienteTel.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Teléfono");
                }

                if (txtModClienteDir.Text == "" || txtModClienteDir.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Dirección");
                }

                // *Caso especial para "Descuento" si cliente no tiene descuento se tomara valor "0"
                if (txtModClienteDes.Text == "" || txtModClienteDes.Text == null)
                {
                    txtModClienteDes.Text = Convert.ToString(0);
                }

                // Fin

                // Inicio "Chequeo [Tipo] de dato
                if (ValidacionTipoInt(txtModClienteDocBuscado.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Documento");
                }

                if (ValidacionTipoLong(txtModClienteTel.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Teléfono");
                }

                if (ValidacionTipoLong(txtModClienteDes.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Descuento");
                }
                // Fin

                //  Inicio "Chequeo cantidad minima "
                if (txtModClienteTel.Text.Length < 8)
                {
                    minimo = 8;
                    throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "Telefono");
                }
                if (txtModClienteDir.Text.Length < 5)
                {
                    minimo = 5;
                    throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "Dirección");
                }
                //Fin

                // Casteo de listado
                List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];
                Cliente clienteModificar = (Cliente) Session["ClienteModificar"];

                // Asignacion de ingresos
                clienteModificar.Cédula = Convert.ToInt32(txtModClienteDoc.Text);
                clienteModificar.Dirección = txtModClienteDir.Text;
                clienteModificar.Teléfono = Convert.ToInt64(txtModClienteTel.Text);
                clienteModificar.Descuento = Convert.ToInt32(txtModClienteDes.Text);                       
                       
                Session["Clientes"] = clienteModificar.Modificar(listadoClientes, clienteModificar);

                Response.Redirect("MantenimientoCliente.aspx");                                                           
                }

            catch (Excepciones)
            {
                lbModificarClienteResultado.Visible = true;
                lbModificarClienteResultado.ForeColor = System.Drawing.Color.Red;
                lbModificarClienteResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch
            {
                lbModificarClienteResultado.ForeColor = System.Drawing.Color.Red;
                lbModificarClienteResultado.Text = "Ha ocurrido un error.";
                lbModificarClienteResultado.Visible = true;
            }
        }      

        // Boton "Buscar"
        protected void btModificarClienteBuscar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtModClienteDocBuscado.Text == "" || txtModClienteDocBuscado.Text == null)
                {
                    deshabilitarElementos();
                    throw new Excepciones(numeroExcepcion = 5, campoExcepcion = "Buscar cliente");
                }
                // Fin

                // Casteo de listado
                List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];

                // Chequeo si existe el cliente a buscar
                bool clienteExistente = false;
               
                foreach (var cliente in listadoClientes)
                    {
                        if (cliente.Cédula == Convert.ToInt32(txtModClienteDocBuscado.Text) == true)
                            {
                                clienteExistente = true;

                                Session["ClienteModificar"] = cliente;

                                lbModificarClienteDocumento.Visible = true;
                                txtModClienteDoc.Visible = true;
                                txtModClienteDoc.Text = Convert.ToString(cliente.Cédula);

                                lbModificarClienteDireccion.Visible = true;
                                txtModClienteDir.Visible = true;
                                txtModClienteDir.Text = cliente.Dirección;

                                lbModificarClienteTelefono.Visible = true;
                                txtModClienteTel.Visible = true;
                                txtModClienteTel.Text = Convert.ToString(cliente.Teléfono);

                                lbModificarClienteDescuento.Visible = true;
                                txtModClienteDes.Visible = true;
                                txtModClienteDes.Text = Convert.ToString(cliente.Descuento);

                                btModificarClienteAceptar.Visible = true;
                           }
                        }
                 
                if (clienteExistente == false)                                                                  
                    {
                        deshabilitarElementos();
                        lbModificarClienteResultado.ForeColor = System.Drawing.Color.Black;
                        lbModificarClienteResultado.Text = "No se han encontrado coincidencias.";
                        lbModificarClienteResultado.Visible = true;
                    }
            }

            catch (Excepciones)
            {                
                lbModificarClienteResultado.Visible = true;
                lbModificarClienteResultado.ForeColor = System.Drawing.Color.Red;
                lbModificarClienteResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch
            {
                deshabilitarElementos();
                lbModificarClienteResultado.ForeColor = System.Drawing.Color.Red;
                lbModificarClienteResultado.Text = "Ha ocurrido un error.";
            }
        }

        // Boton "Cancelar"
        protected void btModificarClienteCancelar_Click(object sender, EventArgs e)
        {
            Session["ClienteModificar"] = null;
            Response.Redirect("MantenimientoCliente.aspx");
        }

        // Metodo para deshabilitar elementos
        protected void deshabilitarElementos()
        {
            lbModificarClienteDocumento.Visible = false;
            txtModClienteDoc.Visible = false;
            lbModificarClienteDireccion.Visible = false;
            txtModClienteDir.Visible = false;
            lbModificarClienteTelefono.Visible = false;
            txtModClienteTel.Visible = false;
            lbModificarClienteDescuento.Visible = false;
            txtModClienteDes.Visible = false;           
            btModificarClienteAceptar.Visible = false;
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