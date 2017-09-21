using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class DatosEmpresa : System.Web.UI.Page
    {
        // Evento al cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            // Carga de datos al cargar pagina si existen datos en la session de "Empresa"
             if (!IsPostBack)
            { 
            if (Session["Empresa"] != null)
            { 
            Empresa empresaOriginal = (Empresa)Session["Empresa"];

            txtDatoEmpresaRUT.Text = Convert.ToString(empresaOriginal.RutEmpresa);
            txtDatoEmpresaDireccion.Text = empresaOriginal.DireccionEmpresa;
            txtDatoEmpresaTelefono.Text = Convert.ToString(empresaOriginal.TelefonoEmpresa);
            }

            }
        }

        // Evento para volver a la pagina principal
        protected void btDatosEmpresaCancelar_Click(object sender, EventArgs e)
        {
            /*
            // Creacion de datos de prueba

               // Datos clientes
               List<Cliente> listadoClientesPrueba = new List<Cliente>();
               Cliente clientePrueba = new Cliente(12341234, "Av. Rivera 9821", 59899169713, 50);
               listadoClientesPrueba.Add(clientePrueba);
               Cliente clientePrueba2 = new Cliente(45674567, "El pinar 8596", 59891789456, 25);
               listadoClientesPrueba.Add(clientePrueba2);
               Cliente clientePrueba3 = new Cliente(11223344, "Montevideo", 59891789499,0);
               listadoClientesPrueba.Add(clientePrueba3);

               Session["Clientes"] = listadoClientesPrueba;

               // Datos productos enlatados
               List<Producto> listadoProductosPrueba = new List<Producto>();
               ProductoEnlatado productoEnlatadoAgregar1 = new ProductoEnlatado(7777888899994444, "Atun de la pepa",Convert.ToDateTime("20-5-2016"), 50,true);
               listadoProductosPrueba.Add(productoEnlatadoAgregar1);
               ProductoEnlatado productoEnlatadoAgregar2 = new ProductoEnlatado(9999888899991111, "Lomitos de atun", Convert.ToDateTime("20-5-2016"), 80, true);
               listadoProductosPrueba.Add(productoEnlatadoAgregar2);


               // Datos productos congelados
               ProductoCongelado productoCongeladoAgregar1 = new ProductoCongelado(2222333355558888,"Papas fritas", Convert.ToDateTime("18-8-2016"), 200, 3);
               listadoProductosPrueba.Add(productoCongeladoAgregar1);
               ProductoCongelado productoCongeladoAgregar2 = new ProductoCongelado(1111777755558888, "Ravioles", Convert.ToDateTime("18-8-2016"), 150, 1);
               listadoProductosPrueba.Add(productoCongeladoAgregar2);

               // Agregamos datos nuevos
               Session["Productos"] = listadoProductosPrueba;

               // Datos de prueba de ventas  (Datos cliente y productos deben coincidir)
               List<Ventas> listadoVentasPrueba = new List<Ventas>();
               Ventas ventaPrueba1 = new Ventas(123123123, 12341234, 7777888899994444, Convert.ToDateTime("19-06-2016"), Convert.ToDateTime("01-01-2000"),50,1,false);
               listadoVentasPrueba.Add(ventaPrueba1);

               // Agregamos ventas nuevas
               Session["Ventas"] = listadoVentasPrueba;

               // Fin de creacion de datos de prueba
               */

            Response.Redirect("Default.aspx");
        }

        // Evento para guardar datos
        protected void btDatosEmpresaGuardar_Click(object sender, EventArgs e)
        {
            // Informacion para excepciones
            int numeroExcepcion = 0;
            string campoExcepcion = "";
            int minimo = 0;
            try
            {
                // Inicio "Cheqeo para excepcion campos vacios", se identifican expeciones en clase "Excepciones"
                if (txtDatoEmpresaRUT.Text == "" || txtDatoEmpresaRUT.Text == null)
                    {                   
                        throw new Excepciones(numeroExcepcion = 1,campoExcepcion = "RUT");                 
                    }

                if (txtDatoEmpresaDireccion.Text == "" || txtDatoEmpresaDireccion.Text == null )
                    {
                        throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Dirección");
                    }

                if (txtDatoEmpresaTelefono.Text == "" || txtDatoEmpresaTelefono.Text == null)
                    {
                        throw new Excepciones(numeroExcepcion = 1, campoExcepcion = "Teléfono");
                    }
                // Fin

                // Inicio "Chequeo [Tipo] de dato
                if (ValidacionTipoLong(txtDatoEmpresaRUT.Text) == false)
                    {
                        throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "RUT");
                    }

                if (ValidacionTipoLong(txtDatoEmpresaTelefono.Text) == false)
                    {
                        throw new Excepciones(numeroExcepcion = 2, campoExcepcion = "Teléfono");
                    }
                // Fin

                //Inicio "Chequeo minimo valido"
                if (txtDatoEmpresaRUT.Text.Length < 12)
                    {
                        minimo = 12;
                        throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "RUT");
                    }

                if (txtDatoEmpresaDireccion.Text.Length < 5)
                {
                    minimo = 5;
                    throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "Dirección");
                }

                if (txtDatoEmpresaTelefono.Text.Length < 8)
                    {
                        minimo = 8;
                        throw new Excepciones(numeroExcepcion = 4, campoExcepcion = "Teléfono");
                    }
                //FIN

                long telefono = Convert.ToInt64(txtDatoEmpresaTelefono.Text);
                long rut = Convert.ToInt64(txtDatoEmpresaRUT.Text);
                string direccion = txtDatoEmpresaDireccion.Text;

                Empresa empresa = new Empresa(rut, direccion, telefono); // Creamos objeto empresa y guardamos en session
                Session["Empresa"] = empresa;

                Response.Redirect("Default.aspx");           
            }

            catch (Excepciones)
            {
                lbDatoEmpresaResultado.Visible = true;
                lbDatoEmpresaResultado.ForeColor = System.Drawing.Color.Red;
                lbDatoEmpresaResultado.Text = Excepciones.mensajesExc(numeroExcepcion,campoExcepcion, minimo);
            }

            catch
            {
                lbDatoEmpresaResultado.Visible = true;
                lbDatoEmpresaResultado.ForeColor = System.Drawing.Color.Red;
                lbDatoEmpresaResultado.Text = "Ha ocurrido un error.";
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