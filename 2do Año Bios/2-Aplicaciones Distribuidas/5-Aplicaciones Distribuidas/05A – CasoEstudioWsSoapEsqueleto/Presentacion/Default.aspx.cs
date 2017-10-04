using System;
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

using ReferenciaCalculosMatematicos;


public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

     protected void btnCalculoF_Click(object sender, EventArgs e)
    {
        try
        {
            //obtengo el numero para calcular el factorial
            long _numero = (Convert.ToInt64(txtNumero.Text));

            //creo un objeto que me permuta consumir el WS a travez del soap
            CalculosMatematicosSoapClient unServicio = new CalculosMatematicosSoapClient("CalculosMatematicosSoap");

            //consumo directamente una operacion del WS
            lblDespliego.Text = "Resultado del factorial: " + unServicio.Factorial(_numero);

            //limpio cajas de ingreso
            txtNumero.Text = "";
        }
        catch (Exception ex)
        {
            lblDespliego.Text = ex.Message;
        }
    }

    protected void btnCalculoP_Click(object sender, EventArgs e)
    {
        try
        {
            //obtengo el numero para calcular el factorial
            double _numeroB = (Convert.ToDouble(txtBase.Text));
            double _numeroE = (Convert.ToDouble(txtExponente.Text));

            //creo un objeto que me permuta consumir el WS a travez del soap
            CalculosMatematicosSoapClient unServicio = new CalculosMatematicosSoapClient("CalculosMatematicosSoap");

            //consumo directamente una operacion del WS
            lblDespliego.Text = "Resultado de la potencia: " + unServicio.Potencia(_numeroB,_numeroE);

            //limpio cajas de ingreso
            txtNumero.Text = "";
        }
        catch (Exception ex)
        {
            lblDespliego.Text = ex.Message;
        }
    }
}
