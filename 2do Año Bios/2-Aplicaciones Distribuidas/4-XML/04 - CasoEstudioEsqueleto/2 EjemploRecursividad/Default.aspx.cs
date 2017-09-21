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

//agrego uso de XML
using System.Xml;

public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnProcesar_Click(object sender, EventArgs e)
    {
        TxtMostrar.Text = "";

        // levanto arcivo xml que voy a mostrar en la paina
        XmlDocument _XmlAlumnos = new XmlDocument();
        _XmlAlumnos.Load(Server.MapPath("~/XML/Alumnos.xml"));

        // obteno nodo raiz
        XmlNode _NodoRaiz = _XmlAlumnos.DocumentElement;

        // muestro el nodo raiz en el listbox
        TxtMostrar.Text += "Nombre Nodo Raiz: " + _NodoRaiz.Name + "\n";

        // Invoco metodo revusrivo para mostrar contenido
        MostrarNodoRecursivo(_NodoRaiz);
  
    }

 
    protected void BtnAlReves_Click(object sender, EventArgs e)
    {
        TxtMostrar.Text = "";

        // levanto arcivo xml que voy a mostrar en la paina
        XmlDocument _XmlAlumnos = new XmlDocument();
        _XmlAlumnos.Load(Server.MapPath("~/XML/Alumnos.xml"));

        // obteno nodo raiz
        XmlNode _NodoRaiz = _XmlAlumnos.DocumentElement;

        // Invoco metodo revusrivo para mostrar contenido
        MostrarNodoRecursivo2(_NodoRaiz);

        // muestro el nodo raiz en el listbox
        TxtMostrar.Text += "Nombre Nodo Raiz: " + _NodoRaiz.Name + "\n";

    }

    // Funcion recursiva
    private void MostrarNodoRecursivo(XmlNode pNodo)
    {
        // Recorrer todos los nodos hijos directos del nodo que viene por parametro
        for(int indice = 0; indice < pNodo.ChildNodes.Count;indice++)
        {
            if(pNodo.ChildNodes[indice].NodeType == XmlNodeType.Element) // Etiqueta no texto contenido
            {
                // Agrego el nombre de la etiqueta si estoy ante un elemento del tipo <elemento>
                // Pregunto si tiene elementos ijos,asi no intento (por eso preunto por la cantidad de ijos mayor a 1 ya que el texto contenido se consideta un ijo mas)
                if(pNodo.ChildNodes[indice].ChildNodes.Count > 1)
                {
                    TxtMostrar.Text += pNodo.ChildNodes[indice].Name + "\n"; // Name nombre de etiqueta

                }
                else
                {
                    TxtMostrar.Text += "\t" + pNodo.ChildNodes[indice].Name;
                }
            }

            else
            {
                // Arero el texto si estoy ante el contenido de un elemento <elemento>  contenido </elemento>
                TxtMostrar.Text += ":  " + pNodo.ChildNodes[indice].InnerText + "\n";
            }

            // SI ay nodos ijos,mando cada uno a mostrarse
            if(pNodo.ChildNodes.Count > 0)
            {
                MostrarNodoRecursivo(pNodo.ChildNodes[indice]);
            }
        }
    }

    private void MostrarNodoRecursivo2(XmlNode pNodo)
    {
        // Recorrer todos los nodos hijos directos del nodo que viene por parametro
        for (int indice = pNodo.ChildNodes.Count-1; indice >= 0; indice--)
        {
            if (pNodo.ChildNodes[indice].NodeType == XmlNodeType.Element) // Etiqueta no texto contenido
            {
                // Agrego el nombre de la etiqueta si estoy ante un elemento del tipo <elemento>
                // Pregunto si tiene elementos ijos,asi no intento (por eso preunto por la cantidad de ijos mayor a 1 ya que el texto contenido se consideta un ijo mas)
                if (pNodo.ChildNodes[indice].ChildNodes.Count > 1)
                {
                    TxtMostrar.Text += pNodo.ChildNodes[indice].Name + "\n"; // Name nombre de etiqueta

                }
                else
                {
                    TxtMostrar.Text += "\t" + pNodo.ChildNodes[indice].Name;
                }
            }

            else
            {
                // Arero el texto si estoy ante el contenido de un elemento <elemento>  contenido </elemento>
                TxtMostrar.Text += ":  " + pNodo.ChildNodes[indice].InnerText + "\n";
            }

            // SI ay nodos ijos,mando cada uno a mostrarse
            if (pNodo.ChildNodes.Count > 0)
            {
                MostrarNodoRecursivo2(pNodo.ChildNodes[indice]);
            }
        }
    }

}
