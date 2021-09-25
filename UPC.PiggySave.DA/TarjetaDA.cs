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
        IEnumerable<Tarjeta> ListarPorBanco(int idBanco);
        IEnumerable<TarjetaXUsuario> ListarPorUsuario(int idUsuario);
    }
    public class TarjetaDA : ITarjetaDA
    {
        private readonly dbPiggySaveDataContext dc;
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

        public IEnumerable<Tarjeta> ListarPorBanco(int idBanco)
        {
            try
            {
                var query = from tar in dc.Tarjetas
                            where tar.idBanco.Equals(idBanco)
                            select tar;

                return query;
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                throw objException;
            }
        }

        public IEnumerable<TarjetaXUsuario> ListarPorUsuario(int idUsuario)
        {
            try
            {
                var query = from tar in dc.TarjetaXUsuarios
                            where tar.idUsuario.Equals(idUsuario)
                            select tar;

                return query;
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                throw objException;
            }
        }
    }
}
