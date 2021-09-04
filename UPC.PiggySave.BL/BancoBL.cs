using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BE;

namespace UPC.PiggySave.BL
{
    interface IBancoBL {
        int Registrar(BancoBE.Entidad objBancoBE);
        bool Modificar(BancoBE.Entidad objBancoBE);
        BancoBE.Entidad Buscar(int idBanco);
        bool Eliminar(int idBanco);
    }

    public class BancoBL : IBancoBL
    {
        public BancoBE.Entidad Buscar(int idBanco)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int idBanco)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BancoBE.Entidad objBancoBE)
        {
            throw new NotImplementedException();
        }

        public int Registrar(BancoBE.Entidad objBancoBE)
        {
            throw new NotImplementedException();
        }
    }
}
