using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaApartamento : IPersistenciaApartamento
    {
        // Singleton
        private static PersistenciaApartamento _instancia = null;
        private PersistenciaApartamento() { }

        // OBTENER
        public static PersistenciaApartamento ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaApartamento();

            return _instancia;
        }

        // AGREGAR
        public void Agregar(Apartamento apartamento)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("CREAR_APARTAMENTO", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _padron = new SqlParameter("@Padron", apartamento.Padron);
            SqlParameter _nombre = new SqlParameter("@Nombre", apartamento.Zona.Nombre);
            SqlParameter _departamento = new SqlParameter("@Departamento", apartamento.Zona.Departamento);
            SqlParameter _nombreLogueo = new SqlParameter("@NombreLogueo", apartamento.Empleado.NombreLogueo);
            SqlParameter _precio = new SqlParameter("@Precio", apartamento.Precio);
            SqlParameter _direccion = new SqlParameter("@Direccion", apartamento.Direccion);
            SqlParameter _tipoDeAccion = new SqlParameter("@TipoDeAccion", apartamento.TipoDeAccion);
            SqlParameter _baño = new SqlParameter("@Banios", apartamento.Baño);
            SqlParameter _habitaciones = new SqlParameter("@Habitaciones", apartamento.Habitaciones);
            SqlParameter _metrosCuadradosP = new SqlParameter("@MetrosCuadradosP", apartamento.MetrosCuadradosP);
            SqlParameter _ascensor = new SqlParameter("@Asensor", apartamento.Ascensor);
            SqlParameter _piso = new SqlParameter("@Piso", apartamento.Piso);
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
            _Comando.Parameters.Add(_ascensor);
            _Comando.Parameters.Add(_piso);
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
        public void Eliminar(Apartamento apartamento)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("BORRAR_APARTAMENTO", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _padron = new SqlParameter("@Padron", apartamento.Padron);
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
                    throw new Exception("El apartamento no existe..");
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
        public void Modificar(Apartamento apartamento)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("MODIFICAR_APARTAMENTO", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _padron = new SqlParameter("@Padron", apartamento.Padron);
            SqlParameter _nombre = new SqlParameter("@Nombre", apartamento.Zona.Nombre);
            SqlParameter _departamento = new SqlParameter("@Departamento", apartamento.Zona.Departamento);
            SqlParameter _nombreLogueo = new SqlParameter("@NombreLogueo", apartamento.Empleado.NombreLogueo);
            SqlParameter _precio = new SqlParameter("@Precio", apartamento.Precio);
            SqlParameter _direccion = new SqlParameter("@Direccion", apartamento.Direccion);
            SqlParameter _tipoDeAccion = new SqlParameter("@TipoDeAccion", apartamento.TipoDeAccion);
            SqlParameter _baño = new SqlParameter("@Banios", apartamento.Baño);
            SqlParameter _habitaciones = new SqlParameter("@Habitaciones", apartamento.Habitaciones);
            SqlParameter _metrosCuadradosP = new SqlParameter("@MetrosCuadradosP", apartamento.MetrosCuadradosP);
            SqlParameter _ascensor = new SqlParameter("@Ascensor", apartamento.Ascensor);
            SqlParameter _piso = new SqlParameter("@Piso", apartamento.Piso);
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
            _Comando.Parameters.Add(_ascensor);
            _Comando.Parameters.Add(_piso);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                _Afectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (_Afectados == -1)
                {
                    throw new Exception("El apartamento no existe..");
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
        public Apartamento Buscar(int Padron)
        {

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("BUSCAR_APARTAMENTO " + Padron, _Conexion);

            SqlDataReader _Reader;

            Apartamento apartamento = null;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                if (_Reader.Read())
                {
                    int _Habitaciones = (int)_Reader["Habitaciones"];
                    int _Banios = (int)_Reader["Banios"];
                    int _Piso = (int)_Reader["Piso"];
                    int _MetrosCuadradosP = (int)_Reader["MetrosCuadradosP"];
                    int _Precio = (int)_Reader["Precio"];
                    string _Direccion = (string)_Reader["Direccion"];
                    bool _Ascensor = (bool)_Reader["Ascensor"];
                    string _TipoDeAccion = (string)_Reader["TipoDeAccion"];
                    string _NombreLogueo = (string)_Reader["NombreLogueo"];
                    string _Nombre = (string)_Reader["Nombre"];
                    string _Departamento = (string)_Reader["Departamento"];

                    // OBJETOS VACIOS
                    List<string> servicios = new List<string>();
                    Zona zona = new Zona(_Nombre,_Departamento,"",0,servicios,true);
                    Empleado empleado = new Empleado("","1234512345", true);

                    // OBJETO A DEVOLVER
                    apartamento = new Apartamento(Padron,zona,empleado,_Precio,_Direccion,_TipoDeAccion,_Banios,_Habitaciones,_MetrosCuadradosP,_Ascensor,_Piso);

                }

                if(_Reader.HasRows == false)
                {
                    return apartamento;
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
            return apartamento;
        }

        // LISTAR
        public List<Apartamento> Listar()
        {      
            List<Apartamento> _Lista = new List<Apartamento>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("LISTAR_APARTAMENTO", _Conexion);
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
                    bool Ascensor = (bool)_Reader["Ascensor"];
                    int Piso = (int)_Reader["Piso"];

                    List<string> servicios = new List<string>();
                    Zona zona = new Zona(Nombre, Departamento, "", 1,servicios,true);
                    Empleado empleado = new Empleado(NombreLogueo,"1231231231",true);
                    Apartamento apartamento = new Apartamento(Padron,zona,empleado,Precio,Direccion,TipoDeAccion,Baño,Habitaciones,MetrosCuadradosP,Ascensor,Piso);

                    _Lista.Add(apartamento);

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
