using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaFactura:IPersistenciaFactura
    {
        private static PersistenciaFactura _myClass = null;

        private PersistenciaFactura() { }

        public static PersistenciaFactura getPersistenciaFactura
        {
            get
            {
                if (_myClass == null) { _myClass = new PersistenciaFactura(); }
                return _myClass;
            }
        }


        //Operaciones
        public void AltaFactura(Factura factura)
        {
            SqlConnection conn = new SqlConnection(Conexion.Cnn);
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = conn;
                command.CommandText = "AltaFactura";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FacID", factura.ID));
                command.Parameters.Add(new SqlParameter("@FacAlta", factura.FechaAlta.ToString("yyyy-MM-dd HH:mm:ss")));
                command.Parameters.Add(new SqlParameter("@FacCliente", factura.Cliente));

                conn.Open();

                int res = command.ExecuteNonQuery();

                if (res == 1)
                {
                    PersistenciaLineas pLines = new PersistenciaLineas();

                    foreach (LineaFactura lin in factura.Lineas)
                    {
                        pLines.AltaLineas(lin, factura.ID, conn);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Factura BuscarFactura(int id)
        {
            string _cliente;
            DateTime _alta;
            Factura factura = null;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("EXEC BuscarFactura " + id, oConexion);

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _cliente = (string)oReader["FacCliente"];
                    _alta = (DateTime)oReader["FacAlta"];

                    PersistenciaLineas pLineas = new PersistenciaLineas();

                    factura = new Factura(id, _cliente, _alta, pLineas.BuscarLineas(id));
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
            return factura;
        }

        public void EliminarFactura(int id)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("EXEC BajaFactura " + id, oConexion);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }


        public void ModificarFactura(Factura factura)
        {
            SqlConnection conn = new SqlConnection(Conexion.Cnn);
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = conn;
                command.CommandText = "ModificarFactura";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FacID", factura.ID));
                command.Parameters.Add(new SqlParameter("@Cliente", factura.Cliente));

                conn.Open();

                command.ExecuteNonQuery();

                PersistenciaLineas pLineas = new PersistenciaLineas();

                //Eliminamos todas las lineas
                pLineas.EliminarLineas(factura.ID, conn);

                //Cargamos las lineas nuevamente
                foreach (LineaFactura lin in factura.Lineas)
                {
                    pLineas.AltaLineas(lin, factura.ID, conn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
