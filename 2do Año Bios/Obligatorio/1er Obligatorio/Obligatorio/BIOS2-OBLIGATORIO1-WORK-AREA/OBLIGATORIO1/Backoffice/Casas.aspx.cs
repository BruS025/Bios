using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Casas : System.Web.UI.Page
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
                btCrearCasa.Visible = false;
                btModificarCasa.Visible = false;
                btEliminarCasa.Visible = false;
                botones.Visible = true;

                throw new Exception("Debe ingresar un padron..");
            }

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            Propiedad propiedad = LPropiedad.Buscar(Convert.ToInt32(txtBuscar.Text));

            // MODIFICAR/ELIMINAR PROPIEDAD
            if (propiedad is Casa)
            {
                Session["Casa"] = propiedad;
                btCrearCasa.Visible = false;
                btModificarCasa.Visible = true;
                btEliminarCasa.Visible = true;
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
                FondoJardin.Checked = ((Casa)propiedad).FondoJardin;
                txtMetrosCuadradosC.Text = Convert.ToString(((Casa)propiedad).MetrosCuadradosC);
                txtPrecio.Text = Convert.ToString(propiedad.Precio);

            }

            // PROPIEDAD EXISTENTE DE OTRO TIPO
            else if (propiedad != null)
            {
                btCrearCasa.Visible = false;
                btModificarCasa.Visible = false;
                btEliminarCasa.Visible = false;
                botones.Visible = true;
                cuadroPropiedad.Visible = false;
                throw new Exception("El padron ingresado no pertenece a una casa..");

            }

            // CREAR PROPIEDAD
            else
            {
                Session["Casa"] = txtBuscar.Text;
                lbResultado.Text = "";
                btCrearCasa.Visible = true;
                btModificarCasa.Visible = false;
                btEliminarCasa.Visible = false;
                LimpiarCampos();
                botones.Visible = true;
                txtPadron.Text = (string)Session["Casa"];

            }

            cuadroPropiedad.Visible = true;

        }

        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // CREAR
    protected void btCrearCasa_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtBaños.Text == "" || txtDireccion.Text == "" || txtHabitaciones.Text == "" || txtMetrosCuadradosP.Text == "" || txtPadron.Text == "" || txtMetrosCuadradosC.Text == "" || txtPrecio.Text == "")
            {
                throw new Exception("Debe completar los campos..");
            }

            List<string> listadoServicios = null;
            Zona zona = new Zona(ZonasControl1.getNombre(), ZonasControl1.getDepartamento(), "", 0, listadoServicios, true);
            Empleado empleado = (Empleado)Session["Empleado"];

            Casa casa = new Casa(Convert.ToInt32(Session["Casa"]), zona, empleado, Convert.ToInt32(txtPrecio.Text), txtDireccion.Text, ddlTipoAccion.SelectedValue, Convert.ToInt32(txtBaños.Text), Convert.ToInt32(txtHabitaciones.Text), Convert.ToInt32(txtMetrosCuadradosP.Text), FondoJardin.Checked, Convert.ToInt32(txtMetrosCuadradosC.Text));

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            LPropiedad.Agregar(casa);

            lbResultado.Text = "Se ha creado casa satisfactoriamente";

            LimpiarCampos();
            cuadroPropiedad.Visible = false;
            btCrearCasa.Visible = false;
            btModificarCasa.Visible = false;
            btEliminarCasa.Visible = false;

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // MODIFICAR
    protected void btModificarCasa_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtBaños.Text == "" || txtDireccion.Text == "" || txtHabitaciones.Text == "" || txtMetrosCuadradosP.Text == "" || txtPadron.Text == "" || txtMetrosCuadradosC.Text == "" || txtPrecio.Text == "")
            {
                throw new Exception("Debe completar los campos..");
            }

            Empleado empleado = (Empleado)Session["Empleado"];

            Casa casa = (Casa)Session["Casa"];

            casa.Empleado = empleado;
            casa.Zona.Nombre = ZonasControl1.getNombre();
            casa.Zona.Departamento = ZonasControl1.getDepartamento();
            casa.Precio = Convert.ToInt32(txtPrecio.Text);
            casa.Direccion = txtDireccion.Text;
            casa.TipoDeAccion = ddlTipoAccion.SelectedValue;
            casa.Baño = Convert.ToInt32(txtBaños.Text);
            casa.Habitaciones = Convert.ToInt32(txtHabitaciones.Text);
            casa.MetrosCuadradosP = Convert.ToInt32(txtMetrosCuadradosP.Text);
            casa.FondoJardin= FondoJardin.Checked;
            casa.MetrosCuadradosC= Convert.ToInt32(txtMetrosCuadradosC.Text);

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            LPropiedad.Modificar(casa);

            lbResultado.Text = "Se ha modificado propiedad satisfactoriamente";

            cuadroPropiedad.Visible = false;
            btEliminarCasa.Visible = false;
            btCrearCasa.Visible = false;
            btModificarCasa.Visible = false;

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // ELIMINAR
    protected void btEliminarCasa_Click(object sender, EventArgs e)
    {
        try
        {

            Casa casa = (Casa)Session["Casa"];

            ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
            LPropiedad.Eliminar(casa);

            lbResultado.Text = "Se ha eliminado propiedad satisfactoriamente";

            cuadroPropiedad.Visible = false;
            btEliminarCasa.Visible = false;
            btCrearCasa.Visible = false;
            btModificarCasa.Visible = false;

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // LIMPIAR CAMPOS
    protected void LimpiarCampos()
    {
        txtPadron.Text = "";
        txtBaños.Text = "";
        txtDireccion.Text = "";
        txtHabitaciones.Text = "";
        txtMetrosCuadradosP.Text = "";
        txtMetrosCuadradosC.Text = "";
        txtPrecio.Text = "";
        FondoJardin.Checked = false;
    }
}