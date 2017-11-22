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
using System.Collections.Generic;

using RefWCF;

public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnListar_Click(object sender, EventArgs e)
    {
        List<Articulo> _lista = null;
        try
        {
            IServicioArticulo SArticulo = new ServicioArticuloClient();
            _lista = SArticulo.ListarArticulo().ToList();
            gvListado.DataSource = _lista;
            gvListado.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {

        try
        {
            Articulo articulo = null;

            IServicioArticulo SArticulo = new ServicioArticuloClient();
            articulo = SArticulo.BuscarArticulo(Convert.ToInt32(txtCodigo.Text));

            if(articulo !=null)
            {
                txtCodigo.Text = Convert.ToString(articulo.Codigo);
                txtNombre.Text = articulo.Nombre;
                txtPrecio.Text = Convert.ToString(articulo.Precio);
                lblError.Text = "Se encontro";
                Session["Articulo"] = articulo;

            }
            else
            {
                lblError.Text = "No existe puede agregarlo";
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;        
        }
    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            Articulo articulo = new Articulo();

            articulo.Codigo = Convert.ToInt32(txtCodigo.Text);
            articulo.Nombre = txtNombre.Text;
            articulo.Precio = Convert.ToInt32(txtPrecio.Text);

            IServicioArticulo SArticulo = new ServicioArticuloClient();
            SArticulo.AgregarArticulo(articulo);

            lblError.Text = "se agrego";

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Articulo art = new Articulo();

            art.Codigo = ((Articulo)Session["Articulo"]).Codigo;
            art.Nombre = txtNombre.Text;
            art.Precio = Convert.ToInt32(txtPrecio.Text);

            IServicioArticulo SArticulo = new ServicioArticuloClient();
            SArticulo.ModificarArticulo(art);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnBaja_Click(object sender, EventArgs e)
    {
        try
        {
           IServicioArticulo SArticulo = new ServicioArticuloClient();
           SArticulo.EliminarArticulo(((Articulo)Session["Articulo"]));

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
