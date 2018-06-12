using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FishScale.Repositorio;
using FishScale.Models;

namespace FishScale.Controllers
{
    [Authorize]
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult Graficos()
        {
            MonitoracaoRepositorio repositorio = new MonitoracaoRepositorio();
            Monitoracao dadosMaisRecentes = repositorio.ObterMonitoracao().First();

            Response.AddHeader("Refresh", "30");
            return View(dadosMaisRecentes);
        }
    }
}