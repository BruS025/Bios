using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ListarDuenios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GVPropietarios.DataSource = Logica.LogicaDueño.Listar();
            GVPropietarios.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void GVPropietarios_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            //obtengo Duenio Seleccionado
            EntidadesCompartidas.Duenio unD = Logica.LogicaDueño.Buscar(Convert.ToInt32(GVPropietarios.SelectedRow.Cells[1].Text));

            if (unD != null)
            {
                lblDuenio.Text = unD.ToString();

                //obtengo las viviendas de dicho Dueño
                List<EntidadesCompartidas.Vivienda> _lista = Logica.LogicaVivienda.ListarPorDuenio(unD);

                GVViviendas.DataSource = _lista;
                GVViviendas.DataBind();
            }
            else
            {
                lblDuenio.Text = "";
                GVViviendas.DataSource = null;
                GVViviendas.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}