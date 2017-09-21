using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaCasa : IPersistenciaCasa
    {
        // Singleton
        private static PersistenciaCasa _instancia = null;
        private PersistenciaCasa() { }

        // OBTENER
        public static PersistenciaCasa ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaCasa();

            return _instancia;
        }

        // AGREGAR
        public void Agregar(Casa casa)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("CREAR_CASA", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _padron = new SqlParameter("@Padron", casa.Padron);
            SqlParameter _nombre = new SqlParameter("@Nombre", casa.Zona.Nombre);
            SqlParameter _departamento = new SqlParameter("@Departamento", casa.Zona.Departamento);
            SqlParameter _nombreLogueo = new SqlParameter("@NombreLogueo", casa.Empleado.NombreLogueo);
            SqlParameter _precio = new SqlParameter("@Precio", casa.Precio);
            SqlParameter _direccion = new SqlParameter("@Direccion", casa.Direccion);
            SqlParameter _tipoDeAccion = new SqlParameter("@TipoDeAccion", casa.TipoDeAccion);
            SqlParameter _baño = new SqlParameter("@Banios", casa.Baño);
            SqlParameter _habitaciones = new SqlParameter("@Habitaciones", casa.Habitaciones);
            SqlParameter _metrosCuadradosP = new SqlParameter("@MetrosCuadradosP", casa.MetrosCuadradosP);
            SqlParameter _fondoJardin = new SqlParameter("@FondoJardin", casa.FondoJardin);
            SqlParameter _metrosCuadradosC = new SqlParameter("@MetrosCuadradosC", casa.MetrosCuadradosC);
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
            _Comando.Parameters.Add(_fondoJardin);
            _Comando.Parameters.Add(_metrosCuadradosC);
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
        public void Eliminar(Casa casa)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("BORRAR_CASA", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _padron = new SqlParameter("@Padron", casa.Padron);
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
                    throw new Exception("El casa no existe..");
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
        public void Modificar(Casa casa)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("MODIFICAR_CASA", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _padron = new SqlParameter("@Padron", casa.Padron);
            SqlParameter _nombre = new SqlParameter("@Nombre", casa.Zona.Nombre);
            SqlParameter _departamento = new SqlParameter("@Departamento", casa.Zona.Departamento);
            SqlParameter _nombreLogueo = new SqlParameter("@NombreLogueo", casa.Empleado.NombreLogueo);
            SqlParameter _precio = new SqlParameter("@Precio", casa.Precio);
            SqlParameter _direccion = new SqlParameter("@Direccion", casa.Direccion);
            SqlParameter _tipoDeAccion = new SqlParameter("@TipoDeAccion", casa.TipoDeAccion);
            SqlParameter _baño = new SqlParameter("@Banios", casa.Baño);
            SqlParameter _habitaciones = new SqlParameter("@Habitaciones", casa.Habitaciones);
            SqlParameter _metrosCuadradosP = new SqlParameter("@MetrosCuadradosP", casa.MetrosCuadradosP);
            SqlParameter _fondoJardin = new SqlParameter("@Fondo_Jardin", casa.FondoJardin);
            SqlParameter _metrosCuadradosC = new SqlParameter("@MetrosCuadradosC", casa.MetrosCuadradosC);
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
            _Comando.Parameters.Add(_fondoJardin);
            _Comando.Parameters.Add(_metrosCuadradosC);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                _Afectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (_Afectados == -1)
                {
                    throw new Exception("El casa no existe..");
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
        public Casa Buscar(int Padron)
        {

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("BUSCAR_CASA " + Padron, _Conexion);

            SqlDataReader _Reader;

            Casa casa = null;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                if (_Reader.Read())
                {
                    int _Habitaciones = (int)_Reader["Habitaciones"];
                    int _Banios = (int)_Reader["Banios"];
                    bool _FondoJardin = (bool)_Reader["FondoJardin"];
                    int _MetrosCuadradosP = (int)_Reader["MetrosCuadradosP"];
                    int _Precio = (int)_Reader["Precio"];
                    string _Direccion = (string)_Reader["Direccion"];
                    int _MetrosCuadradosC = (int)_Reader["MetrosCuadradosC"];
                    string _TipoDeAccion = (string)_Reader["TipoDeAccion"];
                    string _NombreLogueo = (string)_Reader["NombreLogueo"];
                    string _Nombre = (string)_Reader["Nombre"];
                    string _Departamento = (string)_Reader["Departamento"];

                    // OBJETOS VACIOS
                    List<string> servicios = new List<string>();
                    Zona zona = new Zona(_Nombre, _Departamento, "", 0, servicios, true);
                    Empleado empleado = new Empleado("", "1234512345", true);

                    // OBJETO A DEVOLVER
                    casa = new Casa(Padron, zona, empleado, _Precio, _Direccion, _TipoDeAccion, _Banios, _Habitaciones, _MetrosCuadradosP, _FondoJardin, _MetrosCuadradosC);

                }

                if (_Reader.HasRows == false)
                {
                    return casa;
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
            return casa;
        }

        // LISTAR
        public List<Casa> Listar()
        {
            List<Casa> _Lista = new List<Casa>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("LISTAR_CASA", _Conexion);
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
                    bool FondoJardin = (bool)_Reader["FondoJardin"];
                    int MetrosCuadradosC= (int)_Reader["MetrosCuadradosC"];

                    Empleado empleado = new Empleado(NombreLogueo, "1234123412", true);
                    List<string> zonas = new List<string>();
                    Zona zona = new Zona(Nombre, Departamento, "", 0, zonas, true);

                    Casa casa = new Casa(Padron,zona,empleado,Precio,Direccion,TipoDeAccion,Baño,Habitaciones,MetrosCuadradosP,FondoJardin,MetrosCuadradosC);

                    _Lista.Add(casa);

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
