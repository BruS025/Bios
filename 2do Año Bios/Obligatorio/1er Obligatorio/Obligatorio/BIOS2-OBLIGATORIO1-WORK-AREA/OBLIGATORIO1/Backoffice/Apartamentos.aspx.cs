using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Apartamentos : System.Web.UI.Page
{
    // PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cuadroPropiedad.Visible = false;
            botones.Visible = false;
            LimpiarCampos();

        }
    }

    // BUSCAR
    protected void btBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtBuscar.Text == "")
            {
                btCrearApartamento.Visible = false;
                btModificarApartamento.Visible = false;
                btEliminarApartamento.Visible = false;
                botones.Visible = true;

                throw new Exception ("Debe ingresar un padron..");
            }

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            Propiedad propiedad = LPropiedad.Buscar(Convert.ToInt32(txtBuscar.Text));

            // MODIFICAR/ELIMINAR PROPIEDAD
            if (propiedad is Apartamento)
            {
                Session["Apartamento"] = propiedad;
                btCrearApartamento.Visible = false;
                btModificarApartamento.Visible = true;
                btEliminarApartamento.Visible = true;
                lbResultado.Text = "";
                LimpiarCampos();
                botones.Visible = true;

                // Cargar datos de propiedad
                txtPadron.Text = Convert.ToString(propiedad.Padron);
                ZonasControl1.setDepartamento(propiedad.Zona.Departamento);
                ZonasControl1.setNombre(propiedad.Zona.Nombre);
                txtDireccion.Text = Convert.ToString(propiedad.Direccion);
                ddlTipoAccion.SelectedValue = propiedad.TipoDeAccion;
                txtBaños.Text = Convert.ToString(propiedad.Baño);
                txtHabitaciones.Text = Convert.ToString(propiedad.Habitaciones);
                txtMetrosCuadradosP.Text = Convert.ToString(propiedad.MetrosCuadradosP);
                Asensor.Checked = ((Apartamento)propiedad).Ascensor;
                txtPiso.Text = Convert.ToString(((Apartamento)propiedad).Piso);
                txtPrecio.Text = Convert.ToString(propiedad.Precio);

            }

            // PROPIEDAD EXISTENTE DE OTRO TIPO
            else if ( propiedad != null)
            {
                btCrearApartamento.Visible = false;
                btModificarApartamento.Visible = false;
                btEliminarApartamento.Visible = false;
                botones.Visible = true;
                cuadroPropiedad.Visible = false;
                throw new Exception("El padron ingresado no pertenece a un apartamento..");

            }

            // CREAR PROPIEDAD
            else
            {
                Session["Apartamento"] = txtBuscar.Text;
                lbResultado.Text = "";
                btCrearApartamento.Visible = true;
                btModificarApartamento.Visible = false;
                btEliminarApartamento.Visible = false;
                LimpiarCampos();
                txtPadron.Text = (string)Session["Apartamento"];
                botones.Visible = true;

            }

            cuadroPropiedad.Visible = true;
            
        }

        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // CREAR
    protected void btCrearApartamento_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtBaños.Text == "" || txtDireccion.Text == "" || txtHabitaciones.Text == "" || txtMetrosCuadradosP.Text == "" || txtPadron.Text == "" || txtPiso.Text == "" || txtPrecio.Text == "")
            {
                throw new Exception("Debe completar los campos..");
            }

            List<string> listadoServicios = null;
            Zona zona = new Zona(ZonasControl1.getNombre(), ZonasControl1.getDepartamento(), "", 0, listadoServicios, true);
            Empleado empleado = (Empleado)Session["Empleado"];

            Apartamento apartamento = new Apartamento(Convert.ToInt32(Session["Apartamento"]), zona, empleado, Convert.ToInt32(txtPrecio.Text), txtDireccion.Text, ddlTipoAccion.SelectedValue, Convert.ToInt32(txtBaños.Text), Convert.ToInt32(txtHabitaciones.Text), Convert.ToInt32(txtMetrosCuadradosP.Text), Asensor.Checked, Convert.ToInt32(txtPiso.Text));

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            LPropiedad.Agregar(apartamento);

            lbResultado.Text = "Se ha creado apartamento satisfactoriamente";

            LimpiarCampos();
            cuadroPropiedad.Visible = false;
            btCrearApartamento.Visible = false;
            btModificarApartamento.Visible = false;
            btEliminarApartamento.Visible = false;

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // MODIFICAR
    protected void btModificarApartamento_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtBaños.Text == "" || txtDireccion.Text == "" || txtHabitaciones.Text == "" || txtMetrosCuadradosP.Text == "" || txtPadron.Text == "" || txtPiso.Text == "" || txtPrecio.Text == "")
            {
                throw new Exception("Debe completar los campos..");
            }

            Empleado empleado = (Empleado)Session["Empleado"];

            Apartamento apartamento = (Apartamento)Session["Apartamento"];

            apartamento.Empleado = empleado;
            apartamento.Zona.Nombre = ZonasControl1.getNombre();
            apartamento.Zona.Departamento = ZonasControl1.getDepartamento();
            apartamento.Precio = Convert.ToInt32(txtPrecio.Text);
            apartamento.Direccion = txtDireccion.Text;
            apartamento.TipoDeAccion = ddlTipoAccion.SelectedValue;
            apartamento.Baño = Convert.ToInt32(txtBaños.Text);
            apartamento.Habitaciones = Convert.ToInt32(txtHabitaciones.Text);
            apartamento.MetrosCuadradosP = Convert.ToInt32(txtMetrosCuadradosP.Text);
            apartamento.Ascensor = Asensor.Checked;
            apartamento.Piso = Convert.ToInt32(txtPiso.Text);

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            LPropiedad.Modificar(apartamento);

            lbResultado.Text = "Se ha modificado propiedad satisfactoriamente";

            cuadroPropiedad.Visible = false;
            btEliminarApartamento.Visible = false;
            btCrearApartamento.Visible = false;
            btModificarApartamento.Visible = false;

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // ELIMINAR
    protected void btEliminarApartamento_Click(object sender, EventArgs e)
    {
        try
        {

            Propiedad apartamento = (Apartamento)Session["Apartamento"];

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            LPropiedad.Eliminar(apartamento);

            lbResultado.Text = "Se ha eliminado propiedad satisfactoriamente";

            cuadroPropiedad.Visible = false;
            btEliminarApartamento.Visible = false;
            btCrearApartamento.Visible = false;
            btModificarApartamento.Visible = false;

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // LIMPIAR CAMPOS
    protected void LimpiarCampos()
    {
        // LIMPIAR CAMPOS
        txtPadron.Text = "";
        txtBaños.Text = "";
        txtDireccion.Text = "";
        txtHabitaciones.Text = "";
        txtMetrosCuadradosP.Text = "";
        txtPiso.Text = "";
        txtPrecio.Text = "";
        Asensor.Checked = false;

    }

}