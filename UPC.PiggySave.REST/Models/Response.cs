using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPC.PiggySave.REST.Models
{
    public class Response<T>
    {
        public T value { get; set; }
        public bool error { get; set; }
        public string errorMessage { get; set; }
    }
}