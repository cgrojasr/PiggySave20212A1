using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for MonedaModel
/// </summary>
[DataContract]
public class MonedaModel
{
    [DataMember]
    public int id { get; set; }
    [DataMember]
    public string nombre { get; set; }
    [DataMember]
    public string abreviatura { get; set; }
    [DataMember]
    public int idUsuarioRegistro { get; set; }
}