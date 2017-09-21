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




public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnbtnConsulta1_Click(object sender, EventArgs e)
    {
        // Limpio el resultado anterior
        GvResultado.DataSource = null;
        GvResultado.DataBind();
        TxtResultado.Text = "";

        XElement _doc = XElement.Load(Server.MapPath("~/XML/Alumnos.xml"));

        var _resultado = (from unNodo in _doc.Elements("Alumno")
                          where (int)unNodo.Element("Nota") >= 70
                          select
                          new
                          {
                              Nombre = unNodo.Element("Nombre").Value, // SI usamos elements cre conunto de conjuntos
                              Apellido = unNodo.Element("Apellido").Value,
                              Nota = unNodo.Element("Nota").Value
                          }).ToList();

        GvResultado.DataSource = _resultado;
        GvResultado.DataBind();

    }

    protected void btnbtnConsulta2_Click(object sender, EventArgs e)
    {
        // Limpio el resultado anterior
        GvResultado.DataSource = null;
        GvResultado.DataBind();
        TxtResultado.Text = "";

        XElement _doc = XElement.Load(Server.MapPath("~/XML/Alumnos.xml"));

        var _resultado = (from unNodo in _doc.Elements("Alumno")
                          where (int)unNodo.Element("Nota") <= 70
                          select
                          new
                          {
                              Nombre = unNodo.Element("Nombre").Value, // SI usamos elements cre conunto de conjuntos
                              Apellido = unNodo.Element("Apellido").Value,
                              Nota = unNodo.Element("Nota").Value
                          }).ToList();

        GvResultado.DataSource = _resultado;
        GvResultado.DataBind();
    }

    protected void btnbtnConsulta3_Click(object sender, EventArgs e)
    {
        // Limpio el resultado anterior
        GvResultado.DataSource = null;
        GvResultado.DataBind();
        TxtResultado.Text = "";

        XElement _doc = XElement.Load(Server.MapPath("~/XML/Alumnos.xml"));

        int _resultado = (from unNodo in _doc.Elements("Alumno")
                          where (int)unNodo.Element("Nota") >= 70
                          select unNodo).Count();

        TxtResultado.Text = "Aprobaron " + _resultado + " alumnos";
    }

    protected void btnbtnConsulta4_Click(object sender, EventArgs e)
    {
        // Limpio el resultado anterior
        GvResultado.DataSource = null;
        GvResultado.DataBind();
        TxtResultado.Text = "";

        XElement _doc = XElement.Load(Server.MapPath("~/XML/Alumnos.xml"));

        var _resultado = (from unNodo in _doc.Elements("Alumno")
                          group unNodo by unNodo.Element("Materia").Value
                          into tabla
                          select
                          new
                          {
                              Materia = tabla.Key, // SI usamos elements cre conunto de conjuntos
                              Cantidad = tabla.Count()
                          }).ToList();

        GvResultado.DataSource = _resultado;
        GvResultado.DataBind();
    }

    protected void bt90_Click(object sender, EventArgs e)
    {
        // Limpio el resultado anterior
        GvResultado.DataSource = null;
        GvResultado.DataBind();
        TxtResultado.Text = "";

        XElement _doc = XElement.Load(Server.MapPath("~/XML/Alumnos.xml"));

        var _resultado = (from unNodo in _doc.Elements("Alumno")
                          group unNodo by unNodo.Elements("Materia")
                          into tabla
                          select tabla);

        if(_resultado.Count() > 0)
        {
            TxtResultado.Text = "Aprobaron " + _resultado + " alumnos";
        }
        
    }
}