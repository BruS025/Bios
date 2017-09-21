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
    public partial class Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                /*Creo la tabla y columnas que guarda los items del pedido*/
                DataTable tabla = new DataTable("TablaArticulos");

                DataColumn Id = new DataColumn("Id");
                DataColumn Nombre = new DataColumn("Nombre");
                DataColumn Cantidad = new DataColumn("Cantidad");
                DataColumn Precio = new DataColumn("Precio");

                tabla.Columns.Add(Id);
                tabla.Columns.Add(Nombre);
                tabla.Columns.Add(Cantidad);
                tabla.Columns.Add(Precio);

                Session["ItemsPedido"] = tabla;

                /*Cargo la fecha*/
                txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

                /*Cargo los articulos dentro del DropdownList*/
                string query = "SELECT Id, Nombre FROM Articulos";
                SqlConnection conexion = new SqlConnection(Conexion.CnnString);
                SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                DataSet ds = new DataSet();

                try
                {
                    adaptador.Fill(ds, "Articulos");

                    if (ds.Tables["Articulos"].Rows.Count != 0)
                    {

                        ddlListArticulos.DataSource = ds.Tables["Articulos"];
                        ddlListArticulos.DataValueField = "Id";
                        ddlListArticulos.DataTextField = "Nombre";
                        ddlListArticulos.DataBind();
                    }
                }
                catch (SqlException sqlex)
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "ERROR SQL: " + sqlex.Message;
                }
                catch (Exception ex)
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "ERROR inesperado: " + ex.Message;
                }    
            }
            
        }

        protected void btnAgregarItem_Click(object sender, EventArgs e)
        {
            int cantidad = 0;
            int precio = 0;

            if (int.TryParse(txtCantidad.Text, out cantidad) && int.TryParse(txtPrecio.Text, out precio))
            {
                DataTable tablaItemsPedidos = (DataTable)Session["ItemsPedido"];

                DataRow row = tablaItemsPedidos.NewRow();
                row["Id"] = ddlListArticulos.SelectedValue;
                row["Nombre"] = ddlListArticulos.SelectedItem.Text;
                row["Cantidad"] = txtCantidad.Text;
                row["Precio"] = txtPrecio.Text;
                tablaItemsPedidos.Rows.Add(row);

                gvItemsPedido.DataSource = tablaItemsPedidos;
                gvItemsPedido.DataBind();

                CalcularTotalYSubtotal(tablaItemsPedidos);

                txtCantidad.Text = "";
                txtPrecio.Text = "";
            }
            else
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Precio o Cantidad invalidos.";
            }
        }

        public void CalcularTotalYSubtotal(DataTable tabla) 
        {
            int subtotal = 0;

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                int cantidad = Convert.ToInt32(tabla.Rows[i]["Cantidad"]);
                int precio = Convert.ToInt32(tabla.Rows[i]["Precio"]);

                subtotal = (precio * cantidad) +  subtotal ;
            }

            txtSubTotal.Text = subtotal.ToString();
            txtTotal.Text =  (subtotal * 1.22).ToString();
        }

        protected void btnGuardarPedido_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "" || txtCliente.Text.Length < 3)
            {
                lblMensaje.ForeColor = Color.Blue;
                lblMensaje.Text = "Debe ingresar un cliente válido";
            }
            else
            {
                DataTable tablaItemsPedidos = (DataTable)Session["ItemsPedido"]; 

                SqlConnection conexion = new SqlConnection(Conexion.CnnString);
                /*Creo una transacción*/
                SqlTransaction transaction;

                string total = txtTotal.Text.Replace(",",".");
                string subtotal=txtSubTotal.Text.Replace(",",".");

                string scriptPedido = "INSERT INTO Pedido VALUES('" + txtfecha.Text + "', '" + txtDesc.Text + "', " + total + ", " + subtotal + ", '" + txtCliente.Text + "')";


                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                conexion.Open();
                transaction = conexion.BeginTransaction("Transacción de ejemplo");

                comando.Transaction = transaction;
                try
                {
                    /*Creo el pedido*/
                    comando.CommandText = scriptPedido;
                    comando.ExecuteNonQuery();

                    /*Obtengo el Id Generado*/
                    comando.CommandText = "SELECT @@IDENTITY as id;";
                    SqlDataReader reader = comando.ExecuteReader();

                    int idPedido = 0;

                    while (reader.Read())
                    {
                        idPedido = Convert.ToInt32(reader["id"]);
                    }
                    reader.Close();

                    if (idPedido == 0)
                    {
                        throw new Exception("Error al procesar el pedido");
                    }
                    /*Creo los items del pedido*/
                    string scriptItemsTemplate = "INSERT INTO Tiene VALUES({0}, {1}, {2}, {3});";

                    for (int i = 0; i < tablaItemsPedidos.Rows.Count; i++)
                    {
                        int idArticulo = Convert.ToInt32(tablaItemsPedidos.Rows[i]["Id"]);
                        int cantidad = Convert.ToInt32(tablaItemsPedidos.Rows[i]["Cantidad"]);
                        int precio = Convert.ToInt32(tablaItemsPedidos.Rows[i]["Precio"]);

                        comando.CommandText = String.Format(scriptItemsTemplate, idArticulo, idPedido, cantidad, precio);

                        comando.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    lblMensaje.ForeColor = Color.Green;
                    lblMensaje.Text = "Pedido agregado con éxito";

                
                }
                catch (SqlException sqlex)
                {
                    
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "ERROR SQL: " + sqlex.Message;

                    transaction.Rollback();
                }
                catch (Exception ex)
                {

                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "ERROR inesperado: " + ex.Message;

                    transaction.Rollback();
                }
                finally
                {
                    conexion.Close();
                }
            }
        }
    }
}