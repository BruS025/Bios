using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;
using Logica;

public partial class AltaFactura : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblError.Text = "";

            List<Articulo> articulos = FabricaLogica.getLogicaArticulos().ListarArticulo();

            Session["Articulos"] = articulos;
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        DateTime fecha;
        string nombreCliente;
        List<LineasFactura> L = (List<LineasFactura>)Session["Lineas"];
        Factura F;

        try
        {
            fecha = Convert.ToDateTime(txtFecha.Text);
            nombreCliente = txtNombreCliente.Text;

            F = new Factura(fecha, nombreCliente, L);
            FabricaLogica.getLogicaFactura().AgregarFactura(F);
            lblError.Text = "Alta con Exito";

            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnAgregarArticulo_Click(object sender, EventArgs e)
    {
        int codArt;
        int cantidad;
        LineasFactura linea;
        List<LineasFactura> lineas;

        lineas = (List<LineasFactura>)Session["Lineas"];

        if(lineas == null)
        {
            lineas = new List<LineasFactura>();
        }
        
        List<Articulo> articulos = (List<Articulo>)Session["Articulos"];

        

        try
        {
            codArt = Convert.ToInt32(txtCodigoArticulo.Text);
            cantidad = Convert.ToInt32(txtCantidad.Text);

            Articulo articuloEncontrado = FabricaLogica.getLogicaArticulos().BuscarArticulo(codArt);

            if (articuloEncontrado == null)
            {
                throw new Exception("El articulo con el codigo especificado no existe");
            }
            else
            {
                foreach (LineasFactura L in lineas)
                {
                    if (L.Articulo.Codigo == codArt)
                    {

                        return; //codigo duplicado
                    }
                } 
                
                linea = new LineasFactura(articuloEncontrado, cantidad);

                lineas.Add(linea);

                Session["Lineas"] = lineas;

 
                gvProductos.DataSource = lineas;
                gvProductos.DataBind();

            }


 

            btnAgregar.Enabled = true;

            txtCodigoArticulo.Text = "";
            txtCantidad.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void LimpiarFormulario()
    {
        txtFecha.Text = "";
        txtCodigoArticulo.Text = "";
        txtCantidad.Text = "";
        txtNombreCliente.Text = "";

        btnAgregar.Enabled = false;

        Session["Lineas"] = null;
    }
}