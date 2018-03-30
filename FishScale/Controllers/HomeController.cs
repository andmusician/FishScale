using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishScale.Controllers
{
    public class HomeController : Controller  
    {
        public ActionResult Index() // Action Result é um método que retorna uma View dentro da pasta View
        {
            ViewBag.Message = "Your Index description page.";

            return View();
        }

        public ActionResult Sobre() // Action Result é um método que retorna uma View de mesmo nome dentro da pasta View
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contato() // Action Result é um método que retorna uma View de mesmo nome dentro da pasta View
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login() // Action Result é um método que retorna uma View de mesmo nome dentro da pasta View
        {
            ViewBag.Message = "Your Login page.";

            return View();
        }
    }
}