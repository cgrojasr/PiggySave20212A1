using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UPC.PiggySave.BL;
using UPC.PiggySave.DA;

namespace UPC.PiggySave.UT
{
    /// <summary>
    /// Summary description for UsuarioUT
    /// </summary>
    [TestClass]
    public class UsuarioUT
    {
        public UsuarioUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void Registrar()
        {
            var objUsuarioBL = new UsuarioBL();
            var objUsuario = new Usuario {
                idUsuarioRegistro = 0,
                nombre = "Genaro",
                apellido = "Rojas",
                contrasena = "111",
                email = "genaro@upc.edu.pe",
                activo = true,
                fechaRegistro = DateTime.Now
            };

            var objUsuarioRpta = objUsuarioBL.Registrar(objUsuario);
            Assert.AreEqual(objUsuarioRpta.idUsuario, 2);
        }
    }
}
