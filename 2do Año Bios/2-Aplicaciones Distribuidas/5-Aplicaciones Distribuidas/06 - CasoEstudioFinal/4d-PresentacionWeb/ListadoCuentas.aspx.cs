using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServicioWCF;

public partial class ListadoCuentas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                RpCuentas.DataSource = new ServicioWCFClient().ListaMovsDeCliente((Cliente)Session["Usuario"]);
                RpCuentas.DataBind();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }

    }

    protected void RpCuentas_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Listar")
        {
            try
            {
                ServicioWCF.Cuenta _unaCuenta = new ServicioWCFClient().BuscarCuenta(Convert.ToInt32(((TextBox)(e.Item.Controls[1])).Text));
                List<ServicioWCF.Movimiento> _miLista = new ServicioWCFClient().ListarMovimientosDeCuenta(_unaCuenta).ToList();
                s.DataSource = _miLista;
                s.DataBind();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }
}