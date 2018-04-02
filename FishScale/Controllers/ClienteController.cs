using FishScale.Models;
using System.Data.SqlClient;
using System.Web.Mvc;


namespace FishScale.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Cliente()
        {
            // Criando um objeto do tipo Cliente da Model
            // IMPORTANTE: OS VALORES DAS VARIÁVEIS SERÃO CHAMADOS DO SQL SERVER

            ////SqlConnection minhaconexao = new SqlConnection("Server=tcp:domotichouse.database.windows.net,1433;Database=Domotic;User ID=andmusician@domotichouse;Password=mficbr100%;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //SqlConnection minhaconexao = new SqlConnection("Server=tcp:domotichouse.database.windows.net,1433;Initial Catalog=Domotic;Persist Security Info=False;User ID=andmusician;Password=mficbr100%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //minhaconexao.Open();

            //string strQuerySelect = "SELECT * FROM FISHSCALE";
            //SqlCommand cmdComandoSelect = new SqlCommand(strQuerySelect, minhaconexao);
            //SqlDataReader dados = cmdComandoSelect.ExecuteReader();

            //while (dados.Read())
            //{
            //    System.Console.WriteLine($"clienteid:{0}, nome:{1}, maquinaid:{2}, sistemaoperacional:{3}, freehd: {4}, usedhd: {5}, freeram: {6}, usedram: {7}, dataview: {8}", dados["clienteid"], dados["nome"], dados["maquinaid"], dados["sistemaoperacional"], dados["freehd"], dados["usedhd"], dados["freeram"], dados["usedram"], dados["dataview"]);
            //}


            var cliente = new Cliente
            {
                Nome = "Bandtec",
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