using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BE;

namespace UPC.PiggySave.DA
{
    interface ITarjetaDA
    {
        TarjetaBE.TarjetaUsuario BuscarPorUsuario(int idTarjeta, int idUsuario);
    }
    public class TarjetaDA : ITarjetaDA
    {
        dbPiggySaveDataContext dc;
        public TarjetaDA()
        {
            dc = new dbPiggySaveDataContext();
        }

        public TarjetaBE.TarjetaUsuario BuscarPorUsuario(int idTarjeta, int idUsuario)
        {
            var objTarjetaBE = new TarjetaBE.TarjetaUsuario();
            try
            {
                var tarjeta = (from tarusu in dc.TarjetaXUsuarios
                               where tarusu.idTarjeta.Equals(idTarjeta) && tarusu.idUsuario.Equals(idUsuario)
                               select tarusu).Single();

                objTarjetaBE.idUsuario = tarjeta.idUsuario;
                objTarjetaBE.idTarjeta = tarjeta.idTarjeta;
                objTarjetaBE.diaCierre = tarjeta.diaCierre;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objTarjetaBE;
        }
    }
}
