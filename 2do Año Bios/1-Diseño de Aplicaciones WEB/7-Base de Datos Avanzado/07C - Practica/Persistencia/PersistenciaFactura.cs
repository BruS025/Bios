using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaFactura:IPersistenciaFactura
    {
        public void AgregarFactura(Factura F)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaFactura", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@fechaFac", F.FechaFac);
            oComando.Parameters.AddWithValue("@nomCli", F.NomCli);
            oComando.Parameters.AddWithValue("@totBru", F.TotBru);
            oComando.Parameters.AddWithValue("@totIva", F.TotIva);
            oComando.Parameters.AddWithValue("@totFac", F.TotFac);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(_Retorno);

            SqlTransaction _miTransaccion = null;

            try
            {
                oConexion.Open();

                _miTransaccion = oConexion.BeginTransaction();
                oComando.Transaction = _miTransaccion;
                oComando.ExecuteNonQuery();
               int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("Ocurrio un error al dar de alta la Factura");

                foreach (LineasFactura l in F.Lineas)
                {
                    PersistenciaLinea.GetInstancia().AgregarLinea(l, oAfectados,_miTransaccion);
                }
                _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        //Singleton

        private static PersistenciaFactura _instancia = null;

        private PersistenciaFactura() { }

        public static PersistenciaFactura GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaFactura();

            return _instancia;
        }
    }
}
