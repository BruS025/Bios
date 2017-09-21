using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

public partial class ListarTodoEmp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        string strConexion = "data source=.; Initial Catalog = Empresa; Integrated security = true";
        SqlConnection conexion = new SqlConnection(strConexion);
        SqlCommand comando = new SqlCommand("SELECT * FROM Empleados", conexion);
        lblError.Text = "";

        try
        {
            conexion.Open();
            SqlDataReader lector = comando.EndExecuteReader();
            
            if(!lector.HasRows)
            {
                lblError.Text = "La tabla no contiene datos";
            }
            else
            {
                ltEmpleado.Items.Clear();
                while(lector.Read())
                {
                    //otra forma de obtener datos de un regitro leido por un dataReader
                    ltEmpleado.Items.Add(lector["Nombre"].ToString() + " " + lector["Edad"].ToString());
                }
                lector.Close();
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally
        {
            conexion.Close();
        }
    }
}

