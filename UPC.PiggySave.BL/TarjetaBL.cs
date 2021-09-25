using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BL.Tools;
using UPC.PiggySave.DA;

namespace UPC.PiggySave.BL
{
    interface ITarjetaBL {
        TarjetaXUsuario BuscarPorUsuario(int idTarjeta, int idUsuario);
        IEnumerable<Tarjeta> ListarPorBanco(int idBanco);
        IEnumerable<TarjetaXUsuario> ListarPorUsuario(int idUsuario);
    }

    public class TarjetaBL : ITarjetaBL
    {
        private readonly TarjetaDA objTarjetaDA;
        public TarjetaBL()
        {
            objTarjetaDA = new TarjetaDA();
        }

        public TarjetaXUsuario BuscarPorUsuario(int idTarjeta, int idUsuario)
        {
            try
            {
                return objTarjetaDA.BuscarPorUsuario(idTarjeta, idUsuario);
            }
            catch (Exception ex)
            {
                if (ex is Exception)
                {
                    var objBLException = new BLException(BLConstants.ExceptionMessage, ex);
                    throw new PiggySaveException(objBLException.Message);
                }
                else
                {
                    throw new PiggySaveException(ex.Message);
                }
            }
        }

        public IEnumerable<Tarjeta> ListarPorBanco(int idBanco)
        {
            try
            {
                return objTarjetaDA.ListarPorBanco(idBanco);
            }
            catch (Exception ex)
            {
                if (ex is Exception)
                {
                    var objBLException = new BLException(BLConstants.ExceptionMessage, ex);
                    throw new PiggySaveException(objBLException.Message);
                }
                else
                {
                    throw new PiggySaveException(ex.Message);
                }
            }
        }

        public IEnumerable<TarjetaXUsuario> ListarPorUsuario(int idUsuario)
        {
            try
            {
                return objTarjetaDA.ListarPorUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                if (ex is Exception)
                {
                    var objBLException = new BLException(BLConstants.ExceptionMessage, ex);
                    throw new PiggySaveException(objBLException.Message);
                }
                else
                {
                    throw new PiggySaveException(ex.Message);
                }
            }
        }
    }
}
