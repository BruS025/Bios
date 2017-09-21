using System;
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

using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    private DataSet _Ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            // es un postback obteno info en la memoria
            _Ds = (DataSet)ViewState["_Ds"];
        }

        else // Es el primer inreso a la paina enero objeto par auardar info
        {
            _Ds = new DataSet("Ventas");
            ViewState["_Ds"] = _Ds;
        }
        
    }

    protected void BtnAccion1_Click(object sender, EventArgs e)
    {
        // Creo conexion con BD
        SqlConnection _cnn = new SqlConnection("Data Source =.; Initial Catalog = Ventas; Integrated Security = true");

        // Creo adaptadores
        SqlDataAdapter _daFam = new SqlDataAdapter("Select * from Familias", _cnn);
        SqlDataAdapter _daArt = new SqlDataAdapter("Select * from Articulos", _cnn);

        // Car datos
        _daFam.Fill(_Ds, "Familias");
        _daArt.Fill(_Ds, "Articulos");
        ViewState["_Ds"] = _Ds;

        // Car rillas
        GVFamilias.DataSource = _Ds.Tables["Familias"];
        GVFamilias.DataBind();
        GVArticulos.DataSource = _Ds.Tables["Articulos"];
        GVArticulos.DataBind();

    }

    // Combinar lo de la base de datos con archivo xml
    protected void BtnAccion2_Click(object sender, EventArgs e)
    {
        DataSet _DsAux = new DataSet();
        _DsAux.ReadXml(Server.MapPath("~/XML/DatosXML.XML"));

        // combino la info q viene de bd (y que ta esta en datase en memoria)
        _Ds.Merge(_DsAux, true, MissingSchemaAction.Ignore);
        ViewState["_Ds"] = _Ds;

        GVFamilias.DataSource = _Ds.Tables["Familias"];
        GVFamilias.DataBind();
        GVArticulos.DataSource = _Ds.Tables["Articulos"];
        GVArticulos.DataBind();

    }

    protected void BtnAccion3_Click(object sender, EventArgs e)
    {
        _Ds.WriteXmlSchema(Server.MapPath("~/XML/EsquemaXML.xml"));
        _Ds.WriteXml(Server.MapPath("~/XML/DatosCompletosXML.xml"));
        _Ds.WriteXml(Server.MapPath("~/XML/DatosEsquemaXML.xml"), XmlWriteMode.WriteSchema);



    }
 
}
