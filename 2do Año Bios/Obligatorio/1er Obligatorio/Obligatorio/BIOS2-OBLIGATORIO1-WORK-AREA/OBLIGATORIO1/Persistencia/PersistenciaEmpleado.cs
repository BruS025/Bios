using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaEmpleado : IPersistenciaEmpleado
    {
        // Singleton
        private static PersistenciaEmpleado _instancia = null;
        private PersistenciaEmpleado() { }

        public static PersistenciaEmpleado ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaEmpleado();

            return _instancia;
        }

        // AGREGAR
        public void Agregar(Empleado empleado)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("CREAR_EMPLEADO", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nombre = new SqlParameter("@NombreLogueo", empleado.NombreLogueo);
            SqlParameter _contraseña = new SqlParameter("@Contrasenia", empleado.Contraseña);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = 0;

            _Comando.Parameters.Add(_nombre);
            _Comando.Parameters.Add(_contraseña);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                resultado = (int)_Comando.Parameters["@Retorno"].Value;

                if(resultado == -1)
                {
                    throw new Exception("Ya existe ese empleado");
                }
            }

            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }

            finally
            {
                _Conexion.Close();
            }
        }

        // ELIMINAR
        public void Eliminar(Empleado empleado)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("BORRAR_EMPLEADO", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nombre = new SqlParameter("@NombreLogueo", empleado.NombreLogueo);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int _Afectados = -1;

            _Comando.Parameters.Add(_nombre);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                _Afectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (_Afectados == -1)
                {
                    throw new Exception("El empleado no existe..");
                }
            }

            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }

            finally
            {
                _Conexion.Close();
            }
        }

        // MODIFICAR
        public void Modificar(Empleado empleado)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("MODIFICAR_EMPLEADO", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nombre = new SqlParameter("@NombreLogueo", empleado.NombreLogueo);
            SqlParameter _contraseña = new SqlParameter("@Contrasenia", empleado.Contraseña);
            SqlParameter _activo = new SqlParameter("@Activo", empleado.Activo);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int _Afectados = 0;

            _Comando.Parameters.Add(_nombre);
            _Comando.Parameters.Add(_contraseña);
            _Comando.Parameters.Add(_activo);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                _Afectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (_Afectados == -1)
                {
                    throw new Exception("El empleado no existe..");
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
        public Empleado Buscar(string nombre)
        {
            Empleado empleado = null;
            string nombreLogueo = "";
            string contraseña = "";
            bool activo = true;

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("BUSCAR_EMPLEADOS " + nombre, _Conexion);

            SqlDataReader _Reader;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                if (_Reader.Read())
                {
                    nombreLogueo = (string)_Reader["NombreLogueo"];
                    contraseña = (string)_Reader["Contrasenia"];
                    activo = true;
                    // activo = (bool)_Reader["Activo"];
                    empleado = new Empleado(nombreLogueo, contraseña, activo);
                }

                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return empleado;
        }

        // LISTAR
        public List<Empleado> Listar()
        {
            string _nombre;
            string _contraseña;
            bool _activo;

            List<Empleado> _Lista = new List<Empleado>();
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("LISTAR_EMPLEADOS", _Conexion);
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    _nombre = (string)_Reader["NombreLogueo"];
                    _contraseña = (string)_Reader["Contrasenia"];
                    _activo = (bool)_Reader["Activo"];

                    Empleado empleado = new Empleado(_nombre, _contraseña, _activo);
                    _Lista.Add(empleado);

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

        // LISTAR TODOS
        public List<Empleado> ListarTodos()
        {
            string _nombre;
            string _contraseña;
            bool _activo;

            List<Empleado> _Lista = new List<Empleado>();
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("LISTAR_EMPLEADOST", _Conexion);
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    _nombre = (string)_Reader["NombreLogueo"];
                    _contraseña = (string)_Reader["Contrasenia"];
                    _activo = (bool)_Reader["Activo"];

                    Empleado empleado = new Empleado(_nombre, _contraseña, _activo);
                    _Lista.Add(empleado);

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

        // LOGIN
        public bool Login(string nombre, string contraseña)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("LOGIN_EMPLEADO", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nombre = new SqlParameter("@NombreLogueo" , nombre);
            SqlParameter _contraseña = new SqlParameter("@Contraseña", contraseña);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            _Comando.Parameters.Add(_nombre);
            _Comando.Parameters.Add(_contraseña);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                resultado = (int)_Comando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                {
                    throw new Exception("Contraseña no valida..");
                }

                else
                {
                    return true;
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
