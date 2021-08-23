using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.BE
{
    public class AuditoriaBE
    {
        public int idUsuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public bool activo { get; set; }
    }
}
