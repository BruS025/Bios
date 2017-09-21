using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Configuration;
using System.Data;
using System.Xml.Linq;

public partial class AbmLibro : System.Web.UI.Page
{
    // Att de formulario
    private int _haySeleccion = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            // Mando a cargar la grilla con los datos que ya contenga dicho archivo
            CargarDatos();

            // Por defecto no tenemos nada seleccionado
            _haySeleccion = 0;
            ViewState["_haySeleccion"] = _haySeleccion;

            // Determino botones por defectos
            this.BotonesPorDefecto();
        }

        else
        {
            // Mantengo el estado de si hubo seleccion o no para modificar y eliminar
            _haySeleccion = (int)ViewState["_haySeleccion"];
        }
 
    }

    protected void GVLibros_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // Determino arc de orien de datos
            string _camino = Server.MapPath(ConfigurationManager.AppSettings["XmlLibros"]);
            // Recupero el documento xml, para agregar nuevo nodo de libro
            XmlDocument _DocumentoXML = new XmlDocument();
            _DocumentoXML.Load(_camino);

            XmlNode _NodoL = _DocumentoXML.DocumentElement.ChildNodes[GVLibros.SelectedIndex];
            // Determino q nodo esta seleccionado
            ViewState["_haySeleccion"] = GVLibros.SelectedIndex;

            TxtIsbn.Text = _NodoL["ISBN"].InnerText;
            TxtTitulo.Text = _NodoL["Titulo"].InnerText;
            TxtCategoria.Text = _NodoL.Attributes["Categoria"].InnerText;

            // Determino  el autor recordar q solo puede aber un elemento seleccionado en la sta
            foreach (ListItem _unItem in DdlAutor.Items)
            {
                if (_unItem.Value == _NodoL["Autor"].InnerText)
                {
                    _unItem.Selected = true;
                }
                else
                {
                    _unItem.Selected = false;
                }
            }
            this.BotonesBM();
        }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }

    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            // Determino arc de orien de datos
            string _camino = Server.MapPath(ConfigurationManager.AppSettings["XmlLibros"]);
            // Recupero el documento xml, para agregar nuevo nodo de libro
            XmlDocument _DocumentoXML = new XmlDocument();
            _DocumentoXML.Load(_camino);

            // Codigo defensivo LINQ to XML
            // Por que devuelve todas las etieuteas sin importar el nivel
            XElement.Parse(_DocumentoXML.OuterXml);
            
            // Creo el nodo libro con su atributo
            XmlNode _NodoL = _DocumentoXML.CreateNode(XmlNodeType.Element, "Libro", "");
            XmlAttribute _AtributoCategoria = _DocumentoXML.CreateAttribute("Categoria");
            _AtributoCategoria.InnerText = TxtCategoria.Text.Trim();
            _NodoL.Attributes.Append(_AtributoCategoria);

            // Creo nodo ISBN
            XmlNode _NodoI = _DocumentoXML.CreateNode(XmlNodeType.Element, "ISBN", "");
            _NodoI.InnerText = TxtIsbn.Text.Trim();
            _NodoL.AppendChild(_NodoI);

            // Creo subnodo Titulo
            XmlNode _NodoT = _DocumentoXML.CreateNode(XmlNodeType.Element, "Titulo", "");
            _NodoT.InnerText = TxtTitulo.Text.Trim();
            _NodoL.AppendChild(_NodoT);

            // Creo nodo Autor
            XmlNode _NodoA = _DocumentoXML.CreateNode(XmlNodeType.Element, "Autor", "");
            _NodoA.InnerText = DdlAutor.SelectedValue;
            _NodoL.AppendChild(_NodoA);

            _DocumentoXML.DocumentElement.AppendChild(_NodoL); // Agrego nodo a la reailz - agrego nodo primario

            _DocumentoXML.Save(_camino);

            // Actualiza pantalla
            this.CargarDatos();
            this.LimpiarControles();
            this.BotonesPorDefecto();

            LblError.Text = "Alta con exito";

        }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }
 
    }

    protected void BtnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            string _camino = Server.MapPath(ConfigurationManager.AppSettings["XmlLibros"]);

            // Recupero el documento xml, para eliminar nodo de libro.
            XmlDocument _DocumentoXML = new XmlDocument();
            _DocumentoXML.Load(_camino);

            // Primero verifico si alun libro desde la rilla
            // POsicion nodo (int)ViewState["_haySeleccion"]
            XmlNode _NodoL = _DocumentoXML.DocumentElement.ChildNodes[(int)ViewState["_haySeleccion"]];
            if (_NodoL == null)
            {
                LblError.Text = "No se puede eliminar, por que no se selecciono nada";
                return;
            }

            // Elimino el nodo seleccionado
            _DocumentoXML.DocumentElement.RemoveChild(_NodoL);
            // Salvo los cambios
            _DocumentoXML.Save(_camino);
            // Determino que no ay seleccion
            ViewState["_haySeleccion"] = 0;
            // Actualizo pantalla
            this.CargarDatos();
            this.LimpiarControles();
            this.BotonesPorDefecto();
            // Si yee aca es por que todo ok
            LblError.Text = "Baja con exito";
        }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }
        

    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            // Determino arc de orien de datos
            string _camino = Server.MapPath(ConfigurationManager.AppSettings["XmlLibros"]);
            // Recupero el documento xml, para agregar nuevo nodo de libro
            XmlDocument _DocumentoXML = new XmlDocument();
            _DocumentoXML.Load(_camino);

            // Primero verifico su se sekeccuibi akgun libro desde la grila
            XmlNode _NodoL = _DocumentoXML.DocumentElement.ChildNodes[(int)ViewState["_haySeleccion"]];

            if(_NodoL == null)
            {
                LblError.Text = "No se puede eliminar, por uqe no se selecciono nada";
                return;
            }

            _NodoL["ISBN"].InnerText = TxtIsbn.Text.Trim();
            _NodoL["Titulo"].InnerText = TxtTitulo.Text.Trim();
            _NodoL.Attributes["Categoria"].InnerText = TxtCategoria.Text.Trim();
            _NodoL["Autor"].InnerText = DdlAutor.SelectedValue;

            _DocumentoXML.Save(_camino);
            ViewState["_haySeleccion"] = 0;

            // Actualiza pantalla
            this.CargarDatos();
            this.LimpiarControles();
            this.BotonesPorDefecto();

            LblError.Text = "Modifico con exito";

        }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }
    }

    private void CargarDatos()
    {
        try
        {
            // Determino el camino completo de la ubicacion del archivo XML para ABM
            string _camino = Server.MapPath(ConfigurationManager.AppSettings["XmlLibros"]);
            // Leo info del archivo
            DataSet _Ds = new DataSet();
            _Ds.ReadXml(_camino);
            // Cargo la informacion de los libros en la grilla
            GVLibros.DataSource = _Ds;
            GVLibros.DataBind();
            // Cargo datos Autores
            _Ds.ReadXml(Server.MapPath("~/XML/Autores.xml"), XmlReadMode.InferSchema);
            DdlAutor.DataSource = _Ds.Tables["Autor"];
            DdlAutor.DataTextField = "Nombre";
            DdlAutor.DataValueField = "codigo";
            DdlAutor.DataBind();

        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;

        }
    }

    private void BotonesPorDefecto()
    {
        BtnAlta.Enabled = true;
        BtnBaja.Enabled = false;
        BtnModificar.Enabled = false;

    }

    private void BotonesBM()
    {
        BtnAlta.Enabled = false;
        BtnBaja.Enabled = true;
        BtnModificar.Enabled = true;
    }

    private void LimpiarControles()
    {
        TxtIsbn.Text = "";
        TxtTitulo.Text = "";
        TxtCategoria.Text = "";
        DdlAutor.SelectedIndex = 0;
    }

}