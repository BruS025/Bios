using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Articulos
{
    public partial class Articulos : System.Web.UI.Page
    {
        string Conexion_Str = "Data Source=.;Initial Catalog = ArticulosDB; Integrated Security= true;";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //forma sql conectada
        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (txt_Id.Text!="")
            {
                lblMensajes.Text = "No debe poner un valor en campo Id";
            }
            else
             {
            SqlConnection conexion = new SqlConnection(Conexion_Str);
            string query = "insert into Articulos values ('" + txt_Nombre.Text + "','" + txt_Tipo.Text + "')";
            SqlCommand comando = new SqlCommand(query, conexion);


            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

                lblMensajes.Text = "ERROR SQL: " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
             }
        }
        //SP conectado
        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Conexion_Str);
            SqlCommand comando = new SqlCommand("Buscar", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter("@Id", txt_Id.Text);
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
                txt_Nombre.Text = parametroNombre.Value.ToString();
                txt_Tipo.Text = parametroTipo.Value.ToString();


            }
            catch (SqlException ex)
            {

                lblMensajes.Text = "ERROR SQL: " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
             
        }
        //SP conectado
        protected void btn_Modificar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Conexion_Str);
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

                if (resultado==1)
                {
                    lblMensajes.Text = "Se modificó correctamente";
                }
                else
                {
                    lblMensajes.Text = "No se encontro Articulo";
                }
                

            }
            catch (SqlException ex)
            {

                lblMensajes.Text = "ERROR SQL: " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
             
        }
        //sql conectado
        protected void btn_Borrar_Click(object sender, EventArgs e)
        {
            
                SqlConnection conexion = new SqlConnection(Conexion_Str);
                string query = "delete from Articulos where id=" + txt_Id.Text ;
                SqlCommand comando = new SqlCommand(query, conexion);


                try
                {
                    conexion.Open();
                    
                    if (txt_Id.Text!="")
	                    {
		                    lblMensajes.Text="Id tiene que estar vacio";
                    	}
                    lblMensajes.Text ="Correcto";
                    comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {

                    lblMensajes.Text = "ERROR SQL: " + ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

       
    
}