using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListarviviendasAntiguedad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnListar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtAños.Text.Trim().Length == 0)
            {
                lblError.Text = "Debe ingresar una Cantidad de años";
            }
            else 
            {
                int CantA = Convert.ToInt32(txtAños.Text);

                if (CantA < 0)
                    lblError.Text = "No hay Antiguedad Negativa - Ingrese nuevamente";

                //muestro 
                List<EntidadesCompartidas.Vivienda> _lista = Logica.LogicaVivienda.ListarAntiguedad(CantA);

                GvViviendas.DataSource = _lista;
                GvViviendas.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}