using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EntidadesCompartidas;
using Logica;
using System.Web.Services.Protocols;
using System.Xml;

namespace Service
{
    /// <summary>
    /// Descripción breve de ServicioArticulos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioArticulos : System.Web.Services.WebService
    {
        /*
            Aqui dentro puedo hacer todas las operaciones que quiera, tomando en concideracion lo siguiente
            1- si las operaciones no son publicas no importa si las marco para operaciones http nadie las va a poder consumir
         */

        [WebMethod] //Atributo de comportamiento http (esto marca que esta puede ser vista desde un request http)
        public Articulo BuscarArticulo(int pCodigo)
        {
            try
            {
                ILogicaArticulo LArticulo = FabricaLogica.getLogicaArticulo();
                return LArticulo.BuscarArticulo(pCodigo);
            }
            catch (Exception ex)
            {
                throw getSoapException(ex);
            }
        }

        [WebMethod] 
        public void AltaArticulo(Articulo articulo)
        {
            try
            {
                ILogicaArticulo LArticulo = FabricaLogica.getLogicaArticulo();
                LArticulo.AgregarArticulo(articulo);
            }
            catch (Exception ex)
            {
                throw getSoapException(ex);
            }
        }

        [WebMethod]
        public void BajaArticulo(Articulo articulo)
        {
            try
            {
                ILogicaArticulo LArticulo = FabricaLogica.getLogicaArticulo();
                LArticulo.EliminarArticulo(articulo);
            }
            catch (Exception ex)
            {
                throw getSoapException(ex);
            }
        }

        [WebMethod] 
        public void ModificarArticulo(Articulo articulo)
        {
            try
            {
                ILogicaArticulo LArticulo = FabricaLogica.getLogicaArticulo();
                LArticulo.ModificarArticulo(articulo);
            }
            catch (Exception ex)
            {
                throw getSoapException(ex);
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
                throw getSoapException(ex);
            }
        }

        private SoapException getSoapException(Exception ex) 
        {
            XmlDocument _unDoc = new XmlDocument();
            XmlNode _NodoError = _unDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
            XmlNode _NodoDetalle = _unDoc.CreateNode(XmlNodeType.Element, "Error", "");
            _NodoDetalle.InnerText = ex.Message;
            _NodoError.AppendChild(_NodoDetalle);

            SoapException _miEx = new SoapException("Error WS", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);
            return _miEx;
        }

    }
}
