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

public partial class AltaEmpl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        //Conexion a la bd
        SqlConnection conexion = new SqlConnection();
        conexion.ConnectionString = Conexion.Cnn;

        // comando que ejecutara el sp de alta

        SqlCommand comando = new SqlCommand ();
        comando.Connection = conexion;
        comando.CommandText = "AltaEmpleados ";
        comando.CommandType = CommandType.StoredProcedure;

        //parametros para envio de datos al sp
        // SqlParameter define parametros de entrada y salida

        SqlParameter oNombre = new SqlParameter("@nombre", txtNombre.Text);
        SqlParameter oCi = new SqlParameter("@Cedula", txtCI.Text);
        SqlParameter oEdad = new SqlParameter("@edad", txtEdad.Text);
        SqlParameter oSueldo = new SqlParameter("@sueldo", 25);
        SqlParameter oCasado = new SqlParameter("@casado", false);
        SqlParameter oTrabaja = new SqlParameter("@trabaja", 11111111);
        comando.Parameters.Add(oNombre);
        comando.Parameters.Add(oCi);
        comando.Parameters.Add(oEdad);
        comando.Parameters.Add(oSueldo);
        comando.Parameters.Add(oCasado);
        comando.Parameters.Add(oTrabaja);

        //captira el retorno del procedimiento almacenado

        SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
        oRetorno.Direction = ParameterDirection.ReturnValue;
        comando.Parameters.Add(oRetorno);

        try
        {
            //conexion manual a bd

            conexion.Open();

            //ejecucion del sp 

            comando.ExecuteNonQuery();

            //determino resultado de la ejecucion

            int retorno = (int)comando.Parameters["@Retorno"].Value;
            if (retorno == 0)
                lblError.Text = "No se realizo el alta";
            else if (retorno == -1)
                lblError.Text = "La cedula ya existia";
            else
                lblError.Text = "Alta con exito";

            //Limpia la pantall

            txtCI.Text = "";
            txtNombre.Text = "";
            txtNombre.Text = "";
        }
        catch (SqlException ex)
        {
            lblError.Text = "Error de sql" + ex.Message;
        }
        finally
        {
            conexion.Close();
        }
    }
}
