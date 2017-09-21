using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Controles_ZonaControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarZona();

        }
    }

    protected void ddlDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarZona();
    }

    protected void CargarZona()
    {
        ILogicaZona LZona = FabricaLogica.getLogicaZona();
        List<Zona> listadoZona = LZona.Listar();


        List<Zona> _ListarResultado = (from zonas in (listadoZona)
                                       where zonas.Departamento.Contains(ddlDepartamentos.SelectedValue)
                                       select zonas).ToList<Zona>();

        nombreZona.DataSource = _ListarResultado;
        nombreZona.DataBind();
    }

    public string getDepartamento()
    {
        string departamento = ddlDepartamentos.SelectedValue;
        return departamento;
    }

    public string getNombre()
    {
        string nombre = nombreZona.SelectedValue;
        return nombre;
    }

    public void setDepartamento(string departamento)
    {
        ddlDepartamentos.SelectedValue = departamento;
        CargarZona();
    }

    public void setNombre(string nombre)
    {
        nombreZona.SelectedValue = nombre;
    }
}