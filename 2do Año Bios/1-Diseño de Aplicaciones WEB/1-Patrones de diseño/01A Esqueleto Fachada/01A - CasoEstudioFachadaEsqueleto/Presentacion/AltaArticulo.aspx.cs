using System;
using System.Collections;
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
using Logica;

using EntidadesCompartidas;

public partial class AltaArticulo : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Articulo A = new Articulo(Convert.ToInt32(txtCodigo.Text), txtNombre.Text, Convert.ToDecimal(txtPrecio.Text));
            FachadaLogica.AgregarArticulo(A);

            lblError.Text = "Articulo Ingresado Correctamente";

            LimpiarTxt();

        }
        catch (Exception ex)
        {
            lblError.Text =String.Format("Error al agregar el articulo {0}", ex.Message);
        }
        

    }

    private void LimpiarTxt()
    {
        txtPrecio.Text = "";
        txtNombre.Text = "";
        txtCodigo.Text = "";
    }

}
