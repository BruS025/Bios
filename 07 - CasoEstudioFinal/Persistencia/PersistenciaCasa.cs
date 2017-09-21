using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;



namespace Persistencia
{
   public class PersistenciaCasa
    {

       public static List<Vivienda> ListarTodo()
       {
           List<Vivienda> _lista = new List<Vivienda>(); ;
           SqlDataReader _Reader;

           SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
           SqlCommand _Comando = new SqlCommand("ListarCasas", _Conexion);
           _Comando.CommandType = CommandType.StoredProcedure;

           try
           {
               _Conexion.Open();
               _Reader = _Comando.ExecuteReader();

               if (_Reader.HasRows)
               {
                   while (_Reader.Read())
                   {
                       Casa V = new Casa(Convert.ToInt32(_Reader["PadronViv"]), _Reader["DirViv"].ToString(), Convert.ToDateTime(_Reader["FConsViv"]), Convert.ToInt32(_Reader["PreAlqViv"]), Convert.ToInt32(_Reader["MtFondoC"]), PersitenciaDueño.Buscar(Convert.ToInt32(_Reader["CiD"])));
                       _lista.Add(V);
                   }
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

           return _lista;
       }

       public static List<Vivienda> ListarPorDuenio(Duenio unD)
       {
           List<Vivienda> _lista = new List<Vivienda>(); ;
           SqlDataReader _Reader;

           SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
           SqlCommand _Comando = new SqlCommand("ListarCasasDuenio", _Conexion);
           _Comando.CommandType = CommandType.StoredProcedure;

           _Comando.Parameters.AddWithValue("@Ci", unD.CI);

           try
           {
               _Conexion.Open();
               _Reader = _Comando.ExecuteReader();

               if (_Reader.HasRows)
               {
                   while (_Reader.Read())
                   {
                       Casa V = new Casa(Convert.ToInt32(_Reader["PadronViv"]), _Reader["DirViv"].ToString(), Convert.ToDateTime(_Reader["FConsViv"]), Convert.ToInt32(_Reader["PreAlqViv"]), Convert.ToInt32(_Reader["MtFondoC"]), unD);
                       _lista.Add(V);
                   }
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

           return _lista;
       }

       public static int CantTotalCasas()
       {
           int _CantTotal = 0;
           SqlDataReader _Reader;

           SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
           SqlCommand _Comando = new SqlCommand("CantTotalCasas", _Conexion);
           _Comando.CommandType = CommandType.StoredProcedure;

           SqlParameter _cant = new SqlParameter("@CantC", SqlDbType.Int);
           _cant.Direction = ParameterDirection.Output;
           _Comando.Parameters.Add(_cant);

           try
           {
               _Conexion.Open();
               _Reader = _Comando.ExecuteReader();

               //obtengo valor
               _CantTotal = Convert.ToInt32(_cant.Value);

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

           return _CantTotal;
       }


    }
}
