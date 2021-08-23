using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BE;

namespace UPC.PiggySave.BL
{
    interface IBancoBL {
        Response<int> Registrar(BancoBE.Entidad objBancoBE);
        Response<bool> Modificar(BancoBE.Entidad objBancoBE);
        Response<BancoBE.Entidad> Buscar(int idBanco);
        Response<bool> Eliminar(int idBanco);
    }

    public class BancoBL : IBancoBL
    {
        public Response<BancoBE.Entidad> Buscar(int idBanco)
        {
            throw new NotImplementedException();
        }

        public Response<bool> Eliminar(int idBanco)
        {
            throw new NotImplementedException();
        }

        public Response<bool> Modificar(BancoBE.Entidad objBancoBE)
        {
            throw new NotImplementedException();
        }

        public Response<int> Registrar(BancoBE.Entidad objBancoBE)
        {
            throw new NotImplementedException();
        }
    }
}
