using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.BE
{
    public class TransaccionBE
    {
        public class Entidad : AuditoriaBE {
            public int idTransaccion { get; set; }
            public DateTime fecha { get; set; }
            public int idUsuario { get; set; }
            public int idTarjeta { get; set; }
            public int idMoneda { get; set; }
            public decimal montoTotal { get; set; }
            public int cuotas { get; set; }
            public decimal montoCuota { get; set; }
        }
    }
}
