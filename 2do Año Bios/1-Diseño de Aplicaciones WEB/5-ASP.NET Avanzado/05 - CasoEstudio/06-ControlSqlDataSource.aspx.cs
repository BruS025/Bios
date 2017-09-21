using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Data.SqlClient;

public partial class _06_ControlSqlDataSource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void BtnConsulta_Click(object sender, EventArgs e)
    {
        
    }
    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        //Verifico que se haya ingresado un numero en el codigo
        try
        {
            int unCodigo = Convert.ToInt32(txtCodigo.Text);
            //Si tengo numero borro
            sdsArticulos.Delete();
            LblError.Text = "Eliminacion Exitosa";
        }
        catch (Exception ex)
        {
            LblError.Text = "Error tratando de borrar" + ex.Message;
        }
    }
}
