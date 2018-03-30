namespace FishScale.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public int ClienteId { get; set; }
        public int MaquinaId { get; set; }
        public string SistemaOperacional { get; set; }
        public double FreeHD { get; set; }
        public double UsedHD { get; set; }
        public double FreeRam { get; set; }
        public double UsedRam { get; set; }

        // VIDEO ASP.Net MVC na Prática - Parte 2 - TEMPO: 15:22
    }
}