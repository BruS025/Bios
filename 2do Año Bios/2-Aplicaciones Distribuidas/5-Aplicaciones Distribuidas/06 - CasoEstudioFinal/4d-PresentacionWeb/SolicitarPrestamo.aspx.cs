using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Messaging;
using System.Configuration;




public partial class SolicitarPrestamo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

  
    protected void BtnRefresh_Click(object sender, EventArgs e)
    {
        //limpio la pantalla
        TxtMonto.Text = "";
        LblError.Text = "";

    }


    protected void BtnSolicitar_Click(object sender, EventArgs e)
    {
        try
        {
            //obtengo el cliente logueado
            ServicioWCF.Cliente _unCliente = (ServicioWCF.Cliente)Session["Usuario"];

            //creo objeto prestamo 
            ServicioWCF.Prestamo _unPrestamo = new ServicioWCF.Prestamo();
            _unPrestamo.UnCliente= _unCliente;
            _unPrestamo.Fecha = DateTime.Now;
            _unPrestamo.Monto = Convert.ToDouble(TxtMonto.Text);
            _unPrestamo.Aprobado = false;

 
            //lo solicito
            new ServicioWCF.ServicioWCFClient().AltaPrestamo(_unPrestamo);
            //si llego aca - no hubo errores
            LblError.Text = "Prestamos Solicitado Correctamente";
            TxtMonto.Text = "";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }

    }


    protected void BtnConsultar_Click(object sender, EventArgs e)
    {
        try
        {

            //obtengo el cliente logueado
            ServicioWCF.Cliente _unCliente = (ServicioWCF.Cliente)Session["Usuario"];
            //realizo listado
            GVPrestamos.DataSource = new ServicioWCF.ServicioWCFClient().ListoPrestamosCliente(_unCliente);
            GVPrestamos.DataBind();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

}