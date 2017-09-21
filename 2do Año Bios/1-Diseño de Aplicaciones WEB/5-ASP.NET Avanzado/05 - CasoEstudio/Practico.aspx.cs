using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Practico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Articulo> listArt = Persistencia.ListarArt();

            Session["Lista"] = listArt;

            foreach(Articulo item in listArt)
            {
                Menu1.Items.Add(new MenuItem(item.Nombre,Convert.ToString(item.Codigo)));
            }
        }
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        WebUserControl1.quete = Persistencia.BuscarArt(Convert.ToInt32(e.Item.Value));
        
    }
}