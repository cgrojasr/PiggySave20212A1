using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.BL.Tools
{
    public class PiggySaveException : Exception
    {
        public PiggySaveException()
        {
        }

        public PiggySaveException(string message)
            : base(message)
        {
        }

        public PiggySaveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
