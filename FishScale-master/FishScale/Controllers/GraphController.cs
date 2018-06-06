using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishScale.Controllers
{
    [Authorize]
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult Graficos()
        {
            return View();
        }
    }
}