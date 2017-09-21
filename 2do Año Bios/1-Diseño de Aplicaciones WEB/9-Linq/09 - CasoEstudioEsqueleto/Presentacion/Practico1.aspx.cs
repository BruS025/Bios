using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Practico1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnMail30_Click(object sender, EventArgs e)
    {
        List<EntidadesCompartidas.Mail> _listaResultado = (from mail in (Logica.LogicaMail.ListarMail())
                                                           where mail.Asunto.Length > 30
                                                           select mail).ToList<EntidadesCompartidas.Mail>();

        gvMostrar.DataSource = _listaResultado;
        gvMostrar.DataBind();
    }

    protected void btnUsuariosNombre_Click(object sender, EventArgs e)
    {
        List<EntidadesCompartidas.Usuarios> _listaResultado = (from unUse in (Logica.LogicaUsuario.ListarUsuarios())
                                                               orderby unUse.NombreUsuario
                                                               select unUse).ToList<EntidadesCompartidas.Usuarios>();

        gvMostrar.DataSource = _listaResultado;
        gvMostrar.DataBind();
    }

    protected void btnAndresito_Click(object sender, EventArgs e)
    {
        List<EntidadesCompartidas.Mail> _listaResultado = (from unUse in (Logica.LogicaMail.ListarMail())
                                                           where unUse.UserEnvio.NombreUsuario.Contains("Andresito")
                                                           select unUse).ToList<EntidadesCompartidas.Mail>();

        gvMostrar.DataSource = _listaResultado;
        gvMostrar.DataBind();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        List<EntidadesCompartidas.Mail> _listaResultado = (from unUse in (Logica.LogicaMail.ListarMail())
                                                           where unUse.Asunto.Count() > 10 || unUse.Texto == ""
                                                           select unUse).ToList<EntidadesCompartidas.Mail>();

        gvMostrar.DataSource = _listaResultado;
        gvMostrar.DataBind();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        var _listaResultado = from unUse in (Logica.LogicaMail.ListarMail())
                              select new
                              {
                                  envia = unUse.UserEnvio.NombreCompleto,
                                  recive = unUse.UserRecibio.NombreCompleto
                              };
        gvMostrar.DataSource = _listaResultado;
        gvMostrar.DataBind();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        var _ListaResultado = from unUse in (Logica.LogicaMail.ListarMail())
                              group unUse by unUse.UserEnvio.NombreCompleto
                              into tabla
                              select new
                              {
                                  tabla.Key,
                                  canti = tabla.Count(),
                              };




        gvMostrar.DataSource = _ListaResultado;
        gvMostrar.DataBind();
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        var _ListaResultado = from unUse in (Logica.LogicaMail.ListarMail())
                              group unUse by unUse.UserEnvio.NombreCompleto
                              into tabla
                              where tabla.Count() > 3
                              select new
                              {
                                  tabla.Key,
                                  canti = tabla.Count(),
                              };




        gvMostrar.DataSource = _ListaResultado;
        gvMostrar.DataBind();
    }

    protected void ado1_Click(object sender, EventArgs e)
    {
        System.Data.DataSet _ds = new System.Data.DataSet();
        System.Data.DataTable _tablaUser = null;
        System.Data.DataTable _tablaMail = null;

        System.Data.SqlClient.SqlDataAdapter _daU = new System.Data.SqlClient.SqlDataAdapter("Select * From Usuario", "Data Source =.; Initial Catalog = BDLinqToAdo;Integrated Security = True");

        _daU.Fill(_ds, "Usuario");
        _tablaUser = _ds.Tables["Usuario"];

        System.Data.SqlClient.SqlDataAdapter _daM = new System.Data.SqlClient.SqlDataAdapter("Select * From MAIL", "Data Source =.; Initial Catalog = BDLinqToAdo;Integrated Security = True");

        _daM.Fill(_ds, "MAIL");
        _tablaMail = _ds.Tables["MAIL"];

        var resultado = from UnRegUser in _tablaUser.Select()
                        join UnRegMail in _tablaMail.Select()
                        on UnRegUser["IdLogueo"] equals UnRegMail["Envio"]
                        select new
                        {
                            NombreUser = UnRegUser["NombreCompleto"],
                            unmail = UnRegMail["Texto"],
                        };

        gvAdoMostrar.DataSource = resultado;
        gvAdoMostrar.DataBind();

    }

    protected void ado2_Click(object sender, EventArgs e)
    {
        System.Data.DataSet _ds = new System.Data.DataSet();
        System.Data.DataTable _tablaUser = null;
        System.Data.DataTable _tablaMail = null;

        System.Data.SqlClient.SqlDataAdapter _daU = new System.Data.SqlClient.SqlDataAdapter("Select * From Usuario", "Data Source =.; Initial Catalog = BDLinqToAdo;Integrated Security = True");

        _daU.Fill(_ds, "Usuario");
        _tablaUser = _ds.Tables["Usuario"];

        System.Data.SqlClient.SqlDataAdapter _daM = new System.Data.SqlClient.SqlDataAdapter("Select * From MAIL", "Data Source =.; Initial Catalog = BDLinqToAdo;Integrated Security = True");

        _daM.Fill(_ds, "MAIL");
        _tablaMail = _ds.Tables["MAIL"];

        var resultado = from UnRegUser in _tablaUser.Select()
                        join UnRegMail in _tablaMail.Select()
                        on UnRegUser["IdLogueo"] equals UnRegMail["Recivio"]
                        group UnRegUser by UnRegUser["NombreCompleto"]
                        into tablaRes
                        select new
                        {
                            NombreUser = tablaRes.Key,
                            cantMail = tablaRes.Count()
                        };

        gvAdoMostrar.DataSource = resultado;
        gvAdoMostrar.DataBind();
    }
}
