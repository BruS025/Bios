using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolAdo
{
    public partial class ListarTodoEmp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            string strConexion = "data source=.; Initial Catalog = Empresa; Integrated Security = true";
            SqlConnection conexion = new SqlConnection(strConexion);
            SqlCommand comando = new SqlCommand("SELECT * FROM Empleados", conexion);
            lblError.Text = "";
            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                if (!lector.HasRows)
                {
                    lblError.Text = "La tabla no contiene datos";
                }
                else
                {
                    ltEmpleado.Items.Clear();
                    while (lector.Read())
                    {
                        //otra forma de obtener datos de un registro leido por un DataReader
                        ltEmpleado.Items.Add(lector["nombre"].ToString() + " " + lector["edad"].ToString());
                    }
                    lector.Close();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}