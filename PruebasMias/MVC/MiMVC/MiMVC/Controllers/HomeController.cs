using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()//metodo que va en url por defecto 
        {
            return "Mi app MVC 5";
        }


    }
}