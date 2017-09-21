using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Articulos
{
    public partial class Articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {

            if (txt_Id.Text != "")
            {
                lblMensajes.ForeColor = Color.Blue;
                lblMensajes.Text = "No debe poner un valor en campo Id";
            }
            else
            {
                if (txt_Nombre.Text == "" || txt_Tipo.Text == "")
                {
                    lblMensajes.ForeColor = Color.Blue;
                    lblMensajes.Text = "Los campos Nombre y Tipo son obligatorios";
                }
                else
                {

                    SqlConnection conexion = new SqlConnection(Conexion.CnnString);
                    string query = "INSERT INTO Articulos VALUES('" + txt_Nombre.Text + "', '" + txt_Tipo.Text + "')";

                    SqlCommand comando = new SqlCommand(query, conexion);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();

                        lblMensajes.ForeColor = Color.Green;
                        lblMensajes.Text = "Articulo agregado con éxito";

                        txt_Id.Text = "";
                        txt_Nombre.Text = "";
                        txt_Tipo.Text = "";
                    }
                    catch (SqlException sqlex)
                    {
                        lblMensajes.ForeColor = Color.Red;
                        lblMensajes.Text = "ERROR SQL: " + sqlex.Message;
                    }
                    catch (Exception ex) {

                        lblMensajes.ForeColor = Color.Red;
                        lblMensajes.Text = "ERROR inesperado: " + ex.Message;
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {

            int id = 0;

            if (!int.TryParse(txt_Id.Text, out id))
            {
                lblMensajes.ForeColor = Color.Blue;
                lblMensajes.Text = "Debe ingresar un Id valido";
            }
            else
            {

                SqlConnection conexion = new SqlConnection(Conexion.CnnString);
                SqlCommand comando = new SqlCommand("Buscar", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parametroId = new SqlParameter("@Id", id);
                SqlParameter parametroNombre = new SqlParameter("@Nombre", SqlDbType.VarChar, 150);
                parametroNombre.Direction = ParameterDirection.Output;
                SqlParameter parametroTipo = new SqlParameter("@Tipo", SqlDbType.VarChar, 50);
                parametroTipo.Direction = ParameterDirection.Output;

                comando.Parameters.Add(parametroId);
                comando.Parameters.Add(parametroNombre);
                comando.Parameters.Add(parametroTipo);

                try
                {
                    conexion.Open();
                    comando.ExecuteScalar();

                    if (parametroNombre.Value.ToString() != "" && parametroTipo.Value.ToString() != "")
                    {
                    
                        txt_Nombre.Text = parametroNombre.Value.ToString();
                        txt_Tipo.Text = parametroTipo.Value.ToString();

                        lblMensajes.ForeColor = Color.Green;
                        lblMensajes.Text = "Artículo encontrado éxito";
                    }
                    else
                    {
                        lblMensajes.ForeColor = Color.Blue;
                        lblMensajes.Text = "Artículo encontrado éxito";
                    }
                }
                catch (SqlException sqlex)
                {
                    lblMensajes.ForeColor = Color.Red;
                    lblMensajes.Text = "ERROR SQL: " + sqlex.Message;
                }
                catch (Exception ex)
                {

                    lblMensajes.ForeColor = Color.Red;
                    lblMensajes.Text = "ERROR inesperado: " + ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
             
        }

        protected void btn_Modificar_Click(object sender, EventArgs e)
        {
            
            int id = 0;

            if (!int.TryParse(txt_Id.Text, out id))
            {
                lblMensajes.ForeColor = Color.Blue;
                lblMensajes.Text = "Debe ingresar un Id valido";
            }
            else
            {
                SqlConnection conexion = new SqlConnection(Conexion.CnnString);
                SqlCommand comando = new SqlCommand("Modificar", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parametroId = new SqlParameter("@Id", txt_Id.Text);
                SqlParameter parametroNombre = new SqlParameter("@Nombre", txt_Nombre.Text);
                SqlParameter parametroTipo = new SqlParameter("@Tipo", txt_Tipo.Text);
             
                comando.Parameters.Add(parametroId);
                comando.Parameters.Add(parametroNombre);
                comando.Parameters.Add(parametroTipo);

                try
                {
                    conexion.Open();
                    int resultado = comando.ExecuteNonQuery();

                    if (resultado == 1)
                    {
                        lblMensajes.ForeColor = Color.Green;
                        lblMensajes.Text = "Se modificó correctamente";
                    }
                    else
                    {
                        lblMensajes.ForeColor = Color.Blue;
                        lblMensajes.Text = "No se encontro Articulo";
                    }
                }
                catch (SqlException sqlex)
                {
                    lblMensajes.ForeColor = Color.Red;
                    lblMensajes.Text = "ERROR SQL: " + sqlex.Message;
                }
                catch (Exception ex)
                {

                    lblMensajes.ForeColor = Color.Red;
                    lblMensajes.Text = "ERROR inesperado: " + ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        protected void btn_Borrar_Click(object sender, EventArgs e)
        {

            int id = 0;

            if (!int.TryParse(txt_Id.Text, out id))
            {
                lblMensajes.ForeColor = Color.Blue;
                lblMensajes.Text = "Debe ingresar un Id valido";
            }
            else
            {
                SqlConnection conexion = new SqlConnection(Conexion.CnnString);
                string query = "DELETE FROM Articulos WHERE id = " + id;
                SqlCommand comando = new SqlCommand(query, conexion);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    lblMensajes.ForeColor = Color.Green;
                    lblMensajes.Text = String.Format("El artículo con el Id ({0}) ha sido borrado", id);

                    txt_Id.Text = "";
                    txt_Nombre.Text = "";
                    txt_Tipo.Text = "";
                }
                catch (SqlException sqlex)
                {
                    lblMensajes.ForeColor = Color.Red;
                    lblMensajes.Text = "ERROR SQL: " + sqlex.Message;
                }
                catch (Exception ex)
                {

                    lblMensajes.ForeColor = Color.Red;
                    lblMensajes.Text = "ERROR inesperado: " + ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }
    }    
}