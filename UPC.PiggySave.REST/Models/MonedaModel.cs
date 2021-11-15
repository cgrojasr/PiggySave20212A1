using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPC.PiggySave.REST.Models
{
    public class MonedaModel
    {
        public int idMoneda { get; set; }
        public string nombre { get; set; }
        public string abreviatura { get; set; }
        public int idUsuarioRegistro { get; set; }
        public bool activo { get; set; }
    }
}