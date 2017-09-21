using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _05_ControlRepeater : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                rtArticulos.DataSource = Persistencia.ListarFam();
                rtArticulos.DataBind();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }



    protected void rtArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //como argumento del evento nos viene el nombre del boton que proboco el evento(solamente el comando asociado)
        //tambien viene la propiedad item que reprecenta la linea completa del repeater donde esta almacenado el boton que provoco el evento
        //no tenemos forma de selected item index ni nada solo sabemos item por medio del argumento
        //como reprecenta una linea del repeater tiene la propiedad controls que es el conjunto de controles contenidos en la linea del repeater junto con el control
        if (e.CommandName == "Borrar")
        {
            try
            {
                int _resultado = Persistencia.EliminarFam(Convert.ToInt32(((TextBox)(e.Item.Controls[1])).Text));
                if (_resultado == 1)
                {
                    LblError.Text = "Eliminacion correcta";
                }
                else
                {
                    LblError.Text = "Error";
                }
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
        else
        {
            try
            {
                //Intento listar los articulos de la familia seleccionada
                List<Articulo> _miLista = Persistencia.ListarArtFam(Convert.ToInt32(((TextBox)(e.Item.Controls[1])).Text));
                gvArticulos.DataSource = _miLista;
                gvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }
}
