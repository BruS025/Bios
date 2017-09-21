using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;



namespace Persistencia
{
    public class PersistenciaApartamento
    {
        public static void Alta(Apartamento unaV)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("AgregarApartamento", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Padron", unaV.Padron);
            _Comando.Parameters.AddWithValue("@Dir", unaV.Direccion);
            _Comando.Parameters.AddWithValue("@Fecha", unaV.FechaCons);
            _Comando.Parameters.AddWithValue("@Precio", unaV.Alquiler);
            _Comando.Parameters.AddWithValue("@Duenio", unaV.Dueño.CI);
            _Comando.Parameters.AddWithValue("@Portero", unaV.Portero);
            _Comando.Parameters.AddWithValue("@Piso", unaV.Piso);
            _Comando.Parameters.AddWithValue("@Gastos", unaV.GComunes);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya Existe el Padron");
                else if (oAfectados == -2)
                    throw new Exception("No existe el Dueño");
                else if (oAfectados == -3)
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

        public static void Modificar(Apartamento unaV)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ModificarApartamento", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Padron", unaV.Padron);
            _Comando.Parameters.AddWithValue("@Dir", unaV.Direccion);
            _Comando.Parameters.AddWithValue("@Fecha", unaV.FechaCons);
            _Comando.Parameters.AddWithValue("@Precio", unaV.Alquiler);
            _Comando.Parameters.AddWithValue("@Duenio", unaV.Dueño.CI);
            _Comando.Parameters.AddWithValue("@Portero", unaV.Portero);
            _Comando.Parameters.AddWithValue("@Piso", unaV.Piso);
            _Comando.Parameters.AddWithValue("@Gastos", unaV.GComunes);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No Existe el Padron - No se Modifico");
                else if (oAfectados == -2)
                    throw new Exception("No existe el Dueño");
                else if (oAfectados == -3)
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

        public static Apartamento Buscar(int pPadron)
        {
            Apartamento V = null;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("Exec BuscarApartamento " + pPadron, _Conexion);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                     V = new Apartamento(Convert.ToInt32(_Reader["PadronViv"]),_Reader["DirViv"].ToString(), Convert.ToDateTime(_Reader["FConsViv"]),Convert.ToInt32(_Reader["PreAlqViv"]),Convert.ToBoolean(_Reader["PorteroApto"]),Convert.ToInt32(_Reader["PisoApto"]), Convert.ToInt32(_Reader["GCApto"]),PersitenciaDueño.Buscar(Convert.ToInt32(_Reader["CiD"])));

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

            return V;
        }

        public static List<Vivienda> ListarTodo()
        {
            List<Vivienda> _lista = new List<Vivienda>(); ;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ListarApartamentos", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Apartamento V = new Apartamento(Convert.ToInt32(_Reader["PadronViv"]), _Reader["DirViv"].ToString(), Convert.ToDateTime(_Reader["FConsViv"]), Convert.ToInt32(_Reader["PreAlqViv"]), Convert.ToBoolean(_Reader["PorteroApto"]), Convert.ToInt32(_Reader["PisoApto"]), Convert.ToInt32(_Reader["GCApto"]), PersitenciaDueño.Buscar(Convert.ToInt32(_Reader["CiD"])));
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
            SqlCommand _Comando = new SqlCommand("ListarApartamentosDuenio", _Conexion);
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
                        Apartamento V = new Apartamento(Convert.ToInt32(_Reader["PadronViv"]), _Reader["DirViv"].ToString(), Convert.ToDateTime(_Reader["FConsViv"]), Convert.ToInt32(_Reader["PreAlqViv"]), Convert.ToBoolean(_Reader["PorteroApto"]), Convert.ToInt32(_Reader["PisoApto"]), Convert.ToInt32(_Reader["GCApto"]), unD);
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

        public static int CantTotalAptos()
        {
            int _CantTotal = 0;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("CantTotalAptos", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _cant = new SqlParameter("@CantA", SqlDbType.Int);
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
