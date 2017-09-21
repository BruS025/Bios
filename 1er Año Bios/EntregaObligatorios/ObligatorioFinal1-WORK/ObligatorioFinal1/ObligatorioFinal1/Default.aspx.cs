using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

namespace ObligatorioFinal1
{
    public partial class Default : System.Web.UI.Page
    {
        // Cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    // Chequear que el usuario no tiene una session abierta, si la tiene redirigir a pantalla next dependiendo el tipo de usuario
                    if (Session["Usuario"] != null)
                    {

                        if (Session["Usuario"] is Usuario)
                        {
                            Response.Redirect("MantenimientoRealizarPedido.aspx");
                        }

                        else if (Session["Usuario"] is Administrador)
                        {
                            Response.Redirect("BienvenidaAdministrador.aspx");
                        }
                    }
                }

                catch (Exception ex)
                {
                    lbError.Text = ex.Message;
                }
            }
        }

        // Iniciar login
        protected void entrar_Click(object sender, EventArgs e)
        {
            try
            {

                string NomLogueo = inputEmail.Value;

                byte[] stringAByte = System.Text.ASCIIEncoding.ASCII.GetBytes(inputPassword.Value);
                string Password = Convert.ToBase64String(stringAByte);

                Cliente cliente = new Cliente();
                Administrador admin = new Administrador();

                cliente = LogicaUsuario.LoginCliente(NomLogueo, Password);

                if (cliente.UsuarioNombre != null)
                {
                    Session["Usuario"] = cliente;
                    Response.Redirect("MantenimientoRealizarPedido.aspx");

                }

                else
                {
                    admin = LogicaUsuario.LoginAdministrador(NomLogueo, Password);

                    if (admin.UsuarioNombre != null)
                    {
                        Session["Usuario"] = admin;
                        Response.Redirect("BienvenidaAdministrador.aspx");
                    }
                }

                lbError.Text = "Sus credenciales no son validas..";
            }

            catch (Exception ex)
            {
                lbError.Text = ex.Message;
            }
        }

        // Redirigir usuario a pagina de registro
        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}