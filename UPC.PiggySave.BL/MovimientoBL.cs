﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BE;
using UPC.PiggySave.DA;

namespace UPC.PiggySave.BL
{
    interface IMovimientoBL
    {
        Response<List<MovimientoBE.Entidad>> RegistroMasivo(TransaccionBE.Entidad objTransaccionBE);
    }
    public class MovimientoBL : IMovimientoBL
    {
        MovimientoDA objMovimientoDA;

        public MovimientoBL()
        {
            objMovimientoDA = new MovimientoDA();
        }

        public Response<List<MovimientoBE.Entidad>> RegistroMasivo(TransaccionBE.Entidad objTransaccionBE)
        {
            var response = new Response<List<MovimientoBE.Entidad>>();
            try
            {
                var lstMovimientoBE = new List<MovimientoBE.Entidad>();
                var objTarjetaBL = new TarjetaBL();
                var tarjeta = objTarjetaBL.BuscarPorUsuario(objTransaccionBE.idTarjeta, objTransaccionBE.idUsuario);
                for (int i = 0; i < objTransaccionBE.cuotas; i++) {
                    var objMovimientoBE = new MovimientoBE.Entidad()
                    {
                        idTransaccion = objTransaccionBE.idTransaccion,
                        periodoFacturacion = CalcularPeriodoInicial(objTransaccionBE.fecha, tarjeta.value.diaCierre, i+1),
                        numeroCuota = i + 1,
                        idMoneda = objTransaccionBE.idMoneda,
                        monto = objTransaccionBE.montoCuota,
                        idUsuarioRegistro = objTransaccionBE.idUsuarioRegistro
                    };
                    lstMovimientoBE.Add(objMovimientoBE);
                }

                response.value = objMovimientoDA.RegistroMasivo(lstMovimientoBE);
            }
            catch (Exception ex)
            {
                response.error = true;
                response.errorMessage = ex.Message;
            }

            return response;
        }

        private int CalcularPeriodoInicial(DateTime fechaTransaccion, int diaCierre, int numeroCuota) {
            var periodo = 0;
            if (fechaTransaccion.Day > diaCierre)
                periodo = fechaTransaccion.AddMonths(numeroCuota).Year * 100 + fechaTransaccion.AddMonths(numeroCuota).Month;
            else
                periodo = fechaTransaccion.AddMonths(numeroCuota - 1).Year * 100 + fechaTransaccion.AddMonths(numeroCuota - 1).Month;
            return periodo;
        }
    }
}
