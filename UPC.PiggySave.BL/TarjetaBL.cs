using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BE;
using UPC.PiggySave.DA;

namespace UPC.PiggySave.BL
{
    interface ITarjetaBL
    {
        Response<TarjetaBE.TarjetaUsuario> BuscarPorUsuario(int idTarjeta, int idUsuario);
    }
    public class TarjetaBL : ITarjetaBL
    {
        TarjetaDA objTarjetaDA;
        public TarjetaBL()
        {
            objTarjetaDA = new TarjetaDA();
        }

        public Response<TarjetaBE.TarjetaUsuario> BuscarPorUsuario(int idTarjeta, int idUsuario)
        {
            var response = new Response<TarjetaBE.TarjetaUsuario>();
            try
            {
                var tarjeta = objTarjetaDA.BuscarPorUsuario(idTarjeta, idUsuario);
                response.value = tarjeta;
            }
            catch (Exception ex)
            {
                response.error = true;
                response.errorMessage = ex.Message;
            }

            return response;
        }
    }
}
