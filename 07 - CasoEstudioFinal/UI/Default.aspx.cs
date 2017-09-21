using System;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;



public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
        //por defecto cada vez q vuelvo o paso por la defaul, determino q se realizo un Deslogueo
        Session["Usuario"] = null;
    }



    protected void BtnLogueo_Click(object sender, EventArgs e)
    {
        try
        {
            //verifico usuario
            EntidadesCompartidas.Usuario unUsu = Logica.LogicaUsuario.Logueo(TxtNomUsu.Text.Trim(), TxtPassUsu.Text.Trim());
            if (unUsu != null)
            {
                //si llego aca es pq es valido
                Session["Usuario"] = unUsu;
                Response.Redirect("Principal.aspx");
            }
            else
                LblError.Text = "Datos Incorrectos";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}
