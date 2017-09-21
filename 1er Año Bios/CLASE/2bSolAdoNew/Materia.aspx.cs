using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace _2bSolAdoNew
{
    public partial class Materia : System.Web.UI.Page
    {
        string Conexion_Str = "Data Source=.;Initial Catalog = Academia; Integrated Security= true;";


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarConectado_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Conexion_Str);
            SqlCommand comando = new SqlCommand("SELECT IdMateria, Nombre, CargaHoraria FROM Materias where IdMateria=" + txtNumero.Text, conexion);

            SqlDataReader lector = null;
            lstMaterias.Items.Clear();

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    txtNombre.Text = lector.GetString(1);
                    txtCargaHoraria.Text = lector.GetInt32(2).ToString();

                }

                lector.Close();
            }
            catch (SqlException ex)
            {
                lblResultado.Text = "ERROR DE SQL: " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }

        }

        protected void btnBuscarDesconectado_Click(object sender, EventArgs e)
        {
            //determino la conexion
            SqlConnection conexion = new SqlConnection(Conexion_Str);

            //cargo objeto que busca la info en la bd
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT IdMateria,Nombre,CargaHoraria FROM Materias", conexion);

            //objeto donde se almacenara en memoria la info obtenida
            DataSet ds = new DataSet();

            try
            {
                adaptador.Fill(ds, "Materias"); //FILL consulta los datos y los agrega al dataset

                //cargo la info en la grilla
                txtNombre.Text = ds.Tables["Materias"].Rows[0]["Nombre"].ToString();
                txtCargaHoraria.Text = ds.Tables["Materias"].Rows[1]["CargaHoraria"].ToString();


                //mantengo la info en la memoria del servidor
                Session["dataset"] = ds;
            }
            catch (SqlException ex)
            {
                lblResultado.Text = "ERROR SQL: " + ex.Message;
            }
        }

        protected void btnAgregarConSQL_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Conexion_Str);
            string query = "insert into Materias values (" + txtNumero.Text + "," + "'" + txtNombre.Text + "'" + txtCargaHoraria.Text + ")";
            SqlCommand comando = new SqlCommand(query, conexion);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error" + ex.Message;
            }
            finally
            { conexion.Close(); }
           
            



        }

        protected void btnAgregarConSP_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Conexion_Str);
            SqlCommand comando = new SqlCommand("Agregar", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter("@IdMateria", txtNumero.Text);
            SqlParameter parametro1 = new SqlParameter("@Nombre", txtNombre.Text);
            SqlParameter parametro2 = new SqlParameter("@Año", txtCargaHoraria.Text);
            comando.Parameters.Add(parametro);
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);

            //captura el retorno del SP
            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(Retorno);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                //determino resultado de la ejecucion
                int retorno = (int)comando.Parameters["@Retorno"].Value;
                if (retorno == 0)
                {
                    lblResultado.Text = "no se pudo agregar";
                }
                else if (retorno == -1)
                {
                    lblResultado.Text = "ya existia";
                }
                else
                {
                    lblResultado.Text = "exito";
                }
                txtCargaHoraria.Text = "";
                txtNombre.Text = "";
                txtNumero.Text = "";
            }
            catch (SqlException ex)
            {
                lblResultado.Text = "ERROR SQL: " + ex.Message;

            }
            finally
            {
                conexion.Close();
            }




        }

        protected void btnModificarCon_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Conexion_Str);
            string query = "update Materias set Nombre =  '" + txtNombre.Text + "', CargaHoraria = " + txtCargaHoraria.Text + " where IdMateria= " + txtNumero.Text;
            SqlCommand comando = new SqlCommand(query, conexion);


            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

                lblResultado.Text = "ERROR SQL: " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }

        }

        protected void btnListarMateriasCon_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Conexion_Str);
            SqlCommand comando = new SqlCommand("SELECT IdMateria, Nombre, CargaHoraria FROM Materias", conexion);

            conexion.Open();
            SqlDataReader lector = comando.ExecuteReader();

            if (!lector.HasRows)
            {
                lblResultado.Text = "La tabla no contiene datos";
            }
            else
            {
                lstMaterias.Items.Clear();
                while (lector.Read())
                {
                    lstMaterias.Items.Add(lector["IdMateria"].ToString() + "" + lector["Nombre"].ToString() + "" + lector["CargaHoraria"].ToString());
                }
                lector.Close();

            }

        }

        protected void btnListarMateriasDesc_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Conexion_Str);

            string SQL = "SELECT IdMateria, Nombre, CargaHoraria FROM Materias";

            SqlDataAdapter adaptador = new SqlDataAdapter(SQL, conexion);

            DataSet ds = new DataSet();

            try
            {
                adaptador.Fill(ds, "Materias");

                grdMaterias.DataSource = ds.Tables["Materias"];

                grdMaterias.DataBind();

                // Session["dataset"] = ds;

            }
            catch (SqlException ex)
            {
                lblResultado.Text = "ERROR SQL: " + ex.Message;

            }

        }


    }
}