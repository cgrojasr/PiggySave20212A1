using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.BE
{
    public class TarjetaBE
    {
        public class TarjetaUsuario
        {
            public int idTarjeta { get; set; }
            public int idUsuario { get; set; }
            public int diaCierre { get; set; }
        }
    }
}
