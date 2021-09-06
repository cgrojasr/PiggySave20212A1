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
        private readonly TransaccionBL objTransaccionBL;
        public TransaccionController()
        {
            objTransaccionBL = new TransaccionBL();
        }

        [HttpPost]
        public IHttpActionResult Registrar(TransaccionModel objTransaccionModel)
        {
            var response = new Response<TransaccionModel>();
            try
            {
                try
                {
                    var transaccion = new Transaccion
                    {
                        idMoneda = objTransaccionModel.idMoneda,
                        idUsuario = objTransaccionModel.idUsuario,
                        idTarjeta = objTransaccionModel.idTarjeta,
                        montoTotal = objTransaccionModel.montoTotal,
                        cuotas = objTransaccionModel.cuotas,
                        montoCuota = objTransaccionModel.montoCuota,
                        fecha = objTransaccionModel.fecha,
                        idUsuarioRegistro = objTransaccionModel.idUsuarioRegistro
                    };
                    transaccion = objTransaccionBL.Registrar(transaccion);
                    objTransaccionModel.idTransaccion = transaccion.idTransaccion;
                    var movimientos = new List<MovimientoModel>();
                    foreach (Movimiento movimiento in transaccion.Movimientos)
                    {
                        var objMovimietoModel = new MovimientoModel
                        {
                            idMovimiento = movimiento.idMovimiento,
                            monto = movimiento.monto,
                            numeroCuota = movimiento.numeroCuota,
                            periodoFacturacion = movimiento.periodoFacturacion
                        };
                        movimientos.Add(objMovimietoModel);
                    }

                    objTransaccionModel.movimientos = movimientos;

                    response.value = objTransaccionModel;
                }
                catch (PiggySaveException PSex)
                {
                    response.error = true;
                    response.errorMessage = PSex.Message;
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
