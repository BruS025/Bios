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
using System.Web.Services.Protocols;





public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnListar_Click(object sender, EventArgs e)
    {
        try
        {
            WSArticulos.ServicioArticulos Service = new WSArticulos.ServicioArticulos();

            List<WSArticulos.Articulo> arts = Service.ListarArticulo().ToList();

            gvListado.DataSource = arts;
            gvListado.DataBind();
        }
        catch (SoapException ex)
        {
            lblError.Text = ex.Detail.InnerText;
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
            txtNombre.Text = "";
            txtPrecio.Text = "";

            WSArticulos.ServicioArticulos Service = new WSArticulos.ServicioArticulos();

            WSArticulos.Articulo art = Service.BuscarArticulo(Convert.ToInt32(txtCodigo.Text));

            if (art != null)
            {
                txtNombre.Text = art.Nombre;
                txtPrecio.Text = art.Precio.ToString();
                BtnBaja.Enabled = true;
                BtnModificar.Enabled = true;
                BtnAlta.Enabled = false;
            }
            else
            {
                BtnBaja.Enabled = false;
                BtnModificar.Enabled = false;
                BtnAlta.Enabled = true;
            }
        }
        catch (SoapException ex)
        {
            lblError.Text = ex.Detail.InnerText;
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
            WSArticulos.Articulo art = new WSArticulos.Articulo();

            art.Codigo = Convert.ToInt32(txtCodigo.Text);
            art.Nombre = txtNombre.Text;
            art.Precio = Convert.ToDecimal(txtPrecio.Text);

            WSArticulos.ServicioArticulos Service = new WSArticulos.ServicioArticulos();

            Service.AltaArticulo(art);

            lblError.Text = "Alta correcta";
            BtnListar_Click(null, null);
        }
        catch (SoapException ex)
        {
            lblError.Text = ex.Detail.InnerText;
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
            WSArticulos.Articulo art = new WSArticulos.Articulo();

            art.Codigo = Convert.ToInt32(txtCodigo.Text);
            art.Nombre = txtNombre.Text;
            art.Precio = Convert.ToDecimal(txtPrecio.Text);

            WSArticulos.ServicioArticulos Service = new WSArticulos.ServicioArticulos();

            Service.ModificarArticulo(art);

            lblError.Text = "Modificación correcta";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";

            BtnListar_Click(null,null);
        }
        catch (SoapException ex)
        {
            lblError.Text = ex.Detail.InnerText;
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
            WSArticulos.Articulo art = new WSArticulos.Articulo();
            art.Codigo = Convert.ToInt32(txtCodigo.Text);

            WSArticulos.ServicioArticulos Service = new WSArticulos.ServicioArticulos();
            Service.BajaArticulo(art);

            lblError.Text = "Baja correcta";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";

            BtnListar_Click(null, null);
        }
        catch (SoapException ex)
        {
            lblError.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
