using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2.Clases;

namespace Obligatorio2
{
    public partial class CalcularTotalMensual : System.Web.UI.Page
    {
        // Evento para cargar pagina
        protected void Page_Load(object sender, EventArgs e)
            {
                try
                {
                    if (Session["Ventas"] == null) // Chequeo existencia de ventas
                        {
                            ocultarElementos();
                            lbGananciaMensualError.Visible = true;
                            lbGananciaMensualError.Text = "No se encuentran ventas registradas.";
                        }

                    else
                        {
                            List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];

                            if (listadoVentas.Count < 1) // Chequeo existencia de ventas
                    {
                                ocultarElementos();
                                lbGananciaMensualError.Visible = true;
                                lbGananciaMensualError.Text = "No se encuentran ventas registradas.";

                            }
                        }           
                }

                catch
                    {
                        ocultarElementos();
                        lbGananciaMensualError.Visible = true;
                        lbGananciaMensualError.Text = "Ha ocurrido un error.";
                    }
            }

        // Evento para volver al menu
        protected void btCalculoMensualVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        // Evento para desplegar informe "MES"
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
            // Listado de ventas y productos
            List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];

            // Tomamos fecha de los dropDownList
            int mes = Convert.ToInt32(ddlMes.SelectedValue);
            int anio = Convert.ToInt32(ddlAnio.SelectedValue);
            DateTime mesCalcular = Convert.ToDateTime("01/" + mes +"/"+anio);
            int cantidadVentas = 0;
            double valorVentas = 0;         

            foreach (var ventas in listadoVentas) // Chequea las ventas para fecha seleccionado y incrementa contadores
                {
                    if (ventas.FechaVenta.Month == mes && ventas.FechaVenta.Year == anio)
                    {
                        cantidadVentas = cantidadVentas + ventas.CantidadProducto;
                        valorVentas = valorVentas + ventas.TotalVenta;
                    }
                }
            lbTotalMensualCantidad.Text = Convert.ToString(cantidadVentas);
            lbTotalMensualMonto.Text = Convert.ToString(valorVentas);
            mostrarElementos();
        }

            catch
                {

                }
      }

        // Evento para desplegar informe "AÑO"
        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Listado de ventas y productos
                List<Ventas> listadoVentas = (List<Ventas>)Session["Ventas"];

                // Tomamos fecha de los dropDownList

                int mes = Convert.ToInt32(ddlMes.SelectedValue);
                int anio = Convert.ToInt32(ddlAnio.SelectedValue);
                DateTime mesCalcular = Convert.ToDateTime("01/" + mes + "/" + anio);
                int cantidadVentas = 0;
                double valorVentas = 0;

                foreach (var ventas in listadoVentas)
                {
                    if (ventas.FechaVenta.Month == mes && ventas.FechaVenta.Year == anio)
                    {
                        cantidadVentas = cantidadVentas + ventas.CantidadProducto;
                        valorVentas = valorVentas + ventas.TotalVenta;
                    }
                }
                lbTotalMensualCantidad.Text = Convert.ToString(cantidadVentas);
                lbTotalMensualMonto.Text = Convert.ToString(valorVentas);
                mostrarElementos();
            }

            catch
            {

            }
        }

        // Evento para ocultar elementos
        protected void ocultarElementos()
        {
            lbTotalFechaSeleccionar.Visible = false;
            ddlMes.Visible = false;
            ddlAnio.Visible = false;
            lbTotalMensualResultado.Visible = false;
            lbTotalMensualCantidad.Visible = false;
            lbTotalMensualResultado2.Visible = false;
            lbCalculatTotalGenerado.Visible = false;
            lbTotalMensualMonto.Visible = false;
        }

        // Evento para mostrar elementos
        protected void mostrarElementos()
        {
            // Volvemos a mostrar campos
            lbTotalMensualResultado.Visible = true;
            lbTotalMensualCantidad.Visible = true;
            lbTotalMensualResultado2.Visible = true;
            lbCalculatTotalGenerado.Visible = true;
            lbTotalMensualMonto.Visible = true;
        }
    }
}