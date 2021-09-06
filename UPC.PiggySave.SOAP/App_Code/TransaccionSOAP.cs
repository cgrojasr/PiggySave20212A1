using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.PiggySave.BL;
using UPC.PiggySave.DA;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransaccionSOAP" in code, svc and config file together.
public class TransaccionSOAP : ITransaccionSOAP
{
    TransaccionBL objTransaccionBL;

    public TransaccionSOAP()
    {
        objTransaccionBL = new TransaccionBL();
    }

    public Response<TransaccionModel.RegistroResponse> Modificar(TransaccionModel.RegistroRequest request)
    {
        //try
        //{
        //    var objTransaccionBE = new TransaccionBE.Entidad
        //    {
        //        idTransaccion = objTransacionModel.idTransaccion,
        //        idMoneda = objTransacionModel.idMoneda,
        //        idTarjeta = objTransacionModel.idTarjeta,
        //        idUsuario = objTransacionModel.idUsuario,
        //        idUsuarioRegistro = objTransacionModel.idUsuarioRegistro,
        //        montoCuota = objTransacionModel.montoCuota,
        //        montoTotal = objTransacionModel.montoTotal,
        //        cuotas = objTransacionModel.cuotas
        //    };

        //    return objTransaccionBL.Modificar(objTransaccionBE);
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}

        return null;
    }

    public Response<TransaccionModel.RegistroResponse> Registrar(TransaccionModel.RegistroRequest request)
    {
        var response = new Response<TransaccionModel.RegistroResponse>();
        try
        {
            var objTransaccion = new Transaccion
            {
                fecha = request.fecha,
                idUsuario = request.idUsuario,
                idTarjeta = request.idTarjeta,
                idMoneda = request.idMoneda,
                montoTotal = request.montoTotal,
                cuotas = request.cuotas,
                montoCuota = request.montoCuota,
                idUsuarioRegistro = request.idUsuarioRegistro
            };

            objTransaccion = objTransaccionBL.Registrar(objTransaccion);
            request.idTransaccion = objTransaccion.idTransaccion;

            var movimientos = new List<MovimientoModel.Response>();
            foreach (Movimiento movimiento in objTransaccion.Movimientos)
            {
                var objMovimientoModel = new MovimientoModel.Response
                {
                    idMovimiento = movimiento.idMovimiento,
                    periodoFacturacion = movimiento.periodoFacturacion,
                    monto = movimiento.monto,
                    idMoneda = movimiento.idMoneda,
                    numeroCuota = movimiento.numeroCuota
                };

                movimientos.Add(objMovimientoModel);
            }

            var transaccionModel = new TransaccionModel.RegistroResponse();
            transaccionModel.transaccion = request;
            transaccionModel.movimientos = movimientos;
            response.value = transaccionModel;
        }
        catch (Exception ex)
        {
            response.error = true;
            response.errorMessage = ex.Message;
        }

        return response;
    }
}
