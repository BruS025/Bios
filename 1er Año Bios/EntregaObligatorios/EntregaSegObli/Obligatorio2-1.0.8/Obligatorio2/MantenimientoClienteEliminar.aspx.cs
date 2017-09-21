using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class EliminarCliente : System.Web.UI.Page
    {
        // Evento de carga de pagina
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Evento para volver a pagina "Listado de clientes"
        protected void btEliminarClienteVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoCliente.aspx");
        }

        // Evento para eliminar "Cliente"
        protected void btEliminarClienteAceptar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;

            try
                {
                // Inicio "Cheqeo para excepcion campos vacios"
                if (txtEliminarClienteDocumento.Text == "" || txtEliminarClienteDocumento.Text == null)
                    {
                        throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Documento");
                    }

                // Inicio "Chequeo [Tipo] de dato
                if (ValidacionTipoInt(txtEliminarClienteDocumento.Text) == false)
                    {
                        throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Documento");
                    }
                // Fin

                // Casteo de listados
                List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];
                List<Cliente> listadoClientes = (List<Cliente>)Session["Clientes"];

                Cliente clienteEliminar = new Cliente();
                Ventas ventaEj = new Ventas(); // Solo se utiliza para invocar metodo

                List<Ventas> nuevoListadoVentas = new List<Ventas>();

                foreach (var cliente in listadoClientes)
                    {
                        if (clienteEliminar.BuscarExistenciaDocumento(Convert.ToInt32(txtEliminarClienteDocumento.Text), listadoClientes) == true)
                            {   
                                clienteEliminar.Cédula = Convert.ToInt32(txtEliminarClienteDocumento.Text);                               
                            }                       
                    }

                if (Session["Ventas"] != null)
                    {                  
                        if (listadoVentas.Count > 0)
                            { 
                                nuevoListadoVentas = ventaEj.VentasCliente(clienteEliminar.Cédula, listadoVentas);
                                if (nuevoListadoVentas.Count > 0)
                                {
                                    foreach (var venta in nuevoListadoVentas)
                                    {
                                        listadoVentas.Remove(venta);
                                    }
                                }                                       
                            }
                    }                      

                if (clienteEliminar.Cédula != Convert.ToInt32(txtEliminarClienteDocumento.Text))
                {
                    lbEliminarClienteResultado.ForeColor = System.Drawing.Color.Black;
                    lbEliminarClienteResultado.Text = "Ingrese un documento registrado.";
                }
                else
                {
                    Session["Clientes"] = clienteEliminar.Eliminar(listadoClientes, clienteEliminar);
                    Session["Ventas"] = listadoVentas;
                    Response.Redirect("MantenimientoCliente.aspx");
                }

                }

            catch (Excepciones)
                {
                    lbEliminarClienteResultado.Visible = true;
                    lbEliminarClienteResultado.ForeColor = System.Drawing.Color.Red;
                    lbEliminarClienteResultado.Text = Excepciones.mensajesExc(numeroExcepcion, campoExcepcion, minimo);
                }

            catch (Exception)
               {
                    lbEliminarClienteResultado.ForeColor = System.Drawing.Color.Red;
                    lbEliminarClienteResultado.Text = "No ha sido posible eiminar cliente.";
               }
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