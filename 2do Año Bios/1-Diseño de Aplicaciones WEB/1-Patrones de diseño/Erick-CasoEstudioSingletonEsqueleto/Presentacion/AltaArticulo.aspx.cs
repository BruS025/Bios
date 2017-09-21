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

public partial class AltaArticulo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {

        try
        {
            Logica.FabricaLogica.getLogicaArticulo().AgregarArticulo(new Articulo(Convert.ToInt32(txtCodigo.Text),
                                                                                    txtNombre.Text,
                                                                                    Convert.ToDecimal(txtPrecio.Text)));
            lblError.Text = "Artículo agregado correctamente.";

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = "Error: " + ex.Message;
        }

    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            
            if (txtCodigo.Text == "") { lblError.Text = "Ingrese el código a buscar."; return; }

            Articulo artAux = Logica.FabricaLogica.getLogicaArticulo().BuscarArticulo(Convert.ToInt32(txtCodigo.Text));

            if (artAux == null) { lblError.Text = "No se encontraron datos."; return; }

            txtNombre.Text = artAux.Nombre;
            txtPrecio.Text = artAux.Precio.ToString();
        }
        catch (Exception ex)
        {
            lblError.Text = "Error: " + ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtCodigo.Text == "") { lblError.Text = "Ingrese el código del artículo."; return; }

            Logica.FabricaLogica.getLogicaArticulo().EliminarArticulo(new Articulo(Convert.ToInt32(txtCodigo.Text),
                                                                                    null,
                                                                                    0));
            lblError.Text = "Artículo eliminado correctamente.";

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = "Error: " + ex.Message;
        }
    }
}