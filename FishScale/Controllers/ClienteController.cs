using FishScale.Models;
using FishScale.Repositorio;
using System;
using System.Web.Mvc;

namespace FishScale.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private ClienteRepositorio _repositorio;
        
        public ActionResult ObterClientes()
        {
            _repositorio = new ClienteRepositorio();
            ModelState.Clear();

            return View(_repositorio.ObterClientes());
        }

        public ActionResult IncluirCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirCliente(Cliente clienteObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new ClienteRepositorio();

                    if (_repositorio.AdicionarCliente(clienteObj))
                    {
                        ViewBag.Mensagem = "Cliente Cadastrado com Sucesso!";
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return View("ObterClientes");
            }

        }

        public ActionResult EditarCliente(int id)
        {
            _repositorio = new ClienteRepositorio();
            return View(_repositorio.ObterClientes().Find(c => c.ClienteID == id));
        }

        [HttpPost]
        public ActionResult EditarCliente(int id, Cliente clienteObj)
        {
            try
            {
                _repositorio = new ClienteRepositorio();
                _repositorio.AtualizarCliente(clienteObj);
                return RedirectToAction("ObterClientes");
            }
            catch (Exception)
            {
                return View("ObterClientes");
            }

        }

        public ActionResult ExcluirCliente(int id)
        {
            try
            {
                _repositorio = new ClienteRepositorio();
                if (_repositorio.ExcluirCliente(id))
                {
                    ViewBag.Mensagem = "Cliente Excluido com Sucesso!";
                }
                return RedirectToAction("ObterClientes");
            }
            catch (Exception)
            {
                return View("ObterClientes");
            }
        }
    }
}