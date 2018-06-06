using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FishScale.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public int QtdeMaquinas { get; set; }  
        public string NomeCliente { get; set; }
        public double AlertaHD { get; set; }
        public double AlertaRam { get; set; }             
      
    }
}