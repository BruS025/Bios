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

public partial class _Default : System.Web.UI.Page
{
    private int _seleccion = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            CargarDatos();
            _seleccion = 0;
            ViewState["_seleccion"] = _seleccion;
            this.BotonesPorDefecto();

        }

        else
        {
            _seleccion = (int)ViewState["_seleccion"];
        }

    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {
                    
        // Determino arc de orien de datos
        string _camino = Server.MapPath(ConfigurationManager.AppSettings["XmlAutos"]);
        // Recupero el documento xml, para agregar nuevo nodo de libro
        XmlDocument _DocumentoXML = new XmlDocument();
        _DocumentoXML.Load(_camino);

        // Codigo defensivo LINQ to XML
        // Por que devuelve todas las etieuteas sin importar el nivel
        XElement.Parse(_DocumentoXML.OuterXml);

        // Creo el nodo libro con su atributo
        XmlNode _NodoL = _DocumentoXML.CreateNode(XmlNodeType.Element, "Auto", "");

        // Creo nodo ISBN
        XmlNode _NodoI = _DocumentoXML.CreateNode(XmlNodeType.Element, "Matricula", "");
        _NodoI.InnerText = TxtMatricula.Text.Trim();
        _NodoL.AppendChild(_NodoI);

        // Creo subnodo Titulo
        XmlNode _NodoT = _DocumentoXML.CreateNode(XmlNodeType.Element, "Marca", "");
        _NodoT.InnerText = TxtMarca.Text.Trim();
        _NodoL.AppendChild(_NodoT);

        // Creo subnodo Titulo
        XmlNode _NodoM = _DocumentoXML.CreateNode(XmlNodeType.Element, "Modelo", "");
        _NodoM.InnerText = txtModelo.Text.Trim();
        _NodoL.AppendChild(_NodoM);

        // Creo nodo Autor
        XmlNode _NodoA = _DocumentoXML.CreateNode(XmlNodeType.Element, "Duenio", "");
        _NodoA.InnerText = ddlDuenio.SelectedValue;
        _NodoL.AppendChild(_NodoA);

        // Creo subnodo Titulo
        XmlNode _NodoP = _DocumentoXML.CreateNode(XmlNodeType.Element, "Precio", "");
        _NodoP.InnerText = txtPrecio.Text.Trim();
        _NodoL.AppendChild(_NodoP);

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
            string _camino = Server.MapPath(ConfigurationManager.AppSettings["XmlAutos"]);

            // Recupero el documento xml, para eliminar nodo de libro.
            XmlDocument _DocumentoXML = new XmlDocument();
            _DocumentoXML.Load(_camino);

            // Primero verifico si alun libro desde la rilla
            // POsicion nodo (int)ViewState["_haySeleccion"]
            XmlNode _NodoL = _DocumentoXML.DocumentElement.ChildNodes[(int)ViewState["_seleccion"]];
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
            ViewState["_seleccion"] = 0;
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
            string _camino = Server.MapPath(ConfigurationManager.AppSettings["XmlAutos"]);
            // Recupero el documento xml, para agregar nuevo nodo de libro
            XmlDocument _DocumentoXML = new XmlDocument();
            _DocumentoXML.Load(_camino);

            // Primero verifico su se sekeccuibi akgun libro desde la grila
            XmlNode _NodoL = _DocumentoXML.DocumentElement.ChildNodes[(int)ViewState["_seleccion"]];

            if (_NodoL == null)
            {
                LblError.Text = "No se puede eliminar, por uqe no se selecciono nada";
                return;
            }

            _NodoL["Matricula"].InnerText = TxtMatricula.Text.Trim();
            _NodoL["Marca"].InnerText = TxtMarca.Text.Trim();
            _NodoL["Modelo"].InnerText = txtModelo.Text.Trim();
            _NodoL["Duenio"].InnerText = ddlDuenio.SelectedValue;
            _NodoL["Precio"].InnerText = txtPrecio.Text.Trim();

            _DocumentoXML.Save(_camino);
            ViewState["_seleccion"] = 0;

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

    protected void GVAutos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // Determino arc de orien de datos
            string _camino = Server.MapPath(ConfigurationManager.AppSettings["XmlAutos"]);
            // Recupero el documento xml, para agregar nuevo nodo de libro
            XmlDocument _DocumentoXML = new XmlDocument();
            _DocumentoXML.Load(_camino);

            XmlNode _NodoL = _DocumentoXML.DocumentElement.ChildNodes[GVAutos.SelectedIndex];
            // Determino q nodo esta seleccionado
            ViewState["_seleccion"] = GVAutos.SelectedIndex;

            TxtMatricula.Text = _NodoL["Matricula"].InnerText;
            TxtMarca.Text = _NodoL["Marca"].InnerText;
            txtModelo.Text = _NodoL["Modelo"].InnerText;
            ddlDuenio.SelectedValue = _NodoL["Duenio"].InnerText;
            txtPrecio.Text = _NodoL["Precio"].InnerText;
            
            // Determino  el autor recordar q solo puede aber un elemento seleccionado en la sta
            foreach (ListItem _unItem in ddlDuenio.Items)
            {
                if (_unItem.Value == _NodoL["Duenio"].InnerText)
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

    private void CargarDatos()
    {
        try
        {
            // Determino el camino completo de la ubicacion del archivo XML para ABM
            string _camino = Server.MapPath(ConfigurationManager.AppSettings["XmlAutos"]);
            // Leo info del archivo..........
            DataSet _Ds = new DataSet();
            _Ds.ReadXml(_camino);
            // Cargo la informacion de los autos
            GVAutos.DataSource = _Ds;
            GVAutos.DataBind();
            // Cargo datos duenio
            _Ds.ReadXml(Server.MapPath("~/XML/Duenios.xml"), XmlReadMode.InferSchema);
            ddlDuenio.DataSource = _Ds.Tables["Duenio"];
            ddlDuenio.DataTextField = "Nombre";
            ddlDuenio.DataValueField = "Cedula";
            ddlDuenio.DataBind();
            ddlDuenio2.DataSource = _Ds.Tables["Duenio"];
            ddlDuenio2.DataTextField = "Nombre";
            ddlDuenio2.DataValueField = "Cedula";
            ddlDuenio2.DataBind();
            

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
        TxtMatricula.Text = "";
        ddlDuenio.SelectedIndex = 0;
        TxtMarca.Text = "";
        txtModelo.Text = "";
        txtPrecio.Text = "";
    }

    protected void btBuscar_Click(object sender, EventArgs e)
    {
        // Limpio el resultado anterior
        GVAutos.DataSource = null;
        GVAutos.DataBind();
        LblError.Text = "";

        XElement _doc = XElement.Load(Server.MapPath("~/XML/Autos.xml"));
        XElement _doc2 = XElement.Load(Server.MapPath("~/XML/Duenios.xml"));

        var _resultado = (from unNodo in _doc.Elements("Auto")
                         select unNodo).ToList();

        if (txtMatricula2.Text != "")
        {
            _resultado = (from unNodo in _resultado
                          where (string)unNodo.Element("Matricula") == txtMatricula2.Text
                          select unNodo).ToList();
        }

        if (txtMarca2.Text != "")
        {
            _resultado = (from unNodo in _resultado
                          where (string)unNodo.Element("Marca") == txtMarca2.Text
                          select unNodo).ToList();
        }

        if (txtModelo2.Text != "")
        {
            _resultado = (from unNodo in _resultado
                          where (string)unNodo.Element("Modelo") == txtModelo2.Text
                          select unNodo).ToList();
        }

        if (ddlDuenio2.SelectedValue != "")
        {
           _resultado = (from unNodo in _resultado
                         join otroNodo in _doc2.Elements("Duenio") on (string)unNodo.Element("Duenio") equals (string)otroNodo.Element("Cedula")
                          where (string)otroNodo.Element("Nombre") == ddlDuenio2.SelectedValue
                          select unNodo).ToList();
        }

        if (txtPrecio2.Text != "")
        {
            _resultado = (from unNodo in _resultado
                          where (string)unNodo.Element("Precio") == txtPrecio2.Text
                          select unNodo).ToList();
        }

        var final = (from unNodo in _resultado
                     select
                     new
                     {
                         Matricula = unNodo.Element("Matricula").Value,
                         Marca = unNodo.Element("Marca").Value,
                         Modelo = unNodo.Element("Modelo").Value,
                         Duenio = unNodo.Element("Duenio").Value,
                         Precio = unNodo.Element("Precio").Value
                     }).ToList();
        
        GVAutos.DataSource = final;
        GVAutos.DataBind();
    }
}