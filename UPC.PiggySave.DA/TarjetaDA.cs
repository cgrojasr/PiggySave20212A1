using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA.Interfaces;
using UPC.PiggySave.DA.Tools;
using System.Configuration;

namespace UPC.PiggySave.DA
{
    public class TarjetaDA : ITarjetaDA, ICRUD<Tarjeta>
    {
        private readonly dbPiggySaveDataContext dc;
        public TarjetaDA()
        {
            dc = new dbPiggySaveDataContext(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString);
        }

        public bool Modificar(Tarjeta objT)
        {
            throw new NotImplementedException();
        }

        public Tarjeta Buscar(int id)
        {
            throw new NotImplementedException();
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

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
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

        public Tarjeta Registrar(Tarjeta objT)
        {
            throw new NotImplementedException();
        }
    }
}
