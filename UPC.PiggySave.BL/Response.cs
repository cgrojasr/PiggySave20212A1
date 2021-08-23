using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.BL
{
    public class Response<T>
    {
        public T value { get; set; }
        public bool error { get; set; }
        public string errorMessage { get; set; }
    }
}
