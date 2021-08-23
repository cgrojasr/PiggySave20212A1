using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BE;

namespace UPC.PiggySave.DA
{
    interface ITransaccionDA {
        int Registro(TransaccionBE.Entidad objTransaccionBE);
        bool Modificar(TransaccionBE.Entidad objTrasaccionBE);
    }

    public class TransaccionDA : ITransaccionDA
    {
        dbPiggySaveDataContext dc;

        public TransaccionDA()
        {
            dc = new dbPiggySaveDataContext();
        }

        public bool Modificar(TransaccionBE.Entidad objTrasaccionBE)
        {
            bool respuesta;
            try
            {
                var query = (from trans in dc.Transaccions
                            where trans.idTransaccion.Equals(objTrasaccionBE.idTransaccion)
                            select trans).Single();

                query.idMoneda = objTrasaccionBE.idMoneda;
                query.montoTotal = objTrasaccionBE.montoTotal;
                query.cuotas = objTrasaccionBE.cuotas;
                query.montoCuota = objTrasaccionBE.montoCuota;
                query.activo = objTrasaccionBE.activo;
                query.fecha = objTrasaccionBE.fecha;
                query.idUsuarioModifico = objTrasaccionBE.idUsuarioRegistro;
                query.fechaModifico = DateTime.Now;

                dc.SubmitChanges();

                respuesta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public int Registro(TransaccionBE.Entidad objTransaccionBE)
        {
            int id;
            try
            {
                var transaccion = new Transaccion();
                transaccion.idUsuario = objTransaccionBE.idUsuario;
                transaccion.idTarjeta = objTransaccionBE.idTarjeta;
                transaccion.idMoneda = objTransaccionBE.idMoneda;
                transaccion.montoTotal = objTransaccionBE.montoTotal;
                transaccion.cuotas = objTransaccionBE.cuotas;
                transaccion.fecha = objTransaccionBE.fecha;
                transaccion.idUsuarioRegistro = objTransaccionBE.idUsuarioRegistro;
                transaccion.fechaRegistro = DateTime.Now;
                transaccion.activo = true;

                dc.Transaccions.InsertOnSubmit(transaccion);
                dc.SubmitChanges();

                id = transaccion.idTransaccion;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return id;
        }
    }
}
