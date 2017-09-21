using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Locales : System.Web.UI.Page
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
                btCrearLocal.Visible = false;
                btModificarLocal.Visible = false;
                btEliminarLocal.Visible = false;
                botones.Visible = true;

                throw new Exception("Debe ingresar un padron..");
            }

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            Propiedad propiedad = LPropiedad.Buscar(Convert.ToInt32(txtBuscar.Text));

            // MODIFICAR/ELIMINAR PROPIEDAD
            if (propiedad is Local)
            {
                Session["Local"] = propiedad;
                btCrearLocal.Visible = false;
                btModificarLocal.Visible = true;
                btEliminarLocal.Visible = true;
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
                Habilitacion.Checked = ((Local)propiedad).Habilitacion;
                txtPrecio.Text = Convert.ToString(propiedad.Precio);

            }

            // PROPIEDAD EXISTENTE DE OTRO TIPO
            else if (propiedad != null)
            {
                btCrearLocal.Visible = false;
                btModificarLocal.Visible = false;
                btEliminarLocal.Visible = false;
                botones.Visible = true;
                cuadroPropiedad.Visible = false;
                throw new Exception("El padron ingresado no pertenece a un local..");

            }

            // CREAR PROPIEDAD
            else
            {
                Session["Local"] = txtBuscar.Text;
                lbResultado.Text = "";
                btCrearLocal.Visible = true;
                btModificarLocal.Visible = false;
                btEliminarLocal.Visible = false;
                LimpiarCampos();
                txtPadron.Text = (string)Session["Local"];
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
    protected void btCrearLocal_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtBaños.Text == "" || txtDireccion.Text == "" || txtHabitaciones.Text == "" || txtMetrosCuadradosP.Text == "" || txtPadron.Text == "" || txtPrecio.Text == "")
            {
                throw new Exception("Debe completar los campos..");
            }

            List<string> listadoServicios = null;
            Zona zona = new Zona(ZonasControl1.getNombre(), ZonasControl1.getDepartamento(), "", 0, listadoServicios, true);
            Empleado empleado = (Empleado)Session["Empleado"];

            Local local = new Local(Convert.ToInt32(Session["Local"]), zona, empleado, Convert.ToInt32(txtPrecio.Text), txtDireccion.Text, ddlTipoAccion.SelectedValue, Convert.ToInt32(txtBaños.Text), Convert.ToInt32(txtHabitaciones.Text), Convert.ToInt32(txtMetrosCuadradosP.Text), Habilitacion.Checked);

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            LPropiedad.Agregar(local);

            lbResultado.Text = "Se ha creado local satisfactoriamente";

            LimpiarCampos();
            cuadroPropiedad.Visible = false;
            btCrearLocal.Visible = false;
            btModificarLocal.Visible = false;
            btEliminarLocal.Visible = false;

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // MODIFICAR
    protected void btModificarLocal_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtBaños.Text == "" || txtDireccion.Text == "" || txtHabitaciones.Text == "" || txtMetrosCuadradosP.Text == "" || txtPadron.Text == "" || txtPrecio.Text == "")
            {
                throw new Exception("Debe completar los campos..");
            }

            Empleado empleado = (Empleado)Session["Empleado"];

            Local local = (Local)Session["Local"];

            local.Empleado = empleado;
            local.Zona.Nombre = ZonasControl1.getNombre();
            local.Zona.Departamento = ZonasControl1.getDepartamento();
            local.Precio = Convert.ToInt32(txtPrecio.Text);
            local.Direccion = txtDireccion.Text;
            local.TipoDeAccion = ddlTipoAccion.SelectedValue;
            local.Baño = Convert.ToInt32(txtBaños.Text);
            local.Habitaciones = Convert.ToInt32(txtHabitaciones.Text);
            local.MetrosCuadradosP = Convert.ToInt32(txtMetrosCuadradosP.Text);
            local.Habilitacion = Habilitacion.Checked;

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            LPropiedad.Modificar(local);

            lbResultado.Text = "Se ha modificado propiedad satisfactoriamente";

            cuadroPropiedad.Visible = false;
            btEliminarLocal.Visible = false;
            btCrearLocal.Visible = false;
            btModificarLocal.Visible = false;

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // ELIMINAR
    protected void btEliminarLocal_Click(object sender, EventArgs e)
    {
        try
        {

            Propiedad local = (Local)Session["Local"];

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            LPropiedad.Eliminar(local);

            lbResultado.Text = "Se ha eliminado propiedad satisfactoriamente";

            cuadroPropiedad.Visible = false;
            btEliminarLocal.Visible = false;
            btCrearLocal.Visible = false;
            btModificarLocal.Visible = false;

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
        txtPrecio.Text = "";
        Habilitacion.Checked = false;
    }
}