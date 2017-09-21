using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolAdo
{
    public partial class EjemploDataSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Session["dataset"] !=null)
            {
                //Obtengo puntero a la tabla con datos
                DataTable dt = ((DataSet)Session["dataset"]).Tables["Empleados"];

                //Recorro cada registro par adejar la edad en 0
                for (int i = 0;i<dt.Rows.Count;i++)
                {
                    DataRow dr = dt.Rows[i];
                    dr["Edad"] = 0;
                }
                lblError.Text = "DataSet actualizado en la session";
            }
            else
            {
                lblError.Text = "Error borrar edades: el dataset no estaba en la session";
            }
        }

        protected void btnActualizo_Click(object sender, EventArgs e)
        {
            if (Session["dataset"] !=null)
            {
                if (!((DataSet)Session["dataset"]).HasChanges())
                {
                    lblError.Text = "No se a modificado ningun dato";
                }
                else
                {
                    try
                    {
                        DataSet dsCambiado = (DataSet)Session["dataset"];
                        SqlConnection conexion = new SqlConnection();
                        conexion.ConnectionString = "data source=.; Initial Catalog = Empresa; Integrated Security = true";
                        SqlDataAdapter adaptador = new SqlDataAdapter("Select Cedula,Nombre,Edad From Empleados", conexion);
                        SqlCommandBuilder oConstructorComando = new SqlCommandBuilder(adaptador);
                        adaptador.Update(dsCambiado, "Empleados");
                        dsCambiado.AcceptChanges();
                        lblError.Text = "BD actualizada";
                    }
                    catch(SqlException ex)
                    {
                        lblError.Text = "Error sql: " + ex.Message;
                    }
                }
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            //Detewrmino la conexion
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "data source=.; Initial Catalog = Empresa; Integrated Security = true";

            //Cargo objeto que busca la info en la bd

            SqlDataAdapter adaptador = new SqlDataAdapter("Select Cedula,Nombre,Edad From Empleados", conexion);

            //Objeto donde se alamacenara en memoria la info obtenida
            DataSet ds = new DataSet();

            try
            {
                adaptador.Fill(ds, "Empleados");

                //Cargo la info en la grilla
                gvEmpleado.DataSource = ds.Tables["Empleados"];
                gvEmpleado.DataBind();

                //Mantengo la info en la memoria del servidor
                Session["dataset"] = ds;
            }
            catch (SqlException ex)
            {
                lblError.Text = "Error de sql: " + ex.Message;
            }
        }
    }
}