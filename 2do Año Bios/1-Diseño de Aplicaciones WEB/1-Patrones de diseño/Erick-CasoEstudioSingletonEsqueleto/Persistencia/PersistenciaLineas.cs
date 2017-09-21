using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaLineas
    {
        internal void AltaLineas(LineaFactura linea, int idFactura, SqlConnection conexion = null)
        {
            if (conexion == null) {conexion = new SqlConnection(Conexion.Cnn); }
           
            try
            {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conexion;
                    command.CommandText = "AltaLineaFactura";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@CodArt", linea.Articulo.Codigo));
                    command.Parameters.Add(new SqlParameter("@FacID", idFactura));
                    command.Parameters.Add(new SqlParameter("@Cantidad", linea.Cantidad));

                    command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LineaFactura> BuscarLineas(int id)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("EXEC ListarLineasFactura " + id, conexion);

            SqlDataReader oReader;
            List<LineaFactura> resultado = new List<LineaFactura>();
            try
            {
                conexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    resultado.Add(new LineaFactura(new Articulo(Convert.ToInt32(oReader["CodArt"]), oReader["NomArt"].ToString(), Convert.ToDecimal(oReader["PreArt"])),
                                                   Convert.ToInt32(oReader["LFaCantidad"])));
                }
                oReader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }

        public void EliminarLineas(int idFactura, SqlConnection oConexion)
        {
            if (oConexion == null) { oConexion = new SqlConnection(Conexion.Cnn); }
            SqlCommand oComando = new SqlCommand("EXEC EliminarLineasFactura " + idFactura, oConexion);

            try
            {
                oComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos: " + ex.Message);
            }

        }
    }
}
