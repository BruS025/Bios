using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient; 

namespace Persistencia
{
    internal class PersistenciaFactura
    {
        // Singleton
        private static PersistenciaFactura _instancia = null;

        private PersistenciaFactura() { }

        public static PersistenciaFactura GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaFactura();

            return _instancia;
        }

        //Operaciones
        public void AltaFactura(Factura F)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaFactura", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter _id = new SqlParameter("@IdFactura", F.Id);
                SqlParameter _fechaFac = new SqlParameter("Fecha", F.Fecha);
                SqlParameter _cliente = new SqlParameter("@NombreCli", F.Cliente);

                oComando.Parameters.Add(_id);
                oComando.Parameters.Add(_fechaFac);
                oComando.Parameters.Add(_cliente);

                oConexion.Open();

                int resultado = oComando.ExecuteNonQuery();

                if (resultado == 1)
                {
                    PersistenciaLineas pLineas = new PersistenciaLineas();

                    foreach (Linea Lineaa in F.Lineas)
                    {
                        pLineas.AgregarLinea(Lineaa, F.Id);
                    }
                }
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

        public void EliminarFactura(Factura F)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("EliminarFactura", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter _id = new SqlParameter("@IdFactura", F.Id);
                oComando.Parameters.Add(_id);

                oConexion.Open();
                oComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new ApplicationException("Hay errores    ==>" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public Factura BuscarFactura (int IdFactura)
        {
            string _idCliente;
            DateTime _fechaFac;
            Factura Factura = null;//ponemos en null la factura para que asegurarnos que este vacia

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("EliminarFactura" + IdFactura, oConexion);

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    _idCliente = (string)oReader[""];
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
