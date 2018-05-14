using FishScale.Models;
using FishScale.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishScale.Controllers
{
    [Authorize]
    public class MaquinaController : Controller
    {
        private MaquinaRepositorio _repositorio;
        
        public ActionResult ObterMaquinas()
        {
            _repositorio = new MaquinaRepositorio();
            ModelState.Clear();

            return View(_repositorio.ObterMaquinas());
        }
                
        public ActionResult IncluirMaquina()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirMaquina(Maquina maquinaObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new MaquinaRepositorio();

                    if (_repositorio.AdicionarMaquina(maquinaObj))
                    {
                        ViewBag.Mensagem = "Máquina Cadastrada com Sucesso!";
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return View("ObterMaquinas");
            }

        }
                
        public ActionResult EditarMaquina(int id)
        {
            _repositorio = new MaquinaRepositorio();
            return View(_repositorio.ObterMaquinas().Find(m => m.MaquinaID == id));
        }

        [HttpPost]
        public ActionResult EditarMaquina(int id, Maquina maquinaObj)
        {
            try
            {
                _repositorio = new MaquinaRepositorio();
                _repositorio.AtualizarMaquinas(maquinaObj);
                return RedirectToAction("ObterMaquinas");
            }
            catch (Exception)
            {
                return View("ObterMaquinas");
            }

        }

        public ActionResult ExcluirMaquina(int id)
        {
            try
            {
                _repositorio = new MaquinaRepositorio();
                if (_repositorio.ExcluirMaquina(id))
                {
                    ViewBag.Mensagem = "Máquina excluida com sucesso!";
                }
                return RedirectToAction("ObterMaquinas");
            }
            catch (Exception)
            {
                return View("ObterMaquinas");
            }
        }
    }
}