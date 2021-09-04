using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for MovimientoModel
/// </summary>
public class MovimientoModel
{
    public MovimientoModel()
    {}

    public class Response
    {
        [DataMember]
        public int idMovimiento { get; set; }
        [DataMember]
        public int periodoFacturacion { get; set; }
        [DataMember]
        public int numeroCuota { get; set; }
        [DataMember]
        public int idMoneda { get; set; }
        [DataMember]
        public decimal monto { get; set; }
    }
}