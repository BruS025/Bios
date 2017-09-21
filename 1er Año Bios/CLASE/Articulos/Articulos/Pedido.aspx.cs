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
    public partial class Pedido : System.Web.UI.Page
    {
        string Conexion_Str = "Data Source=.\\SQLExpress;Initial Catalog = ArticulosDB; Integrated Security= true;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conexion = new SqlConnection(Conexion_Str);

                SqlDataAdapter adaptador = new SqlDataAdapter("select Id,Nombre from Articulos", conexion);

                //objeto donde se almacenara en memoria la info obtenida
                DataSet ds = new DataSet();

                try
                {
                    adaptador.Fill(ds, "Articulos"); //FILL consulta los datos y los agrega al dataset
                    DropDownList1.DataSource = ds.Tables["Articulos"];
                    //cargo la info en la grilla
                    DropDownList1.DataValueField = "id";
                    DropDownList1.DataTextField = "Nombre";
                    DropDownList1.DataBind();

                    if (Session["dataset"] == null)
                    {

                        DataTable tabla = new DataTable("TablaArticulos");
                        DataColumn id = new DataColumn("Id");
                        DataColumn Nombre = new DataColumn("Nombre");
                        DataColumn Cantidad = new DataColumn("Cantidad");
                        DataColumn Precio = new DataColumn("Precio");

                        tabla.Columns.Add("Id");
                        tabla.Columns.Add("Nombre");
                        tabla.Columns.Add("Cantidad");
                        tabla.Columns.Add("Precio");
                        Session["dataset"] = tabla;
                    }

                }
                catch (SqlException ex)
                {
                    LbResultado.Text = "ERROR SQL: " + ex.Message;
                }
            }
        }

        protected void BtGuardar_Click(object sender, EventArgs e)
        {
            if (Session["dataset"] != null)
            {

                DataTable tabla = (DataTable)Session["dataset"];

                DataRow row = tabla.NewRow();

                row["Id"] = DropDownList1.SelectedValue;
                row["Nombre"] = DropDownList1.SelectedItem.Text;
                row["Cantidad"] = txtCantidadaG.Text;
                row["Precio"] = txtPrecioGuar.Text;
                tabla.Rows.Add(row);
                GridMostrar.DataSource = tabla;

                GridMostrar.DataBind();
                Session["dataset"] = tabla;

                txtCantidadaG.Text = "";
                txtPrecioGuar.Text = "";
            }
        }

        protected void BtGuarPedi_Click(object sender, EventArgs e)
        {
            txtFecha.Text;
            txtDescuento.Text;
            txtSubTotal.Text;
            txtTotal.Text;
            txtCliente.Text;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString= "Data Source=.\\SQLExpress;Initial Catalog = ArticulosDB; Integrated Security= true;";

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "Agregarr ";
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter oFecha = new SqlParameter("@fecha", txtFecha.Text);
            SqlParameter oDescuento = new SqlParameter("@descuento", txtDescuento.Text);
            /*       //conexion a la bd
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "data source=.; Initial Catalog = Empresa; Integrated Security = true";

            //comando q ejecutara el SP de alta
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "AltaEmpleados ";
            comando.CommandType = CommandType.StoredProcedure;

            //parametros para envio de datos al SP
            SqlParameter oNombre = new SqlParameter("@nombre", txtNombre.Text);
            SqlParameter oCI = new SqlParameter("@cedula", txtCI.Text);
            SqlParameter oEdad = new SqlParameter("@edad", txtEdad.Text);
            SqlParameter oSueldo = new SqlParameter("@sueldo", 25);
            SqlParameter oCasado = new SqlParameter("@casado", false);
            SqlParameter oTrabaja = new SqlParameter("@trabaja", 11111111);
            comando.Parameters.Add(oNombre);
            comando.Parameters.Add(oCI);
            comando.Parameters.Add(oEdad);
            comando.Parameters.Add(oSueldo);
            comando.Parameters.Add(oCasado);
            comando.Parameters.Add(oTrabaja);

            //captura el retorno del procedimiento almacenado.
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(oRetorno);*/
        }
    }
}
 