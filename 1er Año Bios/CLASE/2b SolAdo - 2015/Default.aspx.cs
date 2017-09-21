using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
     
    protected void btnlistar_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection("data source =.;initial catalog=academia;integrated security = true");
        SqlCommand cmd = new SqlCommand("select * from materias", cnn);

        try
        {
            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                lstmaterias.Items.Add(lector["idmateria"].ToString() + " " + lector["nombre"].ToString() + " " + lector["cargahoraria"].ToString());
            }
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
        finally
        {
            cnn.Close();
        }
    }
     
    protected void btnmostrar_Click(object sender, EventArgs e)
    {
        //Creo conexion y comando para ejecutar alta
        SqlConnection cnn = new SqlConnection("data source =.;initial catalog=academia;integrated security = true");
        SqlCommand cmd = new SqlCommand("select * from materias where idmateria=" + txtnumero.Text, cnn);

        try
        {
            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                lector.Read();
                txtnombre.Text = lector[1].ToString();
                txtcarga.Text = lector[2].ToString();
            }
            else
            {
                lblresultado.Text = "No hay datos";
            }
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
        finally
        {
            cnn.Close();
        }
    }

    protected void btngrilla_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection cnn = new SqlConnection("data source =.;initial catalog=academia;integrated security = true");
            SqlDataAdapter da = new SqlDataAdapter("select * from materias", cnn);
            DataSet datos = new DataSet();
            da.Fill(datos, "materias");

            grdmaterias.DataSource = datos.Tables["materias"];
            grdmaterias.DataBind();
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
    }

    protected void btnalumos_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection("data source =.;initial catalog=academia;integrated security = true");
        SqlCommand cmd = new SqlCommand("select * from alumnos", cnn);
 
        try
        {
            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                LBAlumnos.Items.Add(lector["ci"].ToString() + "    " + lector["nombre"].ToString());
            }
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
        finally
        {
            cnn.Close();
        }
    }

    protected void btnmodificar_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection("data source =.;initial catalog=academia;integrated security = true");
        string cadena = "update  materias set nombre='" + txtnombre.Text + "', cargahoraria= " + txtcarga.Text + " where idmateria = " + txtnumero.Text;
        SqlCommand cmd = new SqlCommand(cadena, cnn);

        try
        {
            cnn.Open();
            lblresultado.Text = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
        finally
        {
            cnn.Close();
        }
    }

    protected void btnagregar_Click(object sender, EventArgs e)
    {
        //determino la conexion y el comando para generar el alta con comando
        //sql manual en la bd
        SqlConnection cnn = new SqlConnection("data source =.;initial catalog=academia;integrated security = true");
        string cadena = "insert into materias values (" + txtnumero.Text + ",'" + txtnombre.Text + "'," + txtcarga.Text + ")";
        
        SqlCommand cmd = new SqlCommand(cadena, cnn);

        try
        {
            cnn.Open();
            //la cantidad de registros afectados se devuelve automaticamente con 
            //la ejecuciuon de la operacion
            lblresultado.Text = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
        finally
        {
            cnn.Close();
        }
    }

    protected void btnagregarsp_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection("data source =.;initial catalog=academia;integrated security = true");
        SqlCommand cmd = new SqlCommand("Agregar", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        //datos que se envian al SP
        cmd.Parameters.AddWithValue("@IdMateria", txtnumero.Text);
        cmd.Parameters.AddWithValue("@nombre", txtnombre.Text);
        cmd.Parameters.AddWithValue("@año", txtcarga.Text);

        // captura Return del SP
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(retorno);

        try
        {
            cnn.Open();
            cmd.ExecuteNonQuery();
            lblresultado.Text = retorno.Value.ToString();
        }
        catch (Exception es)
        {
            lblresultado.Text = es.Message;
        }
        finally
        {
            cnn.Close();
        }

    }

    protected void btnMostrarDes_Click(object sender, EventArgs e)
    {
        DataSet datos = new DataSet();

        try
        {
            SqlConnection cnn = new SqlConnection("data source =.;initial catalog=academia;integrated security = true");
            SqlDataAdapter da = new SqlDataAdapter("select * from materias where idmateria=" + txtnumero.Text, cnn);
            da.Fill(datos, "materias");

            //determino si hay resultado, preguntando si almenos hay un registro en la tabla 
            if (datos.Tables["materias"].Rows.Count > 0)
            {
                txtnumero.Text = datos.Tables["materias"].Rows[0]["idmateria"].ToString();
                txtnombre.Text = datos.Tables["materias"].Rows[0]["nombre"].ToString();
                txtcarga.Text = datos.Tables["materias"].Rows[0]["cargahoraria"].ToString();
            }
            else
            {
                lblresultado.Text = "no existe la materia";
            }
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }

    }

    protected void btnParamOut_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection("data source =.;initial catalog=academia;integrated security = true");
        SqlCommand cmd = new SqlCommand("Salida", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        //parametro de envio de informacion
        SqlParameter id = new SqlParameter("@id", txtnumero.Text);
        cmd.Parameters.Add(id);
        
        //parametro de salida
        SqlParameter sal = new SqlParameter("@nom", SqlDbType.VarChar, 20);
        sal.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(sal);

        try
        {
            cnn.Open();
            //devuelve el primer valor de la primer columna de la consulta
            cmd.ExecuteScalar();
            lblresultado.Text = sal.Value.ToString();
            cnn.Close();
        }
        catch (Exception es)
        {
            lblresultado.Text = es.Message;
        }

    }
  
}
