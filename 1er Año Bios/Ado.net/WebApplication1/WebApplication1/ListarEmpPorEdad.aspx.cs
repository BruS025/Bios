using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolAdo
{
    public partial class ListarEmpPorEdad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {

            if (txtEdad.Text == "")
            {
                lblError.Text = "Debe ingresar una edad";
            }
            string strConexion = "data source=.; Initial Catalog = Empresa; Integrated Security = true";
            SqlConnection conexion = new SqlConnection(strConexion);
            SqlCommand comando = new SqlCommand("ListarPorEdad", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter("@edad", txtEdad.Text);
            comando.Parameters.Add(parametro);

            SqlDataReader lector = null;
            ltEmpleado.Items.Clear();

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    //GetXXX -->una forma de obtener los datos de un registro por el DataReader

                    ltEmpleado.Items.Add(lector.GetInt32(0).ToString() + " - " + lector.GetString(1));
                }
                txtEdad.Text = " ";
                lector.Close();
            }
            catch (SqlException ex)
            {
                lblError.Text = "Error de sql: " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}