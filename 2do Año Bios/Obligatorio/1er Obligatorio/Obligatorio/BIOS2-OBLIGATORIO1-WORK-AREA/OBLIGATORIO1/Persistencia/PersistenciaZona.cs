using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaZona : IPersistenciaZona
    {

        // Singleton
        private static PersistenciaZona _instancia = null;
        private PersistenciaZona() { }

        public static PersistenciaZona ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaZona();

            return _instancia;
        }

        // Operaciones de instancia

        // AGREGAR
        public void Agregar(Zona zona )
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("CREAR_ZONA", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nombre = new SqlParameter("@Nombre", zona.Nombre);
            SqlParameter _departamento = new SqlParameter("@Departamento", zona.Departamento);
            SqlParameter _nombreOficial = new SqlParameter("@NombreOficial", zona.NombreOficial);
            SqlParameter _habitantes = new SqlParameter("@Habitantes", zona.Habitantes);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int _Afectados = 0;

            _Comando.Parameters.Add(_nombre);
            _Comando.Parameters.Add(_departamento);
            _Comando.Parameters.Add(_nombreOficial);
            _Comando.Parameters.Add(_habitantes);
            _Comando.Parameters.Add(_Retorno);

            SqlTransaction _miTransaccion = null;

            try
            {
                _Conexion.Open();

                _miTransaccion = _Conexion.BeginTransaction();

                _Comando.Transaction = _miTransaccion;

                _Comando.ExecuteNonQuery();

                _Afectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (_Afectados == -1)
                {
                    throw new Exception("Esta zona ya existe..");
                }

                foreach (var item in zona.Servicios)
                {
                    AgregarZ(zona.Nombre, zona.Departamento ,item, _miTransaccion);
                }
                _miTransaccion.Commit();
            }

            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw new ApplicationException("ERROR: " + ex.Message);
            }

            finally
            {
                _Conexion.Close();
            }
        }

        // ELIMINAR
        public void Eliminar(Zona zona)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("BORRAR_ZONA", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nombre = new SqlParameter("@Nombre", zona.Nombre);
            SqlParameter _departamento = new SqlParameter("@Departamento", zona.Departamento);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int _Afectados = -1;

            _Comando.Parameters.Add(_nombre);
            _Comando.Parameters.Add(_departamento);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                _Afectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (_Afectados == -1 || _Afectados == -2)
                {
                    throw new Exception("Ha ocurrido un error..");
                }

                else if (_Afectados == -3)
                {
                    throw new Exception("Esta zona no existe..");
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

        // MODIFICAR las pk no se modifican
        public void Modificar(Zona zona)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("MODIFICAR_ZONA", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nombre = new SqlParameter("@Nombre", zona.Nombre);
            SqlParameter _departamento = new SqlParameter("@Departamento", zona.Departamento);
            SqlParameter _NombreOficial = new SqlParameter("@NombreOficial", zona.NombreOficial);
            SqlParameter _Habitantes = new SqlParameter("@Habitantes", zona.Habitantes);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int _Afectados = -1;

            _Comando.Parameters.Add(_nombre);
            _Comando.Parameters.Add(_departamento);
            _Comando.Parameters.Add(_NombreOficial);
            _Comando.Parameters.Add(_Habitantes);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                _Afectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (_Afectados == -1)
                {
                    throw new Exception("La zona no existe..");
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

        // BUSCAR
        public Zona Buscar(string departamento, string nombre)
        {
            Zona zona = null;

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("BUSCAR_ZONAS", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nombre = new SqlParameter("@Nombre", nombre);
            SqlParameter _departamento = new SqlParameter("@Departamento", departamento);

            _Comando.Parameters.Add(_departamento);
            _Comando.Parameters.Add(_nombre);

            SqlDataReader _Reader;

            // SERVICIOS          
            SqlCommand _comandoServicios = new SqlCommand("LISTAR_SERVICIOS",_Conexion);
            _comandoServicios.CommandType = CommandType.StoredProcedure;
            _comandoServicios.Parameters.AddWithValue("@Nombre", nombre);
            _comandoServicios.Parameters.AddWithValue("@Departamento", departamento);
            SqlDataReader _ReaderServicios;

            List<string> listadoServicios = new List<string>();
            string nombreOficial = "";
            int habitantes = 0;
            bool activo = false;
            string servicio = "";

            try
            {
                _Conexion.Open();

                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows == false)
                {
                    _Reader.Close();
                    return zona;
                    // throw new Exception("No se han encontrado resultados");
                }

                while (_Reader.Read())
                {

                    nombreOficial = (string)_Reader["NombreOficial"];
                    habitantes = (int)_Reader["Habitantes"];
                    activo = (bool)_Reader["Activo"];
                }
                _Reader.Close();

                _ReaderServicios = _comandoServicios.ExecuteReader();
                if(_ReaderServicios.HasRows)
                {
                    while(_ReaderServicios.Read())
                    {
                        servicio = (string)_ReaderServicios["Servicio"];

                        listadoServicios.Add(servicio);
                    }
                }

                zona = new Zona(nombre, departamento, nombreOficial, habitantes, listadoServicios, activo);

                _Reader.Close();
                _ReaderServicios.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR: " + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return zona;
        }

        // LISTAR
        public List<Zona> Listar()
        {

            List<Zona> _Lista = new List<Zona>();
            List<string> _Servicios = new List<string>();
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("LISTAR_ZONAS", _Conexion);
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    string nombre = (string)_Reader["Nombre"];
                    string departamento = (string)_Reader["Departamento"];
                    string nombreOficial = (string)_Reader["NombreOficial"];
                    int habitantes = Convert.ToInt32(_Reader["Habitantes"]);

                    Zona zona = new Zona(nombre,departamento,nombreOficial,habitantes,_Servicios,true);

                    _Lista.Add(zona);
                }
                _Reader.Close();             
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR: " + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return _Lista;
        }

        // CREAR SERVICIOS
        public void AgregarZ (string Nombre, string Departamento, string Servicios, SqlTransaction _pTransaccion)
        {
            SqlCommand _comando = new SqlCommand("CREAR_SERVICIO", _pTransaccion.Connection);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Nombre", Nombre);
            _comando.Parameters.AddWithValue("@Departamento", Departamento);
            _comando.Parameters.AddWithValue("@Servicio", Servicios);

            SqlParameter _ParRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParRetorno);
            try
            {
                //determino que debo trabajar con la misma transaccion
                _comando.Transaction = _pTransaccion;

                //ejecuto el comando
                _comando.ExecuteNonQuery();

                //verifico si hay errores
                int retorno = Convert.ToInt32(_ParRetorno.Value);
                if (retorno == -1)
                {
                    throw new Exception("Servicio invalido");
                }
                else if (retorno == 0)
                {
                    throw new Exception("Error no Especificado");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // LISTAR SERVICIOS
        protected List<string> CargarServicios(string departamento, string nombre, SqlTransaction _transaccion)
        {
            List<string> listadoServicios = new List<string>();
            SqlCommand _comando = new SqlCommand("LISTAR_SERVICIOS",_transaccion.Connection);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Nombre", nombre);
            _comando.Parameters.AddWithValue("@Departamento", departamento);

            SqlDataReader _Reader;

            try
            {
                _comando.Transaction = _transaccion;
                _Reader = _comando.ExecuteReader();

                while(_Reader.Read())
                {
                    string servicio = (string)_Reader["Servicio"];

                    listadoServicios.Add(servicio);
                }
                _Reader.Close();

                return listadoServicios;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        // BUSCAR
        public Zona BuscarT(string nombre, string departamento)
        {
            Zona zona = null;

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("BUSCAR_ZONAST", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nombre = new SqlParameter("@Nombre", nombre);
            SqlParameter _departamento = new SqlParameter("@Departamento", departamento);

            _Comando.Parameters.Add(_departamento);
            _Comando.Parameters.Add(_nombre);

            SqlDataReader _Reader;

            // SERVICIOS          
            SqlCommand _comandoServicios = new SqlCommand("LISTAR_SERVICIOS", _Conexion);
            _comandoServicios.CommandType = CommandType.StoredProcedure;
            _comandoServicios.Parameters.AddWithValue("@Nombre", nombre);
            _comandoServicios.Parameters.AddWithValue("@Departamento", departamento);
            SqlDataReader _ReaderServicios;

            List<string> listadoServicios = new List<string>();
            string nombreOficial = "";
            int habitantes = 0;
            bool activo = false;
            string servicio = "";

            try
            {
                _Conexion.Open();

                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows == false)
                {
                    _Reader.Close();
                    throw new Exception("No se han encontrado resultados");
                }

                while (_Reader.Read())
                {

                    nombreOficial = (string)_Reader["NombreOficial"];
                    habitantes = (int)_Reader["Habitantes"];
                    activo = (bool)_Reader["Activo"];
                }
                _Reader.Close();

                _ReaderServicios = _comandoServicios.ExecuteReader();
                if (_ReaderServicios.HasRows)
                {
                    while (_ReaderServicios.Read())
                    {
                        servicio = (string)_ReaderServicios["Servicio"];

                        listadoServicios.Add(servicio);
                    }
                }

                zona = new Zona(nombre, departamento, nombreOficial, habitantes, listadoServicios, activo);

                _Reader.Close();
                _ReaderServicios.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR: " + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return zona;
        }

    }
}
