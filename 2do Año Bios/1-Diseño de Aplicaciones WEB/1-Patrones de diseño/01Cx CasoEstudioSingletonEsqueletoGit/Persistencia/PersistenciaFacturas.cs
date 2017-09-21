using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaFacturas
    {
        // Singleton
        private static PersistenciaFacturas _instancia = null;
        private PersistenciaFacturas() { }

        public static PersistenciaFacturas GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaFacturas();

            return _instancia;
        }

        //Operaciones
        public void AgregarFactura(Factura F)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaFactura", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _id = new SqlParameter("@id", F.Id);
            SqlParameter _cliente = new SqlParameter("@cli", F.Cliente);
            SqlParameter _fecha = new SqlParameter("@fec", F.Fecha);
            // SqlParameter _precio = new SqlParameter("@pre", A.Precio); Pasar cada linea
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_cliente);
            oComando.Parameters.Add(_fecha);
            // oComando.Parameters.Add(_precio);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El codigo de factura ya existe");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public void EliminarFactura(Factura F)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BajaFactura", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _id = new SqlParameter("@cod", F.Id);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_id);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La factura no existe");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }    
        }

        public Factura BuscarFactura(int id)
        {
            int _id;
            string _cliente;
            DateTime _fecha;
            Factura f = null;
            List<Linea> _linea = new List<Linea>();
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("Exec BuscoFactura " + id, oConexion);

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _id = (int)oReader["IdFac"];
                    _cliente = (string)oReader["CliFac"];
                    _fecha = (DateTime)oReader["FecFac"];
                    f = new Factura(_id, _fecha, _cliente, _linea);
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
            return f;
        }

        public List<Factura> ListarFactura()
        {
            int _id;
            string _cliente;
            DateTime _fecha;
            List<Linea> _linea = new List<Linea>();
            List<Factura> _factura = new List<Factura>();
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("Exec ListoFactura", _Conexion);
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    _id = (int)_Reader["IdFac"];
                    _cliente = (string)_Reader["CliFac"];
                    _fecha = (DateTime)_Reader["FecFac"];
                    Factura f = new Factura(_id, _fecha, _cliente, _linea);
                    _factura.Add(f);
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
            return _factura;
        }
    }
}
