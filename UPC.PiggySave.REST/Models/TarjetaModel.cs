using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPC.PiggySave.REST.Models
{
    public class TarjetaModel
    {
    }

    public class Tarjeta_BuscarPorUsuario {
        public int idTarjeta { get; set; }
        public string nombre { get; set; }
        public int diaCierre { get; set; }
        public string nombreBanco { get; set; }
    }
}