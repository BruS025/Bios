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
    public partial class ListarEmpdeEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    SqlConnection conexion = new SqlConnection();
                    conexion.ConnectionString = "data source=.; Initial Catalog = Empresa; Integrated Security = true";
                    SqlDataAdapter oAdaptador = new SqlDataAdapter("ListarEmpresas", conexion);
                    DataSet ds = new DataSet();
                    oAdaptador.Fill(ds, "Empresas");

                    //Cargo la lista con datos
                    cbEmpresa.DataSource = ds.Tables["Empresas"];
                    //determino que dato se muestra y cual data asociado se devuelve
                    cbEmpresa.DataTextField = "Nombre";
                    cbEmpresa.DataValueField = "Ruc";
                    cbEmpresa.DataBind();
                }
            }
            catch (SqlException ex)
            {
                lblError.Text = "Error sql" + ex.Message;
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "data source=.; Initial Catalog = Empresa; Integrated Security = true";

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter("EmpleadosPorRuc" + cbEmpresa.SelectedValue, conexion);
                DataSet ds = new DataSet();
                adaptador.Fill(ds, "Empleados");
                gvEmpleado.DataSource = ds.Tables["Empleados"];
                gvEmpleado.DataBind();
                Session["dataset"] = ds;
            }
            catch(Exception ex)
            {
                lblError.Text = "Error sql" + ex.Message;
            }

        }
    }
}