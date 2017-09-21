using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using System.Web.UI.HtmlControls;
using System.IO;

namespace ObligatorioFinal1
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    if (Session["Usuario"] == null)
                    {
                        Response.Redirect("Default.aspx");
                    }

                    else if (Session["Usuario"] is Cliente)
                    {

                        Response.Redirect("MantenimientoRealizarPedido.aspx");
                    }

                    List<Cargo> listadoCargos = new List<Cargo>(LogicaCargo.Listar());
                 
                    ddlListar.DataSource = listadoCargos;
                    ddlListar.DataBind();

                    ddlCargo.DataSource = listadoCargos;
                    ddlCargo.DataBind();

                    editarDdl.DataSource = listadoCargos;
                    editarDdl.DataBind();

                    CargarGrilla();
                }

                catch (Exception ex)
                {
                    lbError.Text = ex.Message;
                }
            }
        }

        private void CargarGrilla()
        {
            try
            {

                List<Administrador> listadoAdministrador = LogicaUsuario.Listar(Convert.ToInt32(ddlListar.SelectedValue));

                GridAdmins.DataSource = null;

                if (listadoAdministrador != null)
                {
                    if (listadoAdministrador.Count > 0)
                    {
                        GridAdmins.Visible = true;
                        GridAdmins.DataSource = listadoAdministrador;
                        GridAdmins.DataBind();
                    }

                    else
                    {
                        GridAdmins.Visible = false;
                        lbError.Text = "No existen administradores registrados";
                    }
                }

                else
                {
                    GridAdmins.Visible = false;
                    lbError.Text = "No existen administradores registrados";
                }
            }
            catch (Exception)
            {
                lbError.Text = "Ha ocurrido un error";
            }
        }

        protected void btVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> listadoUsuario = new List<Usuario>();

                if (id.Text != "")
                {

                    Usuario admin = LogicaUsuario.Buscar(Convert.ToInt32(id.Text));

                    if (admin.Documento == 0)
                    {
                        CargarGrilla();
                        throw new Exception("ERROR: No se han encontrado coinciencias");
                    }

                    listadoUsuario.Add(admin);

                    GridAdmins.DataSource = null;

                    if (listadoUsuario != null)
                    {
                        if (listadoUsuario.Count > 0)
                        {
                            GridAdmins.Visible = true;
                            GridAdmins.DataSource = listadoUsuario;
                            GridAdmins.DataBind();
                        }
                    }

                    else
                    {
                        GridAdmins.Visible = false;
                        lbError.Text = "No existen Usuarios registrados.";
                    }
                }
                else
                {
                    CargarGrilla();
                }

            }
            catch (Exception ex)
            {
                lbError.Text = ex.Message;
            }
        }

        protected void GridAdmins_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridAdmins.PageIndex = e.NewPageIndex;
            CargarGrilla();
        }

        protected void btGuardarModal_Click(object sender, EventArgs e)
        {
            try
            {

                Administrador admin = new Administrador();
                admin.Documento = Convert.ToInt32(editarDoc.Text);
                admin.UsuarioNombre = editarUsuario.Text;
                admin.Nombre = editarNombre.Text;
                admin.Apellido = editarApellido.Text;
                admin.Cargo = Convert.ToInt32(editarDdl.SelectedValue);
                admin.Contrasenia = modContrasenia.Text;
                admin.Contrasenia = modContraseniaConfirm.Text;

                if (agregarContrasenia.Text != agregarContraseniaConfirm.Text)
                {
                    lbError2.Text = "La contraseña no coincide, vuelva a ingresarla";
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi();</script>");
                }
                else
                {
                    if (editarDoc.Text == "")
                {
                    lbError2.Text = ("ERROR: Ingrese un Documento.");
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi2();</script>");
                }

                int resultado = LogicaUsuario.Modificar(admin, Convert.ToInt32(editarDdl.SelectedValue));

                if (resultado == 2)
                {
                    lbError.Text = "Se ha modificado el administrador satisfactoriamente..";
                    CargarGrilla();

                }
                else
                {
                    lbError.Text = "No se pudo modificar";
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi2();</script>");
                }
                }
            }

            catch (Exception ex)
            {
                lbError.Text = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi2();</script>");
            }
        
    }

        protected void btAgregarModal_Click(object sender, EventArgs e)
        {
            try
            {
                if (docAdmin.Text == "")
                {
                    lbError3.Text = ("ERROR: Ingrese un Documento.");
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi();</script>");

                }

                if (agregarContrasenia.Text != agregarContraseniaConfirm.Text)
                {
                    lbError3.Text = "La contrasenia no coincide, vuelva a ingresarla";
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi();</script>");
                }

                else
                {

                    Administrador nuevoAdmin = new Administrador();

                    nuevoAdmin.Documento = Convert.ToInt32(docAdmin.Text);
                    nuevoAdmin.UsuarioNombre = usAdmin.Text;
                    nuevoAdmin.Nombre = nombreAdmin.Text;
                    nuevoAdmin.Apellido = apellidoAdmin.Text;
                    nuevoAdmin.Cargo = Convert.ToInt32(ddlCargo.SelectedValue);

                    byte[] stringAByte = System.Text.ASCIIEncoding.ASCII.GetBytes(agregarContrasenia.Text);
                    string contrasenia = Convert.ToBase64String(stringAByte);
                    nuevoAdmin.Contrasenia = contrasenia;
            
                    int resultado = LogicaUsuario.Agregar(nuevoAdmin, Convert.ToInt32(ddlCargo.SelectedValue));

                    if (resultado == 2)
                    {
                        lbError.Text = "Administrador agregado..";
                        CargarGrilla();

                        ddlListar.SelectedIndex = 0;
                        docAdmin.Text = "";
                        usAdmin.Text = "";
                        nombreAdmin.Text = "";
                        apellidoAdmin.Text = "";

                    }

                    else if (resultado == 1)
                    {
                        lbError3.Text = " El Documento ingresado ya se encuentra registrado.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi();</script>");
                    }
                    
                    else
                    {
                        lbError3.Text = "No se ha agregado, éste usuario ya se encuentra registrado con otro Cargo..";
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi();</script>");

                    }
                }
            }

            catch (Exception ex)
            {
                lbError3.Text = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi();</script>");
            }
        }
 
        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                btModificarModal.Visible = true;

            }

            catch (Exception ex)
            {

                lbError.Text = (ex.Message);
            }
        }

        protected void GridAdmins_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
              try
              {
                  int resultado = 0;
                  int docEliminar = Convert.ToInt32(GridAdmins.Rows[e.RowIndex].Cells[1].Text);
                  resultado = LogicaUsuario.Eliminar(docEliminar);

                   if (resultado == 1) 
                  {
                      lbError.Text = "Se ha eliminado el administrador.";
                     if (docAdmin.Text != null && docAdmin.Text != "")
                      {
                          if (docEliminar == Convert.ToInt64(docAdmin.Text))
                          {
                            docAdmin.Text = "";
                            usAdmin.Text = "";
                            nombreAdmin.Text = "";
                            apellidoAdmin.Text = "";
                            ddlCargo.SelectedIndex = 0;
                            lbError.Text = "";
                            btModificarModal.Visible = false;
                          }
                      }
                      CargarGrilla();
                  }

                  else if (resultado == -1)
                  {
                      lbError.Text = "No es posible eliminar el usuario.";
                  }
                  else
                  {
                      GridAdmins.Visible = false;
                      lbError.Text = "No existen usuarios registrados.";
                  }
              }
              catch (Exception ex)
              {
                  lbError.Text = ex.Message;
              }      
        }

        // Seleccionar
        protected void GridAdmins_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            editarDoc.Text = this.GridAdmins.Rows[e.NewSelectedIndex].Cells[1].Text;
            editarUsuario.Text = this.GridAdmins.Rows[e.NewSelectedIndex].Cells[2].Text;
            editarNombre.Text = this.GridAdmins.Rows[e.NewSelectedIndex].Cells[3].Text;
            editarApellido.Text = this.GridAdmins.Rows[e.NewSelectedIndex].Cells[4].Text;
            editarDdl.SelectedValue = ddlListar.SelectedValue;          
        }

        // DDL agregar
        protected void ddlCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi();</script>");
        }

        // DDL editar
        protected void editarDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: vpi2();</script>");

        }

        // DDL filtrar
        protected void ddlListar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<Administrador> listadoUsuarios = LogicaUsuario.Listar(Convert.ToInt32(ddlListar.SelectedValue));

                GridAdmins.DataSource = null;

                if (listadoUsuarios != null)
                {
                    if (listadoUsuarios.Count > 0)
                    {
                        GridAdmins.Visible = true;
                        GridAdmins.DataSource = listadoUsuarios;
                        GridAdmins.DataBind();
                        lbError.Text = "";
                    }

                    else
                    {
                        GridAdmins.Visible = false;
                        GridAdmins.DataSource = listadoUsuarios;
                        GridAdmins.DataBind();
                        lbError.Text = "No existen administradores registrados";
                    }
                }

                else
                {
                    GridAdmins.Visible = false;
                    GridAdmins.DataSource = listadoUsuarios;
                    GridAdmins.DataBind();
                    lbError.Text = "No existen administradores registrados";
                }
            }

            catch (Exception ex)
            {
                lbError.Text = "Error :" + ex.Message;
            }
        }      
    }
}