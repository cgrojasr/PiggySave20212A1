using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.BE
{
    public class MovimientoBE
    {
        public class Entidad : AuditoriaBE {
            public int idMovimiento { get; set; }
            public int idTransaccion { get; set; }
            public int periodoFacturacion { get; set; }
            public int numeroCuota { get; set; }
            public int idMoneda { get; set; }
            public decimal monto { get; set; }
        }
    }
}
