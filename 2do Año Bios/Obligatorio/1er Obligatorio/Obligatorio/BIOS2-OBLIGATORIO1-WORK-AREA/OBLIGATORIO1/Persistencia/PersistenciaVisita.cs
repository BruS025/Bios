using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaVisita : IPersistenciaVisita
    {
        // Singleton
        private static PersistenciaVisita _instancia = null;
        private PersistenciaVisita() { }

        // OBTENER
        public static PersistenciaVisita ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaVisita();

            return _instancia;
        }

        // AGREGAR
        public void Agregar(Visita visita)
        {

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("CREAR_VISITA", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _padron = new SqlParameter("@Padron", visita.Propiedad.Padron);
            SqlParameter _nombre = new SqlParameter("@Nombre", visita.Nombre);
            SqlParameter _fechaHora = new SqlParameter("@FechaHora", visita.FechaHora);
            SqlParameter _telefono = new SqlParameter("@Telefono", visita.Telefono);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = 0;

            _Comando.Parameters.Add(_padron);
            _Comando.Parameters.Add(_nombre);
            _Comando.Parameters.Add(_fechaHora);
            _Comando.Parameters.Add(_telefono);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                resultado = (int)_Comando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                {
                    throw new Exception("Ustad ya tiene varias visitas para esta propiedad..");
                }

                if(resultado == -2)
                {
                    throw new Exception("Ya existe una visita para esta fecha..");
                }
            }

            catch (Exception ex)
            {

                throw new ApplicationException("ERROR: " + ex.Message);
            }

            finally
            {
                _Conexion.Close();
            }
        }

    }
}
