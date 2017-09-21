using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;


using System.Data;
using System.Data.SqlClient;



namespace Persistencia
{
   internal class PersitenciaCliente:IPersistenciaCliente
    {
       public void Alta(EntidadesCompartidas.Cliente unCliente)
       {
            SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);

            SqlCommand _comando = new SqlCommand("AltaCliente", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NomCli", unCliente.NomCli);
            _comando.Parameters.AddWithValue("@DirCli", unCliente.DirCli);

            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            SqlTransaction _miTransaccion = null;

            //el sql transaction tiene que estar por fuera del try poque sino no podemos acceder
            //

            try
            {
                //Conecto a la bd
                _cnn.Open();

                //determino que voy a a trabajar en una unica transaccion
                _miTransaccion = _cnn.BeginTransaction();

                //ejecuto comando de alta del cliente en la transaccion
                _comando.Transaction = _miTransaccion;
                _comando.ExecuteNonQuery();

                //verifico si hay errores 
                int _CodCli = Convert.ToInt32(_ParmRetorno.Value);

                if(_CodCli == -1)
                {
                    throw new Exception("Cliente ya existente mi pari");
                }
                else if(_CodCli == 0)
                {
                    throw new Exception("Error no Especifiado");
                }
                //si llego aca es porque puedo dar de alta un cliente
                //genero alta para sus telefonos
                foreach(EntidadesCompartidas.Telefono unTel in unCliente.LosTelefonos)
                {
                    PersitenciaTelefono.Alta(unTel, _CodCli, _miTransaccion);
                    /*a las acciones que se van a repetir le pasamos la transaccion y no la coneccion porque la transaccion sabe que conexion usar*/
                }
                //si llege aca es porque no hubo problemas con los telefonos
                _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
       }//Fin de la op alta

       public List<EntidadesCompartidas.Cliente> Listo()
       {
           SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);

           SqlCommand _comando = new SqlCommand("ListoClientes", _cnn);
           _comando.CommandType = CommandType.StoredProcedure;

           List<EntidadesCompartidas.Cliente> _Lista = new List<EntidadesCompartidas.Cliente>();
           EntidadesCompartidas.Cliente _unCliente = null;

           try
           {
               //me conecto
               _cnn.Open();

               //ejecuto consulta
               SqlDataReader _lector = _comando.ExecuteReader();

               //verifico si hay telefonos
               if (_lector.HasRows)
               {
                   while (_lector.Read())
                   {
                       int _codigo = (int)_lector["CodCli"];
                       string _nombre = (string)_lector["NomCli"];
                       string _direccion = (string)_lector["DirCli"];
                       _unCliente = new EntidadesCompartidas.Cliente(_codigo, _nombre, _direccion);
                       Persistencia.PersitenciaTelefono.CargoTelCliente(_unCliente);

                       _Lista.Add(_unCliente);
                   }
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

           //retorno la lista de clientes
           return _Lista;
       }
    
       public EntidadesCompartidas.Cliente Busco(int CodCli)
       {
           SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);

           SqlCommand _comando = new SqlCommand("BuscoCliente", _cnn);
           _comando.CommandType = CommandType.StoredProcedure;
           _comando.Parameters.AddWithValue("@CodCli", CodCli);

           EntidadesCompartidas.Cliente _unCliente = null;

           try
           {
               //me conecto
               _cnn.Open();

               //ejecuto consulta
               SqlDataReader _lector = _comando.ExecuteReader();

               //verifico si hay telefonos
               if (_lector.HasRows)
               {
                   _lector.Read();
                    int _codigo = (int)_lector["CodCli"];
                    string _nombre = (string)_lector["NomCli"];
                    string _direccion = (string)_lector["DirCli"];
                    _unCliente = new EntidadesCompartidas.Cliente(_codigo, _nombre, _direccion);
                    Persistencia.PersitenciaTelefono.CargoTelCliente(_unCliente);
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

           //retorno el cliente
           return _unCliente;
       }

       public void ModificarTelefonos(EntidadesCompartidas.Cliente unCliente)
       {
            SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);

            SqlTransaction _miTransaccion = null;

            try
            {
                //Abrimos la conexion
                _cnn.Open();

                //determino que voy a trabajar en una unica transaccion
                _miTransaccion = _cnn.BeginTransaction();

                //elimino todos los telefonos
                PersitenciaTelefono.EliminarTelsCliente(unCliente, _miTransaccion);

                //genero alta para los telefonos nuevos
                foreach (EntidadesCompartidas.Telefono unTel in unCliente.LosTelefonos)
                {
                    PersitenciaTelefono.Alta(unTel, unCliente.CodCLi, _miTransaccion);
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
                _cnn.Close();
            }
       }

    }
}
