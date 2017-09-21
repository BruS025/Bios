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
    public class PersistenciaPedido
    {
        public static int Agregar(Pedido venta, Cliente cliente)
        {
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("AgregarVenta", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroFechaPedido = new SqlParameter("@fechaPedido", venta.FechaPedido);
            SqlParameter parametroFechaEntrega = new SqlParameter("@fechaEntrega", venta.FechaEntrega);
            SqlParameter parametroTotal = new SqlParameter("@totalVenta", venta.Total);
            SqlParameter parametroDoc = new SqlParameter("@cliente", cliente.Documento);

            comando.Parameters.Add(parametroFechaPedido);
            comando.Parameters.Add(parametroFechaEntrega);
            comando.Parameters.Add(parametroTotal);
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

        public static List<Pedido> Listar(DateTime fecha,Cliente cliente, Plato plato, Linea linea)
        {

            List<Pedido> lista = new List<Pedido>();

            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("SP_ListarPedidos", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroFecha = new SqlParameter("@fecha", fecha);
            SqlParameter parametroCliente = new SqlParameter("@calle",cliente.Calle);
            SqlParameter parametroClienteDireccion = new SqlParameter("@puerta", cliente.Puerta);
            SqlParameter parametroPlato = new SqlParameter("@plato", plato.Nombre);
            SqlParameter parametroCantidad = new SqlParameter("@linea", linea.Cantidad);


            comando.Parameters.Add(parametroFecha);
            comando.Parameters.Add(parametroCliente);
            comando.Parameters.Add(parametroClienteDireccion);
            comando.Parameters.Add(parametroPlato);
            comando.Parameters.Add(parametroCantidad);

            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    Pedido pedido = new Pedido();                    
                    pedido.FechaPedido = Convert.ToDateTime(lector["FechaPedido"].ToString());
                    cliente.Calle = lector["Calle"].ToString();
                    cliente.Puerta =lector["NroPuerta"].ToString();
                    plato.Nombre = lector["Nombre"].ToString();
                    linea.Cantidad = Convert.ToInt32(lector["Cantidad"].ToString());

                    lista.Add(pedido);
                    
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

        public static List<Pedido> Pendientes(int doc)
        {

            List<Pedido> lista = new List<Pedido>();
          
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("PedidosPendientes", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroDoc = new SqlParameter("@cliente", doc);

            comando.Parameters.Add(parametroDoc);

            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pedido pedido = new Pedido();
                    Linea linea = new Linea();
                    Plato plato = new Plato();
                    List<Linea> lineas = new List<Linea>();

                    pedido.Id = Convert.ToInt32(lector["IdPedido"].ToString());
                    pedido.FechaPedido = Convert.ToDateTime(lector["FechaPedido"].ToString());
                    pedido.FechaEntrega = Convert.ToDateTime(lector["FechaEntregado"].ToString());
                    pedido.Estado = Convert.ToBoolean(lector["Entregado"].ToString());
                    linea.Cantidad = Convert.ToInt32(lector["Cantidad"].ToString());
                    linea.UnPlato = plato;
                    linea.UnPlato.Precio = Convert.ToDouble(lector["Total"].ToString());
                    lineas.Add(linea);
                    pedido.Renglones = lineas;     

                    lista.Add(pedido);
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

        public static List<Pedido> PendientesTodos()
        {

            List<Pedido> lista = new List<Pedido>();
           
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("PedidosPendientesTodos", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    Pedido pedido = new Pedido();
                    Linea linea = new Linea();
                    Plato plato = new Plato();
                    List<Linea> lineas = new List<Linea>();

                    pedido.Id = Convert.ToInt32(lector["IdPedido"].ToString());
                    pedido.FechaPedido = Convert.ToDateTime(lector["FechaPedido"].ToString());
                    pedido.FechaEntrega = Convert.ToDateTime(lector["FechaEntregado"].ToString());
                    pedido.Estado = Convert.ToBoolean(lector["Entregado"].ToString());
                    linea.Cantidad = Convert.ToInt32(lector["Cantidad"].ToString());
                    linea.UnPlato = plato;
                    linea.UnPlato.Precio = Convert.ToDouble(lector["Total"].ToString());
                    lineas.Add(linea);
                    pedido.Renglones = lineas;

                    lista.Add(pedido);
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

        public static int Confirmar(int pedido,DateTime fecha)
        {
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("EntregarPedido", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroPedido = new SqlParameter("@pedido", pedido);
            SqlParameter parametroFecha = new SqlParameter("@fecha", fecha);

            comando.Parameters.Add(parametroPedido);
            comando.Parameters.Add(parametroFecha);

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

        public static DataSet XML (DateTime fecha)
        {
            DataSet table = new DataSet();

            // SP = PedidosXML
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);

            SqlCommand comando = new SqlCommand("PedidosXML", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);

            SqlParameter parametroFecha = new SqlParameter("@fecha", fecha);
            comando.Parameters.Add(parametroFecha);

            try
            {
                da.Fill(table);

                return table;
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
