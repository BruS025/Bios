using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaPrestamo : IPersistenciaPrestamo
    {
        //Singleton
        private static PersistenciaPrestamo _miInstancia;
        private PersistenciaPrestamo() { }
        public static PersistenciaPrestamo GetInstancia()
        {
            if (_miInstancia == null)
                _miInstancia = new PersistenciaPrestamo();
            return _miInstancia;
        }
        public void AltaPrestamo(Prestamo unPrestamo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaPrestamo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@isbn", unPrestamo.IdPrestamo);
            oComando.Parameters.AddWithValue("@nom", unPrestamo.NombreCliente);
            oComando.Parameters.AddWithValue("@reseña", unPrestamo.FechaPide);
            oComando.Parameters.AddWithValue("codaut", unPrestamo.Duracion);
            oComando.Parameters.AddWithValue("@codtip", unPrestamo.LosLibros);

            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(_retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                switch ((int)_retorno.Value)
                {
                    case -1:
                        {
                            throw new Exception("Duplica ISBN");
                        }
                    case -2:
                        {
                            throw new Exception("El Autor No existe");
                        }
                    case -3:
                        {
                            throw new Exception("El Tipo de Libro no Existe");
                        }
                    case 0:
                        {
                            throw new Exception("Error Indefinido");
                        }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }

        public void BajaPrestamo(Prestamo unPrestamo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BajaLibro", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@isbn", unLibro.Codigo);

            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(_retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                switch ((int)_retorno.Value)
                {
                    case -1:
                        {
                            throw new Exception("No Existe el Libro - No se Puede Eiminar");
                        }
                    case 0:
                        {
                            throw new Exception("Error Indefinido");
                        }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public void ModificarPrestamo(Prestamo unPrestamo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("ModificarLibro", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@isbn", unLibro.Codigo);
            oComando.Parameters.AddWithValue("@nom", unLibro.Nombre);
            oComando.Parameters.AddWithValue("@reseña", unLibro.Reseña);
            oComando.Parameters.AddWithValue("codaut", unLibro.UnAutor.Codigo);
            oComando.Parameters.AddWithValue("@codtip", unLibro.UnTipo.Codigo);

            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(_retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                switch ((int)_retorno.Value)
                {
                    case -1:
                        {
                            throw new Exception("No Existe ISBN - No se puede Modificar");
                        }
                    case -2:
                        {
                            throw new Exception("El Autor No existe");
                        }
                    case -3:
                        {
                            throw new Exception("El Tipo de Libro no Existe");
                        }
                    case 0:
                        {
                            throw new Exception("Error Indefinido");
                        }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public Prestamo BuscarPrestamo(int idPrestamo)
        {
            //variables para crear Libro
            string _nombre;
            string _reseña;
            TipoLibro t = null;
            Autor a = null;
            Libro l = null;

            //variables para comunicacion ADO
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("Exec BuscoLibro " + pIsbn, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _nombre = (string)oReader["NomLib"];
                    _reseña = (string)oReader["ReseñaLib"];
                    a = FabricaPersistencia.getPersistenciaAutor().BuscarAutor((int)oReader["CodAut"]);
                    t = FabricaPersistencia.getPersistenciaTipoLibro().BuscarTipo((int)oReader["CodTip"]);
                    l = new Libro(pIsbn, _nombre, _reseña, a, t);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return l;
        }

        public List<Prestamo> ListarPrestamo()
        {
            //variables para crear Libros
            int _isbn;
            string _nombre;
            string _reseña;
            List<Libro> _Lista = new List<Libro>();

            //variables para comunicacion ADO
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("Exec ListoLibro", _Conexion);
            SqlDataReader _Reader;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    _isbn = (int)_Reader["IsbnLib"];
                    _nombre = (string)_Reader["NomLib"];
                    _reseña = (string)_Reader["ReseñaLib"];
                    Autor a = FabricaPersistencia.getPersistenciaAutor().BuscarAutor((int)_Reader["CodAut"]);
                    TipoLibro t = FabricaPersistencia.getPersistenciaTipoLibro().BuscarTipo((int)_Reader["CodTip"]);
                    _Lista.Add(new Libro(_isbn, _nombre, _reseña, a, t));
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return _Lista;
        }
    }
}
