using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.DA.Interfaces
{
    interface IMonedaDA : ICRUD<Moneda>
    {
        IEnumerable<Moneda> Listar();
    }
}
