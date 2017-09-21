﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaAutor:IPersistenciaAutor
    {
        //Singleton
        private static PersistenciaAutor _miInstancia;
        private PersistenciaAutor() { }
        public static PersistenciaAutor GetInstancia()
        {
            if (_miInstancia == null)
                _miInstancia = new PersistenciaAutor();
            return _miInstancia;
        }
 
        //Operaciones
       public Autor BuscarAutor(int pCodigo)
        {
           //Variables para crear Autor
            int _codigo;
            string _nombre;
            string _nacionalidad;
            Autor a = null;

           //variables para manejar ADO
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("Exec BuscoAutor " + pCodigo, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _codigo = (int)oReader["CodAut"];
                    _nombre = (string)oReader["NomAut"];
                    _nacionalidad = (string)oReader["NacAut"];
                    a = new Autor(_codigo,_nombre,_nacionalidad);
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
            return a;
        }

       public List<Autor> ListarAutor()
        {
           //Variables para crear Autores
            int _codigo;
            string _nombre;
            string _nacionalidad;
            List<Autor> _Lista = new List<Autor>();

           //Variables para comunicar con ADO
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("Exec ListoAutor", _Conexion);
            SqlDataReader _Reader;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    _codigo = (int)_Reader["CodAut"];
                    _nombre = (string)_Reader["NomAut"];
                    _nacionalidad = (string)_Reader["NacAut"];
                    _Lista.Add(new Autor(_codigo, _nombre, _nacionalidad));
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
            return _Lista;
        }

    }
}
