﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA.Tools;

namespace UPC.PiggySave.DA
{
    interface ITransaccionDA {
        Transaccion Registro(Transaccion objTransaccionBE);
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

                return true;
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                throw objException;
            }
        }

        public Transaccion Registro(Transaccion objTransaccion)
        {
            try
            {
                dc.Transaccions.InsertOnSubmit(objTransaccion);
                dc.SubmitChanges();

                return objTransaccion;
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                throw objException;
            }
        }
    }
}
