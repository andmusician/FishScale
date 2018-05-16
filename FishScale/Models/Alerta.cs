using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FishScale.Models
{
    public class Alerta
    {
        public int AlertaID { get; set; }
        public double AlertaHD { get; set; }
        public double AlertaRAM { get; set; }
        public int MaquinaID { get; set; }
        public int ClienteID { get; set; }
    }
}