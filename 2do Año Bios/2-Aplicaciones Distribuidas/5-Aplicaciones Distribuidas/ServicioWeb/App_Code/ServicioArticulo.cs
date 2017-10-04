using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using EntidadesCompartidas;
using Logica;

/// <summary>
/// Descripción breve de ServicioArticulo
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class ServicioArticulo : System.Web.Services.WebService
{

    public ServicioArticulo()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Articulo BuscarArticulo(int pCodigo)

    {
        try
        {
            ILogicaArticulo LArticulo = FabricaLogica.getLogicaArticulo();
            return LArticulo.BuscarArticulo(pCodigo);
        }
        catch (Exception ex)
        {
            //generacion manual de excepcion soap para poder obtener
            //solo el mensaje enviado por alguna de las capas
            //1.- se debe crear un nodo xml(nodoError) el cual sera utilizado 
            //para cargar el aributo details de la exepcion SOAP
            XmlDocument _unDoc = new XmlDocument();
            XmlNode _NodoError = _unDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
            //2.-se crea un nodo xml(nodoDetalle) que contendra el texto del error
            XmlNode _NodoDetalle = _unDoc.CreateNode(XmlNodeType.Element, "Error", "");
            _NodoDetalle.InnerText = ex.Message;
            //3.-se agrega el nodo de detalle al nodo de error
            _NodoError.AppendChild(_NodoDetalle);
            //4 creacion manual de exepcion soap

            /*parametro 1 mensaje basico de cada excepcion
             * parametro 2 determina codigo de errro para la exception
             * parametro 3 se obtiene la url de la solicitud actual 
             * parametro 4 informacion especifica sobra la excepcion generada
             * 
             * carga automaticamente la propiedad details
             */



            SoapException _miEx = new SoapException("Error WS", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

            //se lanza excepcion creada (no una automatica del ws)
            throw _miEx;
        }
    }

    [WebMethod]
    public Articulo AltaArticulo(Articulo a)

    {
        try
        {
            ILogicaArticulo LArticulo = FabricaLogica.getLogicaArticulo();
            return LArticulo.AgregarArticulo(a);
        }
        catch (Exception ex)
        {
            //generacion manual de excepcion soap para poder obtener
            //solo el mensaje enviado por alguna de las capas
            //1.- se debe crear un nodo xml(nodoError) el cual sera utilizado 
            //para cargar el aributo details de la exepcion SOAP
            XmlDocument _unDoc = new XmlDocument();
            XmlNode _NodoError = _unDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
            //2.-se crea un nodo xml(nodoDetalle) que contendra el texto del error
            XmlNode _NodoDetalle = _unDoc.CreateNode(XmlNodeType.Element, "Error", "");
            _NodoDetalle.InnerText = ex.Message;
            //3.-se agrega el nodo de detalle al nodo de error
            _NodoError.AppendChild(_NodoDetalle);
            //4 creacion manual de exepcion soap

            /*parametro 1 mensaje basico de cada excepcion
             * parametro 2 determina codigo de errro para la exception
             * parametro 3 se obtiene la url de la solicitud actual 
             * parametro 4 informacion especifica sobra la excepcion generada
             * 
             * carga automaticamente la propiedad details
             */



            SoapException _miEx = new SoapException("Error WS", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

            //se lanza excepcion creada (no una automatica del ws)
            throw _miEx;
        }
    }

    [WebMethod]
    public Articulo BajaArticulo(Articulo a)

    {
        try
        {
            ILogicaArticulo LArticulo = FabricaLogica.getLogicaArticulo();
            return LArticulo.EliminarArticulo(a);
        }
        catch (Exception ex)
        {
            //generacion manual de excepcion soap para poder obtener
            //solo el mensaje enviado por alguna de las capas
            //1.- se debe crear un nodo xml(nodoError) el cual sera utilizado 
            //para cargar el aributo details de la exepcion SOAP
            XmlDocument _unDoc = new XmlDocument();
            XmlNode _NodoError = _unDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
            //2.-se crea un nodo xml(nodoDetalle) que contendra el texto del error
            XmlNode _NodoDetalle = _unDoc.CreateNode(XmlNodeType.Element, "Error", "");
            _NodoDetalle.InnerText = ex.Message;
            //3.-se agrega el nodo de detalle al nodo de error
            _NodoError.AppendChild(_NodoDetalle);
            //4 creacion manual de exepcion soap

            /*parametro 1 mensaje basico de cada excepcion
             * parametro 2 determina codigo de errro para la exception
             * parametro 3 se obtiene la url de la solicitud actual 
             * parametro 4 informacion especifica sobra la excepcion generada
             * 
             * carga automaticamente la propiedad details
             */



            SoapException _miEx = new SoapException("Error WS", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

            //se lanza excepcion creada (no una automatica del ws)
            throw _miEx;
        }
    }

    [WebMethod]
    public Articulo ModificarArticulo(Articulo a)

    {
        try
        {
            ILogicaArticulo LArticulo = FabricaLogica.getLogicaArticulo();
            return LArticulo.ModificarArticulo(a);
        }
        catch (Exception ex)
        {
            //generacion manual de excepcion soap para poder obtener
            //solo el mensaje enviado por alguna de las capas
            //1.- se debe crear un nodo xml(nodoError) el cual sera utilizado 
            //para cargar el aributo details de la exepcion SOAP
            XmlDocument _unDoc = new XmlDocument();
            XmlNode _NodoError = _unDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
            //2.-se crea un nodo xml(nodoDetalle) que contendra el texto del error
            XmlNode _NodoDetalle = _unDoc.CreateNode(XmlNodeType.Element, "Error", "");
            _NodoDetalle.InnerText = ex.Message;
            //3.-se agrega el nodo de detalle al nodo de error
            _NodoError.AppendChild(_NodoDetalle);
            //4 creacion manual de exepcion soap

            /*parametro 1 mensaje basico de cada excepcion
             * parametro 2 determina codigo de errro para la exception
             * parametro 3 se obtiene la url de la solicitud actual 
             * parametro 4 informacion especifica sobra la excepcion generada
             * 
             * carga automaticamente la propiedad details
             */



            SoapException _miEx = new SoapException("Error WS", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

            //se lanza excepcion creada (no una automatica del ws)
            throw _miEx;
        }
    }

    [WebMethod]
    public List<Articulo> ListarArticulo()

    {
        try
        {
            ILogicaArticulo LArticulo = FabricaLogica.getLogicaArticulo();
            return LArticulo.ListarArticulo();
        }
        catch (Exception ex)
        {
            //generacion manual de excepcion soap para poder obtener
            //solo el mensaje enviado por alguna de las capas
            //1.- se debe crear un nodo xml(nodoError) el cual sera utilizado 
            //para cargar el aributo details de la exepcion SOAP
            XmlDocument _unDoc = new XmlDocument();
            XmlNode _NodoError = _unDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
            //2.-se crea un nodo xml(nodoDetalle) que contendra el texto del error
            XmlNode _NodoDetalle = _unDoc.CreateNode(XmlNodeType.Element, "Error", "");
            _NodoDetalle.InnerText = ex.Message;
            //3.-se agrega el nodo de detalle al nodo de error
            _NodoError.AppendChild(_NodoDetalle);
            //4 creacion manual de exepcion soap

            /*parametro 1 mensaje basico de cada excepcion
             * parametro 2 determina codigo de errro para la exception
             * parametro 3 se obtiene la url de la solicitud actual 
             * parametro 4 informacion especifica sobra la excepcion generada
             * 
             * carga automaticamente la propiedad details
             */



            SoapException _miEx = new SoapException("Error WS", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

            //se lanza excepcion creada (no una automatica del ws)
            throw _miEx;
        }
    }
}
