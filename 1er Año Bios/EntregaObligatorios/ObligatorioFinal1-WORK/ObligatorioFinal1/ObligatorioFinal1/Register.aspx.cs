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
    public partial class Register : System.Web.UI.Page
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
                        Usuario cliente = new Usuario();
                        cliente = (Usuario)Session["Usuario"];

                        if (cliente is Usuario)
                        {
                            //Response.Redirect("MantenimientoRealizarPedido.aspx");
                        }

                        else if (cliente is Administrador)
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

        // Registrar un cliente
        protected void btRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente registrar = new Cliente();

                    if (inputPassword.Value == inputPasswordRepeat.Value) //Verificamos error en la contraseña
                    {
                        registrar.Nombre = inputUsername.Value;
                        registrar.Apellido = inputApellido.Value;
                        byte[] stringAByte = System.Text.ASCIIEncoding.ASCII.GetBytes(inputPassword.Value);
                        string contrasenia = Convert.ToBase64String(stringAByte);

                        registrar.Contrasenia = contrasenia;
                        registrar.Documento = Convert.ToInt32(inputDocumento.Value);
                        registrar.UsuarioNombre = inputEmail.Value;
                        registrar.Tarjeta = Convert.ToInt64(inputTarjeta.Value);
                        registrar.Calle = inputCalle.Value;
                        registrar.Puerta = inputPuerta.Value;

                        int resultado = LogicaUsuario.AgregarC(registrar);

                        if (resultado == -1)
                        {
                            lbError.Text = "El documento y nombre de logueo deben ser unicos..";
                        }

                        else if (resultado == 2)
                        {
                            lbError.Text = "Se ha registrado correctamente";
                            Response.Redirect("Default.aspx");
                        }

                        else
                        {
                            lbError.Text = resultado.ToString();
                        }                       
                    }

                    else
                    {
                        lbError.Text = "La contraseña debe coicidir".ToString();
                    }                                  
            }

            catch (Exception ex)
            {

                lbError.Text = ex.Message;
            }         
        }

    }
}