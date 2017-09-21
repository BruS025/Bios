using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using System.Data.SqlClient;

namespace CapaPersistencia
{
    public class PersistenciaMaterias
    {
        public static List<Materias> ListarMaterias()
        {
            List<Materias> lista = new List<Materias>();
            SqlConnection cnn = new SqlConnection("data source =.\\SQLEXPRESS;initial catalog=Academia;integrated security = true");
            SqlCommand cmd = new SqlCommand("select * from Materias", cnn);

            try
            {
                cnn.Open();
                SqlDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Materias materias = new Materias();
                    materias.IdMateria = Convert.ToInt32(lector["IdMateria"].ToString());
                    materias.Nombre = lector["nombre"].ToString();
                    materias.CargaHoraria = Convert.ToInt32(lector["CargaHoraria"].ToString());

                    lista.Add(materias);
                }
                return lista;
            }
            catch (Exception ex)
            {
                //lblresultado.Text = ex.Message;
                return null;
            }
            finally
            {
                cnn.Close();
            }
        }

        public static int AgregarMat(Materias materia)
        {
            SqlConnection cnn = new SqlConnection("data source =.\\SQLEXPRESS;initial catalog=Academia;integrated security = true");
            SqlCommand cmd = new SqlCommand("insert into Materias values(" + materia.IdMateria +","+ "'" + materia.Nombre + "'" +"," + materia.CargaHoraria + ")", cnn);
            
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
