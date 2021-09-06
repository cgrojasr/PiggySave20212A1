using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA;

namespace UPC.PiggySave.BL.Tools
{
    class BLException : Exception
    {
        public BLException()
        {
        }

        public BLException(string message)
            : base(message)
        {
        }

        public BLException(string message, Exception inner)
            : base(message, inner)
        {
            var excepcion = new Excepcion
            {
                message = inner.Message,
                tipoException = inner.GetType().Name,
                fechaRegistro = DateTime.Now,
                clase = inner.Source
            };

            var objExcepcionDA = new ExcepcionDA();
            objExcepcionDA.Registro(excepcion);
        }
    }
}
