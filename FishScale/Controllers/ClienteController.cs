using FishScale.Models;
using System.Web.Mvc;


namespace FishScale.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Cliente() 
        {
            // Criando um objeto do tipo Cliente da Model
            // IMPORTANTE: OS VALORES DAS VARIÁVEIS SERÃO CHAMADOS DO SQL SERVER

            var cliente = new Cliente 
            {
                Nome = "BandTec", 
                ClienteId = 1, 
                MaquinaId = 1, 
                SistemaOperacional = "Windows", 
                FreeHD = 100, 
                UsedHD = 50, 
                FreeRam = 4000, 
                UsedRam = 2000 
            };
            ViewBag.Nome = cliente.Nome;
            ViewBag.ClienteId = cliente.ClienteId;
            ViewBag.MaquinaId = cliente.MaquinaId;
            ViewBag.SistemaOperacional = cliente.SistemaOperacional;
            ViewBag.FreeHD = cliente.FreeHD;
            ViewBag.UsedHD = cliente.UsedHD;
            ViewBag.FreeRam = cliente.FreeRam;
            ViewBag.UsedRam = cliente.UsedRam;
            

            return View(); // Para Criar uma VIEW Empty(whitout Model) e deixar selecionado Use a Layout Page
        }
    }
}