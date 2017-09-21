using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class actalizardataset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnlistar_Click(object sender, EventArgs e)
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=academia;Integrated Security=True");
        SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM materias", conexion);
        DataSet ds = new DataSet();

        try
        {
            adaptador.Fill(ds, "materias");
            grdmaterias.DataSource = ds.Tables["materias"];
            grdmaterias.DataBind();
            Session["dataset"] = ds;
        }
        catch (SqlException ex)
        {
            lblerror.Text = "ERROR SQL: " + ex.Message;
        }
    }

    protected void btnborrar_Click(object sender, EventArgs e)
    {
        if (Session["dataset"] != null)
        {
            DataTable dt = ((DataSet)Session["dataset"]).Tables["materias"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                dr["cargahoraria"] = 0;
            }
            lblerror.Text = "DataSet actualizado en la Session";
        }
        else
        {
            lblerror.Text = "ERROR Borrar Carga Horaria: el dataset no estaba en la Session";
        }
    }

    protected void btnactualizar_Click(object sender, EventArgs e)
    {
        if (Session["dataset"] != null)
        {
            if (!((DataSet)Session["dataset"]).HasChanges())
            {
                lblerror.Text = "No se ha modificado ningún dato";
            }
            else
            {
                try
                {
                    DataSet dsCambiado = (DataSet)Session["dataset"];
                    SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=academia;Integrated Security=True");
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * from materias", conexion);
                    SqlCommandBuilder oConstructorComando = new SqlCommandBuilder(adaptador);
                    adaptador.Update(dsCambiado, "materias");
                    dsCambiado.AcceptChanges();
                    lblerror.Text = "BD actualizada!!!";
                }
                catch (SqlException ex)
                {
                    lblerror.Text = "ERROR SQL: " + ex.Message;
                }
            }
        }
    }

}
