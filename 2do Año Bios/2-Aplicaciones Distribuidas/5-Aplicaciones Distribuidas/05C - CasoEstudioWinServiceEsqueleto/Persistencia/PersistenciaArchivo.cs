using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaArchivo : IPersistenciaArchivo
    {
        //singleton
        private static PersistenciaArchivo _miInstancia;
        private PersistenciaArchivo() { }
        public static PersistenciaArchivo GetInstancia()
        {
            if (_miInstancia == null)
                _miInstancia = new PersistenciaArchivo();
            return (_miInstancia);
        }

        public void AgregarArchivo(Archivo archivo)
        {

            string _cnn = Conexion.STRConexion;
            SqlConnection oConexion = new SqlConnection(_cnn);
            SqlCommand oComando = new SqlCommand("AltaArchivo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nombre = new SqlParameter("@nom", archivo.Nombre);
            SqlParameter _extension = new SqlParameter("@ext", archivo.Extension);
            SqlParameter _tamanio = new SqlParameter("@tam", archivo.Tamanio);
            SqlParameter _fecha = new SqlParameter("@fecha", archivo.FechaCreacion);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_nombre);
            oComando.Parameters.Add(_extension);
            oComando.Parameters.Add(_tamanio);
            oComando.Parameters.Add(_fecha);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = -1;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El nombre de Archivo ya existe");
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
    }
}
