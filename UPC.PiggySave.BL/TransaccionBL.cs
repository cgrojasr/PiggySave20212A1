using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BE;
using UPC.PiggySave.DA;

namespace UPC.PiggySave.BL
{
    interface ITransaccionBL {
        Response<int> Registrar(TransaccionBE.Entidad objTransaccionBE);
        Response<bool> Modificar(TransaccionBE.Entidad objTransaccionBE);
    }
    public class TransaccionBL : ITransaccionBL
    {
        TransaccionDA objTransaccionDA;
        public TransaccionBL()
        {
            objTransaccionDA = new TransaccionDA();
        }

        public Response<bool> Modificar(TransaccionBE.Entidad objTransaccionBE)
        {
            var response = new Response<bool>();
            try
            {
                if (objTransaccionBE.montoTotal.Equals(0))
                    throw new PiggySaveException("Tu monto no puede ser menor o igual a 0");

                var value = objTransaccionDA.Modificar(objTransaccionBE);
                response.value = value;
            }
            catch (PiggySaveException pgex)
            {
                response.error = true;
                response.errorMessage = pgex.Message;
            }
            catch (Exception)
            {
                response.error = true;
                response.errorMessage = "La transacción no pudo ser modificada, por favor inténtelo más tarde";
            }

            return response;
        }

        public Response<int> Registrar(TransaccionBE.Entidad objTransaccionBE)
        {
            var response = new Response<int>();
            try
            {
                if (objTransaccionBE.montoTotal.Equals(0))
                    throw new PiggySaveException("Tu monto no puede ser menor o igual a 0");

                var value = objTransaccionDA.Registro(objTransaccionBE);

                //Registrar los movimiento que se generan de la transaccion 
                var objMovimientoBL = new MovimientoBL();
                objTransaccionBE.idTransaccion = value;
                var lstMovimientos = objMovimientoBL.RegistroMasivo(objTransaccionBE);

                response.value = value;
            }
            catch (PiggySaveException pgex) {
                response.error = true;
                response.errorMessage = pgex.Message;
            }
            catch (Exception)
            {
                response.error = true;
                response.errorMessage = "La transacción no pudo ser registrada, por favor inténtelo más tarde";
            }

            return response;
        }
    }
}
