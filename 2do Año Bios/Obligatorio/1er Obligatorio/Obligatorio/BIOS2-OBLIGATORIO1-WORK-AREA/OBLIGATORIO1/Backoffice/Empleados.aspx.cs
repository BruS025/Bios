using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Empleados : System.Web.UI.Page
{
    // PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btCrearEmpleado.Visible = false;
            btModificarEmpleado.Visible = false;
            btEliminarEmpleado.Visible = false;
            crear.Visible = false;


            // LIMITE DE CAMPOS
            int limite = 10;
            txtBuscar.MaxLength = limite;
            TxtNombre.MaxLength = limite;
            TxtContraseña.MaxLength = limite;

        }
    }

    // BUSCAR
    protected void btBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtBuscar.Text == "")
            {
                throw new Exception("Debe ingresar nombre de usuario..");
            }

            ILogicaEmpleado LEmpleado = FabricaLogica.getLogicaEmpleado();
            Empleado empleado = LEmpleado.Buscar(txtBuscar.Text);

            // MODIFICAR/ELIMINAR EMPLEADLO
            if(empleado != null)
            {
                Session["Empleados"] = empleado;
                btCrearEmpleado.Visible = false;
                btModificarEmpleado.Visible = true;
                btEliminarEmpleado.Visible = true;
                lbResultado.Text = "";
                LimpiarCampos();

                // Cargar campos
                TxtNombre.Text = empleado.NombreLogueo;
                TxtContraseña.Text = "******";
                 
            }

            // Crear empleado
            else
            {
                Session["Empleados"] = txtBuscar.Text;
                btCrearEmpleado.Visible = true;
                btModificarEmpleado.Visible = false;
                btEliminarEmpleado.Visible = false;
                LimpiarCampos();
                TxtNombre.Text = (string)Session["Empleados"];

            }

            crear.Visible = true;
        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // CREAR
    protected void btCrearEmpleado_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtNombre.Text == "" || TxtContraseña.Text == "")
            {
                throw new Exception("Debe completar los campos..");
            }

            Empleado empleado = new Empleado(TxtNombre.Text, TxtContraseña.Text, true);

            ILogicaEmpleado LEmpleado = FabricaLogica.getLogicaEmpleado();
            LEmpleado.Agregar(empleado);

            lbResultado.Text = "Se ha creado empleado satisfactoriamente";
            btCrearEmpleado.Visible = false;
            crear.Visible = false;
            txtBuscar.Text = "";

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // MODIFICAR
    protected void btModificarEmpleado_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtNombre.Text == "" || TxtContraseña.Text == "")
            {
                throw new Exception("Debe completar los campos..");
            }

            Empleado empleado = new Empleado(TxtNombre.Text, TxtContraseña.Text, true);

            ILogicaEmpleado LEmpleado = FabricaLogica.getLogicaEmpleado();
            LEmpleado.Modificar(empleado);

            lbResultado.Text = "Se ha modificado empleado satisfactoriamente";
            lbResultado.Visible = true;
            crear.Visible = false;
            btCrearEmpleado.Visible = false;
            btEliminarEmpleado.Visible = false;
            btModificarEmpleado.Visible = false;
            txtBuscar.Text = "";

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // ELIMINAR
    protected void btEliminarEmpleado_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtNombre.Text == "")
            {
                throw new Exception("Debe completar los campos..");
            }

            if (((Empleado)Session["Empleado"]).NombreLogueo == TxtNombre.Text)
            {
                throw new Exception("No puedes eliminarte a ti mismo..");
            }

            ILogicaEmpleado LEmpleado = FabricaLogica.getLogicaEmpleado();
            LEmpleado.Eliminar(((Empleado)Session["Empleados"]));

            lbResultado.Text = "Se ha eliminado empleado satisfactoriamente";

            crear.Visible = false;
            btEliminarEmpleado.Visible = false;
            btModificarEmpleado.Visible = false;
            txtBuscar.Text = "";

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // LIMPIAR CAMPOS
    protected void LimpiarCampos()
    {
        TxtNombre.Text = "";
        TxtContraseña.Text = "";
        lbResultado.Text = "";
    }
}