namespace FishScale.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public int ClienteId { get; set; }
        public int MaquinaID { get; set; }
        public string SistemaOperacional { get; set; }
        public double FreeHD { get; set; }
        public double UsedHD { get; set; }
        public double FreeRam { get; set; }
        public double UsedRam { get; set; }

    }
}