using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BancoModel
/// </summary>

public class BancoModel
{
    public int idBanco { get; set; }
    public string nombre { get; set; }
    public string abreviatura { get; set; }
    public int idUsuarioRegistro { get; set; }
    public bool activo { get; set; }
}