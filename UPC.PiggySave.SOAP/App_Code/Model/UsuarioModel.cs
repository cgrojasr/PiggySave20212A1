using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for UsuarioModel
/// </summary>
[DataContract]
public class UsuarioModel
{
    public UsuarioModel()
    {
        
    }

    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public string Nombre { get; set; }
    [DataMember]
    public string Apellido { get; set; }
    [DataMember]
    public string Email { get; set; }
    [DataMember]
    public string Contrasena { get; set; }
    [DataMember]
    public int IdUsuarioRegistro { get; set; }
}