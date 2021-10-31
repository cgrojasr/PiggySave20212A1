using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.DA.Interfaces
{
    public interface ICRUD<T>
    {
        T Registrar(T objT);
        bool Modificar(T objT);
        bool Eliminar(int id);
        T Buscar(int id);
    }
}
