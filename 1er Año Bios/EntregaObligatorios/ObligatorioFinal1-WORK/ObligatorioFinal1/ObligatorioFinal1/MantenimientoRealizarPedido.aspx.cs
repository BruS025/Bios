using EntidadesCompartidas;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ObligatorioFinal1
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        // Page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["Carrito"] == null)
                    {
                        List<Plato> linea = new List<Plato>();
                        Session["Carrito"] = linea;
                    }

                    else
                    {
                        List<Plato> linea = (List<Plato>)Session["Carrito"];
                    }

                    if (Session["LineaVenta"] == null)
                    {
                        List<Linea> lineaVenta = new List<Linea>();
                        Session["LineaVenta"] = lineaVenta;
                    }

                    else
                    {
                        List<Linea> lineaVenta = (List<Linea>)Session["LineaVenta"];
                    }

                    Session["Platos"] = listadoPlatos;
                    List<Especializacion> listadoEspecializaciones = new List<Especializacion>(LogicaEspecializacion.Listar());

                    ddlEspecializacion.DataSource = listadoEspecializaciones;
                    ddlEspecializacion.DataBind();

                    List<Casa> listadoCasas = new List<Casa>(LogicaCasa.ListarPedido(Convert.ToInt32(ddlEspecializacion.SelectedValue)));
                    Session["Casas"] = listadoCasas;

                    if (listadoCasas.Count > 0)
                    {
                        ddlCasas.DataSource = listadoCasas;
                        ddlCasas.DataBind();
                    }
                    
                    List<Plato> listarPlatos = new List<Plato>(LogicaPlato.ListarPedido(Convert.ToInt32(ddlEspecializacion.SelectedValue), Convert.ToInt64(ddlCasas.SelectedValue)));
                    Session["Platos"] = listarPlatos;

                    if (listarPlatos.Count > 0)
                    {
                        listadoPlatos.DataSource = listarPlatos;
                        listadoPlatos.DataBind();
                    }
                 }

                catch (Exception ex)
                {
                    lbError.Text = ex.Message;
                }
            }
        }

        // Realizar Venta
        protected void btVender_Click(object sender, EventArgs e)
        {
            try
            {
                List<Plato> lineaCarrito = (List<Plato>)Session["Carrito"];
                List<Linea> lineaVenta = (List<Linea>)Session["LineaVenta"];

                // Obtener cliente que queda guardado desde el login
                Cliente cliente = new Cliente();
                cliente = (Cliente)Session["Usuario"];

                // Creo venta
                double totalVenta = 0;
                bool estado = false;

                if (lineaVenta.Count < 1)
                {
                    lbError.Text = "Debes agregar al menos un producto al carrito..";

                }

                else
                {              
               
                Pedido nuevaVenta = new Pedido(1, Convert.ToDateTime(DateTime.Now), Convert.ToDateTime("1990-01-01"), totalVenta, cliente, lineaVenta, estado);

                int resultado = LogicaPedido.Agregar(nuevaVenta,cliente);
                int resultado2 = 0;

                foreach ( Linea lineaAgregar in lineaVenta)
                {
                    // Total de ventas
                    totalVenta = totalVenta + (lineaAgregar.Cantidad * lineaAgregar.UnPlato.Precio);

                    resultado2 = LogicaLinea.Agregar(lineaAgregar, totalVenta, cliente);

                }

                if (resultado == 1 || resultado2 == 2)
                    {
                        lbError.Text = "Venta exitosa, total facturado: " + Convert.ToString(totalVenta);

                        List<Linea> lineaVenta2 = new List<Linea>();
                        Session["LineaVenta"] = lineaVenta2;

                        List<Plato> linea = new List<Plato>();
                        Session["Carrito"] = linea;

                        listadoCarrito.DataSource = linea;
                        listadoCarrito.DataBind();

                        List<Plato> listarPlatos = new List<Plato>(LogicaPlato.ListarPedido(Convert.ToInt32(ddlEspecializacion.SelectedValue), Convert.ToInt64(ddlCasas.SelectedValue)));
                        Session["Platos"] = listarPlatos;

                        if (listarPlatos.Count > 0)
                        {
                            listadoPlatos.DataSource = listarPlatos;
                            listadoPlatos.DataBind();
                        }

                        // Redirigir a un ticket a futuro si da el tiempo
                    }
                }
            }

            catch (Exception ex)
            {
                lbError.Text = ex.Message;
            }
        }

        // DDL especializacion
        protected void ddlEspecializacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<Casa> listadoCasas = new List<Casa>(LogicaCasa.ListarPedido(Convert.ToInt32(ddlEspecializacion.SelectedValue)));
                Session["Casas"] = listadoCasas;

                if (listadoCasas.Count > 0)
                {
                    ddlCasas.DataSource = listadoCasas;
                    ddlCasas.DataBind();
                }

                else
                {
                    lbError.Text = "No existen platos para la casa seleccionada..";
                }

                List<Plato> listarPlatos = new List<Plato>(LogicaPlato.ListarPedido(Convert.ToInt32(ddlEspecializacion.SelectedValue), Convert.ToInt64(ddlCasas.SelectedValue)));
                Session["Platos"] = listadoPlatos;

                if (listarPlatos.Count > 0)
                {
                    listadoPlatos.DataSource = listarPlatos;
                    listadoPlatos.DataBind();
                }

                else
                {
                    listadoPlatos.DataSource = "";
                    listadoPlatos.DataBind();
                    lbError.Text = "No existen platos para la casa seleccionada..";
                }
            }
            catch (Exception ex)
            {

                lbError.Text = ex.Message;
            }                    
        }

        // DDL casas
        protected void ddlCasas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<Plato> listarPlatos = new List<Plato>(LogicaPlato.ListarPedido(Convert.ToInt32(ddlEspecializacion.SelectedValue), Convert.ToInt64(ddlCasas.SelectedValue)));
                Session["Platos"] = listadoPlatos;

                if (listarPlatos.Count > 0)
                {
                    listadoPlatos.DataSource = listarPlatos;
                    listadoPlatos.DataBind();
                }

                else
                {
                    lbError.Text = "No existen platos para la casa seleccionada..";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Quitar del carrito -1
        protected void btQuitarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                List<Linea> lineas = (List<Linea>)Session["LineaVenta"];
                List<Plato> listadoPlatosCarrito = (List<Plato>)Session["Carrito"];

                while (listadoCarrito.GetSelectedIndices().Length > 0 && lineas.Count > 0)
                {                                      
                    if (lineas.Count > 0)
                    {
                        foreach (var linea in lineas.ToList())
                        {
                            if (linea.UnPlato.Id == Convert.ToInt32(listadoCarrito.SelectedValue))
                            {
                                foreach (var plato in listadoPlatosCarrito.ToList())
                                {
                                    if (plato.Id == Convert.ToInt32(listadoCarrito.SelectedValue))
                                    {

                                        listadoPlatosCarrito.Remove(plato);
                                        Session["Carrito"] = listadoPlatosCarrito;

                                        listadoCarrito.Items.Remove(listadoPlatos.SelectedItem);
                                        listadoCarrito.DataSource = listadoPlatosCarrito;
                                        listadoCarrito.DataBind();

                                        lineas.Remove(linea);
                                        Session["LineaVenta"] = lineas;
                                    
                                        lbCantidad.Text = "0";
                                        break;
                                    }
                                }                                
                            }
                        }
                    }

                    else
                    {
                        lbError.Text = "No existen platos en el carrito..";
                    }
                }
            }

            catch (Exception ex)
            {
                lbError.Text = ex.Message;

            }
        }

        // Agregar desde el carrito +1
        protected void btAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                // Contiene listado de codigos para el carrito
                List<Plato> lineaCarrito = (List<Plato>)Session["Carrito"];

                List<Plato> listadoPlatos = (List<Plato>)Session["Platos"];

                bool modificado = false;

                List<Linea> lineaVenta = new List<Linea>();
                lineaVenta = (List<Linea>)Session["LineaVenta"];
                List<Linea> lineaVentaAux = new List<Linea>();
                // Linea de venta tiene Producto y Cantidad 
                
                List<Plato> platos = new List<Plato>(LogicaPlato.ListarPedido(Convert.ToInt32(ddlEspecializacion.SelectedValue), Convert.ToInt64(ddlCasas.SelectedValue)));
                // volver al listadoPlATOS
                if (listadoCarrito.SelectedValue != "")
                {
                    foreach (Plato plato in listadoPlatos)
                    {
                        if (plato.Id == Convert.ToInt32(listadoCarrito.SelectedValue))
                        {
                            if (lineaVenta != null)
                            {
                                if (lineaVenta.Count > 0)
                                {
                                    foreach (Linea lineaVerificar in lineaVenta)
                                    {
                                        if (lineaVerificar.UnPlato.Id == plato.Id)
                                        {

                                            lineaVentaAux = lineaVenta;

                                            foreach (Linea venAux in lineaVentaAux)
                                            {
                                                if (lineaVerificar.UnPlato.Id == venAux.UnPlato.Id)
                                                {
                                                    venAux.Cantidad = venAux.Cantidad + 1;

                                                    Session["LineaVenta"] = lineaVentaAux;

                                                    lbCantidad.Text = Convert.ToString(venAux.Cantidad);

                                                    modificado = true;

                                                }
                                            }
                                        }

                                        else if (Convert.ToInt32(listadoCarrito.SelectedValue) != lineaVerificar.UnPlato.Id && Convert.ToInt32(listadoCarrito.SelectedValue) == plato.Id && modificado == false) // Agregar siguiente producto
                                        {
                                            bool esta = true;

                                            foreach (Plato enElCarrito in lineaCarrito)
                                            {
                                                if (enElCarrito.Id == plato.Id)
                                                {
                                                    esta = false;
                                                }

                                            }

                                            if (esta == false)
                                            {

                                            }

                                            else
                                            {
                                                lineaVentaAux = lineaVenta; // (List<LineaVenta>)Session["LineaVenta"];

                                                Casa casa = new Casa();
                                                casa.RUT = Convert.ToInt64(ddlCasas.SelectedValue);
                                                Linea lineaAgregar = new Linea(plato, casa, 1);
                                                lineaVentaAux.Add(lineaAgregar);

                                                Session["LineaVenta"] = lineaVentaAux; //lineaVentaAux;

                                                lbCantidad.Text = Convert.ToString(lineaAgregar.Cantidad);

                                                lineaCarrito.Add(plato);
                                                listadoCarrito.DataSource = lineaCarrito;
                                                listadoCarrito.DataBind();
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Casa casa2 = new Casa();
                                    casa2.RUT = Convert.ToInt64(ddlCasas.SelectedValue);
                                    Linea lineaAgregar = new Linea(plato, casa2, 1);
                                    lineaVentaAux.Add(lineaAgregar);
                                    Session["LineaVenta"] = lineaVentaAux;

                                    lbCantidad.Text = Convert.ToString(lineaAgregar.Cantidad);

                                    lineaCarrito.Add(plato);

                                    listadoCarrito.DataSource = lineaCarrito;
                                    listadoCarrito.DataBind();
                                }
                            }
                        }
                    }

                foreach (var linea in lineaVenta)
                    {
                        if (linea.UnPlato.Id == Convert.ToInt32(listadoCarrito.SelectedValue) && modificado == false)
                            {
                                linea.Cantidad = linea.Cantidad + 1;
                                Session["LineaVenta"] = lineaVenta;
                                lbCantidad.Text = linea.Cantidad.ToString();

                            }
                    }
                }

                else
                {
                    lbError.Text = "Debe seleccionar un plato del carrito...";
                }


            }

            catch (Exception ex)
            {
                lbError.Text = ex.Message;
            }

        }

        // Agregar desde gondola al carrito
        protected void btAgregarListado_Click(object sender, EventArgs e)
        {
            try
            {
                Linea linea = new Linea();
                List<Linea> lineaVenta = (List<Linea>)Session["LineaVenta"];

                Casa casa = new Casa();
                List<Casa> listadoCasa = (List<Casa>)Session["Casas"];

                Plato plato = new Plato();
                List<Plato> listadoPlato =(List<Plato>)Session["Platos"];

                List<Plato> listadoPlatosCarrito = (List<Plato>)Session["Carrito"];

                while (listadoPlatos.GetSelectedIndices().Length > 0)
                {                   
                    //crea la linea

                    foreach (Casa casaa in listadoCasa)
                    {
                        if (casaa.RUT == Convert.ToInt64(ddlCasas.SelectedValue))
                        {
                            casa = casaa;
                        }
                    }

                    foreach (Plato platoo in listadoPlato)
                    {
                        if ( platoo.Id == Convert.ToInt32(listadoPlatos.SelectedValue))
                        {
                            plato = platoo;
                            linea.UnaCasa = casa;
                            linea.UnPlato = plato;
                            linea.Cantidad = 1;

                            lineaVenta.Add(linea);

                            listadoPlatosCarrito.Add(platoo);
                            Session["Carrito"] = listadoPlatosCarrito;

                            Session["LineaVenta"] = lineaVenta;
                            //agregar el plato a la session
                            lbCantidad.Text = linea.Cantidad.ToString();
                        }
                    }

                    listadoCarrito.DataSource = listadoPlatosCarrito;
                    listadoCarrito.DataBind();
                    break;

                }
            }
            catch (Exception ex)
            {

                lbError.Text = ex.Message;
            }
        }

        // Limpiar carrito
        protected void btLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                listadoCarrito.Items.Clear();

                List<Plato> listarPlatos = new List<Plato>(LogicaPlato.ListarPedido(Convert.ToInt32(ddlEspecializacion.SelectedValue), Convert.ToInt64(ddlCasas.SelectedValue)));

                listadoPlatos.DataSource = listarPlatos;
                listadoPlatos.DataBind();

                List<Linea> borrar = new List<Linea>();
                Session["LineaVenta"] = borrar;

                List<Plato> borrar2 = new List<Plato>();
                Session["Carrito"] = borrar2;

                lbCantidad.Text = "0";
                lbError.Text = "";

            }
            catch (Exception ex)
            {

                lbError.Text = ex.Message;
            }
        }

        // Cargar valores del plato al modal
        protected void listadoPlatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosPlato();         
        }

        protected void CargarDatosPlato()
        {
            try
            {
                List<Plato> platos = new List<Plato>(LogicaPlato.ListarPedido(Convert.ToInt32(ddlEspecializacion.SelectedValue), Convert.ToInt64(ddlCasas.SelectedValue)));
                Session["Platos"] = platos;

                foreach (Plato plato in platos)
                {
                    if (plato.Id == Convert.ToInt32(listadoPlatos.SelectedValue))
                    {
                        verPlato.Mostrar(plato);
                    }
                }
            }
            catch (Exception ex)
            {

                lbError.Text = ex.Message;
            }
        }
    }
}