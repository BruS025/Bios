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

using EntidadesCompartidas;
using Logica;

public partial class ListarArticulos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ILogicaArticulos LArticulo = FabricaLogica.getLogicaArticulo();
        gvListado.DataSource = LArticulo.ListarArticulo();
        gvListado.DataBind();
    }

}
