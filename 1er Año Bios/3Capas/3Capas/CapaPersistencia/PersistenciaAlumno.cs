using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace CapaPersistencia
{
    public class PersistenciaAlumno
    {
        public static int Agregar(Alumno alumno)
        {
            SqlConnection cnn = new SqlConnection("data source =.\\SQLEXPRESS;initial catalog=Academia;integrated security = true");
            string variable = "insert into Alumnos values(" + alumno.CiAlumno + "," + "'" + alumno.Nombre + "'" + "," + alumno.Generacion + "," + "'" + alumno.NomCalle + "'" + ","+ alumno.NroPuerta + ")";
            SqlCommand cmd = new SqlCommand(variable, cnn);

            try
            {
                cnn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }

        public static List<Alumno> ListarTodos()
        {
            List<Alumno> lista = new List<Alumno>();
            SqlConnection cnn = new SqlConnection("data source =.\\SQLEXPRESS;initial catalog=Academia;integrated security = true");
            SqlCommand cmd = new SqlCommand("select * from Alumnos", cnn);

            try
            {
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Alumno alumno = new Alumno();
                    alumno.CiAlumno = Convert.ToInt32(lector["Ci"].ToString());
                    alumno.Nombre = lector["nombre"].ToString();

                    lista.Add(alumno);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }

        public static Alumno MostrarDatos(int CiAlumno)
        {
            Alumno alumno = new Alumno();
            SqlConnection cnn = new SqlConnection("data source =.\\SQLEXPRESS;initial catalog=Academia;integrated security = true");
            SqlCommand cmd = new SqlCommand("select * from Alumnos where Ci="+CiAlumno , cnn);

            try
            {
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    alumno.CiAlumno = Convert.ToInt32(lector["Ci"].ToString());
                    alumno.Nombre = lector["nombre"].ToString();
                    alumno.Generacion = Convert.ToInt32(lector["gen"].ToString());
                    alumno.NomCalle = lector["CalleDireccion"].ToString();
                    alumno.NroPuerta = Convert.ToInt32(lector["NroDireccion"].ToString());
                }
                return alumno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }

        }

        public static int Modificar(Alumno AlumMod )
        {
            string cadena = "update Alumnos set Nombre= '" + AlumMod.Nombre + "', gen=" + AlumMod.Generacion + ", CalleDireccion='" + AlumMod.NomCalle + "', NroDireccion=" + AlumMod.NroPuerta + " where Ci = " + AlumMod.CiAlumno;
            SqlConnection cnn = new SqlConnection("data source =.\\SQLEXPRESS;initial catalog=Academia;integrated security = true");
            SqlCommand cmd = new SqlCommand(cadena, cnn);

            try
            {
                cnn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }

            
        }

        public static int Eliminar(Alumno Ci)
        {
            string cadena = "delete Alumnos where Ci ="+Ci.CiAlumno;
            SqlConnection cnn = new SqlConnection("data source =.\\SQLEXPRESS;initial catalog=Academia;integrated security = true");
            SqlCommand cmd = new SqlCommand(cadena, cnn);

            try
            {
                cnn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
