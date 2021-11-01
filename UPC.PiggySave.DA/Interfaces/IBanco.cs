using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.DA.Interfaces
{
    interface IBancoDA : ICRUD<Banco>
    {
        IEnumerable<Banco> ListarPorActivo(bool activo);
    }
}
