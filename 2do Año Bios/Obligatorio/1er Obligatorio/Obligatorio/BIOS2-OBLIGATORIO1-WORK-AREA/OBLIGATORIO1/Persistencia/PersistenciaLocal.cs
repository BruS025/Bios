using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaLocal : IPersistenciaLocal
    {
        // Singleton
        private static PersistenciaLocal _instancia = null;
        private PersistenciaLocal() { }

        // OBTENER
        public static PersistenciaLocal ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaLocal();

            return _instancia;
        }

        // AGREGAR
        public void Agregar(Local local)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("CREAR_LOCAL", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _padron = new SqlParameter("@Padron", local.Padron);
            SqlParameter _nombre = new SqlParameter("@Nombre", local.Zona.Nombre);
            SqlParameter _departamento = new SqlParameter("@Departamento", local.Zona.Departamento);
            SqlParameter _nombreLogueo = new SqlParameter("@NombreLogueo", local.Empleado.NombreLogueo);
            SqlParameter _precio = new SqlParameter("@Precio", local.Precio);
            SqlParameter _direccion = new SqlParameter("@Direccion", local.Direccion);
            SqlParameter _tipoDeAccion = new SqlParameter("@TipoDeAccion", local.TipoDeAccion);
            SqlParameter _baño = new SqlParameter("@Banios", local.Baño);
            SqlParameter _habitaciones = new SqlParameter("@Habitaciones", local.Habitaciones);
            SqlParameter _metrosCuadradosP = new SqlParameter("@MetrosCuadradosP", local.MetrosCuadradosP);
            SqlParameter _habilitacion = new SqlParameter("@Habilitacion", local.Habilitacion);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = 0;

            _Comando.Parameters.Add(_padron);
            _Comando.Parameters.Add(_nombre);
            _Comando.Parameters.Add(_departamento);
            _Comando.Parameters.Add(_nombreLogueo);
            _Comando.Parameters.Add(_precio);
            _Comando.Parameters.Add(_direccion);
            _Comando.Parameters.Add(_tipoDeAccion);
            _Comando.Parameters.Add(_baño);
            _Comando.Parameters.Add(_habitaciones);
            _Comando.Parameters.Add(_metrosCuadradosP);
            _Comando.Parameters.Add(_habilitacion);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                resultado = (int)_Comando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                {
                    throw new Exception("Este empleado no existe..");
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

        // ELIMINAR
        public void Eliminar(Local local)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("BORRAR_LOCAL", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _padron = new SqlParameter("@Padron", local.Padron);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int _Afectados = -1;

            _Comando.Parameters.Add(_padron);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                _Afectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (_Afectados == -1)
                {
                    throw new Exception("El local no existe..");
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

        // MODIFICAR
        public void Modificar(Local local)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("MODIFICAR_LOCAL", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _padron = new SqlParameter("@Padron", local.Padron);
            SqlParameter _nombre = new SqlParameter("@Nombre", local.Zona.Nombre);
            SqlParameter _departamento = new SqlParameter("@Departamento", local.Zona.Departamento);
            SqlParameter _nombreLogueo = new SqlParameter("@NombreLogueo", local.Empleado.NombreLogueo);
            SqlParameter _precio = new SqlParameter("@Precio", local.Precio);
            SqlParameter _direccion = new SqlParameter("@Direccion", local.Direccion);
            SqlParameter _tipoDeAccion = new SqlParameter("@TipoDeAccion", local.TipoDeAccion);
            SqlParameter _baño = new SqlParameter("@Banios", local.Baño);
            SqlParameter _habitaciones = new SqlParameter("@Habitaciones", local.Habitaciones);
            SqlParameter _metrosCuadradosP = new SqlParameter("@MetrosCuadradosP", local.MetrosCuadradosP);
            SqlParameter _habilitacion = new SqlParameter("@Habilitacion", local.Habilitacion);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int _Afectados = -1;

            _Comando.Parameters.Add(_padron);
            _Comando.Parameters.Add(_nombre);
            _Comando.Parameters.Add(_departamento);
            _Comando.Parameters.Add(_nombreLogueo);
            _Comando.Parameters.Add(_precio);
            _Comando.Parameters.Add(_direccion);
            _Comando.Parameters.Add(_tipoDeAccion);
            _Comando.Parameters.Add(_baño);
            _Comando.Parameters.Add(_habitaciones);
            _Comando.Parameters.Add(_metrosCuadradosP);
            _Comando.Parameters.Add(_habilitacion);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                _Afectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (_Afectados == -1)
                {
                    throw new Exception("El local no existe..");
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
        public Local Buscar(int Padron)
        {

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("BUSCAR_LOCAL " + Padron, _Conexion);

            SqlDataReader _Reader;

            Local local = null;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                if (_Reader.Read())
                {
                    int _Habitaciones = (int)_Reader["Habitaciones"];
                    int _Banios = (int)_Reader["Banios"];
                    int _MetrosCuadradosP = (int)_Reader["MetrosCuadradosP"];
                    int _Precio = (int)_Reader["Precio"];
                    string _Direccion = (string)_Reader["Direccion"];
                    bool _Habilitacion = (bool)_Reader["Habilitacion"];
                    string _TipoDeAccion = (string)_Reader["TipoDeAccion"];
                    string _NombreLogueo = (string)_Reader["NombreLogueo"];
                    string _Nombre = (string)_Reader["Nombre"];
                    string _Departamento = (string)_Reader["Departamento"];

                    // OBJETOS VACIOS
                    List<string> servicios = new List<string>();
                    Zona zona = new Zona(_Nombre, _Departamento, "", 0, servicios, true);
                    Empleado empleado = new Empleado("", "1234512345", true);

                    // OBJETO A DEVOLVER
                    local = new Local(Padron, zona, empleado, _Precio, _Direccion, _TipoDeAccion, _Banios, _Habitaciones, _MetrosCuadradosP, _Habilitacion);

                }

                if (_Reader.HasRows == false)
                {
                    return local;
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
            return local;
        }

        // LISTAR
        public List<Local> Listar()
        {
            List<Local> _Lista = new List<Local>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("LISTAR_LOCAL", _Conexion);
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    int Padron = (int)_Reader["Padron"];
                    string Departamento = (string)_Reader["Departamento"];
                    string Nombre = (string)_Reader["Nombre"];
                    string NombreLogueo = (string)_Reader["NombreLogueo"];
                    int Precio = (int)_Reader["Precio"];
                    string Direccion = (string)_Reader["Direccion"];
                    string TipoDeAccion = (string)_Reader["TipoDeAccion"];
                    int Baño = (int)_Reader["Banios"];
                    int Habitaciones = (int)_Reader["Habitaciones"];
                    int MetrosCuadradosP = (int)_Reader["MetrosCuadradosP"];
                    bool Habilitacion = (bool)_Reader["Habilitacion"];

                    Empleado empleado = new Empleado(NombreLogueo, "1234123412", true);
                    List<string> zonas = new List<string>();
                    Zona zona = new Zona(Nombre, Departamento, "", 0, zonas, true);

                    Local local = new Local(Padron, zona, empleado, Precio, Direccion, TipoDeAccion, Baño, Habitaciones, MetrosCuadradosP, Habilitacion);

                    _Lista.Add(local);

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

    }
}
