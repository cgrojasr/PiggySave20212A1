using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
