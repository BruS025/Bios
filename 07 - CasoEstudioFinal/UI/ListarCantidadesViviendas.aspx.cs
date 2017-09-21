using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;


public partial class ListarCantidadesViviendas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnListar_Click(object sender, EventArgs e)
    {
        try
        {
            int _cantAptos = 0;
            int _cantCasas = 0;

            Logica.LogicaVivienda.CantTotalviviendas(ref _cantAptos, ref _cantCasas);
            lblAptos.Text = _cantAptos.ToString();
            lblCasas.Text = _cantCasas.ToString();

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }
}