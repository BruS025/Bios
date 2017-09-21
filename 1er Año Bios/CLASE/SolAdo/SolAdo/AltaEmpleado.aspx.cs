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
    public partial class AltaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            //conexion a la bd
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Conexion.Cnn;

            //comando q ejecutara el SP de alta
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "AltaEmpleados ";
            comando.CommandType = CommandType.StoredProcedure;

            //parametros para envio de datos al SP
            SqlParameter oNombre = new SqlParameter("@nombre", txtNombre.Text);
            SqlParameter oCI = new SqlParameter("@cedula", txtCI.Text);
            SqlParameter oEdad = new SqlParameter("@edad", txtEdad.Text);
            SqlParameter oSueldo = new SqlParameter("@sueldo", 25);
            SqlParameter oCasado = new SqlParameter("@casado", false);
            SqlParameter oTrabaja = new SqlParameter("@trabaja", 11111111);
            comando.Parameters.Add(oNombre);
            comando.Parameters.Add(oCI);
            comando.Parameters.Add(oEdad);
            comando.Parameters.Add(oSueldo);
            comando.Parameters.Add(oCasado);
            comando.Parameters.Add(oTrabaja);

            //captura el retorno del procedimiento almacenado.
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(oRetorno);


            try
            {
                //conexion manual a bd
                conexion.Open();

                //ejecucion del SP
                comando.ExecuteNonQuery();

                //determino resultado de la ejecucion
                int retorno = (int)comando.Parameters["@Retorno"].Value;
                if (retorno == 0)
                    lblError.Text = "no se realizo el alta";
                else if (retorno == -1)
                    lblError.Text = "la cedula ya existia";
                else
                    lblError.Text = "Alta con exito";

                //limpia pantalla
                txtCI.Text = "";
                txtNombre.Text = "";
                txtEdad.Text = "";
            }
            catch (SqlException ex)
            {
                lblError.Text = "ERROR DE SQL: " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}