using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for TransaccionModel
/// </summary>
public class TransaccionModel
{
    public TransaccionModel()
    {}

    [DataContract]
    public class RegistroRequest {
        [DataMember]
        public int idTransaccion { get; set; }
        [DataMember]
        public int idMoneda { get; set; }
        [DataMember]
        public decimal montoTotal { get; set; }
        [DataMember]
        public decimal montoCuota { get; set; }
        [DataMember]
        public int cuotas { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public int idUsuario { get; set; }
        [DataMember]
        public int idTarjeta { get; set; }
        [DataMember]
        public int idUsuarioRegistro { get; set; }
    }

    public class RegistroResponse {
        public RegistroRequest transaccion { get; set; }
        public IEnumerable<MovimientoModel.Response> movimientos { get; set; }
    }
}