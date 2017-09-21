using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class UserControl_coloresHost : System.Web.UI.UserControl
{
    // Atributos
    protected int _indiceActualColor; // -1 No se Ha seleccionado nada.
    protected string[] _colores = { "Red", "Blue", "Green", "Yellow" }; // Asigno conjunto de datos esto es un conjunto y lo guardamos en un vector.

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            _indiceActualColor = Convert.ToInt16(ViewState["_indiceActualColor"].ToString());

        }

        else
        {
            _indiceActualColor = 0;
            DesplegarColor();
        }
    }
    protected void DesplegarColor()
    {
        txtColor.Text = _colores[_indiceActualColor];
        ViewState["_indiceActualColor"] = _indiceActualColor.ToString();
    }



    protected void btnAtras_Click(object sender, EventArgs e)
    {
        if (_indiceActualColor == 0)
            {
            _indiceActualColor = _colores.Length - 1;
            }

        else
            {
            _indiceActualColor -= 1;
            }


        DesplegarColor();
    }

    protected void btnAdelante_Click(object sender, EventArgs e)
    {
        if (_indiceActualColor == (_colores.Length - 1))
            _indiceActualColor = 0;
        else
            _indiceActualColor += 1;

        DesplegarColor();
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        btnAplicar.BackColor = System.Drawing.Color.FromName(_colores[_indiceActualColor]);
    }

    protected void btnAplicarHost_Click(object sender, EventArgs e)
    {
        try
        {
            //obtengo referencia a mi pagina host (donde se coloco el control)
            HtmlForm _paginaHost = (HtmlForm)this.Parent;

            //busco los tres controles que voy a modificar
            Label _lblPrueba = (Label)_paginaHost.FindControl("lblPrueba");
            TextBox _txtPrueba = (TextBox)_paginaHost.FindControl("txtPrueba");
            Button _btnPrueba = (Button)_paginaHost.FindControl("btnPrueba");

            //modifico el color de despligue de dichos controles

            _lblPrueba.ForeColor = System.Drawing.Color.FromName(_colores[_indiceActualColor]);
            _btnPrueba.ForeColor = System.Drawing.Color.FromName(_colores[_indiceActualColor]);
            _txtPrueba.ForeColor = System.Drawing.Color.FromName(_colores[_indiceActualColor]);
        }
        catch (Exception)
        {

            throw;
        }
    }
}

