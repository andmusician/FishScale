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
        public int ClienteID { get; set; }
    }
}