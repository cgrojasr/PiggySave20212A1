using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BE;

namespace UPC.PiggySave.DA
{
    interface IMovimientoDA {
        List<MovimientoBE.Entidad> RegistroMasivo(List<MovimientoBE.Entidad> lstMovimientoBE);
    }
    public class MovimientoDA : IMovimientoDA
    {
        dbPiggySaveDataContext dc;

        public MovimientoDA()
        {
            dc = new dbPiggySaveDataContext();
        }

        private int Registro(MovimientoBE.Entidad objMovimientoBE)
        {
            int id;
            try
            {
                var movimiento = new Movimiento { 
                    idTransaccion = objMovimientoBE.idTransaccion,
                    periodoFacturacion = objMovimientoBE.periodoFacturacion,
                    numeroCuota = objMovimientoBE.numeroCuota,
                    idMoneda = objMovimientoBE.idMoneda,
                    monto = objMovimientoBE.monto,
                    idUsuarioRegistro = objMovimientoBE.idUsuarioRegistro,
                    fechaRegistro = DateTime.Now,
                    activo = true
                };

                dc.Movimientos.InsertOnSubmit(movimiento);

                id = movimiento.idMovimiento;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return id;
        }

        public List<MovimientoBE.Entidad> RegistroMasivo(List<MovimientoBE.Entidad> lstMovimientoBE)
        {
            try
            {
                foreach (var movimiento in lstMovimientoBE)
                {
                    var id = Registro(movimiento);
                    movimiento.idMovimiento = id;
                }
                dc.SubmitChanges();

                return lstMovimientoBE;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
