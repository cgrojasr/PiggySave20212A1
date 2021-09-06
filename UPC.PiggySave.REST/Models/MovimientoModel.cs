using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPC.PiggySave.REST.Models
{
    public class MovimientoModel
    {
        public class RegistroResponse
        {
            public int idMovimiento { get; set; }
            public int periodoFacturacion { get; set; }
            public int numeroCuota { get; set; }
            public int idMoneda { get; set; }
            public decimal monto { get; set; }
        }
    }
}