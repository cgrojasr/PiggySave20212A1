using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.DA.Tools
{
    [Serializable]
    public class DAException : Exception
    {
        public DAException()
        {
        }

        public DAException(string message)
            : base(message)
        {
        }

        public DAException(string message, Exception inner)
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
