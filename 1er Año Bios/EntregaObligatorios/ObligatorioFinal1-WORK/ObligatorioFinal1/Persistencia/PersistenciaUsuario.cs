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
    public class PersistenciaUsuario
    {
        public static List<Administrador> Listar(int id)
        {

            List<Administrador> lista = new List<Administrador>();

            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("SP_ListarAdministradores", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter("@IdCargoB", id);

            comando.Parameters.Add(parametroId);

            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();


                while (lector.Read())
                {

                    Administrador admin = new Administrador();
                    admin.Nombre = lector["Nombre"].ToString();
                    admin.Apellido = lector["Apellido"].ToString();
                    admin.Documento = Convert.ToInt32(lector["NroDoc"].ToString());
                    admin.UsuarioNombre = lector["NombreLogueo"].ToString();
                    

                    lista.Add(admin);
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

        public static Administrador Buscar(int documento)
        {
            Administrador admin = new Administrador();

            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("SP_BuscarAdmin", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroDoc = new SqlParameter("@DocB", documento);

            //agrega los parametros
            comando.Parameters.Add(parametroDoc);

            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    admin.Nombre = lector["Nombre"].ToString();
                    admin.Apellido = lector["Apellido"].ToString();
                    admin.Documento = Convert.ToInt32(lector["NroDoc"].ToString());
                    admin.UsuarioNombre = lector["NombreLogueo"].ToString();
                    admin.Contrasenia = lector["Contrasenia"].ToString();

                }

                return admin;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
            catch (Exception)
            {
                throw new Exception();

            }
            finally
            {
                conexion.Close();
            }

        }

        public static int Eliminar(int documento)
        {
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("SP_BorrarAdministrador", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroDoc = new SqlParameter("@NroDocB", documento);
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
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static int Modificar(Administrador user, int id)
        {
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("SP_ModificarAdministrador", conexion);
            comando.CommandType = CommandType.StoredProcedure;


            SqlParameter parametroNombre = new SqlParameter("@NombreM", user.Nombre);
            SqlParameter parametroApellido = new SqlParameter("@ApellidoM", user.Apellido);
            SqlParameter parametroContrasenia = new SqlParameter("@ContraseniaM", user.Contrasenia);
            SqlParameter parametroDocumento = new SqlParameter("@NroDocM", user.Documento);
            SqlParameter parametroNombreLogueo = new SqlParameter("@NombreLogueoM", user.UsuarioNombre);
            SqlParameter parametroId = new SqlParameter("@CargoM", id);


            comando.Parameters.Add(parametroNombre);
            comando.Parameters.Add(parametroApellido);
            comando.Parameters.Add(parametroContrasenia);
            comando.Parameters.Add(parametroDocumento);
            comando.Parameters.Add(parametroNombreLogueo);
            comando.Parameters.Add(parametroId);


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

        public static int Agregar(Administrador user, int id)
        {
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("SP_AgregarAdministrador", conexion);
            comando.CommandType = CommandType.StoredProcedure;


            SqlParameter parametroNombre = new SqlParameter("@NombreN", user.Nombre);
            SqlParameter parametroApellido = new SqlParameter("@ApellidoN", user.Apellido);
            SqlParameter parametroContrasenia = new SqlParameter("@ContraseniaN", user.Contrasenia);
            SqlParameter parametroDocumento = new SqlParameter("@NroDocN", user.Documento);
            SqlParameter parametroNombreLogueo = new SqlParameter("@NombreLogueoN", user.UsuarioNombre);
            SqlParameter parametroId = new SqlParameter("@CargoN", id);

            comando.Parameters.Add(parametroNombre);
            comando.Parameters.Add(parametroApellido);
            comando.Parameters.Add(parametroContrasenia);
            comando.Parameters.Add(parametroDocumento);
            comando.Parameters.Add(parametroNombreLogueo);
            comando.Parameters.Add(parametroId);
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

        public static int AgregarC(Cliente user)
        {
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("SP_AgregarCliente", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter PNombre = new SqlParameter("@NombreN", user.Nombre);
            SqlParameter PApellido = new SqlParameter("@ApellidoN", user.Apellido);
            SqlParameter PContrasenia = new SqlParameter("@ContraseniaN", user.Contrasenia);
            SqlParameter PNroDoc = new SqlParameter("@NroDocN", user.Documento);
            SqlParameter PNomLogueo = new SqlParameter("@NombreLogueoN", user.UsuarioNombre);
            SqlParameter PNroTarjeta = new SqlParameter("@NroTarjetaN", user.Tarjeta);
            SqlParameter PCalle = new SqlParameter("@CalleN", user.Calle);
            SqlParameter PNroPuerta = new SqlParameter("@NroPuertaN", user.Puerta);

            comando.Parameters.Add(PNombre);
            comando.Parameters.Add(PApellido);
            comando.Parameters.Add(PContrasenia);
            comando.Parameters.Add(PNroDoc);
            comando.Parameters.Add(PNomLogueo);
            comando.Parameters.Add(PNroTarjeta);
            comando.Parameters.Add(PCalle);
            comando.Parameters.Add(PNroPuerta);

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

        public static Cliente LoginCliente (string NomLogeo , string pass)
        {
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("SP_LoginCliente", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter PNomLogeo = new SqlParameter("@NomLogueo", NomLogeo);
            SqlParameter PPass = new SqlParameter("@PassUser", pass);

            comando.Parameters.Add(PNomLogeo);
            comando.Parameters.Add(PPass);

            Cliente cliente = new Cliente();

            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    cliente.Nombre = lector["Nombre"].ToString();
                    cliente.Apellido = lector["Apellido"].ToString();
                    cliente.Documento = Convert.ToInt32(lector["NroDoc"].ToString());
                    cliente.UsuarioNombre = lector["NombreLogueo"].ToString();
                    cliente.Tarjeta = Convert.ToInt64(lector["NroTarjeta"].ToString());
                    cliente.Calle = lector["Calle"].ToString();
                    cliente.Puerta = lector["NroPuerta"].ToString();

                }

                return cliente;
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

        public static Administrador LoginAdministrador(string NomLogeo, string pass)
        {
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);
            SqlCommand comando = new SqlCommand("SP_LoginAdministrador", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter PNomLogeo = new SqlParameter("@NomLogueo", NomLogeo);
            SqlParameter PPass = new SqlParameter("@PassUser", pass);

            comando.Parameters.Add(PNomLogeo);
            comando.Parameters.Add(PPass);

            Administrador admin = new Administrador();

            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    admin.Nombre = lector["Nombre"].ToString();
                    admin.Apellido = lector["Apellido"].ToString();
                    admin.Documento = Convert.ToInt32(lector["NroDoc"].ToString());
                    admin.UsuarioNombre = lector["NombreLogueo"].ToString();
                    admin.Cargo = Convert.ToInt32(lector["IdCargo"].ToString());

                }

                return admin;
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

    }
}