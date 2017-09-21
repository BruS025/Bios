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

public partial class AltaArticulo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblError.Text = "";
        }
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
            FabricaLogica.getLogicaArticulos().AgregarArticulo(A);
            lblError.Text = "Alta con Exito";

            List<Articulo> articulos = FabricaLogica.getLogicaArticulos().ListarArticulo();

            articulos.Add(A);

            Session["Articulos"] = articulos;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

}