using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;

using EntidadesCompartidas;
using Logica;


public partial class ABMDuenio : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
            this.LimpioFormulario();
        
    }

    private void ActivoBotonesBM()
    {
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;

        btnAgregar.Enabled = false;
        btnBuscar.Enabled = false;

        txtCI.Enabled = false;
    }

    private void ActivoBotonesA()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;

        txtCI.Enabled = false;
    }

    private void LimpioFormulario()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnBuscar.Enabled = true;

        txtCI.Enabled = true;

        txtCI.Text = "0";
        txtNombre.Text = "";

        lblError.Text = "";
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
             Duenio _unD = new Duenio(Convert.ToInt32(txtCI.Text), txtNombre.Text.Trim());

             Logica.LogicaDueño.Alta(_unD);
             lblError.Text = "Alta con exito";

             //limpio pantalla
             this.LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            int _cedula = Convert.ToInt32(txtCI.Text);
            Duenio _objeto = Logica.LogicaDueño.Buscar(_cedula);

            //determino acciones
            if (_objeto == null)
            {
                //alta
                this.ActivoBotonesA();
                Session["DuenioABM"] = null;
            }
            else
            {
                this.ActivoBotonesBM();
                Session["DuenioABM"] = _objeto;

                txtNombre.Text = _objeto.Nombre;
             }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Duenio _und = (Duenio)Session["DuenioABM"];

            //modifico el objeto
            _und.Nombre = txtNombre.Text.Trim();

            Logica.LogicaDueño.Modificar(_und);
            lblError.Text = "Modificacion con éxito";
            this.LimpioFormulario();
         }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Duenio _und = (Duenio)Session["DuenioABM"];

            Logica.LogicaDueño.Eliminar(_und);

            lblError.Text = "Eliminacion con éxito";
            this.LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
