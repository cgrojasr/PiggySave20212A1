using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.BE
{
    public class BancoBE
    {
        public class Entidad : AuditoriaBE {
            public int idBanco { get; set; }
            public string nombre { get; set; }
            public string abreviatura { get; set; }
        }
    }
}
