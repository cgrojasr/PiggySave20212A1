using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPC.PiggySave.REST.Models
{
    public class TransaccionModel
    {
        public class RegistroRequest
        {
            
            public int idTransaccion { get; set; }
            public int idMoneda { get; set; }
            public decimal montoTotal { get; set; }
            public decimal montoCuota { get; set; }
            public int cuotas { get; set; }
            public DateTime fecha { get; set; }
            public int idUsuario { get; set; }
            public int idTarjeta { get; set; }
            public int idUsuarioRegistro { get; set; }
        }

        public class RegistroResponse
        {
            public RegistroRequest transaccion { get; set; }
            public IEnumerable<MovimientoModel.RegistroResponse> movimientos { get; set; }
        }
    }
}