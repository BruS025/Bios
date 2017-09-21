using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaLinea
    {
        public static int Agregar(Linea linea, double total, Cliente cliente)
        {
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("AgregarLinea", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroTotalVenta = new SqlParameter("@total", total);
            SqlParameter parametroIdPlato = new SqlParameter("@idPlato", linea.UnPlato.Id);
            SqlParameter parametroCasa = new SqlParameter("@casa", linea.UnaCasa.RUT);
            SqlParameter parametroCantidad = new SqlParameter("@cantidad", linea.Cantidad);
            SqlParameter parametroDoc = new SqlParameter("@cliente", cliente.Documento);

            comando.Parameters.Add(parametroTotalVenta);
            comando.Parameters.Add(parametroIdPlato);
            comando.Parameters.Add(parametroCasa);
            comando.Parameters.Add(parametroCantidad);
            comando.Parameters.Add(parametroDoc);

            try
            {
                conexion.Open();
                int resultado = comando.ExecuteNonQuery();
                return resultado;

            }
            catch (SqlException sqlex)
            {

                throw sqlex;
            }

            finally
            {
                conexion.Close();
            }
        }

        public static List<Linea> Pendientes(int venta)
        {
            List<Linea> lista = new List<Linea>();

            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("LineasPendientes", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroVenta = new SqlParameter("@pedido", venta);

            comando.Parameters.Add(parametroVenta);

            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Linea linea = new Linea();
                    Casa casa = new Casa();
                    Plato plato = new Plato();

                    plato.Id = Convert.ToInt32(lector["IdPlato"].ToString());
                    plato.Nombre = Convert.ToString(lector[1].ToString());
                    plato.Precio = Convert.ToDouble(lector["Precio"].ToString());
                    plato.Foto = Convert.ToString(lector["Foto"].ToString());
                    casa.RUT = Convert.ToInt64(lector["Rut"].ToString());
                    casa.Nombre = Convert.ToString(lector[5].ToString());                   
                    linea.Cantidad = Convert.ToInt32(lector["Cantidad"].ToString());
                    linea.UnPlato = plato;
                    linea.UnaCasa = casa;

                    lista.Add(linea);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
