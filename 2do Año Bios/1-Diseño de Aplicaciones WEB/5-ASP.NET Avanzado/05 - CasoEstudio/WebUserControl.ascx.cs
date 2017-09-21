using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    Articulo _quete = null ;

    public Articulo quete
    {
        set
        {
            _quete = value;
            lbRCod.Text = _quete.Codigo.ToString();
            lbRNom.Text = _quete.Nombre.ToString();
            lbRPre.Text = _quete.Precio.ToString();
        }
    }
}