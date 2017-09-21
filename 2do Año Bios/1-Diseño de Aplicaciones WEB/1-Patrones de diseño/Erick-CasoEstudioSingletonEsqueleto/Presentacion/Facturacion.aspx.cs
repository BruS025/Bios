using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Facturacion : System.Web.UI.Page
{
    internal string Mensajes;

    //Constantes para Session
    private const string LINEAS = "Lineas";
    private const string FACTURA = "FacturaFound";
    private const string ART_TMP = "ArtTMP";

    protected void Page_Load(object sender, EventArgs e)
    {
        Mensajes = "";

        if (IsPostBack)
        {
            if (Session[ART_TMP] != null)
            {
                lblArticulo.Text = ((EntidadesCompartidas.Articulo)Session[ART_TMP]).Nombre + " - Precio: " + ((EntidadesCompartidas.Articulo)Session[ART_TMP]).Precio.ToString("N");
            }
        }
        else
        {
            //Si no es postBack vaciamos los datos de la session
            Session[ART_TMP] = null;
            Session[FACTURA] = null;
            Session[LINEAS] = null;
        }
    }

    protected void bntBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Session[ART_TMP] = null;

            if (txtArtCodigo.Text == "") { lblArticulo.Text = "Ingrese el código a buscar."; return; }

            EntidadesCompartidas.Articulo artAux = Logica.FabricaLogica.getLogicaArticulo().BuscarArticulo(Convert.ToInt32(txtArtCodigo.Text));

            if (artAux == null) { lblArticulo.Text = "No se encontraron datos."; return; }

            lblArticulo.Text = artAux.Nombre + " - Precio: " + artAux.Precio.ToString("N");

            Session[ART_TMP] = artAux;

        }
        catch (Exception ex)
        {
            lblArticulo.Text = "Error: " + ex.Message;
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session[ART_TMP] == null) { Alerta("Necesita buscar un artículo"); return; }
            if (txtCantidad.Text == "") { Alerta("Necesita ingresar la cantidad"); return; }

            int cant = 0;

            if (!(Int32.TryParse(txtCantidad.Text, out cant))) { Alerta("La cantidad debe ser un número"); return; }
            if (cant <= 0) { Alerta("La cantidad debe ser mayor que 0");  return; }

            EntidadesCompartidas.LineaFactura LinAux = new EntidadesCompartidas.LineaFactura((EntidadesCompartidas.Articulo)Session[ART_TMP], 
                                                                                              cant);

            //Si no existe creamos la lista de lineas en la session
            if (Session[LINEAS] == null) { Session[LINEAS] = new List<EntidadesCompartidas.LineaFactura>(); }

            //Cargamos el Datatable
            bool nuevo = true;
            foreach (EntidadesCompartidas.LineaFactura item in ((List<EntidadesCompartidas.LineaFactura>)Session[LINEAS]))
            {
                if (item.Articulo.Codigo == LinAux.Articulo.Codigo) { item.Cantidad += LinAux.Cantidad; nuevo = false; }
            }
            
            if (nuevo) ((List<EntidadesCompartidas.LineaFactura>)Session[LINEAS]).Add(LinAux);
            
           
            //Reiniciamos los controles
            Session[ART_TMP] = null;
            txtArtCodigo.Text = "";
            lblArticulo.Text = "Busque un artículo";
            txtCantidad.Text = "1";

            CargarGrilla();
        }
        catch (Exception ex)
        {
           Alerta("Error: " + ex.Message);
        }
    }

    protected void grdLineas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Quitar")
            {

                //Obtenemos la row que se apreto el link quitar
                GridViewRow row = grdLineas.Rows[Convert.ToInt32(e.CommandArgument)];

                //Borramos el artículo con ese código  en la lista de lineas
                foreach (EntidadesCompartidas.LineaFactura item in ((List<EntidadesCompartidas.LineaFactura>)Session[LINEAS]))
                {
                    if (item.Articulo.Codigo == Convert.ToInt32(row.Cells[1].Text))
                    {
                        ((List<EntidadesCompartidas.LineaFactura>)Session[LINEAS]).Remove(item);
                        break;
                    }
                }
                //Verificamos si hay items en la lista de lineas
                if (((List<EntidadesCompartidas.LineaFactura>)Session[LINEAS]).Count == 0) { Session[LINEAS] = null; }
                
                //recargamos la grilla
                CargarGrilla();
            }
        }
        catch(Exception ex)
        {
            Alerta("Quitar - Error: " + ex.Message);
        }
    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session[LINEAS] == null) { Alerta("Necesita ingresar al menos un artículo"); return; }
            if (txtCliente.Text == "") { Alerta("Necesita ingresar un cliente"); return; }

            int id = 0;

            if (!(Int32.TryParse(txtNroFactura.Text, out id))) { Alerta("El id de factura debe ser un número"); return; }
            if (id <= 0) { Alerta("El id de factura debe ser mayor que 0"); return; }

            Logica.ILogicaFactura lFactura = Logica.FabricaLogica.getLogicaFactura();

            EntidadesCompartidas.Factura facAux = lFactura.BuscarFactura(id);

            if (facAux != null) { Alerta("Ya existe una factura con ese Id"); return; }
            else
            {
                facAux = new EntidadesCompartidas.Factura(id, txtCliente.Text, DateTime.Now, (List<EntidadesCompartidas.LineaFactura>)Session[LINEAS]);
            }

            lFactura.AgregarFactura(facAux);

            //Reseteamos los controles
            txtCliente.Text = "";
            txtNroFactura.Text = "";
            txtCantidad.Text = "1";
            txtArtCodigo.Text = "";
            Session[LINEAS] = null;
            btnModificar.Visible = false;

            CargarGrilla();
            
            Alerta("Factura generada correctamente");
        }
        catch(Exception ex)
        {
            Alerta("Grabar - Error: " + ex.Message);
        }
    }

    protected void bntBuscarFactura_Click(object sender, EventArgs e)
    {
        try
        {
            Session[FACTURA] = null;
            Session[LINEAS] = null;

            btnEliminar2.Visible = false;
            btnModificar.Visible = false;
            btnGrabar.Visible = true;
           // btnAgregar.Visible = true;
            txtCliente.Text = "";

            int id = 0;

            if (!(Int32.TryParse(txtNroFactura.Text, out id))) { Alerta("El id de factura debe ser un número"); return; }
            if (id <= 0) {Alerta("El id de factura debe ser mayor que 0"); return; }

            EntidadesCompartidas.Factura facAux = Logica.FabricaLogica.getLogicaFactura().BuscarFactura(Convert.ToInt32(txtNroFactura.Text));

            if (facAux == null) { Alerta("No se encontro la factura"); return; }

            txtCliente.Text = facAux.Cliente; 
            btnEliminar2.Visible = true;
            btnModificar.Visible = true;
            btnGrabar.Visible = false;
           // btnAgregar.Visible = false;

            Session[FACTURA] = facAux;
            Session[LINEAS] = facAux.Lineas;
        }
        catch (Exception ex)
        {
            Alerta("Error: " + ex.Message);
        }
        finally
        {
            CargarGrilla();
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Logica.FabricaLogica.getLogicaFactura().BajaFactura(((EntidadesCompartidas.Factura)Session[FACTURA]).ID);

            btnEliminar2.Visible = false;
            btnModificar.Visible = false;
            btnGrabar.Visible = true;
           // btnAgregar.Visible = true;
            txtNroFactura.Text = "";
            Alerta("Factura nro. " + ((EntidadesCompartidas.Factura)Session[FACTURA]).ID + " eliminada");
            Session[LINEAS] = null;

            //Reseteamos los controles
            txtCliente.Text = "";
            txtNroFactura.Text = "";
            txtCantidad.Text = "1";
            txtArtCodigo.Text = "";
            Session[FACTURA] = null;
            CargarGrilla();
        }
        catch (Exception ex)
        {
            Alerta("Error: " + ex.Message);
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session[LINEAS] == null) { Alerta("Necesita ingresar al menos un artículo"); return; }
            if (txtCliente.Text == "") { Alerta("Necesita ingresar un cliente"); return; }

            ((EntidadesCompartidas.Factura)Session[FACTURA]).Cliente = txtCliente.Text;
            ((EntidadesCompartidas.Factura)Session[FACTURA]).Lineas = (List<EntidadesCompartidas.LineaFactura>)Session[LINEAS];

            Logica.ILogicaFactura lFactura = Logica.FabricaLogica.getLogicaFactura();

            lFactura.ModificarFactura((EntidadesCompartidas.Factura)Session[FACTURA]);

            //Reseteamos los controles
            txtCliente.Text = "";
            txtNroFactura.Text = "";
            txtCantidad.Text = "1";
            txtArtCodigo.Text = "";
            Session[LINEAS] = null;
            btnModificar.Visible = false;
            btnEliminar2.Visible = false;
            btnGrabar.Visible = true;

            Alerta("Factura nro. " + ((EntidadesCompartidas.Factura)Session[FACTURA]).ID + " modificada correctamente");

            Session[FACTURA] = null;
            CargarGrilla();


        }
        catch (Exception ex)
        {
            Alerta("Modificar - Error: " + ex.Message);
        }
    }


    private void CargarGrilla()
    {
        try
        {
            //Verificamos si hay lineas
            if (Session[LINEAS] == null)
            {
                grdLineas.DataSource = null;
                grdLineas.DataBind();
                return;
            }

            System.Data.DataTable tLineas = new System.Data.DataTable();
            tLineas.Columns.Add("Código");
            tLineas.Columns.Add("Nombre");
            tLineas.Columns.Add("Cantidad");
            tLineas.Columns.Add("SubTotal");

            //Cargamos el datatable
            foreach (EntidadesCompartidas.LineaFactura item in ((List<EntidadesCompartidas.LineaFactura>)Session[LINEAS]))
            {
                tLineas.Rows.Add(new object[] { item.Articulo.Codigo, item.Articulo.Nombre, item.Cantidad, (item.Articulo.Precio * item.Cantidad).ToString("N") });
            }

            //Cargamos la grilla
            grdLineas.DataSource = tLineas;
            grdLineas.DataBind();
        }
        catch (Exception ex)
        {
           Alerta("CargarGrilla - Error: " + ex.Message);
        }
        finally
        {
            ActualizarTotales();
        }
    }

    private void ActualizarTotales()
    {
        try
        {
            if (Session[LINEAS] == null) { lblTotal.Text = null;  return; }

            decimal res = 0;

            foreach (EntidadesCompartidas.LineaFactura item in (List<EntidadesCompartidas.LineaFactura>)Session[LINEAS])
            {
                res += item.Articulo.Precio * item.Cantidad;
            }

            lblTotal.Text = "Total: " + res.ToString("N");
        }
        catch (Exception ex)
        {
            Alerta("ActualizarTotales - Error: " + ex.Message);
        }
    }

    private void Alerta(string mensaje)
    {
        Mensajes = "alert('" + mensaje +".')";
    }

 
}