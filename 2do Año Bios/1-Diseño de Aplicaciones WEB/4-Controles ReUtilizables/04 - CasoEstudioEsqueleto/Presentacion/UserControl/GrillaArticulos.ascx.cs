using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_GrillaArticulos : System.Web.UI.UserControl
{
    private int _indiceSeleccionado;
    private DataTable _dt;
    //El primer atributo nos va a servir para saber que posicion de la grilla esta en un momento seleccionado 
    //El segundo atri es para mantener los datos de la grilla entre postback
    protected void Page_Load(object sender, EventArgs e)
    {
        gdArticulos.SelectedIndexChanged += new System.EventHandler(this.SeleccionGrilla);

        if(!IsPostBack)
        {
            _indiceSeleccionado = -1;
            _dt = null;
            ViewState["_dt"] = _dt;
            ViewState["_indiceSeleccionado"] = _indiceSeleccionado;
            //el viewstate no funciona como la session que no importaba de donde estaba apuntado un objeto la memoria se actualizaba igual 
            //el viewstate es el texto que va con la pagina 
        }
        else
        {
            //manejo el estado de la propia pagina ara almacenar entre postback la tabla
            _indiceSeleccionado = Convert.ToInt32(ViewState["_indiceSeleccionado"].ToString());
            _dt = (DataTable)ViewState["_dt"];
        }
    }

    public void CargoArticulos()
    {
        try
        {
            SqlDataAdapter _da = new SqlDataAdapter("select * from Articulos","Data Source =.; Initial Catalog = Ventas; Integrated Security = true");

            //el sqlDataAdapter me permite trabajar de una forma desconectada con una base de datos
            //tiene 2 formas de trabajar 1 a travez de fill que dado un comando de consulta (select) trae todo la info que le devuelve la bd
            //y la coloca dentro de un objeto dataSet con el formato de un dataTable(conjunto de registros)
            //la segunda operacion de un dataadapter es un update que nos permite dado un comando o varios comandos de sentencias de actualizacion
            //va a la bd y hace actualizaciones masivas no hace nada individual 
            //siempre funciona igual el se conecta procesa y se autodesconecta automaticamente

            DataSet _ds = new DataSet();

            _da.Fill(_ds);
            _dt = _ds.Tables[0];
            gdArticulos.DataSource = _dt;
            gdArticulos.DataBind();
            ViewState["_dt"]=_dt;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    //Propiedad del control de usuario que permite saber cual es el registro
    //del articulo seleccionado de la grilla
    public DataRow ArticuloSeleccionado
    {
        get { return _dt.Rows[_indiceSeleccionado]; }
    }

    protected void SeleccionGrilla(object sender, EventArgs e)
    {
        _indiceSeleccionado = gdArticulos.SelectedIndex;
        ViewState["_indiceSeleccionado"] = _indiceSeleccionado;
    }
}