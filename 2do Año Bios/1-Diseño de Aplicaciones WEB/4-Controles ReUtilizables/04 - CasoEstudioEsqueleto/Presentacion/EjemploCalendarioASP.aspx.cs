using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PruebaCalendarioASP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnMostrar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtMostrarFecha.Text== null || txtMostrarFecha.Text== "")
            {
                txtMostrarFecha.Text = CalendarioASP1.Fecha.ToString();

                lbResultado.Text = "";
            }
            else
            {
                CalendarioASP1.Fecha = Convert.ToDateTime(txtMostrarFecha.Text);

                lbResultado.Text = "";
            }   
        }
        catch (Exception ex)
        {

            lbResultado.Text = ex.Message;
        }
    }
}