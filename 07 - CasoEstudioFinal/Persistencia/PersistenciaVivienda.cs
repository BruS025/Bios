using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;



namespace Persistencia
{
   public class PersistenciaVivienda
    {

       public static void Eliminar(Vivienda unaV)
       {
           //comando a ejecutar
           SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
           SqlCommand _Comando = new SqlCommand("EliminarVivienda", _Conexion);
           _Comando.CommandType = CommandType.StoredProcedure;

           //parametros 
           SqlParameter _padron = new SqlParameter("@Padron", unaV.Padron);

           SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
           _Retorno.Direction = ParameterDirection.ReturnValue;

           _Comando.Parameters.Add(_padron);
           _Comando.Parameters.Add(_Retorno);

           try
           {
               _Conexion.Open();
               _Comando.ExecuteNonQuery();

               //determino devolucion del SP
               int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

               if (oAfectados == -1)
                   throw new Exception("No existe - No se Elimina");
               else if (oAfectados == -2)
                   throw new Exception("Error en TRN");

           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               _Conexion.Close();
           }
       }

    }
}
