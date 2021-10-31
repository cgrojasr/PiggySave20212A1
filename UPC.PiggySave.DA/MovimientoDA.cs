using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA.Tools;

namespace UPC.PiggySave.DA
{
    interface IMovimientoDA {
        IEnumerable<Movimiento> RegistroMasivo(List<Movimiento> lstMovimiento);
        bool Eliminar(int idTransaccion);
    }
    public class MovimientoDA : IMovimientoDA
    {
        private readonly dbPiggySaveDataContext dc;
        public MovimientoDA()
        {
            dc = new dbPiggySaveDataContext(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString);
        }

        public IEnumerable<Movimiento> RegistroMasivo(List<Movimiento> lstMovimiento)
        {
            try
            {
                dc.Movimientos.InsertAllOnSubmit(lstMovimiento);
                dc.SubmitChanges();
                return lstMovimiento;
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                throw objException;
            }
        }

        public bool Eliminar(int idTransaccion)
        {
            bool respuesta;
            try
            {
                var movimientos = from mov in dc.Movimientos
                                  where mov.idTransaccion.Equals(idTransaccion)
                                  select mov;

                foreach (Movimiento movimiento in movimientos)
                {
                    movimiento.activo = false;
                }

                dc.SubmitChanges();
                respuesta = true;
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                throw objException;
            }

            return respuesta;
        }
    }
}
