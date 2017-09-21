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

public partial class _04_ExploracionManual : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Obtengo el nodo raiz
        SiteMapNode NodoRaiz = SiteMap.RootNode;

        //a partir del nodo raiz,obtengo los nodos secundarios
        SiteMapNodeCollection ColNodos = NodoRaiz.ChildNodes;

        /*recorro toda la estructura y por cada elemento que tenga en el sitemap,
         * agrego un boton con sus datos*/

        //1.- Agrego el nodo raiz
        LinkButton BotonRaiz = new LinkButton();
        BotonRaiz.ID = "BtnRaiz";
        BotonRaiz.Text = NodoRaiz.Description;
        BotonRaiz.PostBackUrl = NodoRaiz.Url;
        PContenedor.Controls.Add(BotonRaiz);
        //Agrego dps del control un cambio de linea
        PContenedor.Controls.Add(new LiteralControl("<br />"));
        PContenedor.Controls.Add(new LiteralControl("<div style='margin-left:40px'>"));

        //2.-agrego sus hijos y si estos tienen hijos tambien 
        //cada uno con color diferente para marcar los niveles
        foreach  (SiteMapNode Nodo in ColNodos)
        {
            //agrego boton por el nodo
            LinkButton unBoton = new LinkButton();
            unBoton.ID = "btn" + Nodo.Title.Trim();
            unBoton.Text = Nodo.Title;
            unBoton.PostBackUrl = Nodo.Url;
            unBoton.ForeColor = System.Drawing.Color.Brown;
            PContenedor.Controls.Add(unBoton);
            //agrego dps del control un cambio de linea
            PContenedor.Controls.Add(new LiteralControl("<br />"));
            //verifico si hay hijos
            if(Nodo.HasChildNodes)
            {
                PContenedor.Controls.Add(new LiteralControl("<div style='margin-left:80px'>"));
                foreach (SiteMapNode Nodito in Nodo.ChildNodes)
                {
                    //agrego boton por el nodo secundario
                    LinkButton otroBoton = new LinkButton();
                    otroBoton.ID = "btn" + Nodito.Title;
                    otroBoton.Text = Nodito.Description;
                    otroBoton.PostBackUrl = Nodito.Url;
                    otroBoton.ForeColor = System.Drawing.Color.Chartreuse;
                    PContenedor.Controls.Add(otroBoton);
                    //Agrego dps del control un cambio de linea
                    PContenedor.Controls.Add(new LiteralControl("<br />"));
                }//fin nodito
                PContenedor.Controls.Add(new LiteralControl("</div>"));
            }//fin if
        }//fin foreach nodo
        PContenedor.Controls.Add(new LiteralControl("</div>"));
    }
}
