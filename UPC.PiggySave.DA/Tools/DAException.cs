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
        }
    }
}
