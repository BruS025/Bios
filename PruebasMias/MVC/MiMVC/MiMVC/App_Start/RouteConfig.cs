using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MiMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Procesos",
                "Procesos/{action}/{id}",
                defaults : new { Controller = "Procesos", action = "Listado", id = UrlParameter.Optional }
                );

            routes.MapRoute(//Donde viene definida la url por defecto
                name: "Default",//nombre por defecto
                url: "{controller}/{action}/{id}",//forma de la url por defecto
                defaults: new { controller = "Home", action = "Prueba", id = UrlParameter.Optional }//objeto de instacia de ruta
            );
        }
    }
}
