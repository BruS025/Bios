using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Zonas : System.Web.UI.Page
{
    // PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            prop.Visible = false;
            secServicios.Visible = false;
            botones.Visible = false;

            // LIMITE DE CAMPOS
            TxtNombre.MaxLength = 3;
            TxtHabitantes.MaxLength = 20;
            TxtNombreOficial.MaxLength = 20;
            txtServicio.MaxLength = 20;

        }
    }

    // AGREGAR SERVICIO
    protected void btServicio_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtServicio.Text == "")
            {
                throw new Exception("Debe ingresar un servicio..");
            }

            secServicios.Visible = true;
            lbServicios.Items.Add(txtServicio.Text);
            txtServicio.Text = "";

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // QUITAR SERVICIOS
    protected void btQuitar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtServicio.Text == "")
            {
                throw new Exception("Debe ingresar un servicio..");
            }

            secServicios.Visible = true;
            lbServicios.Items.Remove(txtServicio.Text);
            txtServicio.Text = "";

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // CREAR
    protected void btCrearZona_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtHabitantes.Text == "" || Session["Zona"] == null)
            {
                throw new Exception("Debe completar los campos..");
            }

            // Crear listado de servicios
            List<string> listadoServicios = new List<string>();

            for (int i = 0; i < lbServicios.Items.Count; i++)
            {
                listadoServicios.Add(lbServicios.Items[i].Text);
            }

            Zona zona = new Zona(((string[])Session["Zona"])[1], ((string[])Session["Zona"])[0], TxtNombreOficial.Text, Convert.ToInt32(TxtHabitantes.Text),listadoServicios,true);

            ILogicaZona LZona = FabricaLogica.getLogicaZona();
            LZona.Agregar(zona);

            lbResultado.Text = "Se ha creado zona satisfactoriamente";

            prop.Visible = false;
            secServicios.Visible = false;
            btCrearZona.Visible = false;
            btModificarZona.Visible = false;
            btEliminarZona.Visible = false;
            lbServicios.Items.Clear();

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // MODIFICAR FALTA
    protected void btModificarZona_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtNombre.Text == "" || TxtHabitantes.Text == "" || TxtNombreOficial.Text == "")
            {
                throw new Exception("Debe completar los campos..");
            }

            // TOMAR SERVICIOS
            List<string> listadoServicios = new List<string>();

            for (int i = 0; i < lbServicios.Items.Count; i++)
            {
                listadoServicios.Add(lbServicios.Items[i].Text);
            }

            Zona zona = new Zona(TxtNombre.Text, ddlDepartamentos.SelectedValue, TxtNombreOficial.Text, Convert.ToInt32(TxtHabitantes.Text), listadoServicios, true);

            ILogicaZona LZona = FabricaLogica.getLogicaZona();
            LZona.Modificar(zona);

            lbResultado.Text = "Se ha modificado zona satisfactoriamente";

            prop.Visible = false;
            secServicios.Visible = false;
            btCrearZona.Visible = false;
            btModificarZona.Visible = false;
            btEliminarZona.Visible = false;
            TxtNombre.Text = "";

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }

    // ELIMINAR FALTA
    protected void btEliminarZona_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtNombre.Text == "")
            {
                lbResultado.Text = "Debe de ingresar las letras del barrio a borrar";
            }

            ILogicaZona LZona = FabricaLogica.getLogicaZona();
            LZona.Eliminar((Zona)Session["Zona"]);

            lbResultado.Text = "Se ha eliminado la zona";

            btCrearZona.Visible = false;
            btModificarZona.Visible = false;
            btEliminarZona.Visible = false;
            TxtNombre.Text = "";
            prop.Visible = false;
            secServicios.Visible = false;

        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;
        }
    }

    // LIMPIAR CAMPOS
    protected void LimpiarCampos()
    {
        TxtHabitantes.Text = "";
        TxtNombreOficial.Text = "";
        txtServicio.Text = "";
        lbServicios.Items.Clear();
    }

    // BUSCAR
    protected void btBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            lbServicios.Items.Clear();
            lbResultado.Text = "";

            if (TxtNombre.Text == "")
            {
                throw new Exception("Debe ingresar nombre de zona..");
            }

            ILogicaZona LZona = FabricaLogica.getLogicaZona();
            Zona zona = LZona.Buscar(ddlDepartamentos.SelectedValue, TxtNombre.Text);

            // MODIFICAR/ELIMINAR ZONA
            if(zona != null)
            {
                Session["Zona"] = zona;
                btCrearZona.Visible = false;
                btModificarZona.Visible = true;
                btEliminarZona.Visible = true;
                lbResultado.Text = "";
                LimpiarCampos();

                TxtNombreOficial.Text = zona.NombreOficial;
                TxtHabitantes.Text = Convert.ToString(zona.Habitantes);

                foreach (string servicio in zona.Servicios)
                {
                    lbServicios.Items.Add(servicio);
                }
            }
            // CREAR ZONA
            else
            {
                Session["Zona"] = new string[2] { ddlDepartamentos.SelectedValue, TxtNombre.Text};
                btCrearZona.Visible = true;
                btModificarZona.Visible = false;
                btEliminarZona.Visible = false;
                LimpiarCampos();
                ddlDepartamentos.SelectedValue = ((string [])Session["Zona"])[0];
                TxtNombre.Text = ((string[])Session["Zona"])[1];
            }

            botones.Visible = true;
            lbServicios.Visible = true;
            secServicios.Visible = true;
            prop.Visible = true;
            
        }
        catch (Exception ex)
        {
            lbResultado.Text = ex.Message;

        }
    }
}