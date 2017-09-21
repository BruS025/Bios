using System;
using System.Collections.Generic;
using System.Text;

using EntidadesCompartidas; 
using System.Data;
using System.Data.SqlClient;


namespace Persistencia
{
   public class PersistenciaUsuario
    {
       public static EntidadesCompartidas.Usuario Logueo(string pUsu, string pPass)
       {
           //variables
           SqlConnection _cnn = new SqlConnection(Conexion._Cnn);
           SqlCommand _comando = new SqlCommand("Logueo", _cnn);
           _comando.CommandType = CommandType.StoredProcedure;

           Usuario unUsu = null;

           //parametros
           _comando.Parameters.AddWithValue("@Usu", pUsu);
           _comando.Parameters.AddWithValue("@Pass", pPass);

           try
           {
               _cnn.Open();

               SqlDataReader _lector = _comando.ExecuteReader();

               if (_lector.HasRows)
               {
                   _lector.Read();
                   int _ciusu = (int)_lector["CiUsu"];
                   string _nomusu = (string)_lector["NomUsu"];
                   string _usuusu = (string)_lector["UsuUsu"];
                   string _passusu = (string)_lector["PassUsu"];
                   unUsu = new EntidadesCompartidas.Usuario(_ciusu, _nomusu, _usuusu, _passusu);
               }

               _lector.Close();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               _cnn.Close();
           }

           return unUsu;
       }
    }
}
