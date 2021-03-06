﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaCargo
    {
        public static List<Cargo> Listar()
        {
            List<Cargo> lista = new List<Cargo>();
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("SP_ListarCargos", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();


                while (lector.Read())
                {

                    Cargo cargo = new Cargo();
                    cargo.Id = Convert.ToInt32(lector["IdCargo"].ToString());
                    cargo.Tipo = lector["Tipo"].ToString();

                    lista.Add(cargo);
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
