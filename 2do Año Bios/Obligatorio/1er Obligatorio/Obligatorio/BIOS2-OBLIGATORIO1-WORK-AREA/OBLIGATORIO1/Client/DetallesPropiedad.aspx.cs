using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Consulta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            try
            {
                CalVisita.SelectedDate = DateTime.Now;
                CargarControl();

            }

            catch (Exception ex)
            {

                lbResultado.Text = "ERROR: " + ex.Message;
            }
        }
    }

    protected void CargarControl()
    {
        try
        {
            Propiedad propiedad = (Propiedad)Session["Ver"];

            ILogicaZona LZona = FabricaLogica.getLogicaZona();
            Zona zona = LZona.BuscarT(propiedad.Zona.Nombre, propiedad.Zona.Departamento);

            propiedad.Zona = zona;

            VerPropiedad.setPropiedad(propiedad);
        }

        catch (Exception ex)
        {

            lbResultado.Text = "ERROR: " + ex.Message;
        }
    }

    // VISITAR
    protected void btVisitar_Click(object sender, EventArgs e)
    {
        try
        {
            CargarControl();

            if(txtNombre.Text == "" || txtTelefono.Text == "")
            {
                throw new Exception("Debe ingresar nombre y telefono..");

            }

            DateTime fechaAgenda = DateTime.Parse(Convert.ToString(CalVisita.SelectedDate.Year) + "-" + Convert.ToString(CalVisita.SelectedDate.Month) + "-" + Convert.ToString(CalVisita.SelectedDate.Day) + " " + ddlHora.SelectedValue + ":" + ddlMinuto.SelectedValue + ":" + "00");

            Visita visita = new Visita(fechaAgenda, Convert.ToInt32(txtTelefono.Text), txtNombre.Text,(Propiedad)Session["Ver"]);

            ILogicaVisita LVisita = FabricaLogica.getLogicaVisita();
            LVisita.Agregar(visita);

            lbResultado.Text = "Se ha creado visita satisfactoriamente";

        }
        catch (Exception ex)
        {

            lbResultado.Text = "ERROR:" + ex.Message; 

        }
    }

    // ATRAS
    protected void btAtras_Click(object sender, EventArgs e)
    {
        try
        {
            CargarControl();
            Response.Redirect("Default.aspx");
        }

        catch (Exception ex)
        {

            lbResultado.Text = "ERROR:" + ex.Message;

        }
    }

    // SE CAMBIA UNA FECHA
    protected void CalVisita_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            CargarControl();

        }

        catch (Exception ex)
        {

            lbResultado.Text = "ERROR:" + ex.Message;

        }

    }

    // CAMBIA MES
    protected void CalVisita_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        try
        {
            CargarControl();

        }

        catch (Exception ex)
        {

            lbResultado.Text = "ERROR:" + ex.Message;

        }

    }
}