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

        /// <summary>
        /// Busca los datos de una tarjeta de un usuario
        /// </summary>
        /// <param name="idTarjeta">identity de la tarjeta en la tabla Tarjeta</param>
        /// <param name="idUsuario">identity del usuario en la tabla Usuario</param>
        /// <returns>Los datos de la tarjeta un usuario</returns>
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

        /// <summary>
        /// Metodo para buscar las tarjetas que un banco ofrece a los usuarios
        /// </summary>
        /// <param name="idBanco">identity del banco en la base de datos</param>
        /// <returns>Listado de todas las tarjetas del banco</returns>
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

        /// <summary>
        /// Metodo que busca las tarjetas que un usuario tiene registrados
        /// </summary>
        /// <param name="idUsuario">id que lo identifica en la base de datos</param>
        /// <returns>Lista de tarjetas registradas para el usuario con el id consultado</returns>
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
