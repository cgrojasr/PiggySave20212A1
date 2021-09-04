using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for Response
/// </summary>
[DataContract]
public class Response<T>
{
    public Response()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public T value { get; set; }
    [DataMember]
    public bool error { get; set; }
    [DataMember]
    public string message { get; set; }
}