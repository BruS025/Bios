using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


using EntidadesCompartidas;
using Logica;


using System.Collections.Generic;

public partial class ABMApartamento : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioFormulario();

    }

    private void ActivoBotonesBM()
    {
        BtnModificar.Enabled = true;
        BtnEliminar.Enabled = true;

        btnAgregar.Enabled = false;
        BtnBuscar.Enabled = false;

        txtPadron.Enabled = false;
        btnBuscoDuenio.Enabled = true;
    }

    private void ActivoBotonesA()
    {
        BtnModificar.Enabled = false;
        BtnEliminar.Enabled = false;

        btnAgregar.Enabled = true;
        BtnBuscar.Enabled = false;

        txtPadron.Enabled = false;
        btnBuscoDuenio.Enabled = true;
    }

    private void LimpioFormulario()
    {
        btnAgregar.Enabled = false;
        BtnModificar.Enabled = false;
        BtnEliminar.Enabled = false;

        BtnBuscar.Enabled = true;
        btnBuscoDuenio.Enabled = false;

        txtPadron.Enabled = true;

        txtPadron.Text = "0";
        txtDireccion.Text = "";
        txtAlquiler.Text = "0";
        chkPortero.Checked = false;
        txtPiso.Text = "0";
        txtGastosComunes.Text = "0";
        txtDuenioCedula.Text = "";
        lblDuenio.Text = "";

        lblError.Text = "";
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Duenio _und = (Duenio)Session["Duenio"];

            //verifico q tenga un dueño
            if (_und == null)
                throw new Exception("Debe Seleccionar Dueño");


            //creo el objeto
            Apartamento unApto = new Apartamento(Convert.ToInt32(txtPadron.Text), txtDireccion.Text, Calendario.SelectedDate, Convert.ToInt32(txtAlquiler.Text), chkPortero.Checked, Convert.ToInt32(txtPiso.Text), Convert.ToInt32(txtGastosComunes.Text), _und);


            //trato de agregar
            Logica.LogicaVivienda.Alta(unApto);
            lblError.Text = "Alta con éxito";
            this.LimpioFormulario();
  
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
            Apartamento _unA = (Apartamento)Session["Apto"];
            Duenio _und = (Duenio)Session["Duenio"];

            //verifico q tenga un dueño
            if (_und == null)
                throw new Exception("Debe Seleccionar Dueño");


            //modifico el objeto
            _unA.Direccion = txtDireccion.Text.Trim();
            _unA.FechaCons = Calendario.SelectedDate;
            _unA.Alquiler = Convert.ToInt32(txtAlquiler.Text);
            _unA.Portero = chkPortero.Checked;
            _unA.Piso = Convert.ToInt32(txtPiso.Text);
            _unA.GComunes = Convert.ToInt32(txtGastosComunes.Text);
            _unA.Dueño = _und;


            //trato de modificar
            Logica.LogicaVivienda.Modificar(_unA);
            lblError.Text = "Modificacion con éxito";
            this.LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        try
        {

            Apartamento _unA = (Apartamento)Session["Apto"];

            //trato de eliminar
            Logica.LogicaVivienda.Eliminar(_unA);
            lblError.Text = "Eliminacion con éxito";
            this.LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {

            //busco apartamento
            int _padron = Convert.ToInt32(txtPadron.Text);
            Vivienda _objeto = Logica.LogicaVivienda.Buscar(_padron);

            //determino acciones
            if (_objeto == null)
            {
                //alta
                this.ActivoBotonesA();
                Session["Apto"] = _objeto;
                Session["Duenio"] = null;
            }
            else if (_objeto is Casa)
                throw new Exception("El padron pertenece a una Casa - Error");
            else
            {
                this.ActivoBotonesBM();

                Session["Apto"] = _objeto;
                Session["Duenio"] = _objeto.Dueño;

                txtDireccion.Text = _objeto.Direccion;
                Calendario.SelectedDate = _objeto.FechaCons;
                Calendario.VisibleDate = _objeto.FechaCons;
                txtAlquiler.Text = _objeto.Alquiler.ToString();
                chkPortero.Checked = ((Apartamento)_objeto).Portero;
                txtPiso.Text = ((Apartamento)_objeto).Piso.ToString();
                txtGastosComunes.Text = ((Apartamento)_objeto).GComunes.ToString();

                lblDuenio.Text = _objeto.Dueño.ToString();
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnBuscoCliente_Click(object sender, EventArgs e)
    {
        try
        {

            //busco 
            int _cedula = Convert.ToInt32(txtDuenioCedula.Text);
            Duenio _objeto = Logica.LogicaDueño.Buscar(_cedula);

            //determino acciones
            if (_objeto == null)
            {
                Session["Duenio"] = null;
                lblDuenio.Text = "No existe dicha cedula en el sistema";
            }
            else
            {
                Session["Duenio"] = _objeto;
                lblDuenio.Text = _objeto.ToString();
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}