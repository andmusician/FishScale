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
            ViewData["Nome"] = cliente.Nome;
            ViewData["ClienteId"] = cliente.ClienteId;
            ViewData["MaquinaId"] = cliente.MaquinaId;
            ViewData["SistemaOperacional"] = cliente.SistemaOperacional;
            ViewData["FreeHD"] = cliente.FreeHD;
            ViewData["UsedHD"] = cliente.UsedHD;
            ViewData["FreeRam"] = cliente.FreeRam;
            ViewData["UsedRam"] = cliente.UsedRam;
            

            return View(); // Para Criar uma VIEW Empty(whitout Model) e deixar selecionado Use a Layout Page
        }
    }
}