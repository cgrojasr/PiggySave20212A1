﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BL.Tools;
using UPC.PiggySave.DA;
using UPC.PiggySave.DA.Tools;

namespace UPC.PiggySave.BL
{
    interface ITransaccionBL {
        Transaccion Registrar(Transaccion objTransaccion);
        bool Modificar(Transaccion objTransaccion);
    }
    public class TransaccionBL : ITransaccionBL
    {
        TransaccionDA objTransaccionDA;
        public TransaccionBL()
        {
            objTransaccionDA = new TransaccionDA();
        }

        public bool Modificar(Transaccion objTransaccion)
        {
            bool respuesta;
            try
            {
                if (objTransaccion.montoTotal.Equals(0))
                    throw new BLException("Tu monto no puede ser menor o igual a 0");

                respuesta = objTransaccionDA.Modificar(objTransaccion);
            }
            catch (DAException DAex) {
                throw new PiggySaveException(DAex.Message);
            }
            catch (BLException BLex)
            {
                throw new PiggySaveException(BLex.Message);
            }
            catch (Exception ex)
            {
                var objBLException = new BLException(BLConstants.ExceptionMessage, ex);
                throw new PiggySaveException(objBLException.Message);
            }

            return respuesta;
        }

        public Transaccion Registrar(Transaccion objTransaccion)
        {
            try
            {
                if (objTransaccion.montoTotal.Equals(0))
                    throw new BLException("Tu monto no puede ser menor o igual a 0");

                //PASO 1: Se registra la transacción
                objTransaccion.fechaRegistro = DateTime.Now;
                objTransaccion.activo = true;
                objTransaccion = objTransaccionDA.Registro(objTransaccion);

                //PASO 2: Se debe buscar los datos de la tarjeta utilizada por el usuario
                var objTarjetaDA = new TarjetaDA();
                var tarjeta = objTarjetaDA.BuscarPorUsuario(objTransaccion.idTarjeta, objTransaccion.idUsuario);

                //PASO 3: Registrar los movimiento que se generan de la transaccion 
                var movimientos = new List<Movimiento>();
                for (int i=0; i<objTransaccion.cuotas; i++) {
                    var movimiento = new Movimiento {
                        idTransaccion = objTransaccion.idTransaccion,
                        idMoneda = objTransaccion.idMoneda,
                        idUsuarioRegistro = objTransaccion.idUsuarioRegistro,
                        numeroCuota = i + 1,
                        periodoFacturacion = CalcularPeriodo(objTransaccion.fecha, tarjeta.diaCierre, i + 1),
                        monto = objTransaccion.montoCuota,
                        fechaRegistro = DateTime.Now,
                        activo = true
                    };
                    movimientos.Add(movimiento);
                }
                var objMovimientoDA = new MovimientoDA();
                objTransaccion.Movimientos.Assign(objMovimientoDA.RegistroMasivo(movimientos));
            }
            catch (DAException DAex)
            {
                throw new PiggySaveException(DAex.Message);
            }
            catch (BLException BLex)
            {
                throw new PiggySaveException(BLex.Message);
            }
            catch (Exception ex)
            {
                var objBLException = new BLException(BLConstants.ExceptionMessage, ex);
                throw new PiggySaveException(objBLException.Message);
            }

            return objTransaccion;
        }

        private int CalcularPeriodo(DateTime fechaTransaccion, int diaCierre, int numeroCuota)
        {
            var periodo = 0;
            if (fechaTransaccion.Day > diaCierre)
                periodo = fechaTransaccion.AddMonths(numeroCuota).Year * 100 + fechaTransaccion.AddMonths(numeroCuota).Month;
            else
                periodo = fechaTransaccion.AddMonths(numeroCuota - 1).Year * 100 + fechaTransaccion.AddMonths(numeroCuota - 1).Month;
            return periodo;
        }
    }
}
