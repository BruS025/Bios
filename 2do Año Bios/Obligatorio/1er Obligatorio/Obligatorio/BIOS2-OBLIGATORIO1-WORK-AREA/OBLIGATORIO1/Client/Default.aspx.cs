using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class _Default : System.Web.UI.Page
{
    // PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            CargarPropiedades();

        }
    }

    // BUSCAR
    protected void btBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            List<Propiedad> listadoPropiedades = (List<Propiedad>)Session["Propiedades"];
            List<Propiedad> ListarResultado = new List<Propiedad>();

            string departamento = ZonaControl.getDepartamento();
            string nombre = ZonaControl.getNombre();
            string tipoAccion = ddlTipoAccion.SelectedValue;
            int desde = 0;
            int hasta = 999999999;

            if (txtDesde.Text != "")
            {
                desde = Convert.ToInt32(txtDesde.Text);
            }

            if (txtHasta.Text != "")
            {
                hasta = Convert.ToInt32(txtHasta.Text);
            }

            if(ddlTipoPropiedad.SelectedValue == "Apartamento")
            {
                List<Apartamento> listadoApartamento = new List<Apartamento>();

                foreach(Propiedad apartamento in listadoPropiedades)
                {
                    if(apartamento is Apartamento)
                    {
                        listadoApartamento.Add((Apartamento)apartamento);
                    }
                    
                }

                ListarResultado = (from apartamentos in (listadoApartamento)
                                   where apartamentos.Zona.Nombre.Contains(nombre) &&
                                   apartamentos.Zona.Departamento.Contains(departamento) &&
                                   apartamentos.Precio > desde &&
                                   apartamentos.Precio < hasta
                                   select apartamentos).ToList<Propiedad>();

                Repeater1.DataSource = ListarResultado;
                Repeater1.DataBind();

            }

            else if (ddlTipoPropiedad.SelectedValue == "Casa")
            {
                List<Casa> listadoCasa = new List<Casa>();

                foreach (Propiedad casa in listadoPropiedades)
                {
                    if (casa is Casa)
                    {
                        listadoCasa.Add((Casa)casa);
                    }

                }

                ListarResultado = (from casas in (listadoCasa)
                                   where casas.Zona.Nombre.Contains(nombre) &&
                                   casas.Zona.Departamento.Contains(departamento) &&
                                   casas.Precio > desde &&
                                   casas.Precio < hasta
                                   select casas).ToList<Propiedad>();

                Repeater1.DataSource = ListarResultado;
                Repeater1.DataBind();

            }

            else if (ddlTipoPropiedad.SelectedValue == "Local")
            {
                List<Local> listadoLocal = new List<Local>();

                foreach (Propiedad local in listadoPropiedades)
                {
                    if (local is Local)
                    {
                        listadoLocal.Add((Local)local);
                    }

                }

                ListarResultado = (from locales in (listadoLocal)
                                   where locales.Zona.Nombre.Contains(nombre) &&
                                   locales.Zona.Departamento.Contains(departamento) &&
                                   locales.Precio > desde &&
                                   locales.Precio < hasta
                                   select locales).ToList<Propiedad>();

                Repeater1.DataSource = ListarResultado;
                Repeater1.DataBind();

            }

        }
        catch (Exception ex)
        {
            LBResultado.Text = ex.Message;

        }
    }

    // LIMPIAR
    protected void btLimpiar_Click(object sender, EventArgs e)
    {
        try
        {
            ddlTipoAccion.SelectedIndex = 0;
            ZonaControl.setDepartamento("G");
            ddlTipoPropiedad.SelectedIndex = 0;
            txtDesde.Text = "";
            txtHasta.Text = "";
        }

        catch (Exception ex)
        {
            LBResultado.Text = ex.Message;

        }
    }

    // VER
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if(e.CommandName == "Ver")
            {
                //Crear sesion con objeto
                List<Propiedad> listadoPropiedades = (List<Propiedad>)Session["Propiedades"];
                int padron = Convert.ToInt32(((Label)(e.Item.Controls[1])).Text);

                foreach (Propiedad item in listadoPropiedades)
                {
                    if(item.Padron == padron)
                    {
                        if (item is Apartamento)
                        {
                            Session["Ver"] = item;
                        }

                        else if(item is Casa)
                        {
                            Session["Ver"] = item;
                        }
                        else if (item is Local)
                        {
                            Session["Ver"] = item;
                        }
                    }
                }

                Response.Redirect("DetallesPropiedad.aspx");

            }           
        }

        catch (Exception ex)
        {
            LBResultado.Text = ex.Message;

        }
    }

    // CAMBIAR DDL
    protected void ddlTipoAccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarPropiedades();
    }

    // RECARGAR PROPIEDADES
    protected void CargarPropiedades()
    {
        // Listado con todas las propiedades
        List<Propiedad> propiedades2 = new List<Propiedad>();

        ILogicaPropiedad LPropiedad = FabricaLogica.getLogicaPropiedad();
        List<Propiedad> propiedades = LPropiedad.Listar();

        List<Propiedad> _ListarResultados = (from propiedad in (propiedades)
                                             where propiedad.TipoDeAccion.Contains(ddlTipoAccion.SelectedValue)
                                             select propiedad).ToList<Propiedad>();


        Repeater1.DataSource = _ListarResultados;
        Repeater1.DataBind();

        Session["Propiedades"] = null;
        Session["Propiedades"] = propiedades;

    }

}