using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FishScale.Models
{
    public class Maquina
    {
        public int MaquinaID { get; set; }
        public string SistemaOperacional { get; set; }
        public double TotalRAM { get; set; }
        public double TotalHD { get; set; }
        public double UsedHD { get; set; }
        public double UsedRAM { get; set; }
        public DateTime Hora { get; set; }
    }
}