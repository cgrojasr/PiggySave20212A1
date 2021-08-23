using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UPC.PiggySave.BE;
using UPC.PiggySave.BL;

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
            var objTransaccionBE = new TransaccionBE.Entidad
            {
                idUsuario = 1,
                idTarjeta = 1,
                fecha = DateTime.Now,
                idMoneda = 1,
                montoTotal = 3000,
                cuotas = 3,
                montoCuota = 1000,
                idUsuarioRegistro = 0,
                fechaRegistro = DateTime.Now,
                activo = true
            };

            var response = objTransaccionBL.Registrar(objTransaccionBE);

            Assert.AreEqual(0, response.value);
        }

        [TestMethod]
        public void Modificar()
        {
            var objTransaccionBE = new TransaccionBE.Entidad
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

            var response = objTransaccionBL.Modificar(objTransaccionBE);

            Assert.AreEqual(true, response.value);
        }
    }
}
