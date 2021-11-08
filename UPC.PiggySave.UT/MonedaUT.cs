using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.PiggySave.BL;
using UPC.PiggySave.DA;

namespace UPC.PiggySave.UT
{
    /// <summary>
    /// Summary description for MonedaUT
    /// </summary>
    [TestClass]
    public class MonedaUT
    {
        private readonly MonedaBL objMonedaBL;

        public MonedaUT()
        {
            objMonedaBL = new MonedaBL();
        }

        [TestMethod]
        public void Registrar()
        {
            var moneda = new Moneda();
            moneda.nombre = "Peso Mexicano";
            moneda.abreviatura = "MEX";
            moneda.idUsuarioRegistro = 0;

            var result = objMonedaBL.Registrar(moneda);

            Assert.AreEqual(4, result.idMoneda);
        }

        [TestMethod]
        public void Eliminar() {
            var result = objMonedaBL.Eliminar(4);

            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void Buscar() {
            var result = objMonedaBL.Buscar(4);

            Assert.AreEqual("COL", result.abreviatura);
        }

        [TestMethod]
        public void Listar() {
            var result = objMonedaBL.Listar();

            Assert.AreEqual(4, result.Count());

        }

        [TestMethod]
        public void Modificar() {
            var moneda = new Moneda();
            moneda.idMoneda = 4;
            moneda.nombre = "Peso Colombiano";
            moneda.abreviatura = "COL";
            moneda.idUsuarioModifico = 0;

            var result = objMonedaBL.Modificar(moneda);

            Assert.AreEqual(true, result);
        }

    }
}
