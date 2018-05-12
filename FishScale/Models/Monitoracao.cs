using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FishScale.Models
{
    public class Monitoracao
    {
        public int MonitoraID { get; set; }
        public double TotalRAM { get; set; }
        public double TotalHD { get; set; }
        public double UsedHD { get; set; }
        public double UsedRAM { get; set; }
        public DateTime Hora { get; set; }
        public int MaquinaID { get; set; }
    }
}