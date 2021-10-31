using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.DA.Interfaces
{
    interface ITarjetaDA
    {
        TarjetaXUsuario BuscarPorUsuario(int idTarjeta, int idUsuario);
        IEnumerable<Tarjeta> ListarPorBanco(int idBanco);
        IEnumerable<TarjetaXUsuario> ListarPorUsuario(int idUsuario);
    }
}
