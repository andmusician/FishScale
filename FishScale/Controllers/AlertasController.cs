using FishScale.Models;
using FishScale.Repositorio;
using System;
using System.Web.Mvc;

namespace FishScale.Controllers
{
    [Authorize]
    public class AlertasController : Controller
    {
        private AlertaRepositorio _repositorio;

        public ActionResult ObterAlertas()
        {
            _repositorio = new AlertaRepositorio();
            ModelState.Clear();

            return View(_repositorio.ObterAlertas());
        }
    }
}