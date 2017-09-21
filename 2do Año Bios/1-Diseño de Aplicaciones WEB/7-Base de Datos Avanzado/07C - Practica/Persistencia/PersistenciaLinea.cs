using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class PersistenciaLinea
    {
        public void AgregarLinea(LineasFactura L, int numFac,SqlTransaction _pTransaccion)
        {
            SqlCommand oComando = new SqlCommand("AltaLineaFactura", _pTransaccion.Connection);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numFac", numFac);
            oComando.Parameters.AddWithValue("@codArt", L.Articulo.Codigo);
            oComando.Parameters.AddWithValue("@cantidad", L.Cantidad);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(_Retorno);

            int oAfectados;

            try
            {
                oComando.Transaction = _pTransaccion;

                oComando.ExecuteNonQuery();

                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("No existe un articulo con el codigo especificado");
                if (oAfectados == -2)
                    throw new Exception("No existe una factura con el numero especificado");
                if (oAfectados == -3)
                    throw new Exception("La cantidad de lineas de factura no puede superar las 5");
                if (oAfectados == -4)
                    throw new Exception("Ocurrio un error al intentar agregar la linea de factura");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
        }

        //Singleton

        private static PersistenciaLinea _instancia = null;

        private PersistenciaLinea() { }

        public static PersistenciaLinea GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaLinea();

            return _instancia;
        }
    }
}
