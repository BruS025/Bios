using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        // Evento al cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Evento para agregar cliente
        protected void btAgregarClienteNuevo_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
            {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtAgregarClienteDoc.Text == "" || txtAgregarClienteDoc.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Documento");
                }

                if (txtAgregarClienteDir.Text == "" || txtAgregarClienteDir.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Dirección");
                }

                if (txtAgregarClienteTel.Text == "" || txtAgregarClienteTel.Text == null)
                {
                    throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Teléfono");
                }

                // *Caso especial para "Descuento" si cliente no tiene descuento se tomara valor "0"
                if (txtAgregarClienteDesc.Text == "" || txtAgregarClienteDesc.Text == null)
                {
                    txtAgregarClienteDesc.Text = Convert.ToString(0);
                }
                // Fin 

                // Inicio "Chequeo [Tipo] de dato
                if (ValidacionTipoInt(txtAgregarClienteDoc.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Documento");
                }

                if (ValidacionTipoLong(txtAgregarClienteTel.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Teléfono");
                }

                if (ValidacionTipoLong(txtAgregarClienteDesc.Text) == false)
                {
                    throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Descuento");
                }
                // Fin

                //  Inicio "Chequeo cantidad minima "
                if (txtAgregarClienteDoc.Text.Length != 8)
                {
                    minimo = 8;
                    throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "Documento");
                }
                if (txtAgregarClienteDir.Text.Length < 5)
                {
                    minimo = 5;
                    throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "Dirección");
                }
                if (txtAgregarClienteTel.Text.Length < 8)
                {
                    minimo = 8;
                    throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "Telefono");
                }
                //Fin

                // Casteo de listado
                List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];               

                Cliente clienteAgregar = new Cliente(Convert.ToInt32(txtAgregarClienteDoc.Text), txtAgregarClienteDir.Text, Convert.ToInt64(txtAgregarClienteTel.Text), Convert.ToInt32(txtAgregarClienteDesc.Text));

                if (clienteAgregar.BuscarExistenciaDocumento(clienteAgregar.Cédula, listadoClientes) == false)
                {
                    Session["Clientes"] = clienteAgregar.Agregar(listadoClientes, clienteAgregar);
                    Response.Redirect("MantenimientoCliente.aspx");
                }
               
                else
                {
                    throw new Excepciones(numeroExcepcion = 3, campoExcepcion = "Documento");
                }               
            }

            catch (Excepciones)
            {
                lbAgregarClienteResultado.Visible = true;
                lbAgregarClienteResultado.ForeColor = System.Drawing.Color.Red;
                lbAgregarClienteResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
            }

            catch
            {
                lbAgregarClienteResultado.ForeColor = System.Drawing.Color.Red;
                lbAgregarClienteResultado.Text = "No ha sido posible crear nuevo cliente.";
            }
        }

        // Evento para volver a pagina "Listado de clientes"
        protected void btAgregarClienteCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoCliente.aspx");
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