using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Articulos
{
    public partial class ListarArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Conexion.CnnString);

            string query = "SELECT Id, Nombre, Tipo FROM Articulos";

            SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
            DataSet ds = new DataSet();

            try
            {
                adaptador.Fill(ds, "Articulos");

                if (ds.Tables["Articulos"].Rows.Count != 0)
                {

                    gvArticulos.DataSource = ds.Tables["Articulos"];
                    gvArticulos.DataBind();
                }
                else
                {

                    lblMensajeE.ForeColor = Color.Blue;
                    lblMensajeE.Text = "La lista de artículos se encuentra vacía";
                }

            }
            catch (SqlException sqlex)
            {
                lblMensajeE.ForeColor = Color.Red;
                lblMensajeE.Text = "ERROR SQL: " + sqlex.Message;
            }
            catch (Exception ex)
            {
                lblMensajeE.ForeColor = Color.Red;
                lblMensajeE.Text = "ERROR inesperado: " + ex.Message;
            }
        }
    }
}