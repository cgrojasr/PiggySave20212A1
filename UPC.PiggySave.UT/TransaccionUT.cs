using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UPC.PiggySave.BL;
using UPC.PiggySave.DA;

namespace UPC.PiggySave.UT
{
    /// <summary>
    /// Summary description for TransaccionUT
    /// </summary>
    [TestClass]
    public class TransaccionUT
    {
        TransaccionBL objTransaccionBL;
        public TransaccionUT()
        {
            objTransaccionBL = new TransaccionBL();
        }

        
        [TestMethod]
        public void Registrar()
        {
            var objTransaccion = new Transaccion
            {
                idUsuario = 1,
                idTarjeta = 1,
                fecha = DateTime.Now,
                idMoneda = 1,
                montoTotal = 3000,
                cuotas = 6,
                montoCuota = 500,
                idUsuarioRegistro = 0,
                fechaRegistro = DateTime.Now,
                activo = true
            };

            var response = objTransaccionBL.Registrar(objTransaccion);

            Assert.AreEqual(23, response.idTransaccion);
        }

        [TestMethod]
        public void Modificar()
        {
            var objTransaccion = new Transaccion
            {
                idTransaccion = 3,
                idUsuario = 1,
                idTarjeta = 1,
                fecha = DateTime.Now,
                montoTotal = 50000,
                cuotas = 2,
                idUsuarioRegistro = 0,
                activo = false
            };

            var response = objTransaccionBL.Modificar(objTransaccion);

            Assert.AreEqual(true, response);
        }
    }
}
