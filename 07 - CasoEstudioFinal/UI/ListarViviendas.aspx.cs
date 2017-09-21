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


public partial class ListarViviendas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
                Session["Lista"] = Logica.LogicaVivienda.ListarTodo();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }

    protected void BtnListar_Click(object sender, EventArgs e)
    {
        try
        {
            if (DdlTipo.SelectedIndex == 0)
            {
                //muestro todas las vivienda
                GvViviendas.DataSource = (List<EntidadesCompartidas.Vivienda>)Session["Lista"];
                GvViviendas.DataBind();
            }
            else if (DdlTipo.SelectedIndex == 1)
            {
                //muestro solo las casas
                List<EntidadesCompartidas.Casa> _listaC = new List<EntidadesCompartidas.Casa>();
                List<EntidadesCompartidas.Vivienda> _lista = (List<EntidadesCompartidas.Vivienda>)Session["Lista"];

                foreach (EntidadesCompartidas.Vivienda V in _lista)
                {
                    if (V is EntidadesCompartidas.Casa)
                        _listaC.Add((EntidadesCompartidas.Casa)V);
                }

                GvViviendas.DataSource = _listaC; ;
                GvViviendas.DataBind();
            }
            else
            {
                //muestro solo los aptos
                List<EntidadesCompartidas.Apartamento> _listaA = new List<EntidadesCompartidas.Apartamento>();
                List<EntidadesCompartidas.Vivienda> _lista = (List<EntidadesCompartidas.Vivienda>)Session["Lista"];

                foreach (EntidadesCompartidas.Vivienda V in _lista)
                {
                    if (V is EntidadesCompartidas.Apartamento)
                        _listaA.Add((EntidadesCompartidas.Apartamento)V);
                }

                GvViviendas.DataSource = _listaA; ;
                GvViviendas.DataBind();                
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}