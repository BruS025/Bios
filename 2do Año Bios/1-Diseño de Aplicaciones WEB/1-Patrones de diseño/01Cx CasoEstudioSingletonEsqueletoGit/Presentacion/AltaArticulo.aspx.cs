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

using EntidadesCompartidas;
using Logica;

public partial class AltaArticulo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        int _codigo;
        decimal _precio;
        string _nombre;
        Articulo A;

        try
        {
            _codigo = Convert.ToInt32(txtCodigo.Text);
            _precio = Convert.ToDecimal(txtPrecio.Text);
            _nombre = txtNombre.Text;
            A = new Articulo(_codigo, _nombre, _precio);

            ILogicaArticulos LArticulo = FabricaLogica.getLogicaArticulo();
            LArticulo.AgregarArticulo(A);

            // FabricaLogica.getLogicaArticulo().AgregarArticulo(A);

            lblError.Text = "Alta con exito!";
            txtNombre.Text = "";
            txtCodigo.Text = "";
            txtPrecio.Text = "";

        }
        catch (Exception ex)
        {

            lblError.Text = ex.Message;
        }
    }

}