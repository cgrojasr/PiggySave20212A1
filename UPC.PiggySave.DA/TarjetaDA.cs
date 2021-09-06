using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA.Tools;

namespace UPC.PiggySave.DA
{
    interface ITarjetaDA
    {
        TarjetaXUsuario BuscarPorUsuario(int idTarjeta, int idUsuario);
    }
    public class TarjetaDA : ITarjetaDA
    {
        dbPiggySaveDataContext dc;
        public TarjetaDA()
        {
            dc = new dbPiggySaveDataContext();
        }

        public TarjetaXUsuario BuscarPorUsuario(int idTarjeta, int idUsuario)
        {
            var tarjeta = new TarjetaXUsuario();
            try
            {
                tarjeta = (from tarusu in dc.TarjetaXUsuarios
                           where tarusu.idTarjeta.Equals(idTarjeta) && tarusu.idUsuario.Equals(idUsuario)
                           select tarusu).Single();
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                throw objException;
            }

            return tarjeta;
        }
    }
}
