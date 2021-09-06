using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UPC.PiggySave.BL;
using UPC.PiggySave.BL.Tools;
using UPC.PiggySave.DA;
using UPC.PiggySave.REST.Models;

namespace UPC.PiggySave.REST.Controllers
{
    [RoutePrefix("api/transaccion")]
    public class TransaccionController : ApiController
    {
        TransaccionBL objTransaccionBL;
        public TransaccionController()
        {
            objTransaccionBL = new TransaccionBL();
        }

        [HttpPost]
        public IHttpActionResult Registrar(TransaccionModel.RegistroRequest request)
        {
            var response = new Response<TransaccionModel.RegistroResponse>();
            try
            {
                var transaccion = new Transaccion
                {
                    idMoneda = request.idMoneda,
                    idUsuario = request.idUsuario,
                    idTarjeta = request.idTarjeta,
                    montoTotal = request.montoTotal,
                    cuotas = request.cuotas,
                    montoCuota = request.montoCuota,
                    fecha = request.fecha,
                    idUsuarioRegistro = request.idUsuarioRegistro
                };
                transaccion = objTransaccionBL.Registrar(transaccion);
                request.idTransaccion = transaccion.idTransaccion;
                var movimientos = new List<MovimientoModel.RegistroResponse>();
                foreach(Movimiento movimiento in transaccion.Movimientos)
                {
                    var objMovimietoModel = new MovimientoModel.RegistroResponse { 
                        idMovimiento = movimiento.idMovimiento,
                        monto = movimiento.monto,
                        periodoFacturacion = movimiento.periodoFacturacion
                    };
                    movimientos.Add(objMovimietoModel);
                }

                var objTransaccionModel = new TransaccionModel.RegistroResponse
                {
                    transaccion = request,
                    movimientos = movimientos
                };

                response.value = objTransaccionModel;

                return Ok(response);
            }
            catch (PiggySaveException PSex)
            {
                response.error = true;
                response.errorMessage = PSex.Message;
                return Ok(request);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
