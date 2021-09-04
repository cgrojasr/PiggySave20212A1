using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BE;
using UPC.PiggySave.DA.Tools;

namespace UPC.PiggySave.DA
{
    interface ITransaccionDA {
        int Registro(Transaccion objTransaccionBE);
        bool Modificar(Transaccion objTrasaccionBE);
    }

    public class TransaccionDA : ITransaccionDA
    {
        dbPiggySaveDataContext dc;

        public TransaccionDA()
        {
            dc = new dbPiggySaveDataContext();
        }

        public bool Modificar(Transaccion objTrasaccion)
        {
            bool respuesta;
            try
            {
                var transaccion = (from trans in dc.Transaccions
                                   where trans.idTransaccion.Equals(objTrasaccion.idTransaccion)
                                   select trans).Single();

                transaccion.idMoneda = objTrasaccion.idMoneda;
                transaccion.montoTotal = objTrasaccion.montoTotal;
                transaccion.cuotas = objTrasaccion.cuotas;
                transaccion.montoCuota = objTrasaccion.montoCuota;
                transaccion.activo = objTrasaccion.activo;
                transaccion.fecha = objTrasaccion.fecha;
                transaccion.idUsuarioModifico = objTrasaccion.idUsuarioRegistro;
                transaccion.fechaModifico = DateTime.Now;

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

        public int Registro(Transaccion objTransaccion)
        {
            int id;
            try
            {
                dc.Transaccions.InsertOnSubmit(objTransaccion);
                dc.SubmitChanges();

                id = objTransaccion.idTransaccion;
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                throw objException;
            }

            return id;
        }
    }
}
