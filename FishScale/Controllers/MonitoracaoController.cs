﻿using FishScale.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishScale.Controllers
{
    [Authorize]
    public class MonitoracaoController : Controller
    {
        private MonitoracaoRepositorio _repositorio;
        // GET: Monitoracao
        public ActionResult Monitoracao()
        {
            _repositorio = new MonitoracaoRepositorio();
            ModelState.Clear();

            Response.AddHeader("Refresh", "5");
            return View(_repositorio.ObterMonitoracao());
        }

        private AlertaRepositorio _repositorio1;

        public ActionResult ObterAlertas()
        {
            _repositorio1 = new AlertaRepositorio();
            ModelState.Clear();

            Response.AddHeader("Refresh", "5");
            return View(_repositorio1.ObterAlertas());
        }

    }
}