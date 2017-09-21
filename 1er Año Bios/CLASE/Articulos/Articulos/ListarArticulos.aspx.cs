using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Articulos
{
    public partial class ListarArticulos : System.Web.UI.Page
    {
        string Conexion_Str = "Data Source=.\\SQLExpress;Initial Catalog = ArticulosDB; Integrated Security= true;";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Forma desconectada
        protected void Button1_Click(object sender, EventArgs e)
        {

            //determino la conexion
            SqlConnection conexion = new SqlConnection(Conexion_Str);

            //cargo objeto que busca la info en la bd
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Id,Nombre,Tipo FROM Articulos", conexion);

            //objeto donde se almacenara en memoria la info obtenida
            DataSet ds = new DataSet();

            try
            {
                adaptador.Fill(ds, "Articulos");

                GridArticulos.DataSource = ds.Tables["Articulos"];

                GridArticulos.DataBind();
            }
            catch (SqlException ex)
            {
                lbResultado.Text = "Error" + ex.Message;
            }


        }
    }
}