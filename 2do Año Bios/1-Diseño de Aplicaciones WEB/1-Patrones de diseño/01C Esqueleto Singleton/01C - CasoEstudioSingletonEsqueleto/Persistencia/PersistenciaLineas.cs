using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaLineas
    {
        internal void AgregarLinea(Linea linea, int idFactura)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaLinea", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter _IdFac = new SqlParameter("@IdFactura", idFactura);
                SqlParameter _CodArt = new SqlParameter("@CodArt", linea.Articulo.Codigo);
                SqlParameter _Cant = new SqlParameter("@Cantidad", linea.IdCantidad);

                oComando.Parameters.Add(_IdFac);
                oComando.Parameters.Add(_CodArt);
                oComando.Parameters.Add(_Cant);

                oComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public List<Linea> BuscarLinea(int id)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BuscarLinea" + id, oConexion);

            SqlDataReader oReader;

            List<Linea> Resultado = new List<Linea>();

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    Resultado.Add(new Linea(id, new Articulo(Convert.ToInt32(oReader["CodArt"]), oReader["NomArt"].ToString(), Convert.ToDecimal(oReader["PreArt"])),
                                                   Convert.ToInt32(oReader["Cantidad"]),id));
                }
                oReader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                oConexion.Close();
            }
            return Resultado;
        }
    }
}
